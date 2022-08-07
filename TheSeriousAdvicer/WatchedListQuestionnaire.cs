using System;
using System.Windows.Forms;

namespace TheSeriousAdvicer
{
    public partial class WatchedListQuestionnaire : Form
    {
        public WatchedListQuestionnaire(string seriesName, string watchedListsPath)
        {
            this.seriesName = seriesName;
            this.watchedListsPath = watchedListsPath;
            form1 = new Form1();
            InitializeComponent();
            CombineTitle();
        }

        private readonly string seriesName;
        private readonly string watchedListsPath;
        private readonly Form1 form1;

        private void CombineTitle()
        {
            Title.Text = $"You have watched '{seriesName}' series completely! \nDo you want to clean the watch history?";
        }

        private void QYes_Click(object sender, EventArgs e)
        {
            Utility.WatchedEpisodesCleaning(watchedListsPath);
            Hide();
            form1.Show();
        }

        private void QNo_Click(object sender, EventArgs e)
        {
            Hide();
            form1.Show();
        }
    }
}
