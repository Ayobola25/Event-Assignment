using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Assignment
{
    namespace EventAssignment
    {
        /// <summary>
        /// This is the publisher class
        /// </summary>
        internal class AccessControl
        {
            public delegate void CoffeeteaSensorHandler();
            public event CoffeeteaSensorHandler Sensor;

            /// <summary>
            /// Detects if it has started working
            /// </summary>
            public void WorkDetected()
            {
                Console.WriteLine("Detecting Work");
                Thread.Sleep(2000);
                OnWorkDetected();
            }

            /// <summary>
            /// This method raises event on weather it has started working 
            /// </summary>
            public virtual void OnWorkDetected()
            {
                Sensor?.Invoke();
            }
        }

        /// <summary>
        /// Subscriber class that subscribes to 
        /// the AccessControl class
        /// </summary>
        public class CentralControl
        {

            public void GrantDet()
            {
                var access = new AccessControl();
                access.Sensor += OpenCoffeteasensor;
                access.WorkDetected();
            }
            public void OpenCoffeteasensor ()
            {
                Console.WriteLine("A staff is approaching to on the coffeetea sensor handler");
            }
        }
    }
}
