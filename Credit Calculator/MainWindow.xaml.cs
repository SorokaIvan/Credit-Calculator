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
            int amount = int.Parse(Amount.Text); //сумма кредита
            int creditPeriod = int.Parse(CreditPeriod.Text);     //срок кредита месяцы
            double percentages = double.Parse(Percentages.Text); //процентная ставка

            double resultMonthly = CalculationMonthly(amount, creditPeriod, percentages);

            double resultSum = CalculationSum(resultMonthly, creditPeriod);

            sum.Text = Math.Round(resultSum, 2).ToString();
            monthly.Text = Math.Round(resultMonthly, 2).ToString();
        }

        private double CalculationMonthly(int amount, int creditPeriod, double percentages)
        {
            return amount * (percentages / 100 / 12) / (1 - 1 / Math.Pow(percentages / 100 / 12 + 1, creditPeriod));
        }

        private double CalculationSum(double resultMonthly, int creditPeriod)
        {
            return resultMonthly * creditPeriod;
        }
    }
}
