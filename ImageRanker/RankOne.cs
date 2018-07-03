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
        public enum Action
        {
            PickLeft,
            PickRight,
            PickBoth,
            ExcludeLeft,
            ExcludeRight,
            ExcludeBoth,
            Abort
        };

        public Image m_left = null;
        public Image m_right = null;
        public Action m_action;

        public RankOne()
        {
            InitializeComponent();

            radioPickLeft.CheckedChanged += radioButton_CheckedChanged;
            radioPickRight.CheckedChanged += radioButton_CheckedChanged;
            radioPickBoth.CheckedChanged += radioButton_CheckedChanged;
            radioExcludeLeft.CheckedChanged += radioButton_CheckedChanged;
            radioExcludeRight.CheckedChanged += radioButton_CheckedChanged;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            m_action = Action.PickLeft;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            m_action = Action.PickRight;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void RankOne_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK &&
                MessageBox.Show(this, "Abort the ranking process?", "Abort", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void RankOne_Shown(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = m_left;

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = m_right;
        }

        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radio = (RadioButton)sender;
            if (radio.Checked && radio.Tag != null)
                m_action = (Action) Enum.Parse(typeof(Action), radio.Tag.ToString());
        }
    }
}
