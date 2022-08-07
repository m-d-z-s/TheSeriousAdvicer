using System.Windows.Forms;
using System.IO;

namespace TheSeriousAdvicer
{
    public partial class DetailsOfTheSeries : Form
    {
        int key = 1;
        string newSerialName;
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
                var streamWriter = new StreamWriter($@"seriesData\seasons\{newSerialName.ToLowerInvariant()}_seasons", true);
                for (var i = 0; i < numericUpDown1.Value; i++)
                {
                    streamWriter.WriteLine($@"Season {i+1},\seasons\{newSerialName.ToLowerInvariant()}_episodes\season{i+1}episodes");
                }
                streamWriter.Close();
                Hide();
                form1.Show();
            }
            StreamWriter streamWriter1 = new StreamWriter($@"seriesData\{newSerialName.ToLowerInvariant()}_watched", true);
            streamWriter1.Close();
            //создать папку с просмотренными, в нем будут храниться файлы от каждого сериала
            //изменить путь StreamWriter, при записи просмотренных
            //какие нужны файла по дефолту?
            //упростить код
        }
    }
}
