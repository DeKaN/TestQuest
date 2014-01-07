namespace Client
{
    using System;
    using System.Windows.Forms;

    using TestQuestService;

    public partial class AddForm : Form
    {
        public ClientMessage AddingMessage { get; private set; }
        public AddForm()
        {
            InitializeComponent();
            levelComboBox.Items.AddRange(Array.ConvertAll(MainForm.Levels, input => (object)input));
            levelComboBox.SelectedIndex = 0;
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            AddingMessage = new ClientMessage
                            {
                                Date = this.dateTimePicker.Value,
                                Level = MainForm.Levels[this.levelComboBox.SelectedIndex]
                            };
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
