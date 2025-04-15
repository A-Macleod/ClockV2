using ClockV2.Model;
using ClockV2.Presenter;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockV2
{
    internal static class Program
    {

        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Clock - Create the Model, View and Presenter Clock
            var model = new ClockModel();
            var view = new ClockView();
            var presenter = new ClockPresenter(model, view);

            view.Show();

            Application.Run(view);

        }
    }
}
