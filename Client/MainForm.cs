namespace Client
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;

    using Client.ServiceReference;

    using TestQuestService;

    public partial class MainForm : Form
    {
        private BindingList<ClientMessage> bindingList;

        public static MessageLevel[] Levels { get; private set; }

        private readonly LogServiceClient service;
        public MainForm()
        {
            InitializeComponent();
            var vals = Enum.GetValues(typeof(MessageLevel));
            Levels = (MessageLevel[])vals;
            this.levelComboBox.Items.AddRange(vals.Cast<object>().ToArray());
            levelComboBox.SelectedIndex = 0;
            service = new LogServiceClient();
        }

        private void RefreshData()
        {
            var messages = service.GetMessages(
                Levels[levelComboBox.SelectedIndex],
                fromDateTimePicker.Value,
                toDateTimePicker.Value);
            bindingList = new BindingList<ClientMessage>(messages);
            this.resultDataGridView.DataSource = bindingList;
        }

        private void GetButtonClick(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            var addForm = new AddForm();
            if (addForm.ShowDialog() != DialogResult.OK) return;
            service.AddRecord(addForm.AddingMessage);
            RefreshData();
        }
    }
}
