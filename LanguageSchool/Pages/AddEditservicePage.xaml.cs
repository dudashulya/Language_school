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
