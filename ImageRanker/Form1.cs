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
    public class SourceImage : IDisposable
    {
        public void Dispose()
        {
            m_image.Dispose();
        }

        public Image m_image = null;
        public int m_hits = 0;
    };

    public class SortData
    {
        public SourceImage m_left;
        public SourceImage m_right;
        public int m_result;
    };

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loadImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Title = "Add Images";
            dlg.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png";
            dlg.CheckFileExists = true;
            dlg.Multiselect = true;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                List<string> newRanking = null;

                foreach (var fileName in dlg.FileNames)
                {
                    if (!m_sourceImages.Keys.Contains(fileName))
                    {
                        if (newRanking == null)
                            newRanking = (m_ranking == null) ? new List<string>() : m_ranking.ToList();

                        newRanking.Add(fileName);
                    }

                    var newImage = new SourceImage();
                    newImage.m_image = Image.FromFile(fileName);
                    m_sourceImages[fileName] = newImage;
                }

                if (newRanking != null)
                    m_ranking = newRanking.ToArray();

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

        class ImagePair
        {
            public ImagePair(int left, int right)
            {
                m_left = left;
                m_right = right;
            }

            public int m_left;
            public int m_right;
        };

        public static IEnumerable<T> Shuffle<T>(IEnumerable<T> source, Random rng)
        {
            T[] elements = source.ToArray();
            // Note i > 0 to avoid final pointless iteration
            for (int i = elements.Length - 1; i > 0; --i)
            {
                // Swap element "i" with a random earlier element it (or itself)
                int swapIndex = rng.Next(i + 1);
                yield return elements[swapIndex];
                elements[swapIndex] = elements[i];
                // we don't actually perform the swap, we can forget about the
                // swapped element because we already returned it.
            }

            // there is one item remaining that was not returned - we return it now
            yield return elements[0];
        }

        private void rankImages()
        {
            Debug.Assert(m_sourceImages.Count() > 0);
#if false
            Array.Sort(m_ranking, compareImages);
#else
            List<ImagePair> tests = new List<ImagePair>();

            // make it so each image is on each side half the time
            bool alternate = false;

            for (int i = 0; i < m_ranking.Count(); ++i)
            {
                for (int j = i + 1; j < m_ranking.Count(); ++j)
                {
                    tests.Add(alternate ? new ImagePair(j, i) : new ImagePair(i, j));
                    alternate = !alternate;
                }
            }

            foreach (var imagePair in Shuffle(tests, new Random()))
                compareImages(m_ranking[imagePair.m_left], m_ranking[imagePair.m_right]);

            Array.Sort(m_ranking, sortImageHitsDesc);
#endif
        }

        private int sortImageHitsDesc(string x, string y)
        {
            return m_sourceImages[y].m_hits - m_sourceImages[x].m_hits;
        }

        private int compareImages(string x, string y)
        {
            if (x == y)
                return 0;

            m_sortData.m_left = m_sourceImages[x];
            m_sortData.m_right = m_sourceImages[y];
            m_sortData.m_result = 0;

            // trigger UI
            m_pairAvailable.Release();
            m_sortAvailable.WaitOne();

            return m_sortData.m_result;
        }

        private void refreshImageList()
        {
            const int THUMBNAIL_SIZE = 128;

            listImages.Clear();

            listImages.View = View.LargeIcon;
            listImages.LargeImageList = new ImageList();
            listImages.LargeImageList.ImageSize = new Size(THUMBNAIL_SIZE, THUMBNAIL_SIZE);
            listImages.LargeImageList.ColorDepth = ColorDepth.Depth24Bit;

            var enabled = m_sourceImages.Count > 0;
            saveRankingToolStripMenuItem.Enabled = enabled;
            imagesClearToolStripMenuItem.Enabled = enabled;
            rankImagesToolStripMenuItem.Enabled = enabled;

            if (m_ranking == null)
                return;

            foreach (var key in m_ranking)
            {
                var item = listImages.Items.Add(key);
                var bitmap = m_sourceImages[key].m_image;
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

        Dictionary<string, SourceImage> m_sourceImages = new Dictionary<string, SourceImage>();
        string[] m_ranking = null;
        Semaphore m_pairAvailable = new Semaphore(0, 1);
        Semaphore m_sortAvailable = new Semaphore(0, 1);

        SortData m_sortData = new SortData();

        private void loadRankingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> tentativeRanking = new List<string>();

            var dlg = new OpenFileDialog();
            dlg.Title = "Open Ranking";
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
                if (MessageBox.Show(this, "Files listed in the ranking were not loaded. Load them?", "Extra rankings", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (var fileName in extraRankings)
                    {
                        var newImage = new SourceImage();
                        newImage.m_image = Image.FromFile(fileName);
                        m_sourceImages[fileName] = newImage;
                    }
                }
                else
                {
                    foreach (var fileName in extraRankings)
                        tentativeRanking.Remove(fileName);
                }
            }

            if (extraImages.Count > 0)
            {
                if (MessageBox.Show(this, "Files loaded were not ranked. Remove them?", "Extra images", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            dlg.Title = "Save Ranking";
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Remove selected images?", "Remove", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<string> newRanking = m_ranking.ToList();

                foreach (ListViewItem item in listImages.SelectedItems)
                {
                    newRanking.Remove(item.Text);
                    m_sourceImages.Remove(item.Text);
                    listImages.Items.Remove(item);
                }

                m_ranking = newRanking.ToArray();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripMenuItem1.Enabled = listImages.SelectedItems.Count > 0;
        }

        private void imagesClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Clear all images?", "Clear", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                m_sourceImages.Clear();
                m_ranking = null;
                refreshImageList();
            }
        }
    }
}
