using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Логика взаимодействия для SendingMessages.xaml
    /// </summary>
    public partial class SendingMessages : Page
    {
        private List<Attachment> _attachments = new List<Attachment>();
        public SendingMessages()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrganizationsManager());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DepartmentsManager());
        }

        private void btnAboutApplication_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AboutApp());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            // Выход из приложения 
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnSearchEmail_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddRecipientEmail_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddingFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    Attachment attachment = new Attachment(filename);
                    _attachments.Add(attachment);
                    listAttachments.Items.Add(filename);
                }
            }
        }

        private void btnRemoveFile_Click(object sender, RoutedEventArgs e)
        {
            if (listAttachments.SelectedItem != null)
            {
                string selectedFile = listAttachments.SelectedItem.ToString();
                listAttachments.Items.Remove(selectedFile);

                var attachmentToRemove = _attachments.FirstOrDefault(a => a.Name == System.IO.Path.GetFileName(selectedFile));
                if (attachmentToRemove != null)
                {
                    _attachments.Remove(attachmentToRemove);
                }
            }

        }

        private void btnRemoveEmailRecipient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbEmailSender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbSignature_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnDelite_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Хотите отчистить поля для письма?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                cbEmailSender.Text = string.Empty;
                ltbEmailRecipient.Items.Clear();
                tbSubjectLetter.Text = string.Empty;
                rtbLetter.Document.Blocks.Clear();
                listAttachments.Items.Clear();

            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
