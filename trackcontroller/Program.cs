/// what i need to send:
/// to office
///     track state
///     state ofrailway crossings
///     state of signals
///     state of trains
/// to track model
/// 
/// 
/// what i need to get
/// from office
///     authority
///     speed limit
/// from track model
/// 




using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackController
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TrackControllerForm());
        }
    }
}
