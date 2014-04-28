using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Workflow
{
    class Drawing
    {
        public static void drawRope(Pen thePen, Point From, Point To)
        {
            Engine.getGraphic().DrawLine(thePen, From, To);
        }
        public static void drawCircle(Pen thePen, Point midPoint, float Radius)
        {
            Engine.getGraphic().DrawEllipse(thePen, new Rectangle(Utility.toInt(midPoint.X - Radius), Utility.toInt(midPoint.Y - Radius), Utility.toInt(Radius * 2), Utility.toInt(Radius * 2)));
        }
    }
}
