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

namespace parkin_ru1.Pages
{
    public partial class Task3Page : Page
    {
        public Task3Page()
        {
            InitializeComponent();
        }
        private void BtnExecute_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInputArray.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                txtResult.Text = "Ошибка: массив пуст.";
                return;
            }

            int[] array;
            try
            {
                array = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse).ToArray();
            }
            catch
            {
                txtResult.Text = "Ошибка: введите корректные целые числа через пробел.";
                return;
            }

            List<int> seriesLengths = new List<int>();
            int currentLength = 1;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i - 1])
                    currentLength++;
                else
                {
                    seriesLengths.Add(currentLength);
                    currentLength = 1;
                }
            }
            seriesLengths.Add(currentLength);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Исходный массив: [{string.Join(", ", array)}]");
            sb.AppendLine($"Длины серий: {string.Join(", ", seriesLengths)}");

            txtResult.Text = sb.ToString();
        }
        private void BtnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
