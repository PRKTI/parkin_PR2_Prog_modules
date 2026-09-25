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
    public partial class Task5Page : Page
    {
        public Task5Page()
        {
            InitializeComponent();
        }
        private void BtnGenerateAndExecute_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtColumnsCount.Text, out int columnsCount) ||
                !int.TryParse(txtRowsCount.Text, out int rowsCount) ||
                columnsCount <= 0 || rowsCount <= 0)
            {
                txtResult.Text = "Ошибка: введите положительные целые значения M и N.";
                return;
            }

            Random randomGenerator = new Random();
            int[,] originalMatrix = new int[rowsCount, columnsCount];

            for (int i = 0; i < rowsCount; i++)
                for (int j = 0; j < columnsCount; j++)
                    originalMatrix[i, j] = randomGenerator.Next(-10, 11);

            int totalElements = rowsCount * columnsCount;
            int[] ascendingArray = new int[totalElements];
            int[] descendingArray = new int[totalElements];

            int index = 0;
            int minValue = originalMatrix[0, 0];
            int maxValue = originalMatrix[0, 0];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    int currentValue = originalMatrix[i, j];
                    ascendingArray[index] = currentValue;
                    descendingArray[index] = currentValue;

                    if (currentValue < minValue) minValue = currentValue;
                    if (currentValue > maxValue) maxValue = currentValue;
                    index++;
                }
            }

            Array.Sort(ascendingArray);
            Array.Sort(descendingArray);
            Array.Reverse(descendingArray);

            StringBuilder resultBuilder = new StringBuilder();

            resultBuilder.AppendLine("=== Исходный массив ===");
            AppendMatrix(resultBuilder, originalMatrix, rowsCount, columnsCount);

            resultBuilder.AppendLine("\n=== Отсортирован по ВОЗРАСТАНИЮ ===");
            AppendFlatAsMatrix(resultBuilder, ascendingArray, rowsCount, columnsCount);

            resultBuilder.AppendLine("\n=== Отсортирован по УБЫВАНИЮ ===");
            AppendFlatAsMatrix(resultBuilder, descendingArray, rowsCount, columnsCount);

            resultBuilder.AppendLine($"\nМинимальный элемент: {minValue}");
            resultBuilder.AppendLine($"Максимальный элемент: {maxValue}");

            txtResult.Text = resultBuilder.ToString();
        }

        private void AppendMatrix(StringBuilder builder, int[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    builder.Append(matrix[i, j].ToString().PadLeft(4));
                builder.AppendLine();
            }
        }

        private void AppendFlatAsMatrix(StringBuilder builder, int[] array, int rows, int cols)
        {
            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    builder.Append(array[k++].ToString().PadLeft(4));
                builder.AppendLine();
            }
        }

        private void BtnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
