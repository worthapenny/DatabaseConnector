
namespace DatabaseConnector.UserControls
{
    partial class ConnectionStringControl : UserControlBase
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        protected override void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionStringControl));
            tabControlConnString = new TabControl();
            tabPageConnString = new TabPage();
            toolStripMain = new ToolStrip();
            toolStripDropDownButton = new ToolStripDropDownButton();
            fieldHasPassword = new Field();
            fieldConnectionStringRaw = new Field();
            checkBoxNoPassword = new CheckBox();
            tabPageValues = new TabPage();
            flowLayoutPanelValues = new FlowLayoutPanel();
            fieldServer = new Field();
            fieldDbName = new Field();
            fieldDriver = new Field();
            fieldUserName = new Field();
            fieldPassword = new Field();
            checkBoxWinAuthentication = new CheckBox();
            tabPageIni = new TabPage();
            buttonLoadIni = new Button();
            comboBoxIniDriver = new ComboBox();
            labelIniDriver = new Label();
            comboBoxIniHistorian = new ComboBox();
            labelHistorian = new Label();
            comboBoxIniFilePath = new ComboBox();
            labelIniPath = new Label();
            tabControlConnString.SuspendLayout();
            tabPageConnString.SuspendLayout();
            toolStripMain.SuspendLayout();
            tabPageValues.SuspendLayout();
            flowLayoutPanelValues.SuspendLayout();
            tabPageIni.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlConnString
            // 
            tabControlConnString.Controls.Add(tabPageConnString);
            tabControlConnString.Controls.Add(tabPageValues);
            tabControlConnString.Controls.Add(tabPageIni);
            tabControlConnString.Dock = DockStyle.Fill;
            tabControlConnString.Location = new Point(0, 0);
            tabControlConnString.Margin = new Padding(4, 3, 4, 3);
            tabControlConnString.Name = "tabControlConnString";
            tabControlConnString.SelectedIndex = 0;
            tabControlConnString.Size = new Size(708, 130);
            tabControlConnString.TabIndex = 27;
            // 
            // tabPageConnString
            // 
            tabPageConnString.Controls.Add(toolStripMain);
            tabPageConnString.Controls.Add(fieldHasPassword);
            tabPageConnString.Controls.Add(fieldConnectionStringRaw);
            tabPageConnString.Controls.Add(checkBoxNoPassword);
            tabPageConnString.Location = new Point(4, 24);
            tabPageConnString.Margin = new Padding(4, 3, 4, 3);
            tabPageConnString.Name = "tabPageConnString";
            tabPageConnString.Padding = new Padding(4, 3, 4, 3);
            tabPageConnString.Size = new Size(700, 102);
            tabPageConnString.TabIndex = 0;
            tabPageConnString.Text = "Conn. String";
            tabPageConnString.UseVisualStyleBackColor = true;
            // 
            // toolStripMain
            // 
            toolStripMain.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toolStripMain.Dock = DockStyle.None;
            toolStripMain.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton });
            toolStripMain.Location = new Point(624, 3);
            toolStripMain.Name = "toolStripMain";
            toolStripMain.Size = new Size(72, 25);
            toolStripMain.TabIndex = 18;
            toolStripMain.Text = "toolStrip1";
            // 
            // toolStripDropDownButton
            // 
            toolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripDropDownButton.Image = (Image)resources.GetObject("toolStripDropDownButton.Image");
            toolStripDropDownButton.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton.Name = "toolStripDropDownButton";
            toolStripDropDownButton.Size = new Size(29, 22);
            toolStripDropDownButton.Text = "Connection Strings";
            // 
            // fieldHasPassword
            // 
            fieldHasPassword.AllowEnablingTextBox = false;
            fieldHasPassword.Label = "Has Password";
            fieldHasPassword.Location = new Point(2, 31);
            fieldHasPassword.Margin = new Padding(2);
            fieldHasPassword.Name = "fieldHasPassword";
            fieldHasPassword.Percent = 80;
            fieldHasPassword.Size = new Size(356, 24);
            fieldHasPassword.TabIndex = 17;
            fieldHasPassword.Value = "";
            // 
            // fieldConnectionStringRaw
            // 
            fieldConnectionStringRaw.AllowEnablingTextBox = false;
            fieldConnectionStringRaw.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            fieldConnectionStringRaw.Label = "Conn String";
            fieldConnectionStringRaw.Location = new Point(2, 2);
            fieldConnectionStringRaw.Margin = new Padding(2);
            fieldConnectionStringRaw.Name = "fieldConnectionStringRaw";
            fieldConnectionStringRaw.Percent = 80;
            fieldConnectionStringRaw.Size = new Size(648, 24);
            fieldConnectionStringRaw.TabIndex = 16;
            fieldConnectionStringRaw.Value = "";
            // 
            // checkBoxNoPassword
            // 
            checkBoxNoPassword.AutoSize = true;
            checkBoxNoPassword.Location = new Point(82, 60);
            checkBoxNoPassword.Margin = new Padding(4, 3, 4, 3);
            checkBoxNoPassword.Name = "checkBoxNoPassword";
            checkBoxNoPassword.Size = new Size(95, 19);
            checkBoxNoPassword.TabIndex = 15;
            checkBoxNoPassword.Text = "No Password";
            checkBoxNoPassword.UseVisualStyleBackColor = true;
            // 
            // tabPageValues
            // 
            tabPageValues.Controls.Add(flowLayoutPanelValues);
            tabPageValues.Location = new Point(4, 24);
            tabPageValues.Margin = new Padding(4, 3, 4, 3);
            tabPageValues.Name = "tabPageValues";
            tabPageValues.Padding = new Padding(4, 3, 4, 3);
            tabPageValues.Size = new Size(700, 102);
            tabPageValues.TabIndex = 1;
            tabPageValues.Text = "Values";
            tabPageValues.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelValues
            // 
            flowLayoutPanelValues.Controls.Add(fieldServer);
            flowLayoutPanelValues.Controls.Add(fieldDbName);
            flowLayoutPanelValues.Controls.Add(fieldDriver);
            flowLayoutPanelValues.Controls.Add(fieldUserName);
            flowLayoutPanelValues.Controls.Add(fieldPassword);
            flowLayoutPanelValues.Controls.Add(checkBoxWinAuthentication);
            flowLayoutPanelValues.Dock = DockStyle.Fill;
            flowLayoutPanelValues.Location = new Point(4, 3);
            flowLayoutPanelValues.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanelValues.Name = "flowLayoutPanelValues";
            flowLayoutPanelValues.Size = new Size(692, 96);
            flowLayoutPanelValues.TabIndex = 0;
            // 
            // fieldServer
            // 
            fieldServer.AllowEnablingTextBox = false;
            fieldServer.Label = "Server";
            fieldServer.Location = new Point(2, 2);
            fieldServer.Margin = new Padding(2);
            fieldServer.Name = "fieldServer";
            fieldServer.Percent = 2953;
            fieldServer.Size = new Size(328, 24);
            fieldServer.TabIndex = 0;
            fieldServer.Value = "";
            // 
            // fieldDbName
            // 
            fieldDbName.AllowEnablingTextBox = false;
            fieldDbName.Label = "Database Name";
            fieldDbName.Location = new Point(334, 2);
            fieldDbName.Margin = new Padding(2);
            fieldDbName.Name = "fieldDbName";
            fieldDbName.Percent = 2953;
            fieldDbName.Size = new Size(328, 24);
            fieldDbName.TabIndex = 1;
            fieldDbName.Value = "";
            // 
            // fieldDriver
            // 
            fieldDriver.AllowEnablingTextBox = false;
            fieldDriver.Label = "Driver/Provider";
            fieldDriver.Location = new Point(2, 30);
            fieldDriver.Margin = new Padding(2);
            fieldDriver.Name = "fieldDriver";
            fieldDriver.Percent = 2953;
            fieldDriver.Size = new Size(328, 24);
            fieldDriver.TabIndex = 2;
            fieldDriver.Value = "";
            // 
            // fieldUserName
            // 
            fieldUserName.AllowEnablingTextBox = false;
            fieldUserName.Label = "User Name";
            fieldUserName.Location = new Point(334, 30);
            fieldUserName.Margin = new Padding(2);
            fieldUserName.Name = "fieldUserName";
            fieldUserName.Percent = 2953;
            fieldUserName.Size = new Size(328, 24);
            fieldUserName.TabIndex = 3;
            fieldUserName.Value = "";
            // 
            // fieldPassword
            // 
            fieldPassword.AllowEnablingTextBox = false;
            fieldPassword.Label = "Password";
            fieldPassword.Location = new Point(2, 58);
            fieldPassword.Margin = new Padding(2);
            fieldPassword.Name = "fieldPassword";
            fieldPassword.Percent = 2953;
            fieldPassword.Size = new Size(328, 24);
            fieldPassword.TabIndex = 4;
            fieldPassword.Value = "";
            // 
            // checkBoxWinAuthentication
            // 
            checkBoxWinAuthentication.AutoSize = true;
            checkBoxWinAuthentication.Location = new Point(336, 63);
            checkBoxWinAuthentication.Margin = new Padding(4, 7, 4, 3);
            checkBoxWinAuthentication.Name = "checkBoxWinAuthentication";
            checkBoxWinAuthentication.Size = new Size(129, 19);
            checkBoxWinAuthentication.TabIndex = 6;
            checkBoxWinAuthentication.Text = "Win Authentication";
            checkBoxWinAuthentication.UseVisualStyleBackColor = true;
            // 
            // tabPageIni
            // 
            tabPageIni.Controls.Add(buttonLoadIni);
            tabPageIni.Controls.Add(comboBoxIniDriver);
            tabPageIni.Controls.Add(labelIniDriver);
            tabPageIni.Controls.Add(comboBoxIniHistorian);
            tabPageIni.Controls.Add(labelHistorian);
            tabPageIni.Controls.Add(comboBoxIniFilePath);
            tabPageIni.Controls.Add(labelIniPath);
            tabPageIni.Location = new Point(4, 24);
            tabPageIni.Margin = new Padding(4, 3, 4, 3);
            tabPageIni.Name = "tabPageIni";
            tabPageIni.Size = new Size(700, 102);
            tabPageIni.TabIndex = 2;
            tabPageIni.Text = "Ini";
            tabPageIni.UseVisualStyleBackColor = true;
            // 
            // buttonLoadIni
            // 
            buttonLoadIni.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLoadIni.Location = new Point(666, 0);
            buttonLoadIni.Margin = new Padding(4, 3, 4, 3);
            buttonLoadIni.Name = "buttonLoadIni";
            buttonLoadIni.Size = new Size(33, 29);
            buttonLoadIni.TabIndex = 4;
            buttonLoadIni.UseVisualStyleBackColor = true;
            // 
            // comboBoxIniDriver
            // 
            comboBoxIniDriver.FormattingEnabled = true;
            comboBoxIniDriver.Location = new Point(93, 59);
            comboBoxIniDriver.Margin = new Padding(2);
            comboBoxIniDriver.Name = "comboBoxIniDriver";
            comboBoxIniDriver.Size = new Size(195, 23);
            comboBoxIniDriver.TabIndex = 3;
            // 
            // labelIniDriver
            // 
            labelIniDriver.AutoSize = true;
            labelIniDriver.Location = new Point(2, 62);
            labelIniDriver.Margin = new Padding(2, 0, 2, 0);
            labelIniDriver.Name = "labelIniDriver";
            labelIniDriver.Size = new Size(38, 15);
            labelIniDriver.TabIndex = 2;
            labelIniDriver.Text = "Driver";
            // 
            // comboBoxIniHistorian
            // 
            comboBoxIniHistorian.FormattingEnabled = true;
            comboBoxIniHistorian.Location = new Point(93, 31);
            comboBoxIniHistorian.Margin = new Padding(2);
            comboBoxIniHistorian.Name = "comboBoxIniHistorian";
            comboBoxIniHistorian.Size = new Size(195, 23);
            comboBoxIniHistorian.TabIndex = 3;
            // 
            // labelHistorian
            // 
            labelHistorian.AutoSize = true;
            labelHistorian.Location = new Point(2, 33);
            labelHistorian.Margin = new Padding(2, 0, 2, 0);
            labelHistorian.Name = "labelHistorian";
            labelHistorian.Size = new Size(55, 15);
            labelHistorian.TabIndex = 2;
            labelHistorian.Text = "Historian";
            // 
            // comboBoxIniFilePath
            // 
            comboBoxIniFilePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxIniFilePath.FormattingEnabled = true;
            comboBoxIniFilePath.Location = new Point(93, 2);
            comboBoxIniFilePath.Margin = new Padding(2);
            comboBoxIniFilePath.Name = "comboBoxIniFilePath";
            comboBoxIniFilePath.Size = new Size(568, 23);
            comboBoxIniFilePath.TabIndex = 1;
            // 
            // labelIniPath
            // 
            labelIniPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelIniPath.AutoSize = true;
            labelIniPath.Location = new Point(2, 6);
            labelIniPath.Margin = new Padding(2, 0, 2, 0);
            labelIniPath.Name = "labelIniPath";
            labelIniPath.Size = new Size(68, 15);
            labelIniPath.TabIndex = 0;
            labelIniPath.Text = "Ini File Path";
            // 
            // ConnectionStringControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControlConnString);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ConnectionStringControl";
            Size = new Size(708, 130);
            tabControlConnString.ResumeLayout(false);
            tabPageConnString.ResumeLayout(false);
            tabPageConnString.PerformLayout();
            toolStripMain.ResumeLayout(false);
            toolStripMain.PerformLayout();
            tabPageValues.ResumeLayout(false);
            flowLayoutPanelValues.ResumeLayout(false);
            flowLayoutPanelValues.PerformLayout();
            tabPageIni.ResumeLayout(false);
            tabPageIni.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlConnString;
        private TabPage tabPageConnString;
        private CheckBox checkBoxNoPassword;
        private TabPage tabPageValues;
        private FlowLayoutPanel flowLayoutPanelValues;
        private Field fieldDbName;
        private Field fieldServer;
        private Field fieldDriver;
        private Field fieldUserName;
        private Field fieldPassword;
        private CheckBox checkBoxWinAuthentication;
        private TabPage tabPageIni;
        private Field fieldHasPassword;
        private Field fieldConnectionStringRaw;
        private ComboBox comboBoxIniHistorian;
        private Label labelHistorian;
        private ComboBox comboBoxIniFilePath;
        private Label labelIniPath;
        private ComboBox comboBoxIniDriver;
        private Label labelIniDriver;
        private Button buttonLoadIni;
        private ToolStrip toolStripMain;
        private ToolStripDropDownButton toolStripDropDownButton;
    }
}
