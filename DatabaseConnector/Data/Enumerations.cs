namespace DatabaseConnector.Data;

public enum DatabaseConnectionMethod : int
{
    ODBC = 0,
    OLEDB = 1
}

public enum DatabaseType : int
{
    SQLServer = 0,
    MySQL = 1,
    Oracle = 2,
    iHistorian = 3,
    Wonderware = 4,
    PI = 5,
    ClearSCADA = 6,
    PostgreSQL = 7,
    Others = -1
}

public enum DatabaseConnectionStatus
{
    TestConnectionStarted,
    TestConnectionFailed,
    TestConnectionCompleted,
    TestConnectionSuccesseded,
    ExecutionStarted,
    ExecutionSuccessful,
    ExecutionSuccessfulWithNoTables,
    ExecutionCompleted,
    ExecutionFailed
}