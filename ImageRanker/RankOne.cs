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
        public RankOne(SortData sortData)
        {
            InitializeComponent();

            m_sortData = sortData;

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = m_sortData.m_left.m_image;

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = m_sortData.m_right.m_image;
        }

        SortData m_sortData = null;

        private void pickLeft()
        {
            ++m_sortData.m_left.m_hits;
            m_sortData.m_result = -1;
            Close();
        }

        private void pickRight()
        {
            ++m_sortData.m_right.m_hits;
            m_sortData.m_result = 1;
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pickLeft();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pickRight();
        }

        private void RankOne_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left: pickLeft(); break;
                case Keys.Right: pickRight(); break;
                case Keys.Escape: Close(); break;
            }
        }
    }
}
