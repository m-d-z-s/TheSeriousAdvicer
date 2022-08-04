using System;
using System.Windows.Forms;

namespace TheSeriousAdvicer
{
    public partial class Form1 : Form
    {
        RandomEpisodeGeneration random = new RandomEpisodeGeneration("seriesData", @"\seriesList");

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                Ran.Visible = true;
            }
        }

        private void Ran_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(random.RandomEpisodeGenerator(Convert.ToInt32(comboBox1.SelectedIndex))));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            random.WatchedEpisodesCleaning();
        }
    }
}
