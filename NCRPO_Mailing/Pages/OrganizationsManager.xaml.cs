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

namespace NCRPO_Mailing.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrganizationsManager.xaml
    /// </summary>
    public partial class OrganizationsManager : Page
    {
        public OrganizationsManager()
        {
            InitializeComponent();
        }

        private void btfilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btadd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Удалить выбранную организацию из базы данных?\n\nПодумайте еще раз, данные будут удалены навсегда\nP.S. А добавлять их заново придется вам, не мне.", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                
            }
        }

        private void OrganizationsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OrganizationsDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

        private void OrganizationsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
    }
}
