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
                EntryBtn.Visibility= Visibility.Hidden;
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
            if(DiscountFilterCb.SelectedIndex != 0)//выводим сортировку комбобокс
            {
                if (DiscountFilterCb.SelectedIndex == 1)
                {
                    serviceSortList = serviceSortList.Where(x => x.Discount == null || x.Discount < 5);
                }
                if (DiscountFilterCb.SelectedIndex == 2)
                {
                    serviceSortList= serviceSortList.Where(x => x.Discount >= 5 && x.Discount < 15);
                }
                if (DiscountFilterCb.SelectedIndex == 3)
                {
                        serviceSortList = serviceSortList.Where(x => x.Discount >= 15 && x.Discount < 30);
                }
                if (DiscountFilterCb.SelectedIndex == 4)
                {
                    serviceSortList= serviceSortList.Where(x => x.Discount >= 30 && x.Discount < 70);
                }
                if (DiscountFilterCb.SelectedIndex == 5)
                {
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 70 && x.Discount < 100);
                }
            }
            if(SerchTb.Text != null)
            {
                serviceSortList = serviceSortList.Where(x => x.Title.ToLower().Contains(SerchTb.Text.ToLower()) || x.Description.ToLower().Contains(SerchTb.Text.ToLower())); //поиск по слову
            }

                //всегда в конце так как сортировки могут наслаиваться 
            ServicesWp.Children.Clear();
            foreach (var service in serviceSortList)
            {
                ServicesWp.Children.Add(new ServaseUserControl1(service));
            }


            CountDataTb.Text = serviceSortList.Count() + "из" + App.db.Service.Count();// выводить сколько данных показывается из всех
        }

        private void ShortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         Refresh();
        }

        private void DiscountFilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          Refresh();  
        }

        private void SerchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponents ("Добавление Услуги",new AddEditservicePage(new Service())));
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponents("Ближайшие записи", new UpcomingPage()));
        }
    }
}
