using Microsoft.Win32;
using NCRPO_Mailing.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using static System.Net.Mime.MediaTypeNames;

namespace NCRPO_Mailing.Pages
{
    /// <summary>
    /// Логика взаимодействия для SendingMessages.xaml
    /// </summary>
    public partial class SendingMessages : Page
    {
        private List<Attachment> _attachments = new List<Attachment>(); //для прикрепления файлов
        private ObservableCollection<string> _mails = new ObservableCollection<string>();
        private List<string> _emailRecipient = new List<string>();

        // хост и порт можно узнать в интернете 
        private string _smtpHost, _login, _password;
        private int _smtpPort = 25;
        private SmtpClient _client;
        private string _emailSender, _subjectLetter, _letter;
        private FlowDocument _document;


        public SendingMessages(int departmentId)
        {
            InitializeComponent();
            using (var context = new ncrpoContext())
            {
                var emails = context.Emails.Where(em => em.DepartmentId == departmentId).Select(em => em.Email).ToList();
                cbEmailSender.ItemsSource = emails;
                var orgs = context.Organizations.ToList();

                cbINN.ItemsSource = orgs;
                cbEmail.ItemsSource = orgs;
                cbName.ItemsSource = orgs;    
                cbShortName.ItemsSource = orgs;

                var regions = context.Regions.Select(r => new { r.RegionId, r.Name }).ToList();

                cbRegion.DisplayMemberPath = "Name";
                cbRegion.SelectedValuePath = "RegionId";
                cbRegion.ItemsSource = regions;

                var type = context.Types.Select(t => new {t.TypeId, t.Name}).ToList();
                cbType.DisplayMemberPath= "Name";
                cbType.SelectedValuePath= "TypeId";
                cbType.ItemsSource = type;

                var departments = context.Departments.ToList();
                cbFromWhom.ItemsSource = departments;

                var signature = context.Signatures.Where(s => s.DepartmentId == departmentId).Select(s => s.Name).ToList();
                cbSignature.ItemsSource = signature;
                
            }
        }


