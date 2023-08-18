namespace DatabaseConnector.Forms;

partial class DbConnectorParentForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tabControlMain = new TabControl();
        SuspendLayout();
        // 
        // tabControlMain
        // 
        tabControlMain.Dock = DockStyle.Fill;
        tabControlMain.Location = new Point(0, 0);
        tabControlMain.Name = "tabControlMain";
        tabControlMain.SelectedIndex = 0;
        tabControlMain.Size = new Size(921, 676);
        tabControlMain.TabIndex = 0;
        // 
        // DbConnectorParentForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(921, 676);
        Controls.Add(tabControlMain);
        Name = "DbConnectorParentForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "DbConnectorParentForm";
        ResumeLayout(false);
    }

    #endregion

    private TabControl tabControlMain;
}