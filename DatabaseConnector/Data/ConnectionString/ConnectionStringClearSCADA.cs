namespace DatabaseConnector.Data.ConnectionString;

public class ConnectionStringClearSCADA : ConnectionStringBase
{
    public override string ToString()
    {
        string connString = base.ToString();
        connString.Replace("Server", "Location");

        return connString;
    }
}
