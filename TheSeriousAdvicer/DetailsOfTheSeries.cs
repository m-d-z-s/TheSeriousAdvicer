using System.Windows.Forms;
using System.IO;

namespace TheSeriousAdvicer
{
    public partial class DetailsOfTheSeries : Form
    {
        private int key = 1;
        private readonly string newSeriesName;
        private readonly Form1 form1 = new Form1();
        
        public DetailsOfTheSeries()
        {
            InitializeComponent();
        }

        public DetailsOfTheSeries(string seriesName)
        {
            InitializeComponent();
            newSeriesName = seriesName;
        }


        private void button1_Click(object sender, System.EventArgs e)
        {
            numericUpDown1.Enabled = false;
            label2.Text = $"Season {key}";
            button1.Enabled = false;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            var seriesName = Utility.NameFormater(newSeriesName);
            if (key == 1)
            {
                StreamWriter streamWriter = new StreamWriter($@"seriesData\seasons\{seriesName}_episodes\season{key}episodes", true);
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
                StreamWriter streamWriter = new StreamWriter($@"seriesData\seasons\{seriesName}_episodes\season{key}episodes", true);
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
                var streamWriter = new StreamWriter($@"seriesData\seasons\{seriesName}_seasons", true);
                for (var i = 0; i < numericUpDown1.Value; i++)
                {
                    streamWriter.WriteLine($@"Season {i+1},\seasons\{seriesName}_episodes\season{i+1}episodes");
                }
                streamWriter.Close();
                Hide();
                form1.Show();
            }
            if (!Directory.Exists(Form1.watchedListsPath)) Directory.CreateDirectory(Form1.watchedListsPath);
            var sw = new StreamWriter(Form1.watchedListsPath + $@"\{seriesName}_watched"); sw.Close();
        }
    }
}
