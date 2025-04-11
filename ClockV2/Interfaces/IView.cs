using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockV2
{
    interface IView
    {

        void ShowView();
        event FormClosedEventHandler FormClosed;












    }
}
