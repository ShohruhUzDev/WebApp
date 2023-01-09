namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private static int Qushuvchi(int a, int b)
        {
            return a * 10 + b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Func<int, int, int> funk = Qushuvchi; // delegate

            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);

            int c;
            c = funk(a, b);

            label1.Text = "Natija=" + c.ToString();



        }
    }
}