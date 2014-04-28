using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Workflow
{
    class Circle
    {
        private PointF MidPoint;
        private float Radius;

        public Circle(Point midPoint, int radius)
        {
            MidPoint = midPoint;
            Radius = radius;
        }
        public PointF getMidpoint()
        {
            return MidPoint;
        }
        public float getRadius()
        {
            return Radius;
        }

        public int getDistance(PointF Object, PointF MidPoint) //Should be in a math class
        {
            Double vx = Math.Max(Object.X, MidPoint.X) - Math.Min(Object.X, MidPoint.X);
            Double vY = Math.Max(Object.Y, MidPoint.Y) - Math.Min(Object.Y, MidPoint.Y);
            return (int)Math.Sqrt(Math.Pow(vx, 2) + Math.Pow(vY, 2));
        }

        public Boolean inInside(PhysicsObject Object)
        {
            if (getDistance(Object.getMiddle(), MidPoint) < Radius) return true;
            return false;
        }
        public Boolean inInside(PointF Object)
        {
            if (getDistance(Object, MidPoint) < Radius) return true;
            return false;
        }

        public Boolean goingOutside(PointF currentPoint, Vector currentVector)
        {
            if (inInside(currentPoint))
            {
                if (getDistance(new PointF(currentPoint.X + currentVector.getX(), currentPoint.Y + currentVector.getY()), MidPoint) >= Radius) return true;
            }
            return false;
        }
    }
}
