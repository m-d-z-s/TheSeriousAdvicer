using System.Windows.Forms;
using System.IO;

namespace TheSeriousAdvicer
{
    public partial class DetailsOfTheSeries : Form
    {
        string newSerialName;
        //string NameSerial;
        Form1 form1 = new Form1();
        public DetailsOfTheSeries()
        {
            InitializeComponent();
        }

        public DetailsOfTheSeries(string SerialName)
        {
            InitializeComponent();
            newSerialName = SerialName;
        }

        private void numericUpDown2_ValueChanged(object sender, System.EventArgs e)
        {
            for (int i = 1; i <= numericUpDown1.Value; i++)
            {
                label2.Text = "Season " + i.ToString();
                StreamWriter streamWriter = new StreamWriter($@"seriesData\seasons\{newSerialName.ToLowerInvariant()}_episodes\season{i}episodes", true);
                for (int j = 1; j <= numericUpDown2.Value; j++)
                {
                    streamWriter.WriteLine("Episode " + j);
                }
                streamWriter.Close();
            }
            Hide();
            form1.Show();

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            for (int i = 1; i <= numericUpDown1.Value; i++)
            {
                label2.Text = "Season " + i.ToString();
                StreamWriter streamWriter = new StreamWriter($@"seriesData\seasons\{newSerialName.ToLowerInvariant()}_episodes\season{i}episodes", true);
                streamWriter.Close();
            }
        }

    }
}
