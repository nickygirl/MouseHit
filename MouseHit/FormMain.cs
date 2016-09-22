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

        //add function start, stop and terminate
        Button m_startButton;
        Button m_stopButton;
        Button m_terminButton;
        bool m_isInGame;
        bool m_isStart;

        public FormMain()
        {
            InitializeComponent();

            showScore = new Label();
            showScore.Location = new Point(50, 150);

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


            m_startButton = new Button();
            m_stopButton = new Button();
            m_terminButton = new Button();

            m_startButton.Text = "Start";
            m_stopButton.Text = "Stop";
            m_terminButton.Text = "Terminate";

            m_startButton.Location = new Point(20, 170);
            m_stopButton.Location = new Point(100, 170);
            m_terminButton.Location = new Point(180, 170);

            m_isInGame = false;
            m_isStart = false;

            this.Controls.Add(mouse1);
            this.Controls.Add(mouse2);
            this.Controls.Add(mouse3);
            this.Controls.Add(mouse4);
            this.Controls.Add(showScore);
            this.Controls.Add(m_startButton);
            this.Controls.Add(m_stopButton);
            this.Controls.Add(m_terminButton);

            score = 0;
            showScore.Text = score.ToString();

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

            m_startButton.MouseClick += onStartBtn;
            m_stopButton.MouseClick += onStopBtn;
            m_terminButton.MouseClick += onTerminBtn;
            
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

        void onStartBtn(object sender, MouseEventArgs e)
        {
            if (!m_isStart)
            {
                timer.Start();
                m_startButton.Enabled = false;
                m_stopButton.Enabled = true;
                m_isInGame = true;
                m_isStart = true;
            }
           
        }

        void onStopBtn(object sender, MouseEventArgs e)
        {
            if (m_isInGame && m_isStart)
            {
                m_startButton.Enabled = true;
                m_stopButton.Enabled = false;
                timer.Stop();
                m_isStart = false;
            }
           
        }

        void onTerminBtn(object sender, MouseEventArgs e)
        {
            if (m_isInGame)
            {
                m_isInGame = false;
                m_isStart = false;
                m_startButton.Enabled = true;
                m_stopButton.Enabled = false;

                timer.Stop();
                score = 0;
                showScore.Text = score.ToString();
                mouseList[curMouseIndex].Visible = false;
            }
        }
    }
}
