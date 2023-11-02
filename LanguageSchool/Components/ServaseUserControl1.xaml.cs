using LanguageSchool.Pages;
using System;
using System.Collections.Generic;
using System.IO;
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
        public Service service;
        public ServaseUserControl1(Service _service)
        {
            
            InitializeComponent();
            service = _service;
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
            ImageIMG.Source = GetImageSources(service.MainImage);//подключение картинок и их преобразование(превращение картинок из байтов в пнг )

        }
        private BitmapImage GetImageSources(byte[] byteImage) 
            //превращение картинок из байтов в пнг 
        {if( service .MainImage != null )
            { 
                MemoryStream byteStream = new MemoryStream(byteImage);// мемори стрим с потоками байтов, считывать байты и выполнять с ними работу 
                BitmapImage image = new BitmapImage();// отображает картинку в верстке битмапимаге
                image.BeginInit();
                image.StreamSource = byteStream;
                image.EndInit();
                return image;

            }
        return new BitmapImage(new Uri (@"\Resources\school_logo.png", UriKind.Relative));
           
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponents("Редактирование", new AddEditservicePage(service)));
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            if (service.ClientService.Count !=0)
            { MessageBox.Show("Удаление запрещено!");}
            else 
                {
               App.db.Service.Remove(service);
               App.db.SaveChanges();
                MessageBox.Show("Запись удалена:  "+service.Title);
                Navigation.NextPage(new PageComponents("список услуг", new ServaseListPages()));
            } 
        }

        private void SignBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponents("запись на услугу", new SigningUpServicePage(service)));
        }
    }
}
