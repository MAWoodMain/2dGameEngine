using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow
{
    /// <summary>
    /// This class stores all the global varibles and constants which neeed to be accessed thoughout the program.
    /// </summary>
    class Globals
    {

        /// <summary>
        /// A test object which can be controlled by the user.
        /// </summary>
        public static PhysicsObject Object;
        /// <summary>
        /// The time delay between ticks.
        /// </summary>
        public const int tickGap = 20;
        /// <summary>
        /// A count of how many ticks have taken place.
        /// </summary>
        public static long Ticks;
        /// <summary>
        /// A constant that creates constant drag and decelleration
        /// </summary>s
        public const float DefaultResistance = 0.01f;

        public const float Gravity = 9.81f;

        public static String value = "";
    }
}
