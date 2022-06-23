namespace Angliverba
{
    public partial class Form1 : Form
    {
        Tester VerbTester = new Tester();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void TestStart_Click(object sender, EventArgs e)
        {
            var testForm = new TestForm(VerbTester);
            testForm.Show();
            testForm.goTest();
        }

        private void VerbListModify_Click(object sender, EventArgs e)
        {
            var modForm = new ModForm(VerbTester);
            modForm.Show();
        }
    }
}