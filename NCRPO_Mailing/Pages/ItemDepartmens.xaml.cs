using System.Windows;
using System.Windows.Controls;

namespace NCRPO_Mailing.Pages
{
    /// <summary>
    /// Логика взаимодействия для ItemDepartmens.xaml
    /// </summary>
    public partial class ItemDepartmens : Page
    {
        public ItemDepartmens()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Удалить отдел из базы данных?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {

            }
        }
    }
}
