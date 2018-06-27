using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRanker
{
    public partial class RankOne : Form
    {
        public RankOne(Form1.SortData sortData)
        {
            InitializeComponent();

            m_sortData = sortData;

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = m_sortData.itemX;

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = m_sortData.itemY;
        }

        Form1.SortData m_sortData = null;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            m_sortData.result = -1;
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            m_sortData.result = 1;
            Close();
        }
    }
}
