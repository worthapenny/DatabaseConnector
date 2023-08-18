using DatabaseConnector.Data;
using DatabaseConnector.Data.ConnectionString;
using DatabaseConnector.Support;
using Serilog;

namespace DatabaseConnector.UserControls;

public partial class DbConnectorControl : UserControlBase
{

    #region Constructor
    public DbConnectorControl()
        : base()
    {
        DataSourceConnector = new DataSourceConnector();
    }
    #endregion


    #region Override methods

    protected override void InitializeBindings()
    {
        richTexboxQuery.DataBindings.Add("Text", ConnectionString, "Query", true, DataSourceUpdateMode.OnPropertyChanged);
    }

    protected override void InitializeEvents()
    {
        Logging.InMemorySink.Logged += (s, e) => WriteToUI(e);
        DataSourceConnector.DbConnectionStatusChanged += DbConnector_DbConnectionStatusChanged;

        buttonTestConnection.Click += (s, e) => { DataSourceConnector.TestConnection(ConnectionString); };
        buttonExecuteQuery.Click += (s, e) => { ConnectionString.Query = richTexboxQuery.SelectedText.Length > 0 ? richTexboxQuery.SelectedText : richTexboxQuery.Text; DataSourceConnector.ExecuteQuery(ConnectionString); };
        connectionStringControl.DoubleClick += (s, e) => { Log.Information(ConnectionString.ToString()); };
    }



    protected override void InitializeUI()
    {
        this.buttonExecuteQuery.Image = Properties.Resources.round_play;
        this.buttonTestConnection.Image = Properties.Resources.round_checkmark;

        ImageList imageList = new ImageList();
        imageList.Images.Add("database", Properties.Resources.database.ToBitmap());
        imageList.Images.Add("log", Properties.Resources.Copy_16);

        this.tabControl.ImageList = imageList;
        this.tabPageDatabase.ImageKey = "database";
        this.tabPageLog.ImageKey = "log";

        buttonTestConnection.Enabled = true;
        buttonExecuteQuery.Enabled = false;
    }
    #endregion


    #region Public Methods        
    public void SetQuery(string sql, bool append)
    {
        if (append)
            richTexboxQuery.AppendText(sql);
        else
            richTexboxQuery.Text = sql;
    }
    #endregion

    #region Private Methods
    private void WriteToUI(string e)
    {
        richTextBoxLog.Text += e;
        richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
        richTextBoxLog.ScrollToCaret();
    }


    private void DbConnector_DbConnectionStatusChanged(object? sender, DatabaseConnectionEventArgs e)
    {

        switch (e.Status)
        {
            case DatabaseConnectionStatus.TestConnectionStarted:
                Cursor.Current = Cursors.WaitCursor;
                labelQueryOutput.Text = "Testing....";
                break;

            case DatabaseConnectionStatus.TestConnectionFailed:
                tabControl.SelectedTab = tabPageLog;
                buttonExecuteQuery.Enabled = false;
                TestConnectionStatus = false;
                labelQueryOutput.Text = e.TimeTakenMessage;
                MessageBox.Show(this, "Test connection failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;

            case DatabaseConnectionStatus.TestConnectionCompleted:
                Cursor.Current = Cursors.Default;
                break;

            case DatabaseConnectionStatus.TestConnectionSuccesseded:
                tabControl.SelectedTab = tabPageDatabase;
                buttonExecuteQuery.Enabled = true;
                TestConnectionStatus = true;
                labelQueryOutput.Text = e.TimeTakenMessage;
                MessageBox.Show(this, "Test connection was successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                break;



            case DatabaseConnectionStatus.ExecutionStarted:
                Cursor.Current = Cursors.WaitCursor;
                labelQueryOutput.Text = "Executing the query...";
                break;

            case DatabaseConnectionStatus.ExecutionCompleted:
                Cursor.Current = Cursors.Default;
                break;

            case DatabaseConnectionStatus.ExecutionSuccessful:
                dataGridView.DataSource = e.DataSet.Tables[0].DefaultView;
                tabControl.SelectedTab = tabPageDatabase;
                labelQueryOutput.Text = e.TimeTakenMessage;
                break;

            case DatabaseConnectionStatus.ExecutionSuccessfulWithNoTables:
                tabControl.SelectedTab = tabPageLog;
                labelQueryOutput.Text = e.TimeTakenMessage;
                break;

            case DatabaseConnectionStatus.ExecutionFailed:
                tabControl.SelectedTab = tabPageLog;
                labelQueryOutput.Text = "Failed, see log...";
                break;

        }

        Application.DoEvents();
    }

    #endregion


    #region Public Properties 
    public ConnectionStringBase ConnectionString { get { return connectionStringControl.ConnectionString; } }

    public ConnectionStringControl ConnectionStringControl { get { return connectionStringControl; } }

    public bool TestConnectionStatus { get; set; }

    public DataSourceConnector DataSourceConnector { get; set; }
    #endregion

}
