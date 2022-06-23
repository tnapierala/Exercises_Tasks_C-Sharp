using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace zadanie5_Napierala.Consolei
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            w1.SelectionChanged += Cash_SelectionChanged;
            w2.SelectionChanged += Cash1_SelectionChanged;
            w3.SelectionChanged += Cash2_SelectionChanged;
            pl1.TextChanged += Liczba1Value_TextChanged; pl2.TextChanged += Liczba2Value_TextChanged;
            eu1.TextChanged += Liczba3Value_TextChanged; eu2.TextChanged += Liczba4Value_TextChanged;
            us1.TextChanged += Liczba5Value_TextChanged; us2.TextChanged += Liczba6Value_TextChanged;
            btnCalculate.Click += BtnCalculate_Click;
            btnCalculate1.Click += BtnCalculate_Click1;
            btnCalculate2.Click += BtnCalculate_Click2;
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            var wybierzhajs1 = (CashType1)w1.SelectedIndex;
            spResults.Visibility = Visibility.Visible;

            switch (wybierzhajs1)
            {
                case CashType1.USD1:
                    var d1 = Convert.ToDouble(pl1.Text);
                    var x1 = 0.2726;
                    tbxResults.Text = (d1 * x1 + " Dolarow ").ToString();
                    break;
                case CashType1.EUR1:
                    var e1 = Convert.ToDouble(pl2.Text);
                    var x2 = 0.225;
                    tbxResults.Text = (e1 * x2 + " Euro ").ToString();
                    break;
                default:
                    break;
            }
        }
        private void BtnCalculate_Click1(object sender, RoutedEventArgs e)
        {
            var wybierzhajs2 = (CashType2)w2.SelectedIndex;
            spResults1.Visibility = Visibility.Visible;

            switch (wybierzhajs2)
            {
                case CashType2.PLN1:
                    var p1 = Convert.ToDouble(eu1.Text);
                    var x3 = 4.45;
                    tbxResults1.Text = (p1 * x3 + " Zloty ").ToString();
                    break;
                case CashType2.USD2:
                    var d2 = Convert.ToDouble(eu2.Text);
                    var x4 = 1.21;
                    tbxResults1.Text = (d2 * x4 + " Dolarow ").ToString();
                    break;
                default:
                    break;
            }
        }
        private void BtnCalculate_Click2(object sender, RoutedEventArgs e)
        {
            var wybierzhajs3 = (CashType3)w3.SelectedIndex;
            spResults2.Visibility = Visibility.Visible;

            switch (wybierzhajs3)
            {
                case CashType3.PLN2:
                    var p2 = Convert.ToDouble(us1.Text);
                    var x5 = 3.66;
                    tbxResults2.Text = (p2 * x5 + " Zloty ").ToString();
                    break;
                case CashType3.EUR2:
                    var e2 = Convert.ToDouble(us2.Text);
                    var x6 = 0.82;
                    tbxResults2.Text = (e2 * x6 + " Euro ").ToString();
                    break;
                default:
                    break;
            }
        }
        private void Liczba1Value_TextChanged(object sender, TextChangedEventArgs e)
        {
            double val;

            if (!double.TryParse(pl1.Text, out val))
            {
                btnCalculate.IsEnabled = false;
                return;
            }
            btnCalculate.IsEnabled = true;
        }
        private void Liczba2Value_TextChanged(object sender, TextChangedEventArgs e)
        {
            double val;

            if (!double.TryParse(pl2.Text, out val))
            {
                btnCalculate.IsEnabled = false;
                return;
            }
            btnCalculate.IsEnabled = true;
        }
        private void Liczba3Value_TextChanged(object sender, TextChangedEventArgs e)
        {
            double val;

            if (!double.TryParse(eu1.Text, out val))
            {
                btnCalculate1.IsEnabled = false;
                return;
            }
            btnCalculate1.IsEnabled = true;
        }
        private void Liczba4Value_TextChanged(object sender, TextChangedEventArgs e)
        {
            double val;

            if (!double.TryParse(eu2.Text, out val))
            {
                btnCalculate1.IsEnabled = false;
                return;
            }
            btnCalculate1.IsEnabled = true;
        }
        private void Liczba5Value_TextChanged(object sender, TextChangedEventArgs e)
        {
            double val;

            if (!double.TryParse(us1.Text, out val))
            {
                btnCalculate2.IsEnabled = false;
                return;
            }
            btnCalculate2.IsEnabled = true;
        }
        private void Liczba6Value_TextChanged(object sender, TextChangedEventArgs e)
        {
            double val;

            if (!double.TryParse(us2.Text, out val))
            {
                btnCalculate2.IsEnabled = false;
                return;
            }
            btnCalculate2.IsEnabled = true;
        }

        private void Cash_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCash1 = (CashType1)w1.SelectedIndex;

            switch (selectedCash1)
            {
                case CashType1.USD1:
                    liczPL1.Visibility = Visibility.Visible;
                    liczPL2.Visibility = Visibility.Collapsed;
                    liczEU1.Visibility = Visibility.Collapsed;
                    liczEU2.Visibility = Visibility.Collapsed;
                    liczUS1.Visibility = Visibility.Collapsed;
                    liczUS2.Visibility = Visibility.Collapsed;
                    break;
                case CashType1.EUR1:
                    liczPL1.Visibility = Visibility.Collapsed;
                    liczPL2.Visibility = Visibility.Visible;
                    liczEU1.Visibility = Visibility.Collapsed;
                    liczEU2.Visibility = Visibility.Collapsed;
                    liczUS1.Visibility = Visibility.Collapsed;
                    liczUS2.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }
            ClearValues();
        }
        private void Cash1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCash2 = (CashType2)w2.SelectedIndex;

            switch (selectedCash2)
            {
                case CashType2.PLN1:
                    liczEU1.Visibility = Visibility.Visible;
                    liczEU2.Visibility = Visibility.Collapsed;
                    liczPL1.Visibility = Visibility.Collapsed;
                    liczPL2.Visibility = Visibility.Collapsed;
                    liczUS1.Visibility = Visibility.Collapsed;
                    liczUS2.Visibility = Visibility.Collapsed;
                    break;
                case CashType2.USD2:
                    liczEU1.Visibility = Visibility.Collapsed;
                    liczEU2.Visibility = Visibility.Visible;
                    liczPL1.Visibility = Visibility.Collapsed;
                    liczPL2.Visibility = Visibility.Collapsed;
                    liczUS1.Visibility = Visibility.Collapsed;
                    liczUS2.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }
            ClearValues();
        }
        private void Cash2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCash3 = (CashType3)w3.SelectedIndex;

            switch (selectedCash3)
            {
                case CashType3.PLN2:
                    liczUS1.Visibility = Visibility.Visible;
                    liczUS2.Visibility = Visibility.Collapsed;
                    liczPL1.Visibility = Visibility.Collapsed;
                    liczPL2.Visibility = Visibility.Collapsed;
                    liczEU1.Visibility = Visibility.Collapsed;
                    liczEU2.Visibility = Visibility.Collapsed;
                    break;
                case CashType3.EUR2:
                    liczUS1.Visibility = Visibility.Collapsed;
                    liczUS2.Visibility = Visibility.Visible;
                    liczPL1.Visibility = Visibility.Collapsed;
                    liczPL2.Visibility = Visibility.Collapsed;
                    liczEU1.Visibility = Visibility.Collapsed;
                    liczEU2.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }
            ClearValues();
        }

        private void ClearValues()
        {
            btnCalculate.IsEnabled = false;
            btnCalculate1.IsEnabled = false;
            btnCalculate2.IsEnabled = false;
            pl1.Text = string.Empty;
            pl2.Text = string.Empty;
            eu1.Text = string.Empty;
            eu2.Text = string.Empty;
            us1.Text = string.Empty;
            us2.Text = string.Empty;
            tbxResults.Text = string.Empty;
            tbxResults1.Text = string.Empty;
            tbxResults2.Text = string.Empty;
            spResults.Visibility = Visibility.Collapsed;
        }
    }
}
