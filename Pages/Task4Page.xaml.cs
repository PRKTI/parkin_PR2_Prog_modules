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
using System.Windows.Shapes;

namespace parkin_ru1.Pages
{
    public partial class Task4Page : Page
    {
        public Task4Page()
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

            int maxNegIndex = -1;
            int? maxNegValue = null;
            int minPosIndex = -1;
            int? minPosValue = null;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    if (maxNegValue == null || Math.Abs(array[i]) > Math.Abs(maxNegValue.Value))
                    {
                        maxNegValue = array[i];
                        maxNegIndex = i;
                    }
                }
                if (array[i] > 0)
                {
                    if (minPosValue == null || array[i] < minPosValue.Value)
                    {
                        minPosValue = array[i];
                        minPosIndex = i;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Исходный массив: [{string.Join(" ", array)}]");

            if (maxNegIndex == -1 || minPosIndex == -1)
            {
                sb.AppendLine("Невозможно выполнить перестановку: нет отрицательных или положительных элементов.");
                txtResult.Text = sb.ToString();
                return;
            }

            sb.AppendLine($"Макс. по модулю отриц.: {maxNegValue} (позиция {maxNegIndex})");
            sb.AppendLine($"Мин. положительный: {minPosValue} (позиция {minPosIndex})");

            int temp = array[maxNegIndex];
            array[maxNegIndex] = array[minPosIndex];
            array[minPosIndex] = temp;

            sb.AppendLine($"Результат перестановки: [{string.Join(" ", array)}]");

            txtResult.Text = sb.ToString();
        }
        private void BtnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
