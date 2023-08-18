
namespace DatabaseConnector.UserControls;

partial class Field: UserControlBase
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
        this.label = new System.Windows.Forms.Label();
        this.textBox = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // label
        // 
        this.label.Location = new System.Drawing.Point(0, 0);
        this.label.Margin = new System.Windows.Forms.Padding(0);
        this.label.Name = "label";
        this.label.Size = new System.Drawing.Size(148, 20);
        this.label.TabIndex = 0;
        this.label.Text = "???";
        this.label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // textBox
        // 
        this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.textBox.Location = new System.Drawing.Point(152, 1);
        this.textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.textBox.Name = "textBox";
        this.textBox.Size = new System.Drawing.Size(302, 20);
        this.textBox.TabIndex = 1;
        // 
        // Field
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.textBox);
        this.Controls.Add(this.label);
        this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.Name = "Field";
        this.Size = new System.Drawing.Size(455, 21);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label;
    private System.Windows.Forms.TextBox textBox;
}
