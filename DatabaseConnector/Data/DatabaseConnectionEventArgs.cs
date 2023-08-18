using System.Data;

namespace DatabaseConnector.Data;

public class DatabaseConnectionEventArgs : EventArgs
{
    //public event EventHandler<DatabaseConnectionEventArgs> StatusChanged;

    public DatabaseConnectionStatus Status { get; set; }
    public string Message { get; set; }
    public string TimeTakenMessage { get; set; }
    public DataSet DataSet { get; set; }
    public DatabaseConnectionEventArgs(DatabaseConnectionStatus status)
        : this(status, string.Empty, string.Empty)
    {
    }
    public DatabaseConnectionEventArgs(DatabaseConnectionStatus status, string message)
        : this(status, message, string.Empty)
    {
    }
    public DatabaseConnectionEventArgs(DatabaseConnectionStatus status, string message, string timeTaken)
    {
        this.Status = status;
        this.Message = message;
        this.TimeTakenMessage = timeTaken;
    }
    public DatabaseConnectionEventArgs(DatabaseConnectionStatus status, string message, string timeTaken, DataSet ds)
        : this(status, message, timeTaken)
    {
        this.DataSet = ds;
    }

}



