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
using System.Windows.Threading;

namespace LanguageSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для UpcomingPage.xaml
    /// </summary>
    public partial class UpcomingPage : Page
    {
        DateTime endDate = DateTime.Now.AddDays(2);
        DispatcherTimer timer = new DispatcherTimer();
        public UpcomingPage()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(Update);
            timer.Interval = new TimeSpan(0, 0, 30);
            timer.Start();
            //var endtDate = DateTime.Today.AddDays(2);
            EntryList.ItemsSource = App.db.ClientService.Where(x => x.StartTime >= DateTime.Today && x.StartTime >= DateTime.Now && x.StartTime < endDate).
                OrderBy(x => x.StartTime).ToList();
            //EntryList.ItemsSource = App.db.ClientService.Where(x => x.StartTime.ToString("dd.MM.yyyy")== DateTime.Now.ToString("dd.MM.yyyy")|| x.StartTime.ToString("dd.MM.yyyy")== nextDate.ToString("dd.MM.yyyy")).ToList();
        }
        private void Update(object sender, EventArgs e)
        {
            EntryList.ItemsSource = App.db.ClientService.Where(x => x.StartTime >= DateTime.Today && x.StartTime >= DateTime.Now && x.StartTime < endDate).
                           OrderBy(x => x.StartTime).ToList();
        }
    }
}
