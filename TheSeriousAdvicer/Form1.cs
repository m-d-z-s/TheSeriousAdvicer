using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace TheSeriousAdvicer
{
    public partial class Form1 : Form
    {
        RandomEpisodeGeneration random = new RandomEpisodeGeneration(@"seriesData\seriesList", @"\seriesList");

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

        private void AddSerial_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                var series = new Series(textBox1.Text, $@"\seasons\{textBox1.Text.ToLowerInvariant()}_seasons");
                StreamWriter sw = new StreamWriter(random.rootPath, true);
                comboBox1.Items.Add(textBox1.Text);
                sw.WriteLine(series.Name + "," + series.PathToSeasonsList);
                sw.Close();
                //string pathString = Path.Combine($"{textBox1.Text.ToLowerInvariant()}_episodes", @"seriesData\seasons\");
                //Directory.CreateDirectory(pathString);
                //StreamWriter streamWriter = new StreamWriter($@"seriesData\seasons\{textBox1.Text.ToLowerInvariant()}_episodes",true);
            }
            comboBox1.Refresh();
        }
    }
}
