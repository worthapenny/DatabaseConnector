using DatabaseConnector.Data.ConnectionString;

namespace DatabaseConnector.Data;

public class CommonQueries
{
    #region Constructor
    public CommonQueries()
    {
    }
    #endregion

    #region Public Methods
    public static Dictionary<string, string> Get(ConnectionStringBase connString)
    {
        var items = new Dictionary<string, string>();

        switch (connString.Method)
        {
            case DatabaseConnectionMethod.ODBC:
                getOdbcCommonQueries(items, connString);
                break;

            case DatabaseConnectionMethod.OLEDB:
                getOleDbCommonQueries(items, connString);
                break;

            default:
                break;
        }

        return items;
    }


    public static Dictionary<string, string> Get(DatabaseType dbType, ConnectionStringBase connString)
    {
        var items = new Dictionary<string, string>();

        switch (dbType)
        {
            case DatabaseType.SQLServer:
                getSqlServerCommonQueries(items, connString);
                break;

            case DatabaseType.MySQL:
                getMySqlCommonQueries(items, connString);
                break;

            case DatabaseType.Oracle:
                getOracleCommonQueries(items, connString);
                break;

            case DatabaseType.iHistorian:
                getiHistorianCommonQueries(items, connString);
                break;

            case DatabaseType.Wonderware:
                getWonderwareCommonQueries(items, connString);
                break;

            case DatabaseType.PI:
                getPICommonQueries(items, connString);
                break;

            case DatabaseType.ClearSCADA:
                getClearSCADACommonQueries(items, connString);
                break;

            case DatabaseType.PostgreSQL:
                getPostgreSQLCommonQueries(items, connString);
                break;

            case DatabaseType.Others:
            default:
                break;
        }

        return items;
    }
    #endregion

    #region Private Methods
    private static void getOdbcCommonQueries(Dictionary<string, string> items, ConnectionStringBase connString)
    {
        items.Add("SQL Server Conn. String", $"Driver={"SQL Server"};Server={connString.Server};Database={connString.DatabaseName};Trusted_Connection=yes;");
        items.Add("PG Conn. String", $"Driver={"PostgreSQL ODBC Driver(UNICODE)"};Server={connString.Server}; address;Port=5432;Database={connString.DatabaseName};Uid={connString.UserName};Pwd={connString.Password};");
        items.Add("MySQL Conn. String", $"Driver={"MySQL ODBC 5.3 UNICODE Driver"};Server={connString.Server};Database={connString.DatabaseName};User={connString.UserName};Password={connString.Password};Option=3;");
    }

    private static void getOleDbCommonQueries(Dictionary<string, string> items, ConnectionStringBase connString)
    {
        items.Add("SQL Server Conn. String", $"Provider=sqloledb;Server={connString.Server};Database={connString.DatabaseName};User Id={connString.UserName};Password={connString.Password};");
        items.Add("Oracle Conn. String", $"Provider=OraOLEDB.Oracle;Data Source={connString.Server};User Id={connString.UserName};Password={connString.Password};Integrated Security=no;");
        items.Add("PG Conn. String", $"Provider=PostgreSQL OLE DB Provider;Data Source={connString.Server};location=={connString.DatabaseName};User ID={connString.UserName};password={connString.Password};timeout=1000;");
        items.Add("MySQL Conn. String", $"Provider=MySQLProv;Data Source={connString.DatabaseName};User Id={connString.UserName};Password={connString.Password};");
    }
    private static void getSqlServerCommonQueries(Dictionary<string, string> items, ConnectionStringBase connString)
    {
        items.Add("Tables Info", $"SELECT *, SCHEMA_NAME(\"schema_id\") AS 'schema' FROM \"{connString.DatabaseName}\".\"sys\".\"objects\" WHERE \"type\" IN ('P', 'U', 'V', 'TR', 'FN', 'TF', 'IF');");
        items.Add("Data Select", "SELECT TOP(100) * FROM [TableName]");
        items.Add("Get all views", "SELECT * FROM INFORMATION_SCHEMA.VIEWS");
        items.Add("Get Columns", $"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME='TabmeName';");
        items.Add("Get Databases", "SELECT \"name\" FROM \"sys\".\"databases\" ORDER BY \"name\";");
        items.Add("Get Version", "SELECT @@VERSION AS Version_Name ");
        items.Add("Get Edition", "SELECT SERVERPROPERTY('edition')");

        string dbSizeQuery = "" +
            "\nSELECT " +
            "\n\t    t.NAME AS TableName," +
            "\n\t    s.Name AS SchemaName," +
            "\n\t    p.rows AS RowCounts," +
            "\n\t    SUM(a.total_pages) * 8 AS TotalSpaceKB, " +
            "\n\t    CAST(ROUND(((SUM(a.total_pages) * 8) / 1024.00), 2) AS NUMERIC(36, 2)) AS TotalSpaceMB," +
            "\n\t    SUM(a.used_pages) * 8 AS UsedSpaceKB, " +
            "\n\t    CAST(ROUND(((SUM(a.used_pages) * 8) / 1024.00), 2) AS NUMERIC(36, 2)) AS UsedSpaceMB, " +
            "\n\t    (SUM(a.total_pages) - SUM(a.used_pages)) * 8 AS UnusedSpaceKB," +
            "\n\t    CAST(ROUND(((SUM(a.total_pages) - SUM(a.used_pages)) * 8) / 1024.00, 2) AS NUMERIC(36, 2)) AS UnusedSpaceMB" +
            "\nFROM " +
            "\n\t    sys.tables t" +
            "\nINNER JOIN      " +
            "\n\t    sys.indexes i ON t.OBJECT_ID = i.object_id" +
            "\nINNER JOIN " +
            "\n\t    sys.partitions p ON i.object_id = p.OBJECT_ID AND i.index_id = p.index_id" +
            "\nINNER JOIN " +
            "\n\t    sys.allocation_units a ON p.partition_id = a.container_id" +
            "\nLEFT OUTER JOIN " +
            "\n\t    sys.schemas s ON t.schema_id = s.schema_id" +
            "\nWHERE " +
            "\n\t    t.NAME NOT LIKE 'dt%' " +
            "\n\t    AND t.is_ms_shipped = 0" +
            "\n\t    AND i.OBJECT_ID > 255 " +
            "\nGROUP BY " +
            "\n\t    t.Name, s.Name, p.Rows" +
            "\nORDER BY " +
            "\n\t    t.Name";

        items.Add("Database/Table Size", dbSizeQuery);
    }
    private static void getPostgreSQLCommonQueries(Dictionary<string, string> items, ConnectionStringBase connString)
    {
        items.Add("Table Info", "SELECT column_name, data_type from INFORMATION_SCHEMA.COLUMNS where table_name like '%TableName';");
        items.Add("Data Select", "SELECT * from public.\"TableName\" limit 100");
        items.Add("Get Views", "SELECT * FROM pg_views WHERE schemaname NOT IN('information_schema', 'pg_catalog');");
        items.Add("Get Version", "SELECT version()");

        string dbSizeQuery = "" +
            "\nSELECT *, pg_size_pretty(total_bytes) AS total" +
            "\n\t    , pg_size_pretty(index_bytes) AS INDEX" +
            "\n\t    , pg_size_pretty(toast_bytes) AS toast" +
            "\n\t    , pg_size_pretty(table_bytes) AS TABLE" +
            "\n  FROM (" +
            "\n  SELECT *, total_bytes-index_bytes-COALESCE(toast_bytes,0) AS table_bytes FROM (" +
            "\n\t      SELECT c.oid,nspname AS table_schema, relname AS TABLE_NAME" +
            "\n\t              , c.reltuples AS row_estimate" +
            "\n\t              , pg_total_relation_size(c.oid) AS total_bytes" +
            "\n\t              , pg_indexes_size(c.oid) AS index_bytes" +
            "\n\t              , pg_total_relation_size(reltoastrelid) AS toast_bytes" +
            "\n\t          FROM pg_class c" +
            "\n\t          LEFT JOIN pg_namespace n ON n.oid = c.relnamespace" +
            "\n\t          WHERE relkind = 'r'" +
            "\n  ) a" +
            "\n) a;";

        items.Add("Databse/Table Size", dbSizeQuery);
    }

