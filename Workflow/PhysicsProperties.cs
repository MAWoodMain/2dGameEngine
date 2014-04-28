using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Workflow
{           
    class PhysicsProperties
    {
        private PhysicsObject Object;
        private int Mass;
        private int Gravity;
        private Boolean PhysicsEnabled;
        private Boolean CollisionEnabled;
        private Circle AttachedToCircle;

        public PhysicsProperties(PhysicsObject obj, int mass, int gravity, Boolean physicsenabled, Boolean collisionenabled, Circle circle)
        {
            Object = obj;
            Mass = mass;
            Gravity = gravity;
            PhysicsEnabled = physicsenabled;
            CollisionEnabled = collisionenabled;
            AttachedToCircle = circle;
        }

        public int toZero(int Vel, int am)
        {
            if (Vel > 0)
            {
                if (Vel - am < 0) return 0;
                return Vel - am;
            }
            if (Vel < 0)
            {
                if (Vel - am < 0) return 0;
                return Vel - am;
            }
            return 0;
        }

        /// <summary>
        /// Getter for the mass used in this property.
        /// </summary>
        public int getMass()
        {
            return Mass;
        }

        /// <summary>
        /// Getter for the active status of the physics for this object.
        /// </summary>
        public Boolean isPhysicsEnabled()
        {
            return PhysicsEnabled;
        }

        public Circle getAttachedTo()
        {
            return AttachedToCircle;
        }
        public void AttachTo(Circle circle)
        {
            AttachedToCircle = circle;
        }

        /// <summary>
        /// Method for unknown purpose.
        /// </summary>
        public void possibleVector()
        {
            if (Object.getVector().getX() > Gravity) Object.getVector().setVector(Gravity, Object.getVector().getY());
            if (Object.getVector().getX() < Gravity * -1) Object.getVector().setVector(Gravity * -1, Object.getVector().getY());
            if (Object.getVector().getY() > Gravity) Object.getVector().setVector(Object.getVector().getX(), Gravity);
            if (Object.getVector().getY() < Gravity * -1) Object.getVector().setVector(Object.getVector().getX(), Gravity * -1);
        }

        public Boolean isSatOnObject()
        {
            if (CollisionEnabled)
            {
                foreach (PhysicsObject po in Engine.Objects.getPhysicsObjects()) // goes though each other shape on the screen.
                {
                    if (Object != po) // if the object is not its self.
                    {
                        if (Object.getBox().Bounds.IntersectsWith(po.getBox().Bounds)) // if the other object is touching this object.
                        {

                            //Object.getVector().transform(-1, -1);
                            //Object.getVector().applyResistance(Globals.DefaultResistance, 20);
                            if (Utility.isOnTop(Object, po))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public Boolean willBeSatOnObject()
        {
            PhysicsObject futureObject = Object;
            futureObject.getBox().Location = Utility.toPoint(new PointF(futureObject.getBox().Location.X + futureObject.getVector().getX(), futureObject.getBox().Location.Y + futureObject.getVector().getY()));
            if (CollisionEnabled)
            {
                foreach (PhysicsObject po in Engine.Objects.getPhysicsObjects()) // goes though each other shape on the screen.
                {
                    if (Object != po) // if the object is not its self.
                    {
                        if (futureObject.getBox().Bounds.IntersectsWith(po.getBox().Bounds)) // if the other object is touching this object.
                        {

                            //Object.getVector().transform(-1, -1);
                            //Object.getVector().applyResistance(Globals.DefaultResistance, 20);
                            if (Utility.isOnTop(futureObject, po))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public void collisionUpdate() // Checks for collision and acts appropriately.
        {
            if (CollisionEnabled)
            {
                foreach (PhysicsObject po in Engine.Objects.getPhysicsObjects()) // goes though each other shape on the screen.
                {
                    if (Object != po) // if the object is not its self.
                    {
                        if (Object.getBox().Bounds.IntersectsWith(po.getBox().Bounds)) // if the other object is touching this object.
                        {
                            /*
                            //Object.getVector().transform(-1, -1);
                            //Object.getVector().applyResistance(Globals.DefaultResistance, 20);
                            if (Utility.isOnTop(Object, po)) {
                                if (Object.getVector().getY() < 5)
                                {
                                    Object.getVector().transform(1, 0);
                                   // PhysicsEnabled = false;
                                }
                                else { 
                                Object.getVector().transform(-1, -1);
                                po.getVector().transform(-1, -1);
                                }
                            }

                            */









                            if (Object.getVector().getY() > 1) // if there is vertical.
                            {
                                if (Object.getMiddle().Y > po.getMiddle().Y) Object.getVector().setVector(Object.getVector().getX(), Math.Abs(Object.getVector().getY())); //Move down.
                                if (Object.getMiddle().Y <= po.getMiddle().Y) Object.getVector().setVector(Object.getVector().getX(), -Math.Abs(Object.getVector().getY())); //Move up.
                                Object.getVector().applyResistance(Globals.DefaultResistance, 20);
                            }
                            if (po.getVector().getX() > 1) // if there is horizontal velocity.
                            {
                                if (Object.getMiddle().X >= po.getMiddle().X) Object.getVector().setVector(Math.Abs(Object.getVector().getX() + Mass), Object.getVector().getY()); //Move right.
                                if (Object.getMiddle().X < po.getMiddle().X) Object.getVector().setVector(Math.Abs(Object.getVector().getX() + Mass) * -1, Object.getVector().getY()); //Move left.
                                Object.getVector().applyResistance(Globals.DefaultResistance, 20);
                            }
                            if (Math.Abs(Object.getVector().getY()) < 1.5)
                            {
                                Object.getVector().transform(0, 0);
                            }
                        }
                    }
                }
            }
        }
    }
}
