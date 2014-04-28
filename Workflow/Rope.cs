using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Workflow
{
    class Rope
    {
        private Pen thePen;
        private Graphics Graphic;
        private Circle Circle;

        public Rope(Circle circle)
        {
            Circle = circle;
            Graphic = Engine.getWindow().CreateGraphics();
            thePen = new Pen(Color.Brown);
        }

        public void drawLine()
        {
            Graphic.DrawLine(thePen, Circle.getMidpoint(), Circle.getObject().getMiddle());
        }
    }
}
