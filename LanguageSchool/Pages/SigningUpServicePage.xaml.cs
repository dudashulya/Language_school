using LanguageSchool.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для SigningUpServicePage.xaml
    /// </summary>
    public partial class SigningUpServicePage : Page
    {
        Service service;
        public SigningUpServicePage(Service _service)
        {
            InitializeComponent();
            service = _service;
            this.DataContext = service;
            ClientCb.ItemsSource = App.db.Client.ToList();
            ClientCb.DisplayMemberPath = "FullName";
            DateDp.DisplayDateStart = DateTime.Now;
        }
        private bool IsValidTime(string time)
        {
            //Regex formatTime = new Regex(@"\d:{2}\d:{2}") ;//задаем регулярное выражение 
            //if (formatTime.IsMatch(time))// проверяем регул выраж
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(IsValidTime(TimeTb.Text).ToString());
        }
    }
}
