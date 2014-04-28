using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Workflow
{
    /// <summary>
    /// The main class housing the primary form.
    /// </summary>
    class Engine
    {
        private static Form Window;
        private static List<PhysicsObject> PhysicsObjects;
        private static List<Circle> Circles;
        private static Graphics Graphic;

        private static void INIT()
        {
            PhysicsObjects = new List<PhysicsObject>();
            Circles = new List<Circle>();
        }

        public static void Start(Form window)
        {
            INIT();
            Window = window;
        }

        public static void Properties(int SizeX, int SizeY)
        {
            Window.Size = new Size(SizeX, SizeY);
            Window.FormBorderStyle = FormBorderStyle.None;
            Graphic = Window.CreateGraphics();
        }

        public static Form getWindow()
        {
            return Window;
        }

        public static partial class Objects
        {
            public static List<PhysicsObject> getPhysicsObjects()
            {
                return PhysicsObjects;
            }
            public static void addPhysicsObject(PhysicsObject Object)
            {
                Window.Controls.Add(Object.getBox());
                PhysicsObjects.Add(Object);
            }
            public static void removePhysicsObject(PhysicsObject Object)
            {
                PhysicsObjects.Remove(Object);
            }

            public static List<Circle> getCircles()
            {
                return Circles;
            }
            public static void addCircle(Circle Object)
            {
                Circles.Add(Object);
            }
            public static void removeCircle(Circle Object)
            {
                Circles.Remove(Object);
            }
        }

        /// <summary>
        /// A subroutine that starts the tick thread.
        /// </summary>
        public static void Run()
        {
            Thread ticks = new Thread(new ThreadStart(doTick));
            ticks.Start();
            Globals.Ticks = 0;
        }

        /// <summary>
        /// Getter for the graphic plane.
        /// </summary>
        public static Graphics getGraphic()
        {
            return Graphic;
        }

        /// <summary>
        /// The tick subroutine that will be ran by the thread.
        /// </summary>
        public static void doTick()
        {
            while (true)
            {
                try
                {
                    Globals.value = Globals.Ticks + " / " + Globals.tickGap + " = " + (Globals.Ticks / Globals.tickGap).ToString() + " | " + (PhysicsObjects.Count / 2);
                    Graphic.Clear(Color.White); // Clears the screen.
                    foreach (Circle circle in Objects.getCircles())
                    {
                        Drawing.drawCircle(new Pen(Color.Blue), Utility.toPoint(circle.getMidpoint()), Utility.toInt(circle.getRadius()));
                    }
                    foreach (PhysicsObject po in PhysicsObjects) // Goes though each stored object
                    {
                        po.doTick(); // Ticks each object.
                    }
                }
                catch { } // Catches exceptions
                Globals.Ticks += 1; // Adds one to the tick count
                Thread.Sleep(Globals.tickGap); // Waits the tickgap amount of time before repeating.
            }
        }
    }
}
