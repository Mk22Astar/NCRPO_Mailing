﻿using System;
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

namespace NCRPO_Mailing
{
    /// <summary>
    /// Логика взаимодействия для AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        public AddItem(string page)
        {
            InitializeComponent();
            switch (page)
            {
                case "AddEmail":
                    FrmAddItem.Navigate(new NewEmail());
                    break;
                case "AddSignature":
                    FrmAddItem.Navigate(new NewSignature());
                    break;
                default:
                    break;
            }
        }
    }
}