     // Информация об организациях
        private void btnOrganizations_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrganizationsManager());
        }


    // Информация об отделах
        private void btnDepartmens_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DepartmentsManager());
        }
    
    // О приложении
        private void btnAboutApplication_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AboutApp());
        }

     // Выход из приложения 
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void btnSearchEmail_Click(object sender, RoutedEventArgs e)
        {
            string selectedINN = cbINN.Text.ToLower();
            string selectedEmail = cbEmail.Text.ToLower();
            int selectedRegionId = GetSelectedRegionId();
            string selectedName = cbName.Text.ToLower();
            string selectedShortName = cbShortName.Text.ToLower();
            int selectedType = GetSelectedTypeId();
            using (var context = new ncrpoContext())
            {
                // Фильтрация 
                var filteredEmails = context.Organizations.Where(record =>
                        (string.IsNullOrEmpty(selectedINN) || record.Inn.ToLower().Contains(selectedINN)) &&
                        (string.IsNullOrEmpty(selectedEmail) || record.Email.ToLower().Contains(selectedEmail)) &&
                        (selectedRegionId == 0 || record.RegionId == selectedRegionId) &&
                        (string.IsNullOrEmpty(selectedName) || record.Name.ToLower().Contains(selectedName)) &&
                        (string.IsNullOrEmpty(selectedShortName) || record.ShortName.ToLower().Contains(selectedShortName)) &&
                        (selectedType == 0 || record.TypeId == selectedType)
                    ).Select(record => record.Email).ToList();
                // Обновление ListView
                lvMails.ItemsSource = filteredEmails;
            }
        }

        private int GetSelectedRegionId()
        {
            if (cbRegion.SelectedItem != null)
            {
                return (int)cbRegion.SelectedValue;
            }
            return 0; 
        }

        private int GetSelectedTypeId()
        {
            if (cbType.SelectedItem != null)
            {
                return (int)cbType.SelectedValue;
            }
            return 0;
        }


    //добавление почт в список получателей
        private void btnAddRecipientEmail_Click(object sender, RoutedEventArgs e)
        {
            if (lvMails.SelectedItems != null)
            {
                foreach (var selectedItem in lvMails.SelectedItems)
                {
                    string selectedEmail = selectedItem.ToString();
                    if (!ltbEmailRecipient.Items.Contains(selectedEmail))
                    {
                        ltbEmailRecipient.Items.Add(selectedEmail);
                    }
                }
            }
        }

    //Добавление файлов
        private void AddingFile_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch
            {
                MessageBox.Show("Что-то пошло не так при загрузке файлов.\nПопробуйте еще раз или оставьте так");
            }


        }

    //Удаление файлов
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

    //Удаление почт из списка получателей
        private void btnRemoveEmailRecipient_Click(object sender, RoutedEventArgs e)
        {
            if (ltbEmailRecipient.SelectedItem != null)
            {
                ltbEmailRecipient.Items.Remove(ltbEmailRecipient.SelectedItem);
            }

        }

        private void btnAddEmailRecipient_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItem = new AddItem("AddEmail");
            addItem.Left = addItem.Width;
            addItem.Top = addItem.Height;
            addItem.Show();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItem = new AddItem("AddSignature");
            addItem.Left = addItem.Width;
            addItem.Top = addItem.Height;
            addItem.Show();
        }

        private void ckbSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            lvMails.SelectAll();
        }

        private void ckbSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            lvMails.UnselectAll();
        }

        private void btnRemoveAllEmailRecipient_Click(object sender, RoutedEventArgs e)
        {
           ltbEmailRecipient.Items.Clear();
           
        }

        private void btnRemoveAllFile_Click(object sender, RoutedEventArgs e)
        {
            listAttachments.Items.Clear();
        }

        private void cbEmailSender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbSignature_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var context = new ncrpoContext())
            {
                if (cbSignature.SelectedItem != null)
                {
                    string sTitle = cbSignature.SelectedItem.ToString();
                    var signaturText = context.Signatures.Where(s => s.Name == sTitle).Select(s => s.Text).FirstOrDefault();

                    rtbSignature.Document.Blocks.Clear();
                    rtbSignature.Document.Blocks.Add(new Paragraph(new Run(signaturText)));

                }
                
            }
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
                cbSignature.Text = string.Empty;
                rtbSignature.Document.Blocks.Clear();

            }
        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            _emailSender = cbEmailSender.Text;
            foreach (string i in ltbEmailRecipient.Items)
            {
                _emailRecipient.Add(i);
            }
            _subjectLetter = tbSubjectLetter.Text;
            _document = rtbLetter.Document;
            TextRange signatureText = new TextRange(rtbSignature.Document.ContentStart,rtbSignature.Document.ContentEnd);
            _letter = new TextRange(_document.ContentStart, _document.ContentEnd).Text + "\r\n" + signatureText.Text;
            string wromWhom = cbFromWhom.Text;


            try
            {
                if (_emailSender != null)
                {

                    using (var context = new ncrpoContext())
                    {
                        _login = _emailSender;
                        _password = context.Emails.Where(em => em.Email == _login).Select(em => em.Password).FirstOrDefault();

                    }
                    if (_emailSender.EndsWith("yandex.ru"))
                    {
                        _smtpHost = "smtp.yandex.ru";
                    }
                    else if (_emailSender.EndsWith("mail.ru"))
                    {
                        _smtpHost = "smtp.mail.ru";
                    }
                    else
                    {
                        MessageBox.Show("Такая почта не предусмотрена, но в будущем вы сможете добавить ее в список!");
                        return;
                    }
                }

                _client = new SmtpClient(_smtpHost, _smtpPort);
                _client.EnableSsl = true;
                _client.UseDefaultCredentials = false;
                _client.Credentials = new NetworkCredential(_login, _password);
                
                MailMessage message = new MailMessage
                {
                    From = new MailAddress(_emailSender, wromWhom),
                    Subject = _subjectLetter,
                    Body = _letter

                };

                foreach (var attachment in _attachments)
                {
                    message.Attachments.Add(attachment);
                }

                foreach (string el in _emailRecipient)
                {
                    message.To.Add(el);
                    await _client.SendMailAsync(message);
                    message.To.Clear();
                }

                MessageBox.Show("Сообщение отправлено!");
                _emailRecipient.Clear();
                _letter = string.Empty;
                _subjectLetter = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Что-то пошло не так\nПопробуйте еще раз!\n{ex.Message}");
            }
        }

    }

    
}
