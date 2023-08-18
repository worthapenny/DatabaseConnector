using DatabaseConnector.Data;
using DatabaseConnector.Data.ConnectionString;
using Serilog;
using System.ComponentModel;

namespace DatabaseConnector.UserControls;

public partial class ConnectionStringControl : UserControlBase
{
    #region Constructor
    public ConnectionStringControl()
        : base()
    {
        ConnectionString = new ConnectionStringBase();
    }
    #endregion


    #region Override Methods
    protected override void InitializeFields()
    {
        fieldConnectionStringRaw.DynamiceSizing = false;
        fieldConnectionStringRaw.Percent = 80;

        fieldHasPassword.DynamiceSizing = false;
        fieldHasPassword.Percent = 80;

        fieldDbName.Percent = 90;
        fieldDriver.Percent = 90;
        fieldPassword.Percent = 90;
        fieldServer.Percent = 90;
        fieldUserName.Percent = 90;
    }
    protected override void InitializeBindings()
    {
        Binding bindUserName = new Binding("Enabled", checkBoxWinAuthentication, "Checked", true, DataSourceUpdateMode.OnPropertyChanged);
        bindUserName.Format += (s, e) => { e.Value = !(bool)e.Value; };
        fieldUserName.DataBindings.Add(bindUserName);

        Binding bindPassword = new Binding("Enabled", checkBoxWinAuthentication, "Checked", true, DataSourceUpdateMode.OnPropertyChanged);
        bindPassword.Format += (s, e) => { e.Value = !(bool)e.Value; };
        fieldPassword.DataBindings.Add(bindPassword);

        Binding bindNoPassword = new Binding("Enabled", ConnectionString, "NoPassword", true, DataSourceUpdateMode.OnPropertyChanged);
        bindNoPassword.Format += (s, e) => { e.Value = !(bool)e.Value; };
        fieldHasPassword.DataBindings.Add(bindNoPassword);

        checkBoxNoPassword.DataBindings.Add("Checked", ConnectionString, "NoPassword", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxWinAuthentication.DataBindings.Add("Checked", ConnectionString, "WindowsAuthentication", true, DataSourceUpdateMode.OnPropertyChanged);

        fieldHasPassword.DataBindings.Add("Value", ConnectionString, "Password", true, DataSourceUpdateMode.OnPropertyChanged);
        fieldConnectionStringRaw.DataBindings.Add(new Binding("Value", ConnectionString, "ConnectionStringRaw", true, DataSourceUpdateMode.OnPropertyChanged));
        fieldDbName.DataBindings.Add(new Binding("Value", ConnectionString, "DatabaseName", true, DataSourceUpdateMode.OnPropertyChanged));
        fieldDriver.DataBindings.Add(new Binding("Value", ConnectionString, "Driver", true, DataSourceUpdateMode.OnPropertyChanged));
        fieldPassword.DataBindings.Add(new Binding("Value", ConnectionString, "Password", true, DataSourceUpdateMode.OnPropertyChanged));

        fieldServer.DataBindings.Add(new Binding("Value", ConnectionString, "Server", true, DataSourceUpdateMode.OnPropertyChanged));
        fieldUserName.DataBindings.Add(new Binding("Value", ConnectionString, "UserName", true, DataSourceUpdateMode.OnPropertyChanged));

    }
    protected override void InitializeEvents()
    {

        checkBoxNoPassword.CheckedChanged += (s, e) =>
        {
            fieldHasPassword.Enabled = !checkBoxNoPassword.Checked;
            fieldPassword.Enabled = !checkBoxNoPassword.Checked;
        };

        tabControlConnString.SelectedIndexChanged += (s, e) =>
        {
            if (ConnectionString != null)
                ConnectionString.UseRawConnectionString = tabControlConnString.SelectedTab.Name == tabPageConnString.Name;
            else
                Log.Error($"ConnectionString cannot be null");
        };
    }



    protected override void InitializeUI()
    {
        //this.tabControlConnString.TabPages.Remove(tabPageValues);
        this.tabControlConnString.TabPages.Remove(tabPageIni);

        toolStripDropDownButton.Image = Properties.Resources.link;

        fieldHasPassword.TextBoxControl.PasswordChar = '#';
        fieldPassword.TextBoxControl.PasswordChar = '#';

        if (ConnectionString != null)
            ConnectionString.UseRawConnectionString = true;
        else
            Log.Error($"ConnectionString cannot be null");

        LoadConnectionStrings();
    }


    #endregion

    #region Public Methods
    public void LoadConnectionStrings()
    {
        if (toolStripDropDownButton.HasDropDownItems)
            return;


        toolStripDropDownButton.Enabled = CommonQueriesMap.Count > 0;

        foreach (var item in CommonQueriesMap)
        {
            var name = item.Key;
            var query = item.Value;

            var toolStripItem = new ToolStripMenuItem(
                text: name,
                image: Properties.Resources.link,
                onClick: (s, e) => { this.fieldConnectionStringRaw.Value = query; },
                name: name);
            toolStripItem.ToolTipText = $"Conn. string example for: {name}";
            toolStripDropDownButton.DropDownItems.Add(toolStripItem);
        }
    }


    #endregion

    #region Private Methods

    #endregion

    #region Public Property
    [DefaultValue(false)]
    public ConnectionStringBase ConnectionString { get; }

    [DefaultValue(true)]
    public bool UseConnectionStringRaw { get; set; }

    [DefaultValue(DatabaseType.SQLServer)]
    public DatabaseType DatabaseType { get; set; }

    public Dictionary<string, string> CommonQueriesMap { get; set; } = new Dictionary<string, string>();
    #endregion

}
