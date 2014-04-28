using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Workflow
{
    class Utility
    {
        public static Point toPoint(PointF pointf)
        {
            return new Point((int)Math.Round(pointf.X, 0), (int)Math.Round(pointf.Y, 0));
        }

        public static int toInt(float Number)
        {
            return (int)Math.Round(Number, 0);
        }
        public static Boolean isOnTop(PhysicsObject top, PhysicsObject bottom)
        {
            if (top.getMiddle().Y > bottom.getMiddle().Y) return true;
            return false;
        }
    }
}
