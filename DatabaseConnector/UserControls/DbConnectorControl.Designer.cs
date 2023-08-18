
namespace DatabaseConnector.UserControls;

partial class DbConnectorControl : UserControlBase
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbConnectorControl));
        buttonTestConnection = new Button();
        buttonExecuteQuery = new Button();
        richTexboxQuery = new RichTextBox();
        splitContainer = new SplitContainer();
        splitContainerUpper = new SplitContainer();
        connectionStringControl = new ConnectionStringControl();
        labelQueryOutput = new Label();
        tabControl = new TabControl();
        tabPageDatabase = new TabPage();
        dataGridView = new DataGridView();
        tabPageLog = new TabPage();
        richTextBoxLog = new RichTextBox();
        ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
        splitContainer.Panel1.SuspendLayout();
        splitContainer.Panel2.SuspendLayout();
        splitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainerUpper).BeginInit();
        splitContainerUpper.Panel1.SuspendLayout();
        splitContainerUpper.Panel2.SuspendLayout();
        splitContainerUpper.SuspendLayout();
        tabControl.SuspendLayout();
        tabPageDatabase.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
        tabPageLog.SuspendLayout();
        SuspendLayout();
        // 
        // buttonTestConnection
        // 
        buttonTestConnection.Location = new Point(5, 2);
        buttonTestConnection.Margin = new Padding(2);
        buttonTestConnection.Name = "buttonTestConnection";
        buttonTestConnection.Size = new Size(36, 30);
        buttonTestConnection.TabIndex = 23;
        buttonTestConnection.TextAlign = ContentAlignment.MiddleRight;
        buttonTestConnection.UseVisualStyleBackColor = true;
        // 
        // buttonExecuteQuery
        // 
        buttonExecuteQuery.Location = new Point(46, 2);
        buttonExecuteQuery.Margin = new Padding(2);
        buttonExecuteQuery.Name = "buttonExecuteQuery";
        buttonExecuteQuery.Size = new Size(36, 30);
        buttonExecuteQuery.TabIndex = 24;
        buttonExecuteQuery.TextAlign = ContentAlignment.MiddleRight;
        buttonExecuteQuery.UseVisualStyleBackColor = true;
        // 
        // richTexboxQuery
        // 
        richTexboxQuery.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        richTexboxQuery.Location = new Point(0, 35);
        richTexboxQuery.Margin = new Padding(2);
        richTexboxQuery.Name = "richTexboxQuery";
        richTexboxQuery.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
        richTexboxQuery.Size = new Size(629, 166);
        richTexboxQuery.TabIndex = 22;
        richTexboxQuery.Text = "";
        richTexboxQuery.WordWrap = false;
        // 
        // splitContainer
        // 
        splitContainer.BackColor = SystemColors.ScrollBar;
        splitContainer.Dock = DockStyle.Fill;
        splitContainer.Location = new Point(0, 0);
        splitContainer.Margin = new Padding(4, 3, 4, 3);
        splitContainer.Name = "splitContainer";
        splitContainer.Orientation = Orientation.Horizontal;
        // 
        // splitContainer.Panel1
        // 
        splitContainer.Panel1.BackColor = SystemColors.Control;
        splitContainer.Panel1.Controls.Add(splitContainerUpper);
        // 
        // splitContainer.Panel2
        // 
        splitContainer.Panel2.BackColor = SystemColors.Control;
        splitContainer.Panel2.Controls.Add(tabControl);
        splitContainer.Size = new Size(629, 593);
        splitContainer.SplitterDistance = 317;
        splitContainer.SplitterWidth = 5;
        splitContainer.TabIndex = 26;
        // 
        // splitContainerUpper
        // 
        splitContainerUpper.BackColor = SystemColors.ScrollBar;
        splitContainerUpper.Dock = DockStyle.Fill;
        splitContainerUpper.Location = new Point(0, 0);
        splitContainerUpper.Margin = new Padding(4, 3, 4, 3);
        splitContainerUpper.Name = "splitContainerUpper";
        splitContainerUpper.Orientation = Orientation.Horizontal;
        // 
        // splitContainerUpper.Panel1
        // 
        splitContainerUpper.Panel1.BackColor = SystemColors.Control;
        splitContainerUpper.Panel1.Controls.Add(connectionStringControl);
        // 
        // splitContainerUpper.Panel2
        // 
        splitContainerUpper.Panel2.BackColor = SystemColors.Control;
        splitContainerUpper.Panel2.Controls.Add(labelQueryOutput);
        splitContainerUpper.Panel2.Controls.Add(buttonExecuteQuery);
        splitContainerUpper.Panel2.Controls.Add(buttonTestConnection);
        splitContainerUpper.Panel2.Controls.Add(richTexboxQuery);
        splitContainerUpper.Size = new Size(629, 317);
        splitContainerUpper.SplitterDistance = 110;
        splitContainerUpper.SplitterWidth = 5;
        splitContainerUpper.TabIndex = 25;
        // 
        // connectionStringControl
        // 
        connectionStringControl.CommonQueriesMap = (Dictionary<string, string>)resources.GetObject("connectionStringControl.CommonQueriesMap");
        connectionStringControl.Dock = DockStyle.Fill;
        connectionStringControl.Location = new Point(0, 0);
        connectionStringControl.Margin = new Padding(5);
        connectionStringControl.Name = "connectionStringControl";
        connectionStringControl.Size = new Size(629, 110);
        connectionStringControl.TabIndex = 0;
        connectionStringControl.UseConnectionStringRaw = false;
        // 
        // labelQueryOutput
        // 
        labelQueryOutput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        labelQueryOutput.Location = new Point(369, 7);
        labelQueryOutput.Margin = new Padding(4, 0, 4, 0);
        labelQueryOutput.Name = "labelQueryOutput";
        labelQueryOutput.Size = new Size(260, 22);
        labelQueryOutput.TabIndex = 3;
        labelQueryOutput.Text = "Count: N/A";
        labelQueryOutput.TextAlign = ContentAlignment.MiddleRight;
        // 
        // tabControl
        // 
        tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tabControl.Controls.Add(tabPageDatabase);
        tabControl.Controls.Add(tabPageLog);
        tabControl.Location = new Point(0, 2);
        tabControl.Margin = new Padding(4, 3, 4, 3);
        tabControl.Name = "tabControl";
        tabControl.SelectedIndex = 0;
        tabControl.Size = new Size(629, 268);
        tabControl.TabIndex = 2;
        // 
        // tabPageDatabase
        // 
        tabPageDatabase.Controls.Add(dataGridView);
        tabPageDatabase.Location = new Point(4, 24);
        tabPageDatabase.Margin = new Padding(4, 3, 4, 3);
        tabPageDatabase.Name = "tabPageDatabase";
        tabPageDatabase.Padding = new Padding(4, 3, 4, 3);
        tabPageDatabase.Size = new Size(621, 240);
        tabPageDatabase.TabIndex = 0;
        tabPageDatabase.Text = "Database";
        tabPageDatabase.UseVisualStyleBackColor = true;
        // 
        // dataGridView
        // 
        dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView.Dock = DockStyle.Fill;
        dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        dataGridView.Location = new Point(4, 3);
        dataGridView.Margin = new Padding(2);
        dataGridView.Name = "dataGridView";
        dataGridView.RowTemplate.Height = 24;
        dataGridView.Size = new Size(613, 234);
        dataGridView.TabIndex = 10;
        // 
        // tabPageLog
        // 
        tabPageLog.Controls.Add(richTextBoxLog);
        tabPageLog.Location = new Point(4, 24);
        tabPageLog.Margin = new Padding(4, 3, 4, 3);
        tabPageLog.Name = "tabPageLog";
        tabPageLog.Padding = new Padding(4, 3, 4, 3);
        tabPageLog.Size = new Size(621, 240);
        tabPageLog.TabIndex = 1;
        tabPageLog.Text = "Log";
        tabPageLog.UseVisualStyleBackColor = true;
        // 
        // richTextBoxLog
        // 
        richTextBoxLog.BorderStyle = BorderStyle.None;
        richTextBoxLog.Dock = DockStyle.Fill;
        richTextBoxLog.Location = new Point(4, 3);
        richTextBoxLog.Margin = new Padding(4, 3, 4, 3);
        richTextBoxLog.Name = "richTextBoxLog";
        richTextBoxLog.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
        richTextBoxLog.Size = new Size(613, 234);
        richTextBoxLog.TabIndex = 0;
        richTextBoxLog.Text = "";
        richTextBoxLog.WordWrap = false;
        // 
        // DbConnectorControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(splitContainer);
        Margin = new Padding(4, 3, 4, 3);
        Name = "DbConnectorControl";
        Size = new Size(629, 593);
        splitContainer.Panel1.ResumeLayout(false);
        splitContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
        splitContainer.ResumeLayout(false);
        splitContainerUpper.Panel1.ResumeLayout(false);
        splitContainerUpper.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainerUpper).EndInit();
        splitContainerUpper.ResumeLayout(false);
        tabControl.ResumeLayout(false);
        tabPageDatabase.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
        tabPageLog.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
    private Button buttonTestConnection;
    private Button buttonExecuteQuery;
    private RichTextBox richTexboxQuery;
    private SplitContainer splitContainer;
    private Label labelQueryOutput;
    private TabControl tabControl;
    private TabPage tabPageDatabase;
    private DataGridView dataGridView;
    private TabPage tabPageLog;
    private RichTextBox richTextBoxLog;
    private SplitContainer splitContainerUpper;
    private ConnectionStringControl connectionStringControl;
}
