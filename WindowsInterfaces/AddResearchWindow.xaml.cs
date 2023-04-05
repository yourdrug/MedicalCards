using MedicalCards.BLL.Services;
using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories;
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
    /// Логика взаимодействия для AddResearchWindow.xaml
    /// </summary>
    public partial class AddResearchWindow : Window
    {
        private int selectedId { get; set; }
        private Doctor temp_doctor = new Doctor();
        public string[] typeResearch { get; set; }

        public AddResearchWindow(Doctor doctor)
        {
            InitializeComponent();
            temp_doctor = doctor;
            typeResearch = new string[] { "Лабораторное", "Инструментальное", "Диагностическое", "Другое" };
            DataContext = this;
        }

        private void PatientsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectedId = ((Patient)PatientsGrid.SelectedItem).PatientId;
            MessageBox.Show(selectedId.ToString());
            PatientTextBlock.Text = ((Patient)PatientsGrid.SelectedItem).LastName + " " + ((Patient)PatientsGrid.SelectedItem).FirstName;
        }

        private async void Show_Button_Click(object sender, RoutedEventArgs e)
        {
            using var patientService = new PatientService(
                       new PatientRepository(
                           new MedicalCards.DAL.AppContext()
                           ),
                       new AddressRepository(
                           new MedicalCards.DAL.AppContext()
                           )
                       );

            var patients_list = await patientService.GetAll();
            PatientsGrid.ItemsSource = (System.Collections.IEnumerable)patients_list;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            DoctorWindow doctorWindow = new DoctorWindow(temp_doctor);
            doctorWindow.Show();
            this.Close();
        }

        private async void Finish_Button_Click(object sender, RoutedEventArgs e)
        {
            using var researchService = new ResearchService(
                   new ResearchRepository(
                       new MedicalCards.DAL.AppContext()
                       )
                   );

            Research research = new Research();
            research.PatientId = selectedId;
            research.Name = ResearchNameTextBox.Text;
            research.ShortResult = ShortResultTextBox.Text;
            research.Result = ResultTextBox.Text;
            research.Comment = CommentTextBox.Text;
            research.DateOfResearch = (DateTime)DateOfResearch.SelectedDate;
            research.TypeOfResearch = TypeComboBox.Text;

            researchService.CreateNewResearch(research);
            MessageBox.Show("Успешно");

            DoctorWindow doctorWindow = new DoctorWindow(temp_doctor);
            doctorWindow.Show();
            this.Close();
        }
    }
}
