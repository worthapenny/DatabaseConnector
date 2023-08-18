using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace DatabaseConnector.Data.ConnectionString;

public class ConnectionStringBase : INotifyPropertyChanged
{
    #region Constructor
    public ConnectionStringBase()
    {
        ServerText = "Server";
    }
    public ConnectionStringBase(DatabaseConnectionMethod method)
        : this()
    {
        _method = method;
    }
    #endregion

    #region Boiler-Plate (INotifyPropertyChanged)
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
    #endregion


    #region  Public Methods
    public override string ToString()
    {
        string result = "";

        switch (_method)
        {
            case DatabaseConnectionMethod.ODBC:
                result = ToOdbcString();
                break;


            case DatabaseConnectionMethod.OLEDB:
                result = ToOleDbString();
                break;

        }
        return result;
    }

    public string ToOdbcString()
    {
        if (UseRawConnectionString)
        {
            if (NoPassword)
                return ConnectionStringRaw;
            else
                return ConnectionStringRaw + $";Pwd={Password};";
        }


        StringBuilder connString = new StringBuilder();

        connString.Append("Driver={").Append(Driver)
                   .Append("};").Append(ServerText).Append("=").Append(Server).Append(";");



        if (!string.IsNullOrWhiteSpace(DatabaseName))
            connString.Append("Database=").Append(DatabaseName).Append(";");


        if (WindowsAuthentication)
        {
            connString.Append("Trusted_Connection=yes;");
        }
        else
        {
            if (!string.IsNullOrWhiteSpace(UserName))
                connString.Append("Uid=").Append(UserName).Append(";");

            if (!NoPassword)
                connString.Append("Pwd=").Append(Password).Append(";");
        }

        return connString.ToString();
    }

    public string ToOleDbString()
    {
        if (UseRawConnectionString)
        {
            if (NoPassword)
                return ConnectionStringRaw;
            else
                return ConnectionStringRaw + $";Password={Password};";
        }


        StringBuilder connString = new StringBuilder();

        connString.Append("Provider=").Append(Driver)
                   .Append(";Data Source=").Append(Server).Append(";");

        if (!string.IsNullOrWhiteSpace(DatabaseName))
            connString.Append("Initial Catalog=").Append(DatabaseName).Append(";");


        if (WindowsAuthentication)
        {
            connString.Append("Integrated Security=SSPI").Append(";");
        }
        else
        {
            if (!string.IsNullOrWhiteSpace(UserName))
                connString.Append("User Id=").Append(UserName).Append(";");

            if (!NoPassword)
                connString.Append("Password=").Append(Password).Append(";");
        }

        return connString.ToString();
    }
    #endregion


    #region Public Properties
    [DefaultValue(DatabaseConnectionMethod.ODBC)]
    public DatabaseConnectionMethod Method { get { return _method; } set { SetField(ref _method, value); } }

    [DefaultValue("DbName")]
    public string DatabaseName { get { return _databaseName; } set { SetField(ref _databaseName, value); } }
    public string Driver { get { return _driver; } set { SetField(ref _driver, value); } }
    public string ConnectionStringRaw { get { return _connStringRaw; } set { SetField(ref _connStringRaw, value); } }

    [DefaultValue("password")]
    public string Password { get { return getDecrypted(_password); } set { SetField(ref _password, value); } }

    [DefaultValue(@"localhost\SQLExpress")]
    public string Server { get { return _server; } set { SetField(ref _server, value); } }

    [DefaultValue("userName")]
    public string UserName { get { return getDecrypted(_userName); } set { SetField(ref _userName, value); } }

    [DefaultValue(true)]
    public bool UseRawConnectionString { get { return _useRawConnString; } set { SetField(ref _useRawConnString, value); } }

    [DefaultValue(false)]
    public bool NoPassword { get { return _noPassword; } set { SetField(ref _noPassword, value); } }
    public bool WindowsAuthentication { get { return _winAuthentication; } set { SetField(ref _winAuthentication, value); } }
    public string ToConnectionString { get { return ToString(); } }

    public string Query { get { return _query; } set { SetField(ref _query, value); } }

    public string ServerText { get; set; } // For clearSCADA, Server becomes Location
    #endregion


    #region Private Methods

    private string getDecrypted(string encripted)
    {
        string unencrypted = encripted;

        if (!string.IsNullOrWhiteSpace(encripted) && encripted.EndsWith("=="))
        {
            if (encripted.StartsWith("ecp="))
                encripted = encripted.Replace("ecp=", "");
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes("&ER(fdsf");

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(encripted));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader streamReader = new StreamReader(cryptoStream);
            unencrypted = streamReader.ReadToEnd();
        }
        return unencrypted;
    }

    #endregion


    #region Private Fields
    private string _databaseName;
    private string _driver;
    private string _connStringRaw;
    private string _password;
    private string _server;
    private string _userName;
    private bool _useRawConnString;
    private bool _noPassword;
    private bool _winAuthentication;
    private DatabaseConnectionMethod _method;

    private string _query;
    #endregion
}
