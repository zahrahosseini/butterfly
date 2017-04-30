using System;
using System.Drawing;
using System.Windows.Forms;
using CsGL.OpenGL;
using Draw;
using System.Media;

namespace MyGame
{
	public class MainForm : System.Windows.Forms.Form
    {

        private System.ComponentModel.IContainer components;
        public Timer timer1;
        public draw drawobjectandmove;
        public Savemytime smt = new Savemytime();
		public MainForm()
		{
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(640, 480);
			this.Name = "MainForm";
			this.Text = "MyGame";
			this.drawobjectandmove = new draw();
			this.drawobjectandmove.Parent = this;
			this.drawobjectandmove.Dock = DockStyle.Fill;
			this.Show();


           

		}

		static void Main() 
		{
			MainForm form = new MainForm();
			while ((!form.drawobjectandmove.finished) && (!form.IsDisposed))
			{
				form.drawobjectandmove.glDraw();
				form.Refresh();
				Application.DoEvents();
			}
           
			form.Dispose();
		}

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(704, 443);
            this.Name = "MainForm";
            this.ResumeLayout(false);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            smt.lnumber++;
        drawobjectandmove.givetime();
        if (drawobjectandmove.ttime > 200)
        {
            drawobjectandmove.formno++;
         
            timer1.Enabled = false;
        }
        }

   
      


   
	}
	
	
}