using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Workflow
{

    /// <summary>
    /// This is a physics object that has a size, image and velocity vector.
    /// </summary>
    class PhysicsObject
    {
        private PictureBox Box;
        private String Name;
        private Vector Vector;
        private PhysicsProperties Properties;

        //new PhysicsObject("Dave", new PictureBox{VALUES}, new Vector(0, 0), false)

        /// <summary>
        /// This is the main constuctor for physics objects.
        /// </summary>
        public PhysicsObject(String name, PictureBox box, Vector vector, Boolean physics)
        {
            Name = name;
            Box = box;
            Vector = vector;
            Properties = new PhysicsProperties(this, 3, 15, physics, true, null);
            Engine.Objects.addPhysicsObject(this);
        }


        public String getName()
        {
            return Name;
        }
        public Vector getVector()
        {
            return Vector;
        }
        public PictureBox getBox()
        {
            return Box;
        }
        public Point getMiddle()
        {
            return new Point(Box.Location.X + (Box.Width / 2), Box.Location.Y + (Box.Height / 2));
        }
        public void setProperties(PhysicsProperties props)
        {
            Properties = props;
        }
        public void AttachTo(Circle circle)
        {
            Properties.AttachTo(circle);
        }
        public void Dispose()
        {
            Box.Dispose();
            Engine.Objects.removePhysicsObject(this);
        }

        public Boolean isTouchingGround()
        {
            if (Box.Location.Y >= (Engine.getWindow().Size.Height - 1) - Box.Size.Height) return true;
            if (Properties.isSatOnObject()) return true;
           // if (Properties.willBeSatOnObject()) return true;
            return false;
        }
        public Boolean willTouchFloor(int noTurns)
        {
            if (Box.Location.Y + Vector.getY() * noTurns > (Engine.getWindow().Size.Height - 1) - Box.Size.Height) return true;
            return false;
        }
        public Boolean willTouchWall()
        {
            if (Box.Location.X + Vector.getX() > (Engine.getWindow().Size.Width - 1) - Box.Size.Width) return true;
            if (Box.Location.X > Engine.getWindow().Size.Width - 1) return true;
            if (Box.Location.X + Vector.getX() < 1 + Box.Size.Width) return true;
            if (Box.Location.X < 1) return true;
            return false;
        }
        public void teleportTo(Point Location)
        {
            Box.Location = Location;
        }

        public void doTick()
        {
            Engine.getWindow().Invoke((MethodInvoker)delegate
            {
                if (Properties.isPhysicsEnabled())
                {
                    //Vector.setVector(Vector.getX() - GlobalsW.DefaultResistance, Vector.getY() - Globals.DefaultResistance);
                    if (!isTouchingGround() && !(willTouchFloor(1) || willTouchFloor(2)))
                    {
                        //Vector.setVector(Vector.getX(), Vector.getY() + 1);
                        Vector.applyGravity();
                    }
                    else
                    {
                        //if (willTouchGround()) Vector.setVector(Properties.toZero(Vector.getX(), 1), (Vector.getY() * -1) + 1);
                        if (willTouchFloor(1))
                        {
                            //bouncing
                            if (Math.Abs(Vector.getY()) > 5) {
                                Vector.transform(1, -1);
                                Vector.applyResistance(Globals.DefaultResistance, 20);
                            } else {
                                Vector.transform(1, 0);
                                Box.Location = new Point(Box.Location.X, (Engine.getWindow().Size.Height - 1) - Box.Size.Height);
                            }
                        

                    }

                    }
                    if (!isTouchingGround()) {
                        Vector.applyResistance(Globals.DefaultResistance, 1);
                    }else{
                        Vector.applyResistance(Globals.DefaultResistance, 20);
                    }

                   /* switch (willTouchWall())
                    {
                        case Wall.Right:
                            Vector.applyResistance(Globals.DefaultResistance, 20);
                            Vector.transform(-1, 1);
                            //Vector.setVector((Vector.getX() * -1 * (1 - Globals.DefaultResistance * 20)), Vector.getY()*(1 - Globals.DefaultResistance * 20));
                            break;
                        case Wall.Left:
                            Vector.setVector(Math.Abs(Vector.getX()) + Properties.getMass(), Vector.getY());
                            break;
                    }*/
                    if (willTouchWall())
                    {
                        Vector.applyResistance(Globals.DefaultResistance, 20);
                        Vector.transform(-1, 1);
                    }

                    if (Properties.getAttachedTo() != null)
                    {
                       // Drawing.drawRope(new Pen(Color.Brown, 1), Utility.toPoint(getMiddle()), Utility.toPoint(Properties.getAttachedTo().getMidpoint()));
                        if (Properties.getAttachedTo().inInside(this))
                        {
                            if (Properties.getAttachedTo().goingOutside(getMiddle(), Vector))
                            {
                                Vector.invert();
                            }
                        }
                        else
                        {
                            //Outside jump back in code
                          /*  if (getMiddle().X < Properties.getAttachedTo().getMidpoint().X) Vector.setVector(Properties.getAttachedTo().getDistance(getMiddle(), Properties.getAttachedTo().getMidpoint()) * 2, Vector.getY());
                            if (getMiddle().X > Properties.getAttachedTo().getMidpoint().X) Vector.setVector((Properties.getAttachedTo().getDistance(getMiddle(), Properties.getAttachedTo().getMidpoint()) * 2) * -1, Vector.getY());
                            if (getMiddle().Y > Properties.getAttachedTo().getMidpoint().Y) Vector.setVector(Vector.getX(), (Properties.getAttachedTo().getDistance(getMiddle(), Properties.getAttachedTo().getMidpoint()) * 2) * -1);
                            if (getMiddle().Y < Properties.getAttachedTo().getMidpoint().Y) Vector.setVector(Vector.getX(), Properties.getAttachedTo().getDistance(getMiddle(), Properties.getAttachedTo().getMidpoint()) * 2);
                       */ }
                    }

                    Properties.collisionUpdate();
                    //Properties.possibleVector();
                    if (Properties.isPhysicsEnabled())
                    {
                        if (!willTouchFloor(1)) Box.Location = Utility.toPoint(new PointF(Box.Location.X + Vector.getX(), Box.Location.Y + Vector.getY()));
                    }
                    }
                else
                {
                    //Implement an overhead system for games that don't want to use physics
                    Box.Location = Utility.toPoint(new PointF(Box.Location.X + Vector.getX(), Box.Location.Y + Vector.getY()));
                    Vector.setVector(0, 0); //CHANGE THIS FOR BETTER OVERHEAD MOVEMENT SYSTEM
                }
            });
        }
    }
}
