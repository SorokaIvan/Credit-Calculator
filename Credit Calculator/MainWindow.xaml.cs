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

namespace Credit_Calculator
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int Amount = int.Parse(amount.Text); //сумма кредита
            int Term = int.Parse(term.Text);     //срок кредита месяцы
            double Percentages = double.Parse(percentages.Text); //процентная ставка

            double resultMonthly = CalculationMonthly(Amount, Term, Percentages);

            double resultSum = CalculationSum(resultMonthly, Term);

            sum.Text = Math.Round(resultSum, 2).ToString();
            monthly.Text = Math.Round(resultMonthly, 2).ToString();
        }

        private double CalculationMonthly(int amount, int term, double percentages)
        {
            double result;
            double x = (percentages / 100 / 12) + 1;
            double y = Math.Pow(x, term);

            result = amount * ((x - 1) / (1 - (1 / y)));

            return result;
        }

        private double CalculationSum(double resultMonthly, int term)
        {
            return resultMonthly * term;
        }
    }
}
