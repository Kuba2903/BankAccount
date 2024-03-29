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
using WindowApp.Data;
using WindowApp.DBModels;
using WindowApp.ViewModel;

namespace WindowApp.View
{
    /// <summary>
    /// Interaction logic for OpenAccountView.xaml
    /// </summary>
    public partial class OpenAccountView : Window
    {
        public OpenAccountView()
        {
            InitializeComponent();
            OpenAccountViewModel model = new OpenAccountViewModel();
            this.DataContext = model;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            DateTime? selectedDate = datePicker.SelectedDate;

            if (selectedDate.HasValue && selectedDate < new DateTime(1950, 1, 1))
            {
                datePicker.SelectedDate = new DateTime(1950, 1, 1);
            }
        }
    }
}
