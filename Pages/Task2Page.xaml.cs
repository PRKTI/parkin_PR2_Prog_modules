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
    public partial class Task2Page : Page
    {
        public Task2Page()
        {
            InitializeComponent();
        }
        private void BtnExecute_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInputString.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                txtResult.Text = "Ошибка: строка пуста.";
                return;
            }

            string result = Regex.Replace(input.Trim(), @"\s+", " ");

            txtResult.Text = $"Исходная строка: \"{input}\"\n" +
                             $"Результат: \"{result}\"";
        }

        // Обработчик кнопки возврата в меню
        private void BtnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }

}
