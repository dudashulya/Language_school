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
    /// Логика взаимодействия для UpcomingPage.xaml
    /// </summary>
    public partial class UpcomingPage : Page
    {
        public UpcomingPage()
        {
            InitializeComponent();
            var nextDate = DateTime.Today.AddDays(1);
     
            EntryList.ItemsSource = App.db.ClientService.ToList();
            //EntryList.ItemsSource = App.db.ClientService.Where(x => x.StartTime.ToString("dd.MM.yyyy")== DateTime.Now.ToString("dd.MM.yyyy")|| x.StartTime.ToString("dd.MM.yyyy")== nextDate.ToString("dd.MM.yyyy")).ToList();
        }
    }
}
