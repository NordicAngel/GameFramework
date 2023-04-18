using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Exceptions
{
    /// <summary>
    /// Usen when a singelton isn't implemented
    /// </summary>
    public class SingeltonNotInitilised : Exception
    {
        /// <summary>
        /// Usen when a singelton isn't implemented
        /// </summary>
        /// <param name="message">The exceptions message</param>
        public SingeltonNotInitilised(string? message) : base(message)
        {
        }
    }
}
