using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Workflow
{
    /// <summary>
    /// This class defines the object 'vector' which is the trajectory x and y for an object.
    /// </summary>
    class Vector
    {
        private PointF Trajectory;

        /// <summary>
        /// This is the main constructor for the vector
        /// </summary>
        public Vector(float x, float y)
        {
            Trajectory = new PointF(x, y);
        }

        /// <summary>
        /// Setter for the vector.
        /// </summary>
        public void setVector(float x, float y)
        {
            Trajectory = new PointF(x, y);
        }

        /// <summary>
        /// Getter for the x value for the vector.
        /// </summary>
        public float getX() 
        {
            return Trajectory.X;
        }

        /// <summary>
        /// Getter for the y value for the vector.
        /// </summary>
        public float getY() //test
        {
            return Trajectory.Y;
        }
        public void applyGravity()
        {
            if (Trajectory.Y < 1)
            {
                Trajectory.Y++;
            }
            Trajectory.Y = Trajectory.Y + Math.Abs(Trajectory.Y * (Globals.Gravity / (1000 / Globals.tickGap)));
        }
        public void applyResistance(float resistance, int factor)
        {
            Trajectory.X *= (1 - resistance * factor);
            Trajectory.Y *= (1 - resistance * factor);
        }
        public void transform(float x, float y)
        {
            Trajectory.X *= x;
            Trajectory.Y *= y;
        }

        public void invert()
        {
            Trajectory = new PointF(getX() * -1, getY() * -1);
        }
    }
}
