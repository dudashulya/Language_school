using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LanguageSchool.Components
{
    /// <summary>
    /// Логика взаимодействия для ServaseUserControl1.xaml
    /// </summary>
    public partial class ServaseUserControl1 : UserControl
    {
        public ServaseUserControl1(Service service)
        {
            InitializeComponent();

            if(App.isAdmin == false)
            {
                EditBTN.Visibility = Visibility.Hidden;
                DeleteBTN.Visibility = Visibility.Hidden;
            }

            TttleTB.Text = service.Title;
            CostTimeTB.Text = service.costTimeStr;
            DiscountTB.Text = service.DiscountStr;
            CostTb.Text = service.Cost.ToString("0");
            CostTb.Visibility = service.Visibility;
            MainBorder.Background = service.ColorServ;

        }
    }
}
