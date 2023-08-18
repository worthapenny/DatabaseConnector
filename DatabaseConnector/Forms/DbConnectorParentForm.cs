using DatabaseConnector.Data;
using DatabaseConnector.UserControls;

namespace DatabaseConnector.Forms;

public partial class DbConnectorParentForm : FormBase
{
    #region Constructor
    public DbConnectorParentForm()
    {
        InitializeComponent();
    }

    #endregion

    #region Override Methods
    protected override void InitializeFields()
    {
        KeyPreview = true;
    }
    protected override void InitializeEvents()
    {
        // On F5 run the query
        KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.F5)
            {
                foreach (var item in tabControlMain.SelectedTab.Controls)
                {
                    if (item is DbConnectorControl)
                    {
                        DbConnectorControl dbConnector = (DbConnectorControl)item;
                        dbConnector.DataSourceConnector.ExecuteQuery(dbConnector.ConnectionString);
                        return;
                    }
                }
            }
        };


        //        toolStripButtonIIS.Click += (s, e) => { runApplication($@"{Environment.GetEnvironmentVariable("windir")}\System32\inetsrv\iis.msc", string.Empty); };
        //        toolStripButtonOdbc32.Click += (s, e) => { runApplication($@"{Environment.GetEnvironmentVariable("windir")}\syswow64\odbcad32.exe", string.Empty); };
        //        toolStripButtonOdbc64.Click += (s, e) =>
        //        {
        //            Clipboard.SetText(@"%windir%\system32\odbcad32.exe"); MessageBox.Show(this,
        //"Can't open 64 bit thing from a 32 bit app.\n Path is copied to clipboard, use Run and paste", "Win + R > Ctrl + V > Enter");
        //        };
        //        toolStripButtonSWLog.Click += (s, e) => { runApplication(runner.NotepadPPExePath(), runner.GetLatestFile(Runner.SW_LOG_DIR_PATH), true); };
        //        toolStripButtonAgentLog.Click += (s, e) => { runApplication(runner.NotepadPPExePath(), runner.GetLatestFile(Runner.SW_AGENT_LOG_DIR_PATH), true); };
        //        toolStripButtonCreateViewsSW.Click += (s, e) => { addCreateViewSQLtoSWTab(); };


        //        toolStripSplitButtonIni.Click += (s, e) =>
        //        {
        //            if (!string.IsNullOrEmpty(runner.GetIniFilePath()))
        //            {
        //                runApplication(runner.NotepadPPExePath(), runner.GetIniFilePath());
        //            }
        //        };

        //var iniFilePaths = runner.GetIniFilePaths();
        //foreach (var iniFilePath in iniFilePaths)
        //{
        //    toolStripSplitButtonIni.DropDownItems.Add(iniFilePath.Key, Properties.Resources.ini, (s, e) =>
        //    {
        //        runApplication(runner.NotepadPPExePath(), iniFilePath.Value, true);
        //    });
        //}
    }

    protected override void InitializeUI()
    {
        Text = "Database Connector";
        Icon = Properties.Resources.database;
        //toolStripMain.ImageScalingSize = new System.Drawing.Size(16, 16);
        //toolStripMain.Invalidate();

        DateTime lastTwoDays = DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0));

        AddODBC();
        AddOleDB();
        AddSQLite();
        AddSqlServer();
        AddPostgreSQL();
        AddWonderware(lastTwoDays);
        AddiHistorian(lastTwoDays);
        AddOsiPI(lastTwoDays);
        AddClearSCADA(lastTwoDays);
    }
    #endregion

    #region Private Methods

    private void AddODBC()
    {
        DbConnectorControl odbcConnector = new DbConnectorControl();
        odbcConnector.Dock = DockStyle.Fill;
        odbcConnector.ConnectionStringControl.DatabaseType = DatabaseType.Others;
        odbcConnector.ConnectionString.Method = DatabaseConnectionMethod.ODBC;
        odbcConnector.ConnectionString.Query = "SELECT * FROM tableName";
        odbcConnector.ConnectionString.NoPassword = true;

        odbcConnector.ConnectionStringControl.CommonQueriesMap = CommonQueries.Get(odbcConnector.ConnectionString);

        TabPage odbcTab = new TabPage("ODBC");
        odbcTab.Controls.Add(odbcConnector);
        tabControlMain.TabPages.Add(odbcTab);

    }
    private void AddOleDB()
    {
        DbConnectorControl oledbConnector = new DbConnectorControl();
        oledbConnector.Dock = DockStyle.Fill;
        oledbConnector.ConnectionStringControl.DatabaseType = DatabaseType.Others;
        oledbConnector.ConnectionString.Method = DatabaseConnectionMethod.OLEDB;
        oledbConnector.ConnectionString.Query = "SELECT * FROM tableName";
        oledbConnector.ConnectionString.NoPassword = true;

        oledbConnector.ConnectionStringControl.CommonQueriesMap = CommonQueries.Get(oledbConnector.ConnectionString);

        TabPage oledbTab = new TabPage("OleDB");
        oledbTab.Controls.Add(oledbConnector);
        tabControlMain.TabPages.Add(oledbTab);

    }
    private void AddSQLite()
    {

    }
    private void AddSqlServer()
    {
        DbConnectorControl sqlServerConnector = new DbConnectorControl();
        sqlServerConnector.Dock = DockStyle.Fill;
        sqlServerConnector.ConnectionStringControl.DatabaseType = DatabaseType.SQLServer;
        sqlServerConnector.ConnectionString.Method = DatabaseConnectionMethod.ODBC;
        sqlServerConnector.ConnectionString.Query = "SELECT * FROM tableName";
        sqlServerConnector.ConnectionString.NoPassword = true;

        sqlServerConnector.ConnectionStringControl.CommonQueriesMap = CommonQueries.Get(sqlServerConnector.ConnectionString);

        TabPage tab = new TabPage("SQL Server");
        tab.Controls.Add(sqlServerConnector);
        tabControlMain.TabPages.Add(tab);

    }
    private void AddPostgreSQL()
    {
        DbConnectorControl postgresqlConnector = new DbConnectorControl();
        postgresqlConnector.Dock = DockStyle.Fill;
        postgresqlConnector.ConnectionStringControl.DatabaseType = DatabaseType.PostgreSQL;
        postgresqlConnector.ConnectionString.Method = DatabaseConnectionMethod.ODBC;
        postgresqlConnector.ConnectionString.Query = "SELECT * FROM public.\"tableName\"";
        postgresqlConnector.ConnectionString.NoPassword = true;

        postgresqlConnector.ConnectionStringControl.CommonQueriesMap = CommonQueries.Get(postgresqlConnector.ConnectionString);

        TabPage tab = new TabPage("PostgreSQL");
        tab.Controls.Add(postgresqlConnector);
        tabControlMain.TabPages.Add(tab);

    }

    private void AddWonderware(DateTime lastTwoDays)
    {
        DbConnectorControl wwConnector = new DbConnectorControl();
        wwConnector.Dock = DockStyle.Fill;
        wwConnector.ConnectionString.Method = DatabaseConnectionMethod.ODBC;
        wwConnector.ConnectionStringControl.DatabaseType = DatabaseType.Wonderware;
        wwConnector.ConnectionString.Query = $"SELECT * FROM History \n\t WHERE TagName = 'SysInSQLIOS' \n\t\t AND DateTime > '{lastTwoDays.ToShortDateString()}' \n\t\t AND OPCQuality=192";
        wwConnector.ConnectionString.Server = "ServerAddress";
        wwConnector.ConnectionString.DatabaseName = "Runtime";
        wwConnector.ConnectionString.Driver = "SQL Server";
        wwConnector.ConnectionString.UserName = "userName";
        wwConnector.ConnectionString.Password = "password";
        wwConnector.ConnectionString.NoPassword = true;

        TabPage wwTab = new TabPage("Wonderware");
        wwTab.Controls.Add(wwConnector);
        tabControlMain.TabPages.Add(wwTab);

    }

    private void AddOsiPI(DateTime lastTwoDays)
    {
        var dateTime = lastTwoDays.ToString("yyyy-MM-dd");

        DbConnectorControl piConnector = new DbConnectorControl();
        piConnector.Dock = DockStyle.Fill;
        piConnector.ConnectionString.Method = DatabaseConnectionMethod.OLEDB;
        piConnector.ConnectionStringControl.DatabaseType = DatabaseType.PI;
        piConnector.ConnectionString.Query = $"SELECT * FROM piarchive..picomp2 \n\t WHERE tag = 'SINUSOID' \n\t\t AND time > FORMAT('{dateTime}', 'yyyy-MM-dd') \n\t\tAND questionable=0";
        piConnector.ConnectionString.Server = "ServerAddress/IP";
        piConnector.ConnectionString.DatabaseName = "piarchive";
        piConnector.ConnectionString.Driver = "PIOLEDB or PIOLEDB.1";
        piConnector.ConnectionString.UserName = "userName";
        piConnector.ConnectionString.Password = "password";
        piConnector.ConnectionString.ConnectionStringRaw = "Provider=PIOLEDB.1; Data Source=serverAddress/IP;Integrated Security=false; User ID=userName;Password=password;";
        piConnector.ConnectionString.NoPassword = true;

        TabPage piTab = new TabPage("OSI PI");
        piTab.Controls.Add(piConnector);
        tabControlMain.TabPages.Add(piTab);


    }

    private void AddiHistorian(DateTime lastTwoDays)
    {
        DbConnectorControl iHistConnector = new DbConnectorControl();
        iHistConnector.Dock = DockStyle.Fill;
        iHistConnector.ConnectionString.Method = DatabaseConnectionMethod.OLEDB;
        iHistConnector.ConnectionStringControl.DatabaseType = DatabaseType.iHistorian;
        iHistConnector.ConnectionString.Query = $"SELECT * FROM ihrawdata \n\t where tagname = 'tagName' \n\t\t and timestampseconds > '{lastTwoDays.ToString()}' \n\t\t and quality=100";
        iHistConnector.ConnectionString.Server = "Data Source / IP";
        iHistConnector.ConnectionString.DatabaseName = "";
        iHistConnector.ConnectionString.Driver = "ihOLEDB.iHistorian.1";
        iHistConnector.ConnectionString.ConnectionStringRaw = "Provider=ihOLEDB.iHistorian.1;Data Source=DataSource;";
        iHistConnector.ConnectionString.NoPassword = true;

        TabPage iHistTab = new TabPage("iHistorian");
        iHistTab.Controls.Add(iHistConnector);
        tabControlMain.TabPages.Add(iHistTab);



    }

    private void AddClearSCADA(DateTime lastTwoDays)
    {
        DbConnectorControl cleraScadaConnector = new DbConnectorControl();
        cleraScadaConnector.Dock = DockStyle.Fill;
        cleraScadaConnector.ConnectionString.Method = DatabaseConnectionMethod.ODBC;
        cleraScadaConnector.ConnectionStringControl.DatabaseType = DatabaseType.ClearSCADA;
        cleraScadaConnector.ConnectionString.ServerText = "Location"; // Only for ClearSCADA
        cleraScadaConnector.ConnectionString.Query = $"SELECT * FROM CDBHistoric \n\t WHERE id = 1000 \n\t\t and \"Time\" > TIMESTAMP '{lastTwoDays.ToString("yyyy-MM-dd HH:mm:ss")}' \n\t\t and Quality=192";
        cleraScadaConnector.ConnectionString.Server = "Location, NOT server/ip";
        cleraScadaConnector.ConnectionString.DatabaseName = "";
        cleraScadaConnector.ConnectionString.Driver = "ClearSCADA Driver";
        cleraScadaConnector.ConnectionString.UserName = "userName";
        cleraScadaConnector.ConnectionString.Password = "password";
        cleraScadaConnector.ConnectionString.ConnectionStringRaw = "DSN=ClearSCADA32   or   Driver={ClearSCADA Driver};Location=Location;Uid=userName;Pwd=Password;Localtime=Ture;";
        cleraScadaConnector.ConnectionString.NoPassword = true;

        TabPage cleraScadaTab = new TabPage("ClearSCADA");
        cleraScadaTab.Controls.Add(cleraScadaConnector);
        tabControlMain.TabPages.Add(cleraScadaTab);
    }

    #endregion
}
