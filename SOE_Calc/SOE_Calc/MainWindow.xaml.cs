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
        string[] Inputs;
        double[,] matrix = new double[3, 4];

        public MainWindow()
        {
            //Inputs = new TextBox[12] {  Input1, Input2, Input3, Input4, Input5, Input6, Input7, Input8, Input9, Input10, Input11, Input12 };
            InitializeComponent();
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

        private void SolveMatrix(double[,] matrix)
        {
            
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

        }
    }
}
