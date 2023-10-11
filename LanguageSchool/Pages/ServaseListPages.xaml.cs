﻿using LanguageSchool.Components;
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
            }

            var serviceList = App.db.Service.ToList();
            foreach (var servase in serviceList)
            {
                ServicesWp.Children.Add(new ServaseUserControl1(servase));
            }
        }

    }
}
