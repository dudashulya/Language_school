using LanguageSchool.Components;
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

namespace LanguageSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServaseListPages.xaml
    /// </summary>
    public partial class ServaseListPages : Page
    {
        public ServaseListPages()
        {


            InitializeComponent();

            if(App.isAdmin == false)
            {
                AddBtn.Visibility = Visibility.Hidden;
            }

            Refresh();
        }
        private void Refresh()
        {
            IEnumerable<Service> serviceSortList = App.db.Service;
            if (ShortCB.SelectedIndex != 0) 
            {
                if (ShortCB.SelectedIndex == 1)
                {
                    serviceSortList = serviceSortList.OrderBy(x => x.CostDiscaunt);
                }
                else if (ShortCB.SelectedIndex == 2)
                {
                    serviceSortList = serviceSortList.OrderByDescending(x => x.CostDiscaunt);
                } 
            }
            ServicesWp.Children.Clear();
            foreach (var service in serviceSortList)
            {
                ServicesWp.Children.Add(new ServaseUserControl1(service));
            }
        }

        private void ShortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         Refresh();
        }
    }
}
