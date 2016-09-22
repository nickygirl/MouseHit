using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseHit
{
    public partial class FormMain : Form
    {
        List<PictureBox> mouseList;
        int curMouseIndex;
        int score;
        Timer timer;
        Random ran;
        Label showScore;

        public FormMain()
        {
            InitializeComponent();

            showScore = new Label();
            showScore.Location = new Point(50, 120);

            PictureBox mouse1 = new PictureBox();
            PictureBox mouse2 = new PictureBox();
            PictureBox mouse3 = new PictureBox();
            PictureBox mouse4 = new PictureBox();

            mouse1.Location = new Point(50, 50);
            mouse2.Location = new Point(50, 100);
            mouse3.Location = new Point(100, 50);
            mouse4.Location = new Point(100, 100);
            mouse1.BackColor = Color.Blue;
            mouse2.BackColor = Color.Yellow;
            mouse3.BackColor = Color.Red;
            mouse4.BackColor = Color.Green;

            this.Controls.Add(mouse1);
            this.Controls.Add(mouse2);
            this.Controls.Add(mouse3);
            this.Controls.Add(mouse4);
            this.Controls.Add(showScore);
         
            score = 0;

            mouseList = new List<PictureBox>();
            foreach (Control item in this.Controls)
            {
                if (item is PictureBox)
                {
                    mouseList.Add(item as PictureBox);
                    item.MouseDoubleClick += item_MouseDoubleClick;
                    item.Visible = false;
                }
            }

            ran = new Random();
            curMouseIndex = ran.Next(0, mouseList.Capacity);

            timer = new Timer();
            timer.Interval = 1500;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void item_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            score++;
            showScore.Text = score.ToString();
            //set invisible
            mouseList[curMouseIndex].Visible = false;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            mouseList[curMouseIndex].Visible = false;
            curMouseIndex = ran.Next(0, mouseList.Capacity);
            mouseList[curMouseIndex].Visible = true;
        }
    }
}
