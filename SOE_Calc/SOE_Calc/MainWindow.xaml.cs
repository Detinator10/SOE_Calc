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
using System.Text.RegularExpressions;

namespace SOE_Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double[,] matrixcopy = new double[3,4];
        string[] Inputs;
        double[,] matrix = new double[3, 4];
        TextBox[] InputsText;

        public MainWindow()
        {
            //Inputs = new TextBox[12] {  Input1, Input2, Input3, Input4, Input5, Input6, Input7, Input8, Input9, Input10, Input11, Input12 };

            InitializeComponent();
            Inputs = new string[12] { Input1.Text, Input2.Text, Input3.Text, Input4.Text, Input5.Text, Input6.Text, Input7.Text, Input8.Text, Input9.Text, Input10.Text, Input11.Text, Input12.Text };
            InputsText = new TextBox[12] { Input1, Input2, Input3, Input4, Input5, Input6, Input7, Input8, Input9, Input10, Input11, Input12 };
        }

        private void textInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void InputVerification(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
            
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void SolveMatrix()
        {
            matrixcopy = (double[,])matrix.Clone();
            MatrixRowMultiply(0, matrix[1, 1]);
            MatrixRowMultiply(1, matrix[0, 1]);
            RowAddition(1, 0, 0);
            matrixcopy = (double[,])matrix.Clone();

            MatrixRowMultiply(1, matrix[2, 1]);
            MatrixRowMultiply(2, matrix[1, 1]);
            RowAddition(1, 2, 2);
            matrixcopy = (double[,])matrix.Clone();

            MatrixRowMultiply(2, matrix[0, 2]);
            MatrixRowMultiply(0, matrix[2, 2]);
            RowAddition(2, 0, 0);
            matrixcopy = (double[,])matrix.Clone();

            MatrixRowMultiply(2, matrix[0, 2]);
            MatrixRowMultiply(0, matrix[2, 2]);
            RowAddition(2, 0, 0);
            matrixcopy = (double[,])matrix.Clone();

            MatrixRowMultiply(1, matrix[0, 0]);
            MatrixRowMultiply(0, matrix[1, 0]);
            RowAddition(0, 1, 1);
            matrixcopy = (double[,])matrix.Clone();

            MatrixRowMultiply(0, matrix[2, 0]);
            MatrixRowMultiply(2, matrix[0, 0]);
            RowAddition(0, 2, 2);
            matrixcopy = (double[,])matrix.Clone();

            MatrixRowMultiply(1, matrix[2, 2]);
            MatrixRowMultiply(2, matrix[1, 2]);
            RowAddition(2, 1, 1);
            matrixcopy = (double[,])matrix.Clone();

            int column = 0;
            for(int row = 0; row < 3; row++)
            {

                matrix[row, matrix.GetLength(1) - 1] = matrix[row, matrix.GetLength(1)-1] / matrix[row, column];
                matrix[row, column] = 1;
                column++;
            }
            Console.WriteLine(matrix[0, 0].ToString() + " " + matrix[0, 1].ToString() + " " + matrix[0, 2].ToString() + " " + matrix[0, 3].ToString() + " " +
    matrix[1, 0].ToString() + " " + matrix[1, 1].ToString() + " " + matrix[1, 2].ToString() + " " + matrix[1, 3].ToString() + " " +
    matrix[2, 0].ToString() + " " + matrix[2, 1].ToString() + " " + matrix[2, 2].ToString() + " " + matrix[2, 3].ToString());
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Inputs = new string[12] { Input1.Text, Input2.Text, Input3.Text, Input4.Text, Input5.Text, Input6.Text, Input7.Text, Input8.Text, Input9.Text, Input10.Text, Input11.Text, Input12.Text };
            int x = 0;
            int y = 0;
            for (int z = 0; z < 12; z++)
            {

                if (x >= 3)
                {

                    matrix[y, x] = Convert.ToDouble(Inputs[z]);
                    x = 0;
                    y++;
                }
                else
                {
                    matrix[y, x] = Convert.ToDouble(Inputs[z]);
                    x++;
                }


            }

            Console.Write(matrix[0,0].ToString() + " " + matrix[0, 1].ToString() + " " + matrix[0, 2].ToString() + " " + matrix[0, 3].ToString() + " " +
                matrix[1, 0].ToString() + " " + matrix[1, 1].ToString() + " " + matrix[1, 2].ToString() + " " + matrix[1, 3].ToString() + " " +
                matrix[2, 0].ToString() + " " + matrix[2, 1].ToString() + " " + matrix[2, 2].ToString() + " " + matrix[2, 3].ToString());
            SolveMatrix();
            DisplaySolution();

        }

        void MatrixRowMultiply (int row, double scalar)
        {
            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                matrixcopy[row, y] *= scalar;
            }
        }
        void MatrixRowReplace(int row, double[] matrixrow)
        {
            int y = 0;
                foreach (double a in matrixrow)
            {

                matrix[row, y] = a;
                y++;
            }
        }

        void RowAddition(int row1, int row2, int rowwrite)
        {
            MatrixRowMultiply(row2, -1);
            for(int y = 0; y < matrix.GetLength(1); y++)
            {
                Console.WriteLine(matrix[row1, y].ToString());
                Console.Write(matrix[row2, y].ToString());
                matrix[rowwrite, y] = matrixcopy[row1, y] + matrixcopy[row2, y];
            }
        }

        void DisplaySolution()
        {
            xValue.Text = matrix[0, matrix.GetLength(1)-1].ToString();
            yValue.Text = matrix[1, matrix.GetLength(1)-1].ToString();
            zValue.Text = matrix[2, matrix.GetLength(1)-1].ToString();
        }

        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            for(int x = 0; x < 12; x++)
            {
                InputsText[x].Text = null;
            }
            Array.Clear(matrix,0,12);

            xValue.Text = "___";
            yValue.Text = "___";
            zValue.Text = "___";
        }
    }
}
