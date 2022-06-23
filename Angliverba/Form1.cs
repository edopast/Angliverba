namespace Angliverba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TestStart_Click(object sender, EventArgs e)
        {
            var testForm = new TestForm();
            testForm.Show();
        }
    }
}