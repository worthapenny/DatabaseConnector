using System.ComponentModel;

namespace DatabaseConnector.UserControls;

public partial class Field : UserControlBase
{
    #region Constrctor
    public Field()
        : base()
    {
    }
    #endregion


    #region Override Methods
    protected override void InitializeFields()
    {
        DynamiceSizing = false;
    }
    protected override void InitializeEvents()
    {
        DoubleClick += (s, e) => { if (AllowEnablingTextBox) Enabled = !Enabled; };
        label.DoubleClick += (s, e) => { if (AllowEnablingTextBox) Enabled = !Enabled; };
    }
    #endregion


    #region Public Properties

    public string Value
    {
        get { return textBox.Text; }
        set { textBox.Text = value; }
    }

    public string Label
    {
        get { return label.Text; }
        set { label.Text = value; }
    }

    public new bool Enabled
    {
        get { return textBox.Enabled; }
        set { textBox.Enabled = value; }
    }

    [DefaultValue(30)]
    public int Percent
    {
        get
        {
            int pcWidth;
            if (DynamiceSizing)
                pcWidth = (int)(100 * label.Width / this.Width);
            else
                pcWidth = label.Width;

            return pcWidth;
        }
        set
        {
            int labelWidth;
            int textBoxWidth;

            if (DynamiceSizing)
                labelWidth = value * Width / 100;
            else
                labelWidth = value;

            label.Width = labelWidth;
            textBoxWidth = Width - labelWidth;
            textBox.Location = new Point(label.Location.X + label.Width, textBox.Location.Y);
            textBox.Size = new Size(textBoxWidth, textBox.Size.Height);

        }
    }

    [DefaultValue(false)]
    public bool DynamiceSizing { get; set; }

    [DefaultValue(true)]
    public bool AllowEnablingTextBox { get; set; }
    public TextBox TextBoxControl { get { return textBox; } }
    public Label LabelControl { get { return label; } }
    #endregion


    #region Public Events
    public event EventHandler ValueChanged
    {
        add { textBox.TextChanged += value; }
        remove { textBox.TextChanged -= value; }
    }
    #endregion


}
