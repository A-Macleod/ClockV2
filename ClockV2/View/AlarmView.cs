using ClockV2.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockV2
{
    public partial class AlarmView : Form, IView
    {

        private AlarmPresenter presenter;


        public AlarmView()
        {
            InitializeComponent();
        }


        public void SetPresenter(AlarmPresenter presenter)
        {
            this.presenter = presenter;
        }

        public void Add()
        {

        }




    }
}
