using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
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

namespace WPFCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static double lastNumber, result;

        private static OperatorOptions selectedOperator;

        private enum OperatorOptions
        {
            Addition, Subtraction, Multiplication, Division
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        
            var theClicker = sender as Button;
            String number = theClicker.Content.ToString();
            if(Result.Content.ToString() == "0")
            {
                Result.Content = $"{number}";
            }
            else
            {
                Result.Content = $"{Result.Content}{number}";
            }
        

        }
          
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(Result.Content.ToString(), out lastNumber)){
               Result.Content = "0" ; 
            }
            
            if (sender == Add_Button)
            {
                selectedOperator = OperatorOptions.Addition;
                
            }
            


            if (sender == Subtract_Button)
            {
                selectedOperator = OperatorOptions.Subtraction;
            }

            if (sender == Multiply_Button)
            {
                selectedOperator = OperatorOptions.Multiplication;
            }

            if (sender == Divide_Button)
            {
                selectedOperator = OperatorOptions.Division;
            }
           
        }



        private void Equal_Click(object sender, RoutedEventArgs e)
        {

            double number;
            if (double.TryParse(Result.Content.ToString(), out number))
                
            { 
                
                    switch (selectedOperator)
                    {
                        case OperatorOptions.Division:
                            try
                            {
                                if (Result.Content.ToString() == "0")
                                    throw new DivideByZeroException("Can't divide by 0");

                                result = MathService.Divide(lastNumber, number);
                            
                            

                        }
                            catch (DivideByZeroException ex)
                            {
                                MessageBox.Show("Connot divide by 0", "Error!");
                                lastNumber = 0;
                            }
                            break;

                        case OperatorOptions.Multiplication:

                            result = MathService.Multiply(lastNumber, number);
                        

                        break;

                        case OperatorOptions.Addition:

                            result = MathService.Add(lastNumber, number);
                       
                            break;

                        case OperatorOptions.Subtraction:

                            result = MathService.Subtract(lastNumber, number);
                           
                           
                            break;
                    }
                
            }
        }

        public void Percent_Click(object sender, RoutedEventArgs e)
        {


            if (lastNumber == default(double))
                {
                    Result.Content = ((lastNumber / 100) * Double.Parse(Result.Content.ToString())).ToString();
                }
                else
                {
                    Result.Content = (Double.Parse(Result.Content.ToString()) * 0.01).ToString();
                    lastNumber = Double.Parse(Result.Content.ToString());
                }
            
            

        }

        public void AC_Click(object sender, RoutedEventArgs e)
        {
            Result.Content = "0";
            
        }

        public void Negative_Click(object sender, RoutedEventArgs e)
        {
            Result.Content = double.Parse(Result.Content.ToString()) * -1;
        }

        public void Period_Click(object sender, RoutedEventArgs e)
        {
            if (!Result.Content.ToString().Contains("."))
                Result.Content += ".";
        }
            
            public MainWindow()
        {
            InitializeComponent();

            Equals_Button.Click += Equal_Click;
            Percent_Button.Click += Percent_Click;
            AC_Button.Click += AC_Click;
            Negative_Button.Click += Negative_Click;
            Period_Button.Click += Period_Click;
        }

    }
}
