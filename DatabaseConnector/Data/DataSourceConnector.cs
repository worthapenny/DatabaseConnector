using DatabaseConnector.Data.ConnectionMethod;
using DatabaseConnector.Data.ConnectionString;
using Serilog;
using System.Data;
using System.Diagnostics;

namespace DatabaseConnector.Data;

public class DataSourceConnector
{
    #region Public Events
    public event EventHandler<DatabaseConnectionEventArgs>? DbConnectionStatusChanged;
    #endregion

    #region Constructor
    public DataSourceConnector()
    {
    }
    #endregion

    #region Public Methods
    public void TestConnection(ConnectionStringBase connectionString)
    {
        string message = "Testing connection";
        DbConnectionStatusChanged?.Invoke(this, new DatabaseConnectionEventArgs(DatabaseConnectionStatus.TestConnectionStarted, message));

        try
        {
            switch (connectionString.Method)
            {
                case DatabaseConnectionMethod.ODBC:
                    testConnectionODBC(connectionString);
                    break;


                case DatabaseConnectionMethod.OLEDB:
                    testConnectionOLEDB(connectionString);
                    break;
            }

        }
        finally
        {
            message = "Test connection completed";
            DbConnectionStatusChanged?.Invoke(this, new DatabaseConnectionEventArgs(DatabaseConnectionStatus.TestConnectionCompleted, message));
        }

        Log.Debug(Seperator);
    }

    public void ExecuteQuery(ConnectionStringBase connectionString)
    {
        string message = "SQL execution connection";
        DbConnectionStatusChanged?.Invoke(this, new DatabaseConnectionEventArgs(DatabaseConnectionStatus.ExecutionStarted, message));

        var timer = Stopwatch.StartNew();

        try
        {
            switch (connectionString.Method)
            {
                case DatabaseConnectionMethod.ODBC:
                    executeODBC(connectionString);
                    break;


                case DatabaseConnectionMethod.OLEDB:
                    executeOLEDB(connectionString);
                    break;
            }

        }
        finally
        {
            message = "SQL execution completed";
            DbConnectionStatusChanged?.Invoke(this, new DatabaseConnectionEventArgs(DatabaseConnectionStatus.ExecutionCompleted, message, $"{timer.Elapsed}"));
        }

        Log.Debug(Seperator);
    }

    #endregion

    #region Test Connction Methods
    private void testConnectionODBC(ConnectionStringBase connectionString)
    {
        string message = $"Testing {connectionString.Method} connection";
        Log.Information(message);
        try
        {
            var timer = Stopwatch.StartNew();

            ODBCAccess odbcAccess = new ODBCAccess(connectionString.ToString());
            odbcAccess.dbConn.Open();
            odbcAccess.CloseConnection();

            reportSuccessfulConnection($"{timer.Elapsed}");
        }
        catch (Exception ex)
        {
            reportFailureConnection(ex);
        }
    }
    private void testConnectionOLEDB(ConnectionStringBase connectionString)
    {
        string message = $"Testing {connectionString.Method} connection";
        Log.Information(message);
        try
        {
            var timer = Stopwatch.StartNew();

            OleDBAccess oledbAccess = new OleDBAccess(connectionString.ToString());
            oledbAccess.dbConn.Open();
            oledbAccess.CloseConnection();

            reportSuccessfulConnection($"{timer.Elapsed}");
        }
        catch (Exception ex)
        {
            reportFailureConnection(ex);
        }
    }
    private void reportSuccessfulConnection(string timeTaken)
    {
        string message = "Connection was successful";
        Log.Information(message);
        DbConnectionStatusChanged?.Invoke(this, new DatabaseConnectionEventArgs(DatabaseConnectionStatus.TestConnectionSuccesseded, message, timeTaken));
    }
    private void reportFailureConnection(Exception ex)
    {
        Log.Error(ex, $"...while testing connection");

        string message = "Exception occured during test connection";
        DbConnectionStatusChanged?.Invoke(this, new DatabaseConnectionEventArgs(DatabaseConnectionStatus.TestConnectionFailed, message));
    }
    #endregion

    #region Execute Query Methods
    private void executeODBC(ConnectionStringBase connectionString)
    {
        string message = $"Execting quring using {connectionString.Method} connection";
        Log.Information(message);
        try
        {
            var timer = Stopwatch.StartNew();

            ODBCAccess odbcAccess = new ODBCAccess(connectionString.ToString());
            DataSet ds = odbcAccess.dataSetQuery(connectionString.Query);

            if (ds.Tables != null)
            {
                if (ds.Tables.Count > 0)
                    reportSuccessfulExecution(ds, $"{timer.Elapsed}", connectionString.Query);
                else
                    reportSuccessfulExecutionWithNoTables(connectionString.Query);
            }

            odbcAccess.CloseConnection();
        }
        catch (Exception ex)
        {
            reportFailureExecution(ex, connectionString.Query);
        }
    }
    private void executeOLEDB(ConnectionStringBase connectionString)
    {
        string message = $"Execting quring using {connectionString.Method} connection";
        Log.Information(message);
        try
        {
            var timer = Stopwatch.StartNew();

            OleDBAccess oledbAccess = new OleDBAccess(connectionString.ToString());
            DataSet ds = oledbAccess.dataSetQuery(connectionString.Query);

            if (ds.Tables != null)
            {
                if (ds.Tables.Count > 0)
                    reportSuccessfulExecution(ds, $"{timer.Elapsed}", connectionString.Query);
                else
                    reportSuccessfulExecutionWithNoTables(connectionString.Query);
            }

            oledbAccess.CloseConnection();
        }
        catch (Exception ex)
        {
            reportFailureExecution(ex, connectionString.Query);
        }
    }

    private void reportSuccessfulExecution(DataSet ds, string timeTaken, string query)
    {
        string message = $"Execution was successful, tableCount: {ds.Tables.Count}. Query = '{query}'";

        if (ds.Tables != null && ds.Tables.Count > 0)
            timeTaken += $" Count: {ds.Tables[0].Rows.Count}";

        Log.Information(message);
        DbConnectionStatusChanged?.Invoke(this, new DatabaseConnectionEventArgs(DatabaseConnectionStatus.ExecutionSuccessful, message, timeTaken, ds));
    }
    private void reportSuccessfulExecutionWithNoTables(string query)
    {
        string message = $"Execution was successful however no tables found. Was it an UPDATE type of query? Query = '{query}'";
        Log.Information(message);
        DbConnectionStatusChanged?.Invoke(this, new DatabaseConnectionEventArgs(DatabaseConnectionStatus.ExecutionSuccessfulWithNoTables, message));

    }
    private void reportFailureExecution(Exception ex, string query)
    {
        Log.Error(ex, $"...while executing query. Query = {query}");
        string message = "Execution failed because of some exception";
        DbConnectionStatusChanged?.Invoke(this, new DatabaseConnectionEventArgs(DatabaseConnectionStatus.ExecutionFailed, message));
    }
    #endregion

    #region Private Properties
    string seperator = new string('-', 100);
    private string Seperator => seperator;
    #endregion
}