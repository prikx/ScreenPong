using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenOverlay
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.myTimer = new System.Windows.Forms.Timer(this.components);
            this.PaddleRight = new System.Windows.Forms.Panel();
            this.PaddleLeft = new System.Windows.Forms.Panel();
            this.pBall = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // myTimer
            // 
            this.myTimer.Enabled = true;
            this.myTimer.Interval = 1;
            this.myTimer.Tick += new System.EventHandler(this.loop);
            // 
            // PaddleRight
            // 
            this.PaddleRight.BackColor = System.Drawing.Color.Black;
            this.PaddleRight.Location = new System.Drawing.Point(3746, 528);
            this.PaddleRight.Name = "PaddleRight";
            this.PaddleRight.Size = new System.Drawing.Size(64, 757);
            this.PaddleRight.TabIndex = 0;
            this.PaddleRight.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // PaddleLeft
            // 
            this.PaddleLeft.BackColor = System.Drawing.Color.Black;
            this.PaddleLeft.Location = new System.Drawing.Point(12, 528);
            this.PaddleLeft.Name = "PaddleLeft";
            this.PaddleLeft.Size = new System.Drawing.Size(64, 757);
            this.PaddleLeft.TabIndex = 1;
            this.PaddleLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pBall
            // 
            this.pBall.BackColor = System.Drawing.Color.Turquoise;
            this.pBall.Location = new System.Drawing.Point(1465, 880);
            this.pBall.Name = "pBall";
            this.pBall.Size = new System.Drawing.Size(55, 55);
            this.pBall.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(3822, 2113);
            this.Controls.Add(this.pBall);
            this.Controls.Add(this.PaddleLeft);
            this.Controls.Add(this.PaddleRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.LimeGreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        private void startup()
        {
            this.ball = new PongBall(pBall, pBall.Width, pBall.Height);

            List<Rectangle> objects = new List<Rectangle>();
            objects.Add(PaddleLeft.Bounds);
            objects.Add(PaddleRight.Bounds);

            this.coll = new CollisionManager(this.Bounds, objects);
        }
        #endregion

        private void loop(object sender, EventArgs e)
        {
            int y = Cursor.Position.Y;
            this.PaddleRight.Location = new System.Drawing.Point(this.PaddleRight.Location.X, y-(this.PaddleRight.Height/2));
            this.ball.moveTick();
            coll.wallCollisionCheck(this.ball);
            coll.objectCollisionCheck(this.ball);
            this.Refresh();
        }

        private Timer myTimer;
        private Panel PaddleRight;
        private Panel PaddleLeft;
        private Panel pBall;
        private PongBall ball;
        private CollisionManager coll;
    }
}

