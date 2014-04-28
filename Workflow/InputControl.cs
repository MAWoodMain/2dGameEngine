using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workflow
{
    /// <summary>
    /// This class accepts the key press events and acts acordingly.
    /// </summary>
    class InputControl
    {
        /// <summary>
        /// This method catches the key presses events and acts acordingly
        /// </summary>
        public static void whilePressed(Keys key)
        {
            switch (key)
            {
                case Keys.A:
                    Globals.Object.getVector().setVector(Globals.Object.getVector().getX() - 30, Globals.Object.getVector().getY() - 3);
                    break;
                case Keys.D:
                    Globals.Object.getVector().setVector(Globals.Object.getVector().getX() + 30, Globals.Object.getVector().getY() - 3);
                    break;
                case Keys.W:
                    Globals.Object.getVector().setVector(Globals.Object.getVector().getX(), Globals.Object.getVector().getY() - 30);
                    break;
            }
        }
    }
}
