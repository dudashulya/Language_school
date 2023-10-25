using LanguageSchool.Components;
using Microsoft.Win32;
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
using Microsoft.Win32;
using System.IO;

namespace LanguageSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditservicePage.xaml
    /// </summary>
    public partial class AddEditservicePage : Page
    {
        private Service service;
        public AddEditservicePage(Service _service)
        {
            InitializeComponent();
            service = _service;
            this.DataContext = service;
        }

        private void ChangeImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jepg|*.jepg"
            };

           if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                service.MainImage = File.ReadAllBytes(openFileDialog.FileName);
                MainImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {   StringBuilder error = new StringBuilder();//создание строки ошибки 
           if(service.DurationInSeconds>14400|| service.DurationInSeconds<0)
           {
                error.AppendLine("Время услуги НЕ может превышать 4 часа!!!!!!!");
           } 
            if( service.ID ==0)
            {   if (App.db.Service.Any(x => x.Title == service.Title))
                {
                    error.AppendLine("Такая услуга УЖЕ существует!!!!!!!!!!!!");
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    App.db.Service.Add(service);
                }
            }
           if (error.Length>0)
           {
                MessageBox.Show(error.ToString());
                return;
           }
            App.db.SaveChanges(  );

            MessageBox.Show("Сохранено");
            Navigation.NextPage(new PageComponents("Список услуг", new ServaseListPages()));
            
         
        }

    

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, (0)))
            {
                e.Handled = true;
            }
        }
    }
}
