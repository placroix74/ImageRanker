using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ImageRanker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loadImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png";
            dlg.CheckFileExists = true;
            dlg.Multiselect = true;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                m_sourceImages.Clear();

                foreach (var fileName in dlg.FileNames)
                {
                    m_sourceImages[fileName] = Image.FromFile(fileName);
                    m_ranking = m_sourceImages.Keys.ToArray();
                }

                refreshImageList();
            }
        }

        private void rankImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_sourceImages.Count() <= 0)
            {
                MessageBox.Show("Nothing to rank");
                return;
            }

            UseWaitCursor = true;
            var thread = new Thread(rankImages);
            thread.Start();

            do
            {
                if (m_pairAvailable.WaitOne(100))
                {
                    var dlg = new RankOne(m_sortData);
                    dlg.ShowDialog(this);
                    m_sortAvailable.Release();
                }
            }
            while (thread.IsAlive);

            UseWaitCursor = false;
            refreshImageList();
        }

        private void rankImages()
        {
            Debug.Assert(m_sourceImages.Count() > 0);
            m_ranking = m_sourceImages.Keys.ToArray(); // new string[m_sourceImages.Count()];
            Array.Sort(m_ranking, compareImages);
        }

        private int compareImages(string x, string y)
        {
            m_sortData.itemX = m_sourceImages[x];
            m_sortData.itemY = m_sourceImages[y];
            m_sortData.result = 0;

            m_pairAvailable.Release();
            m_sortAvailable.WaitOne();

            return m_sortData.result;
        }

        private void refreshImageList()
        {
            const int THUMBNAIL_SIZE = 128;

            listImages.Clear();

            listImages.View = View.LargeIcon;
            listImages.LargeImageList = new ImageList();
            listImages.LargeImageList.ImageSize = new Size(THUMBNAIL_SIZE, THUMBNAIL_SIZE);
            listImages.LargeImageList.ColorDepth = ColorDepth.Depth24Bit;

            foreach (var key in m_ranking)
            {
                var item = listImages.Items.Add(key);
                var bitmap = m_sourceImages[key];
                var thumbnail = new Bitmap(THUMBNAIL_SIZE, THUMBNAIL_SIZE);

                var dc = Graphics.FromImage(thumbnail);
                dc.FillRectangle(Brushes.Magenta, new Rectangle(0, 0, THUMBNAIL_SIZE, THUMBNAIL_SIZE));
                if (bitmap.Width > bitmap.Height)
                {
                    int newSize = bitmap.Height * THUMBNAIL_SIZE / bitmap.Width;
                    int newPos = (THUMBNAIL_SIZE - newSize) / 2;
                    dc.DrawImage(bitmap, 0, newPos, THUMBNAIL_SIZE, newSize);
                }
                else
                {
                    int newSize = bitmap.Width * THUMBNAIL_SIZE / bitmap.Height;
                    int newPos = (THUMBNAIL_SIZE - newSize) / 2;
                    dc.DrawImage(bitmap, newPos, 0, newSize, THUMBNAIL_SIZE);
                }
                dc.Dispose();

                //thumbnail.GetThumbnailImage.MakeTransparent()
                thumbnail.MakeTransparent(Color.Magenta);
                listImages.LargeImageList.Images.Add(key, thumbnail); //, Color.Magenta);
                item.ImageKey = key;
            }
        }

        Dictionary<string, Image> m_sourceImages = new Dictionary<string, Image>();
        string[] m_ranking = null;
        Semaphore m_pairAvailable = new Semaphore(0, 1);
        Semaphore m_sortAvailable = new Semaphore(0, 1);

        public class SortData
        {
            public Image itemX;
            public Image itemY;
            public int result;
        };

        SortData m_sortData = new SortData();

        private void loadRankingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> tentativeRanking = new List<string>();

            var dlg = new OpenFileDialog();
            dlg.Filter = "Text Files|*.txt";
            dlg.CheckFileExists = true;

            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            var rankingFile = File.OpenText(dlg.FileName);
            if (rankingFile == null)
                return;

            bool missingFiles = false;

            while (!rankingFile.EndOfStream)
            {
                string line = rankingFile.ReadLine();
                if (File.Exists(line))
                    tentativeRanking.Add(line);
                else
                    missingFiles = true;
            }

            rankingFile.Close();

            if (missingFiles)
                MessageBox.Show("Ranking contained files which did not exist and were removed.");

            bool rankingMatches = (tentativeRanking.Count() == m_sourceImages.Count());

            HashSet<string> extraImages = new HashSet<string>();

            foreach (var key in m_sourceImages.Keys)
                extraImages.Add(key);

            List<string> extraRankings = new List<string>();

            // check for filename mismatches
            foreach (var key in tentativeRanking)
            {
                if (m_sourceImages.Keys.Contains(key))
                    extraImages.Remove(key);
                else
                    extraRankings.Add(key);
            }

            if (extraRankings.Count > 0)
            {
                if (MessageBox.Show(this, "Files listed in the ranking were not loaded. Load them?", "Extra rankings", MessageBoxButtons.YesNo) == DialogResult.OK)
                {
                    foreach (var fileName in extraRankings)
                        m_sourceImages[fileName] = Image.FromFile(fileName);
                }
                else
                {
                    foreach (var fileName in extraRankings)
                        tentativeRanking.Remove(fileName);
                }
            }

            if (extraImages.Count > 0)
            {
                if (MessageBox.Show(this, "Files loaded were not ranked. Remove them?", "Extra images", MessageBoxButtons.YesNo) == DialogResult.OK)
                {
                    foreach (var key in extraImages)
                    {
                        m_sourceImages[key].Dispose();
                        m_sourceImages.Remove(key);
                    }
                }
                else
                {
                    foreach (var key in extraImages)
                        tentativeRanking.Add(key);
                }
            }

            m_ranking = tentativeRanking.ToArray();
            refreshImageList();
        }

        private void saveRankingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.Filter = "Text Files|*.txt";
            dlg.CheckPathExists = true;

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var rankingFile = File.OpenWrite(dlg.FileName);

            foreach (var key in m_ranking)
            {
                var data = Encoding.ASCII.GetBytes(key);
                rankingFile.Write(data, 0, data.Length);
                data = Encoding.ASCII.GetBytes("\r\n");
                rankingFile.Write(data, 0, data.Length);
            }

            rankingFile.Close();
        }
    }
}
