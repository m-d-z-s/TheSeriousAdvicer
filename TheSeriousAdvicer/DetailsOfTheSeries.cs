using System.Windows.Forms;
using System.IO;

namespace TheSeriousAdvicer
{
    public partial class DetailsOfTheSeries : Form
    {
        int key = 1;
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


        private void button1_Click(object sender, System.EventArgs e)
        {
            numericUpDown1.Enabled = false;
            label2.Text = $"Season {key}";
            button1.Enabled = false;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            //label2.Text = " ";
            if (key == 1)
            {
                StreamWriter streamWriter = new StreamWriter($@"seriesData\seasons\{newSerialName.ToLowerInvariant()}_episodes\season{key}episodes", true);
                for (int i = 1; i <= numericUpDown2.Value; i++)
                {
                    streamWriter.WriteLine("Episode " + i);
                }
                streamWriter.Close();
                key += 1;
                label2.Text = $"Season {key}";

            }
            else if (key <= numericUpDown1.Value)
            {
                StreamWriter streamWriter = new StreamWriter($@"seriesData\seasons\{newSerialName.ToLowerInvariant()}_episodes\season{key}episodes", true);
                for (int i = 1; i <= numericUpDown2.Value; i++)
                {
                    streamWriter.WriteLine("Episode " + i);
                }
                streamWriter.Close();
                key += 1;
                label2.Text = $"Season {key}";
            }
            if (key > numericUpDown1.Value)
            {
                Hide();
                form1.Show();
            }
        }
    }
}
