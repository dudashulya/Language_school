using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Components
{ 
    public partial class ClientService
    {
        public string TimeStart
        {
            get
            {
                var time = StartTime - DateTime.Now;
                int hours =(int)time.TotalMinutes / 60;
                int minutes =(int)time.TotalMinutes % 60;   
                return $" {hours} : {minutes}  ";
            }
        }
        public TimeSpan MyTimeStart
        {
            get
            {

            }
        }
        public string ColorStr
        {   if()
            get
            {
                return "#FF000"
            }
        }
    }
}
