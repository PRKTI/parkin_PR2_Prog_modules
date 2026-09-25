using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace parkin_ru1.Pages
{
    
    public partial class Task1Page : Page
    {
        public Task1Page()
        {
            InitializeComponent();
        }
        private void TxtInputNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^\d+$");
        }
        private void BtnExecute_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInputNumber.Text.Trim();

            if (input.Length != 6)
            {
                txtResult.Text = "Ошибка: число должно содержать ровно 6 цифр.";
                return;
            }
            // счетчик суим цифр 
            int sumFirst = (input[0] - '0') + (input[1] - '0') + (input[2] - '0');
            int sumLast = (input[3] - '0') + (input[4] - '0') + (input[5] - '0');

            txtResult.Text = $"Число: {input}\n" +
                             $"Сумма первых 3 цифр: {sumFirst}\n" +
                             $"Сумма последних 3 цифр: {sumLast}\n" +
                             $"Результат: {(sumFirst == sumLast ? "РАВНЫ" : "НЕ РАВНЫ")}";
        }
        private void BtnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
