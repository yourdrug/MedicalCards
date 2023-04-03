using MedicalCards.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AuthWindow
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    /// 

    public static class Data
    {
        public static List<Medicines> medicines = new List<Medicines>();
    }

    public partial class App : Application
    {
    }
}
