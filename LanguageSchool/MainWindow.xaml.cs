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
using System.IO;
using LanguageSchool.Pages;

namespace LanguageSchool
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // var path = @"C:\Users\212112\Desktop\Task\Сессия 1\";
            //foreach(var item in App.db.Service.ToArray())
            //{
            //    var fullPath = path + item.MainImagePath;
            //    item.MainImage = File.ReadAllBytes(fullPath); 
            //}
            //App.db.SaveChanges();
            MainFrame.Navigate(new Authorization());
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
                
            {
                MainFrame.GoBack(); 
                MainFrame.RemoveBackEntry();
            }
           
        }

        private void ForwardBTN_Click(object sender, RoutedEventArgs e)
        {
            App.isAdmin = false;
            MainFrame.Navigate(new Authorization());
        }
    }
}
