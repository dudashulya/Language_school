using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LanguageSchool.Components
{
    public partial class Service
    {
        public string costTimeStr
        {
            get
            {
                if (Discount == null)
                    return $"{Cost} рублей за { DurationInSeconds / 60} минут";
                else 
                    return $"{Cost - (Cost *(decimal)Discount /100):0} рублей за {DurationInSeconds/60} минут";

            }
        }
        public Visibility Visibility
        {
            get
            {   if (Discount == 0)   
                    return Visibility.Collapsed;
                else 
                    return Visibility.Visible;
            }

        }

        public string DiscountStr
        {
            get
            {
                if (Discount == 0)
                    return " ";
                else
                    return $"* скидка {Discount}%";
            }
        }
        
    }
}
