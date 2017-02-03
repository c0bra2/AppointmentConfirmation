using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingScheduler
{
    class Schedule
    {
        public Driver customer;
        public string date;
        public string time;
        public string id;
        public int hoursTrained = 0;
        public string hours;
        public string tentative;
        public string type;

        public void  setHours(string h)
        {
            hoursTrained = Int32.Parse(h[0].ToString());
            hours = h;
        } 
    }
}
