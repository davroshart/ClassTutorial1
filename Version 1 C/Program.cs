using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Version_1_C
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
            clsPainting.LoadPaintingForm = new clsPainting.LoadPaintingFormDelegate(frmPainting.Run);
            clsPhotograph.LoadPhotographForm = new clsPhotograph.LoadPhotograohFormDelegate(frmPhotograph.Run);
            clsSculpture.LoadSculptureForm = new clsSculpture.LoadSculptureFormDelegate(frmSculpture.Run);
            Application.Run(new frmMain());
        }
    }
}