using PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockV2
{
    /// <summary>
    /// 
    /// </summary>
    public class AlarmModel
    {

        //PriorityQueue<Alarm> alarms;
        //alarms = new SortedArrayPriorityQueue<Alarm>(8);
        //public SortedArrayPriorityQueue<Alarm> _alarms ;
        //private SortedArrayPriorityQueue<Alarm> _alarms = new SortedArrayPriorityQueue<Alarm>(8);

        private PriorityQueue<Alarm> alarms;




        /// <summary>
        /// 
        /// </summary>
        public AlarmModel()
        {
            alarms = new SortedArrayPriorityQueue<Alarm>(8);
        
        }


        public void Add()
        {
            
        }


            
    }
}
