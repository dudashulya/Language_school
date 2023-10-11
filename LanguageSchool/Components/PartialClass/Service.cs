using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace LanguageSchool.Components
{
    public partial class Service
    {
        public decimal CostDiscaunt
        {
            get
            {
                if (Discount == null)
                    return Cost;
                else
                    return Cost - (Cost * (decimal)Discount / 100);
            }
        }
        public string costTimeStr
        {
            get
            {
                if (Discount == null)
                    return $"{Cost:0} рублей за {DurationInSeconds / 60} минут";
                else
                    return $" {CostDiscaunt:0} рублей за {DurationInSeconds / 60} минут";

            }
        }
        public Visibility Visibility
        {
            get
            {
                if (Discount == null)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }

        }

        public string DiscountStr
        {
            get
            {
                if (Discount == null)
                    return null;
                else
                    return $"* скидка {Discount}%";
            }
        }
        public System.Windows.Media.Brush ColorServ
        {
            get
            {
                if (Discount == null)
                    return new SolidColorBrush(Colors.White);
                else
                    return new SolidColorBrush(Colors.LightGreen);

            }
        }

    }
}
