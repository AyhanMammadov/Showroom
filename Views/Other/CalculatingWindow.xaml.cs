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

namespace Showroom.Views.Other
{
    public partial class CalculatingWindow : Window
    {

        public CalculatingWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(LoanTermTextBox.Text, out int loanTermMonths) && loanTermMonths <= 60 &&
        double.TryParse(InitialPaymentTextBox.Text, out double initialPayment))
            {
                if(loanTermMonths > 0 && initialPayment > initialPayment * 0.10)
                {
                double annualInterestRate = 0.15;
                double monthlyInterestRate = annualInterestRate / 12 ;
                double carPrice = 45900;
                double loanAmount = carPrice - initialPayment;
                double numerator = Math.Pow(1 + monthlyInterestRate, loanTermMonths);
                double monthlyPayment = loanAmount * (monthlyInterestRate * numerator) / (numerator - 1);
                double totalPayment = monthlyPayment * loanTermMonths + initialPayment;
                double totalInterest = totalPayment - loanAmount;

                ResultTextBlock.Text = $"Loan Amount: {carPrice - initialPayment}\n" +
                    $"Initial Payment: {initialPayment}\n" +
                    $"Total Payment: {(int)totalPayment}\n" +
                    $"Total Interest Paid: {(int)totalInterest}\n" +
                    $"Monthly Payment: {(int)monthlyPayment}";
                }
            }
            else
            {
                ResultTextBlock.Text = "Please enter a valid number of installment months (not more than 60 months) and initial payment.";
            }
        }
    }
}
