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
    }
}
