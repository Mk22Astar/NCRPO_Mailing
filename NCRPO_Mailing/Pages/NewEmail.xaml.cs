using System.Windows;
using System.Windows.Controls;

namespace NCRPO_Mailing
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class NewEmail : Page
    {
        public NewEmail()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Данные не сохранятся, вы уверены?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                
            }

        }
    }
}
