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

namespace CalculadoraWPF.Vistas
{
    /// <summary>
    /// Lógica de interacción para Calculadora.xaml
    /// </summary>
    public partial class Calculadora : Window
    {
        private string currentInput = "";
        private string operatorUsed = "";
        private double result = 0;
        public Calculadora()
        {
            InitializeComponent();
        } 

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Content.ToString();
            Display.Text = currentInput;
        }
         
        private void Letter_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Content.ToString();
            Display.Text = currentInput;
        }
         
        private void Operator_Click(object sender, RoutedEventArgs e)
        { 
            Button button = (Button)sender;
            operatorUsed = button.Content.ToString(); 
            result = Convert.ToInt32(currentInput, 16);
            currentInput = "";
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                // Elimina el último carácter de la entrada actual
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
                Display.Text = currentInput;  // Actualiza el display
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            int secondOperand = Convert.ToInt32(currentInput, 16);


            switch (operatorUsed)
            {
                case "+":
                    result += secondOperand;
                    break;
                case "-":
                    result -= secondOperand;
                    break; 
            }

            Display.Text = result.ToString();
            currentInput = result.ToString();
        }
    }
}
