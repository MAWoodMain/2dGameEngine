using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Workflow;

namespace SophieEngine
{
    public partial class Form1 : Form
    {
        Point down = new Point();
        public Form1()
        {
            InitializeComponent();
            Engine.Start(this);
            Engine.Properties(800, 800);
            Engine.Run();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //label1.Text = Globals.value;
            if (Globals.Object != null)
            {
                label1.Text = Globals.Object.isTouchingGround().ToString() + " " + Globals.Object.getVector().getY().ToString();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            down = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            int vx = Math.Max(down.X, e.X) - Math.Min(down.X, e.X);
            int vy = Math.Max(down.Y, e.Y) - Math.Min(down.Y, e.Y);
            if (e.X >= down.X) vx = Math.Abs(vx);
            if (e.X < down.X) vx = vx * -1;
            if (e.Y >= down.Y) vy = Math.Abs(vy);
            if (e.Y < down.Y) vy = vy * -1;
            PhysicsObject phys = new PhysicsObject("Princess", new PictureBox { Size = new Size(10, 10), Location = new Point(e.X, e.Y), BackColor = Color.Black }, new Vector(vx, vy), true);
            //Circle c = new Circle(new Point(400, 400), 150);
            Globals.Object = phys;
            Engine.Objects.addPhysicsObject(phys);
            //Engine.Objects.addCircle(c);
            //phys.AttachTo(c);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            InputControl.whilePressed(e.KeyCode);
        }
    }
}
