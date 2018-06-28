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
        public enum Result
        {
            Left,
            Right,
            Equal,
            Abort
        };

        public Image m_left = null;
        public Image m_right = null;
        public Result m_result = Result.Abort;

        public RankOne()
        {
            InitializeComponent();
        }

        private void pickLeft()
        {
            m_result = Result.Left;
            Close();
        }

        private void pickRight()
        {
            m_result = Result.Right;
            Close();
        }

        private void pickBoth()
        {
            m_result = Result.Equal;
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
                case Keys.Enter: pickBoth(); break;
                case Keys.Escape: Close(); break;
            }

            e.Handled = true;
        }

        private void RankOne_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_result != Result.Abort)
                return;

            if (MessageBox.Show(this, "Abort the ranking process?", "Abort", MessageBoxButtons.YesNo) != DialogResult.Yes)
                e.Cancel = true;
        }

        private void RankOne_Shown(object sender, EventArgs e)
        {
            m_result = Result.Abort;

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = m_left;

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = m_right;
        }
    }
}
