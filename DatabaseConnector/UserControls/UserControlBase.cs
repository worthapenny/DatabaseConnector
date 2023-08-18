namespace DatabaseConnector.UserControls
{
    public partial class UserControlBase : UserControl
    {

        #region Constructor
        public UserControlBase()
        {
            InitializeComponent();
        }
        #endregion

        #region Overridden Methods
        protected override void OnLoad(EventArgs e)
        {
            InitializeFields();
            InitializeBindings();
            InitializeUI();
            InitializeEvents();
        }
        #endregion

        #region Virtual Methods
        protected virtual void InitializeComponent() { }

        protected virtual void InitializeFields() { }

        protected virtual void InitializeBindings() { }

        protected virtual void InitializeUI() { }

        protected virtual void InitializeEvents() { }

        #endregion
    }
}
