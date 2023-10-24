using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LanguageSchool.Components
{
    static class Navigation
    {
        private static List <PageComponents> components = new List <PageComponents> ();//хранит историю
        public static MainWindow mainWindow;  //находятся все элементы, получаем доступ к элементам


        public static void ClearHistory() //очистка
        {
            App.isAdmin = false;
            components.Clear ();
        }
        private static void Update(PageComponents pageComponents)//содержит всю логику добавляем в нее пейдж и вызываем апдате
        {
            mainWindow.TitleTB.Text = pageComponents.Title; //запиши татле
            mainWindow.BackBTN.Visibility=components.Count()>1? System.Windows.Visibility.Visible: System.Windows.Visibility.Hidden; //если в нашей истории больше одного элемента когда находимся на второй странице то показывай кнопку назад иначе нет
            mainWindow.ExsidBTN.Visibility = App.isAdmin ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
            mainWindow.MainFrame.Navigate(pageComponents.Page); //передаем передай падже

        }
        public static void NextPage(PageComponents pageComponents)
        {
            components.Add (pageComponents);
            Update(pageComponents);
        }
        public static void BackPage()
        {
            if (components.Count > 1)
            {
                components.RemoveAt(components.Count-1);
                Update(components[components.Count-1]);
            }
        }
    }
    class PageComponents // какой пейдж и его заголовок храние это и саму страницу
    {
        public string Title { get; set; }
        public Page Page { get; set; }

        public PageComponents(string title, Page page)
        { 
            
            Page = page;
            Title = title;
           
        }
        // это не я, это ктото за меня 
    }
}
