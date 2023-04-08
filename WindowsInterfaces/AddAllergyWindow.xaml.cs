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
    /// Логика взаимодействия для AddAllergyWindow.xaml
    /// </summary>
    public partial class AddAllergyWindow : Window
    {

        public string[] severtyTyping { get; set; }

        public Patient temp_patient { get; set; }

        
        public AddAllergyWindow(Patient patient)
        {
            InitializeComponent();
            temp_patient = patient;
            severtyTyping = new string[] { "Лёгкая", "Средняя", "Тяжелая" };
            DataContext = this;
        }

        private void Finish_Button_Click(object sender, RoutedEventArgs e)
        {
            using var addService = new AdditionalService(
                    new FeaturesRepository(
                        new MedicalCards.DAL.AppContext()
                        ),
                    new AllergyRepository(
                        new MedicalCards.DAL.AppContext()
                        )
                    );


            if (!AllergenTextBox.Text.IsNullOrEmpty() && !ReactionTextBox.Text.IsNullOrEmpty() && !SevertyComboBox.Text.IsNullOrEmpty())
            {
                Allergy allergy = new Allergy();
                allergy.Allergen = AllergenTextBox.Text;
                allergy.Reaction = ReactionTextBox.Text;
                allergy.Severity = SevertyComboBox.Text;
                allergy.PatientId = temp_patient.PatientId;
                addService.AddAllergyToPatient(allergy);
            }

            MessageBox.Show("Успешно");
            PatientWindow patientWindow = new PatientWindow(temp_patient);
            patientWindow.Show();
            this.Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow patientWindow = new PatientWindow(temp_patient);
            this.Hide();
            patientWindow.Show();
        }
    }
}
