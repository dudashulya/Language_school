﻿using LanguageSchool.Components;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LanguageSchool
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static langscholl321 db = new langscholl321 (); //соединение с базой
        public static bool isAdmin=false;
        
    }
    //убегай, возьми меня, я хочу туда где ты дышишь
    // это мокрая зима и сквозь дождь ты меня не слышишь
}   
