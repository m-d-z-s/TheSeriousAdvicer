using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace TheSeriousAdvicer
{
    public partial class Form1 : Form
    {
        internal RandomEpisodeGeneration random = new RandomEpisodeGeneration("seriesData", @"\seriesList");

        public Form1()
        {
            InitializeComponent();
            RefreshComboBox();
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
            if (random.seriesListFilePath.Length != 0)
            {
                MessageBox.Show(Convert.ToString(random.RandomEpisodeGenerator(Convert.ToInt32(comboBox1.SelectedIndex))));
            }
            else
            {
                MessageBox.Show("Add series!");
            }
        }

        private void AddSerial_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string[] strok = File.ReadAllLines(random.seriesListFilePath);
            if(textBox1.Text != "" && strok.Length == 0)
            {
                flag = true;
                var series = new Series(textBox1.Text, $@"\seasons\{textBox1.Text.ToLowerInvariant()}_seasons", random.rootPath + $@"\{textBox1.Text.ToLowerInvariant()}_watched");
                StreamWriter sw = new StreamWriter(random.seriesListFilePath, true);
                sw.WriteLine(series.Name + "," + series.PathToSeasonsList);
                sw.Close();
            }
            else if(textBox1.Text != "" && strok.Length != 0)
            {
                if (AlreadyExists()) MessageBox.Show("This series already exists");
                else
                {
                    flag = true;
                    var series = new Series(textBox1.Text, $@"\seasons\{textBox1.Text.ToLowerInvariant()}_seasons", random.rootPath + $@"\{textBox1.Text.ToLowerInvariant()}_watched");
                    StreamWriter sw = new StreamWriter(random.seriesListFilePath, true);
                    comboBox1.Items.Add(textBox1.Text);
                    sw.WriteLine(series.Name + "," + series.PathToSeasonsList);
                    sw.Close();
                }
            }
            else
            {
                MessageBox.Show("Enter name of your series!");
            }
            if (flag)
            {
                string pathString = Path.Combine($@"seriesData\seasons\{textBox1.Text.ToLowerInvariant()}_episodes");
                Directory.CreateDirectory(pathString);
                var SerialName = textBox1.Text;
                Hide();
                DetailsOfTheSeries detailsOfTheSeries = new DetailsOfTheSeries(SerialName);
                detailsOfTheSeries.Show();
            }

        }

        private bool AlreadyExists()
        {
            var seriesNamesList = new List<string>();

            StreamReader streamReader = new StreamReader(random.seriesListFilePath, false);
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine().Split(',');
                seriesNamesList.Add(line[0]);
            }
            streamReader.Close();

            foreach (var name in seriesNamesList)
            {
                if (textBox1.Text == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void RefreshComboBox()
        {
            comboBox1.Items.Clear();
            var streamReader = new StreamReader(random.seriesListFilePath, false);
            var seriesList = new List<string>();
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine().Split(',');
                seriesList.Add(line[0]);
            }
            seriesList.ForEach(line => comboBox1.Items.Add(line));
            streamReader.Close();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            AddSerial.Visible = true;
        }
    }
}
