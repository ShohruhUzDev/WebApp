namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach (var i in richTextBox1.Text.Split('\n'))
            {
                list.Add(i.Trim());
            }
            var result=from item in list
                       select item.Count();

            label2.Text = result.Count().ToString();
        }
    }
}