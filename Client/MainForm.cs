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

        private readonly MessageLevel[] levels;

        private readonly LogServiceClient service;
        public MainForm()
        {
            InitializeComponent();
            var vals = Enum.GetValues(typeof(MessageLevel));
            levels = (MessageLevel[])vals;
            this.levelComboBox.Items.AddRange(vals.Cast<object>().ToArray());
            service = new LogServiceClient();
        }

        private void RefreshData()
        {
            var messages = service.GetMessages(
                levels[levelComboBox.SelectedIndex],
                fromDateTimePicker.Value,
                toDateTimePicker.Value);
            bindingList = new BindingList<ClientMessage>(messages);
            dataGridView1.DataSource = bindingList;
        }

        private void GetButtonClick(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
