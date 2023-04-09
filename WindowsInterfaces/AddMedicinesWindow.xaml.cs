using AuthWindow;
using MedicalCards.BLL.Services;
using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories;
using Microsoft.IdentityModel.Tokens;
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
using System.Windows.Shapes;

namespace WindowsInterfaces
{
    /// <summary>
    /// Логика взаимодействия для AddMedicinesWindow.xaml
    /// </summary>
    public partial class AddMedicinesWindow : Window
    {
        private int selectedId { get; set; }
        public AddMedicinesWindow()
        {
            InitializeComponent();
        }

        private async void Show_Button_Click(object sender, RoutedEventArgs e)
        {
            using var POMS = new PrescriptionOfMedicinesService(
                    new PrescriptionOfMedicinesRepository(
                        new MedicalCards.DAL.AppContext()
                        ),
                    new AppointmentRepository(
                        new MedicalCards.DAL.AppContext()
                        ),
                    new MedicinesRepository(
                        new MedicalCards.DAL.AppContext()
                        )
                    );

            var temp = await POMS.GetAllMedicines();

            if(temp.Length == 0)
            {
                MessageBox.Show("Нет лекарств");
            }

            else
            {
                MedicinesGrid.ItemsSource = temp;
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void MedicinesGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            selectedId = ((Medicines)MedicinesGrid.SelectedItem).MedicinesId;
            var name = ((Medicines)MedicinesGrid.SelectedItem).Name;
            var comment = ((Medicines)MedicinesGrid.SelectedItem).Comment;
            var price = ((Medicines)MedicinesGrid.SelectedItem).Price;

            var temp = new Medicines();
            temp.MedicinesId = selectedId;
            temp.Name = name;
            temp.Comment = comment;
            temp.Price = price;

            Data.medicines.Add(temp);
            MessageBox.Show("Успешно добавлено лекарство " + name);

            this.Close();
            Owner.Show();
            
        }

    }
}