    private static void getClearSCADACommonQueries(Dictionary<string, string> items, ConnectionStringBase connString)
    {
        var dateTime = DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0)).ToString("yyyy-MM-dd HH:mm:ss");
        items.Add("Last 2 days data", $"SELECT * FROM CDBHistoric \n\t WHERE id = 1000 \n\t\t and \"Time\" > TIMESTAMP '{dateTime}' \n\t\t and Quality=192");
    }

    private static void getPICommonQueries(Dictionary<string, string> items, ConnectionStringBase connString)
    {
        var dateTime = DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0)).ToString("yyyy-MM-dd");

        items.Add("Last 2days Raw", $"SELECT * FROM piarchive..picomp2 \n\t WHERE tag = 'SINUSOID' \n\t\t AND time > FORMAT('{dateTime}', 'yyyy-MM-dd') \n\t\tAND questionable=0");
        items.Add("Last 2days No FORMAT", $"SELECT * FROM piarchive..picomp2 \n\t WHERE tag = 'SINUSOID' \n\t\t AND time > '{dateTime}' \n\t\tAND questionable=0");
        items.Add("Last 1day Interpolated", "SELECT time, value FROM piarchive..piinterp \n\t WHERE tag = 'SINUSOID' \n\t\t AND time BETWEEN '*-1d' \n\t\t AND '*' \n\t\t AND timestep = '1h'");
        items.Add("Last 12hrs Interpolated", "SELECT time, value FROM piarchive..piinterp \n\t WHERE tag = 'SINUSOID' \n\t\t AND time BETWEEN '*-12h' \n\t\t AND '* \n\t\t AND timestep = '15m'");
    }

    private static void getWonderwareCommonQueries(Dictionary<string, string> items, ConnectionStringBase connString)
    {
        var dateTime = DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0)).ToShortDateString();
        items.Add("Last 2 days", $"SELECT * FROM History \n\t WHERE TagName = 'SysInSQLIOS' \n\t\t AND DateTime > '{dateTime}' \n\t\t AND OPCQuality = 192");
    }

    private static void getiHistorianCommonQueries(Dictionary<string, string> items, ConnectionStringBase connString)
    {
        var dateTime = DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0)).ToString();
        items.Add("Last 2 days", $"SELECT * FROM ihrawdata \n\t where tagname = 'tagName' \n\t\t and timestampseconds > '{dateTime}' \n\t\t and quality=100");
    }

    private static void getOracleCommonQueries(Dictionary<string, string> items, ConnectionStringBase connString)
    {
    }

    private static void getMySqlCommonQueries(Dictionary<string, string> items, ConnectionStringBase connString)
    {
        items.Add("Tables Info", $"SHOW TABLE STATUS FROM '{connString.DatabaseName}';");
        items.Add("Data Select", $"SELECT  * FROM '{connString.DatabaseName}'.'TableName' LIMIT 100;");
    }
    #endregion
}

