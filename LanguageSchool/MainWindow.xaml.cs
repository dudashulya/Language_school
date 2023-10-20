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
using LanguageSchool.Components;

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
            Navigation.mainWindow = this;//создали переменную  но нечему не равна она формата майнвиндоу
                                         //var path = @"C:\Users\212112\Desktop\Task\Сессия 1\";
                                         //foreach (var item in App.db.Service.ToArray())
                                         //{
                                         //    var fullPath = path + item.MainImagePath;
                                         //    item.MainImage = File.ReadAllBytes(fullPath);
                                         //}
                                         //App.db.SaveChanges();  запись картинов в байтах в бд, делать перед преобразованием 
            Navigation.NextPage(new PageComponents("Авторизация", new Authorization()));

        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.BackPage();
           
        }

        private void ExsidBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.ClearHistory();
            Navigation.NextPage(new PageComponents("Авторизация", new Authorization()));
        }
    }
}
