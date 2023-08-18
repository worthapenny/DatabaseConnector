using System.Data;
using System.Data.OleDb;

namespace DatabaseConnector.Data.ConnectionMethod;

public class OleDBAccess : IDisposable
{

    public OleDbConnection dbConn { get; set; }

    ///<summary>
    ///   Constructor. Initialize the internal DataSetCommand
    ///   Initialize connection based on the default web.config string
    public OleDBAccess(OleDbConnection Conn)
    {
        dbConn = Conn;
    }
    /// <summary>
    /// custom connection based on input string
    /// </summary>
    /// <param name="sConnection"></param>
    public OleDBAccess(string sConnection)
    {
        createConnection(sConnection);
    }
    ///<summary>
    /// Sub Dispose:
    ///     Dispose of this object's resources.
    ///</summary>
    void IDisposable.Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(true); /// as a service to those who might inherit from us
    }

    ///<summary>
    /// Sub Dispose:
    ///     Free the instance variables of this object.
    ///</summary>
    public void Dispose(Boolean disposing)
    {
        if (!disposing)
        {
            /// we're being collected, so let the GC take care of this object
        }
        if (dbConn != null)
        {
            CloseConnection();

        }

    }
    ///<summary>
    /// Sub createConnection
    /// create connection based on input connection string
    ///</summary>
    protected void createConnection(string sConnection)
    {
        try
        {
            dbConn = new OleDbConnection(sConnection);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

    }
    ///<summary>
    /// Sub createConnection 
    /// create a connection base on the xml configuration
    ///</summary>
    //        protected void createConnection() 
    //        {
    //            createConnection(H2OConfiguration.ConnectionString);
    ////			createConnection("Driver={Microsoft dBase Driver (*.dbf)};DBQ=D:\\Program Files\\H2OMAP Water\\Examples\\davis\\Davismap.DB");
    ////			createConnection("Driver={Microsoft dBase Driver (*.dbf)};DBQ=c:\\inetpub\\wwwroot\\h2oview\\database");
    //        }
    protected bool OpenConnection()
    {
        try
        {
            if ((dbConn.State & ConnectionState.Open) > 0)
            {
                // it's already open.
                return false;
            }
            dbConn.Open();
            return true;
        }
        catch (Exception ex)
        {
            // bubble exception
            throw ex;
        }
    }
    public void CloseConnection()
    {
        try
        {
            if ((dbConn.State & ConnectionState.Open) > 0)
            {
                // it's open.
                dbConn.Close();
                dbConn.Dispose();
                dbConn = null;
            }
        }
        catch (Exception ex)
        {
            // bubble exception
            throw ex;
        }
    }
    ///<summary>
    /// Sub dataSetQuery
    /// </summary>
    /// Param : startRecord indicates the starting record range to be returned
    ///         maxRecord indicates the total record from the starting record to be returned
    /// <usage>        
    ///       MyDataGrid.DataSource = dataSetQuery("SELECT * FROM TABLE;");
    ///       MyDataGrid.DataBind();
    ///</usage>
    ///		
    public DataSet dataSetQuery(String theSQL, int startRecord) { return dataSetQuery(theSQL, startRecord, 0); }
    public DataSet dataSetQuery(String theSQL) { return dataSetQuery(theSQL, 0, 0); }


    public DataSet dataSetQuery(String theSQL, int startRecord, int MaxRecord)
    {
        OleDbDataAdapter da = null;
        DataSet ds = new DataSet();

        try
        {
            if (dbConn.State != ConnectionState.Open)
            {
                dbConn.Open();
            }
            if (dbConn.State != ConnectionState.Open)
            {
                throw new Exception("Unable to open connection.");
            }
            da = new OleDbDataAdapter(theSQL, dbConn);
            if (MaxRecord == 0)
            {
                da.Fill(ds);
            }
            else
            {
                da.Fill(ds, startRecord, MaxRecord, "MEM_TABLE");        ///use a dummy name for the table in memory
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());

        }
        finally
        {
            if (da != null) da.Dispose();
        }

        return ds;
    }
    /// <summary>
    /// Sub dataSetQuery
    /// </summary>
    /// Param : startRecord indicates the starting record range to be returned
    ///         maxRecord indicates the total record from the starting record to be returned
    /// </summary>
    /// <param name="cmd"></param>
    /// <param name="startRecord"></param>
    /// <returns></returns>
    public DataSet dataSetQuery(OleDbCommand cmd, int startRecord) { return dataSetQuery(cmd, startRecord, 0); }
    public DataSet dataSetQuery(OleDbCommand cmd) { return dataSetQuery(cmd, 0, 0); }
    public DataSet dataSetQuery(OleDbCommand cmd, int startRecord, int MaxRecord)
    {
        OleDbDataAdapter da = null;
        DataSet ds = new DataSet();

        try
        {
            if (dbConn.State != ConnectionState.Open)
            {
                dbConn.Open();
            }
            cmd.Connection = dbConn;
            da = new OleDbDataAdapter(cmd);

            if (MaxRecord == 0)
            {
                da.Fill(ds);
            }
            else
            {
                da.Fill(ds, startRecord, MaxRecord, "MEM_TABLE");        ///use a dummy name for the table in memory
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());

        }
        finally
        {
            da.Dispose();
        }

        return ds;
    }
    ///<summary>
    /// Sub dataAdapterQuery
    ///This method uses the SqlDataAdapter to retrieve and display data. The DataAdapter is the bridge between a DataSet and the data source. Using a DataSet and DataAdapter is more memory intensive than using a DataReader, since all of the records returned are populated into a DataTable (taking up valuable system resources).
    ///</summary>
    ///<usage>        
    ///MyDataGrid.DataSource = dataAdapterQuery("SELECT * FROM TABLE;");
    ///MyDataGrid.DataBind();
    ///</usage>
    public OleDbDataAdapter dataAdapterQuery(String sql)
    {
        OleDbDataAdapter da = new OleDbDataAdapter();
        try
        {
            if (dbConn.State != ConnectionState.Open)
            {
                dbConn.Open();
            }

            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.SelectCommand = new OleDbCommand(sql, dbConn);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        return da;
    }
    ///<summary>
    /// Sub Query
    /// This method uses the SqlDataReader to display data. The SqlDataReader provides a means of reading a forward-only stream of data records from a SQL Server data source. For more interactive operations such as scrolling, filtering, navigating, and remoting, use the DataSet.
    /// </summary>
    /// <usage>        
    /// MyDataGrid.DataSource = Query("SELECT * FROM TABLE;");
    /// MyDataGrid.DataBind();
    ///</usage>

    public OleDbDataReader Query(String theSQL)
    {
        OleDbCommand dsCmd;
        OleDbDataReader theResult = null;
        if (dbConn.State != ConnectionState.Open)
        {
            dbConn.Open();
        }

        dsCmd = new OleDbCommand(theSQL, dbConn);

        theResult = dsCmd.ExecuteReader(CommandBehavior.KeyInfo);

        return theResult;
    }

    ///<summary>
    /// Sub CommandQuery
    /// This method uses the SqlDataReader to display data. The SqlDataReader provides a means of reading a forward-only stream of data records from a SQL Server data source. For more interactive operations such as scrolling, filtering, navigating, and remoting, use the DataSet.
    /// </summary>
    /// <usage>      
    /// SqlCommand cmd = new SqlCommand({string} query);
    /// ...   set the command
    /// MyDataGrid.DataSource = CommandQuery(cmd);
    /// MyDataGrid.DataBind();
    ///</usage>
    public OleDbDataReader CommandQuery(OleDbCommand cmd)
    {
        OleDbDataReader theResult = null;
        if (dbConn.State != ConnectionState.Open)
        {
            dbConn.Open();
        }

        cmd.Connection = dbConn;
        try
        {
            theResult = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        finally
        {
            //		cmd.Dispose();
        }

        return theResult;
    }

    ///<summary>
    /// Sub dataAdapterQuery
    ///This method uses the SqlDataAdapter to retrieve and display data. The DataAdapter is the bridge between a DataSet and the data source. Using a DataSet and DataAdapter is more memory intensive than using a DataReader, since all of the records returned are populated into a DataTable (taking up valuable system resources).
    /// </summary>
    ///<usage>        
    ///MyDataGrid.DataSource = dataAdapterQuery(command);
    ///MyDataGrid.DataBind();
    ///</usage>
    public DataSet dataAdapterQuery(OleDbCommand cmd)
    {
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        DataSet ds = new DataSet();

        try
        {
            if (dbConn.State != ConnectionState.Open)
            {
                dbConn.Open();
            }
            cmd.Connection = dbConn;
            da.Fill(ds);
        }
        finally
        {
            da.Dispose();
        }

        return ds;
    }
    public DataSet GetTableDataSet(string sTableName)
    {
        string theSQL = "select * from " + sTableName;
        return dataSetQuery(theSQL);
    }
    public OleDbDataReader GetTableReader(string sTableName)
    {
        string theSQL = "select * from " + sTableName;
        return Query(theSQL);
    }
    ///<summary>
    ///Sub StoredQuery
    ///This method as its name implies, retrieves a stored query from the SQL Server. Simply pass the name of the stored query into the method and it will return an SqlDataReader object.
    ///</summary>
    ///<usage>        
    ///MyDataGrid.DataSource = DBUtil.StoredQuery("YourStoredQuery");
    ///</usage>
    public OleDbDataReader StoredQuery(String theSP)
    {

        OleDbCommand dsCmd;
        OleDbDataReader theResult = null;
        if (dbConn.State != ConnectionState.Open)
        {
            dbConn.Open();
        }

        dsCmd = new OleDbCommand(theSP, dbConn);

        dsCmd.CommandType = CommandType.StoredProcedure;
        try
        {
            theResult = dsCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (Exception e)
        {

            Console.WriteLine(e.ToString());
        }
        finally
        {
            //	dsCmd.Dispose();
        }
        return theResult;

    }
    ///<summary>
    ///Sub SQLOperation
    ///This method should be used when you want to perform any SQL operation other than a query. Therefore, CREATE, DROP, ALTER, DELETE, INSERT INTO, UPDATE are all valid SQL syntax for this method. However, you may not use the SELECT syntax.
    ///</summary>

    public void SQLOperation(String theSQL)
    {

        OleDbCommand dsCmd;
        dsCmd = new OleDbCommand(theSQL, dbConn);
        try
        {
            if (dbConn.State != ConnectionState.Open)
            {
                dbConn.Open();
            }
            dsCmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        finally
        {
            dsCmd.Dispose();
        }

    }

    ///<summary>
    ///Sub ExecuteCommand
    ///This method should be used when you want to perform any SQL operation other than a query. Therefore, CREATE, DROP, ALTER, DELETE, INSERT INTO, UPDATE are all valid SQL syntax for this method. However, you may not use the SELECT syntax.
    ///</summary>
    public bool ExecuteCommand(OleDbCommand cmd)
    {
        cmd.Connection = dbConn;
        try
        {
            if (dbConn.State != ConnectionState.Open)
            {
                dbConn.Open();
            }
            cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            return false;
        }
        finally
        {
            cmd.Dispose();
        }
        return true;
    }

    public Object ExecuteScalar(OleDbCommand cmd)
    {
        cmd.Connection = dbConn;
        Object tempObj = null;
        try
        {
            if (dbConn.State != ConnectionState.Open)
            {
                dbConn.Open();
            }
            tempObj = cmd.ExecuteScalar();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        finally
        {
            cmd.Dispose();
        }
        return tempObj;
    }

    public Object ExecuteScalar(String sql)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = dbConn;
        cmd.CommandText = sql;
        Object tempObj = null;

        try
        {
            if (dbConn.State != ConnectionState.Open)
            {
                dbConn.Open();
            }
            tempObj = cmd.ExecuteScalar();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        finally
        {
            cmd.Dispose();
        }
        return tempObj;
    }
    /// <summary>
    /// 	Get the table schema information from a table
    /// </summary>
    /// <param name="sTableName">
    ///		the table name
    /// </param>
    /// <returns>
    ///		a datatable which only contain the schema
    /// </returns>
    /// <usage>        
    ///     DataTable myTable = GetTableSchema("test");
    ///     DataColumnCollection cols;
    ///		cols = myTable.Columns;
    ///		foreach(DataColumn col in cols)
    ///	    {
    ///     Console.WriteLine(col.ColumnName);
    ///		Console.WriteLine(col.DataType);
    ///		}       
    /// </usage> 
    /// <remarks>
    /// </remarks>		
    public DataTable GetTableSchema(String sTableName)
    {
        string theSQL = "select * from " + sTableName + " where 1=0 ";
        OleDbCommand dsCmd;
        OleDbDataReader theResult = null;
        DataTable dt = null;
        if (dbConn.State != ConnectionState.Open)
        {
            dbConn.Open();
        }

        dsCmd = new OleDbCommand(theSQL, dbConn);
        try
        {
            theResult = dsCmd.ExecuteReader(CommandBehavior.SchemaOnly);
            dt = theResult.GetSchemaTable();
        }
        catch (Exception e)
        {

            Console.WriteLine(e.ToString());
            throw e;
        }
        finally
        {
            if (theResult != null) theResult.Close();
            dsCmd.Dispose();
        }

        return dt;

    }

    public bool CheckColumnExistence(ref DataTable tSchema, string sFieldName)
    {
        bool theResult = false;
        for (int i = 0; i < tSchema.Rows.Count; i++)
        {
            if (tSchema.Rows[i][0].ToString() == sFieldName)
            {
                theResult = true;
            }
        }
        return theResult;
    }

    public string GetColumnType(string sFieldName)
    {
        string sTableName = sFieldName.Substring(0, sFieldName.IndexOf("."));
        string theSQL = "SELECT " + sFieldName + " FROM " + sTableName + " WHERE 1=0 ";
        OleDbCommand dsCmd;
        OleDbDataReader theResult = null;
        DataTable dt = null;
        if (dbConn.State != ConnectionState.Open)
        {
            dbConn.Open();
        }

        dsCmd = new OleDbCommand(theSQL, dbConn);
        try
        {
            theResult = dsCmd.ExecuteReader(CommandBehavior.SchemaOnly);
            dt = theResult.GetSchemaTable();
        }
        catch (Exception e)
        {

            Console.WriteLine(e.ToString());
            throw e;
        }
        finally
        {
            dsCmd.Dispose();
        }

        DataRow oneRow = dt.Rows[0];
        string sDataType = oneRow["DataType"].ToString();

        return sDataType;

    }
    /// <summary>
    /// 	retrieve a string of fieldname with a specified delimiter.
    /// </summary>
    /// <param name="dt">
    ///		a DataTable
    /// </param>
    /// <param name="sDelimiter">
    ///		a delimiter such as ","
    /// </param> 
    /// <returns>
    ///		return a string of field.  For example, "link.name, link.description"
    /// </returns>
    public string GetFieldString(DataTable dt, string sDelimiter, string sTableName)
    {
        return GetFieldString(dt, sDelimiter, sTableName, "");
    }
    public string GetFieldString(DataTable dt, string sDelimiter, string sTableName, string sExcludeField)
    {
        string sfield = "";
        DataColumnCollection cols;
        cols = dt.Columns;

        DataRowCollection drc = dt.Rows;
        int i = 0;
        foreach (DataRow row in drc)
        {
            if (row["ColumnName"].ToString() != "ID" && row["ColumnName"].ToString().ToUpper() != sExcludeField.ToUpper())
            {
                if (i > 0)
                {
                    sfield += sDelimiter;
                }
                sfield += sTableName + "." + row["ColumnName"].ToString();
                i++;
            }
        }

        return sfield;
    }
    Object GetValue(OleDbDataReader dr, int i)
    {
        if (dr.IsDBNull(i))
        {
            return null;
        }
        else
        {
            return dr.GetValue(i);
        }
    }

    ///<summary>
    ///This method is use to build a SQL with some simple checking
    ///</summary>

    public static String BuildSql(String sSQL, String sWhereClause, String sOrderBy)
    {
        if (sWhereClause != "")
        {
            sSQL = sSQL + " WHERE " + sWhereClause;
        }
        if (sOrderBy != "")
        {
            sSQL = sSQL + " Order By " + sOrderBy;
        }
        return sSQL;
    }

    public static String BuildSql(String sSQL, String sWhereClause)
    {
        return BuildSql(sSQL, sWhereClause, "");
    }
    public object NullTest(object objColumn, object Alternate)
    {
        if (Convert.IsDBNull(objColumn))
        {
            return Alternate;
        }
        else
        {
            return objColumn;
        }
    }


    public int GetRecordCount(string sTableName)
    {
        OleDbDataReader r = Query("select Count(*) as numrec from [" + sTableName + "]");
        try
        {
            if (r != null && r.Read())
            {

                return Convert.ToInt16(r["numrec"]);
            }
        }
        finally
        {
            if (r != null) r.Close();
        }
        return 0;
    }
    public int GetMax(string sTableName, string sFieldName)
    {
        OleDbDataReader r = null;
        int iMax = -1;
        try
        {
            r = Query("SELECT max(" + sFieldName + ") as maxid FROM " + sTableName);
            if (r.Read())
            {
                if (r["maxid"] == System.DBNull.Value) return 0;
                return Convert.ToInt16(r["maxid"]);
            }

        }
        finally
        {
            if (r != null) r.Close();
        }
        return iMax;
    }
    public OleDbDataReader GetDBFieldValue(string sTableName, string sFieldName)
    {
        OleDbDataReader r = null;

        try
        {
            r = Query("SELECT " + sFieldName + " FROM " + sTableName);
        }
        catch (Exception e)
        {
            Console.Write(e.ToString());
        }
        return r;

    }
    public bool CleanTableData(string sTable)
    {
        string sSql = "delete from " + sTable;
        try
        {
            //clean up

            SQLOperation(sSql);

        }
        catch (Exception e)
        {
            throw;
        }
        return true;
    }
}

