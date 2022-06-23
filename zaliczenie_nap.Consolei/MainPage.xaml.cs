using RestEase;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Data.SqlClient;
using System.Net.Http;
using Newtonsoft.Json;
using zaliczenie_nap.Consolei.CurrencyAPI;
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

namespace zaliczenie_nap.Consolei
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ICurrencyClient client;
        private const string url = "http://api.nbp.pl/api/exchangerates/rates/a/";
        public MainPage()
        {
            this.InitializeComponent();
            client = RestClient.For<ICurrencyClient>("http://api.nbp.pl/api/exchangerates/rates/a/usd");
            w1.SelectionChanged += Cash_SelectionChanged;
            w2.SelectionChanged += Cash_SelectionChanged;
            w3.SelectionChanged += Cash_SelectionChanged;
            pl1.TextChanged += Liczba1Value_TextChanged; pl2.TextChanged += Liczba2Value_TextChanged;
            eu1.TextChanged += Liczba3Value_TextChanged; eu2.TextChanged += Liczba4Value_TextChanged;
            us1.TextChanged += Liczba5Value_TextChanged; us2.TextChanged += Liczba6Value_TextChanged;
            btnCalculate.Click += BtnCalculate_Click;
            btnCalculate.Click += BtnCalculate_Click1;
            btnCalculate.Click += BtnCalculate_Click2;
            btnClear.Click += BtnClear;
            GetDate();
        }

        public async void GetEur(string urlNew)
        {
            CurrencyApi dane;

            using (var httpClient = new HttpClient())
            {
                /*          var response = await client.GetCurrencyByQuery();
                            var mainCurr = response.Rates;
                            var props = mainCurr.GetType().GetProperties();*/
                
                var json = await httpClient.GetStringAsync(urlNew);

                if (json == string.Empty && json == null)
                {
                    tbRespons.Text = "Brak danych lub polaczenie nie udane";
                    tDate1.Text = "Brak danych lub polaczenie nie udane";
                }
                else
                {
                    dane = JsonConvert.DeserializeObject<CurrencyApi>(json);
                    tbRespons.Text = dane.Rates[0].Mid.ToString();
                    tDate1.Text = dane.Rates[0].EffectiveDate.ToString("d");
                }
                /*          tIList<string> props1 = (IList<string>)props[0];
                            IList<string> allData = props1;
                         ResponseXD.Text = props1.ToString(); */
            }
            
        }
        public async void GetUsd(string urlNew)
        {
            CurrencyApi dane;

            using (var httpClient = new HttpClient())
            {
                /*          var response = await client.GetCurrencyByQuery();
                            var mainCurr = response.Rates;
                            var props = mainCurr.GetType().GetProperties();*/

                var json = await httpClient.GetStringAsync(urlNew);
                dane = JsonConvert.DeserializeObject<CurrencyApi>(json);

                /*          tIList<string> props1 = (IList<string>)props[0];
                            IList<string> allData = props1;
                         ResponseXD.Text = props1.ToString(); */
            }
            tbRespons1.Text = dane.Rates[0].Mid.ToString();
            tDate2.Text = dane.Rates[0].EffectiveDate.ToString("d");
        }
       
        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            spResults.Visibility = Visibility.Visible;
            var wybierzhajs1 = (CashType1)w1.SelectedIndex;

            Clear.Text = (" Please click button 'Clear'. If you want change different currency").ToString();

            switch (wybierzhajs1)
            {
                case CashType1.USD1:
                    var d1 = Convert.ToDouble(pl1.Text);
                    var get1 = Convert.ToDouble(tbRespons1.Text);
                    var wynik = Math.Round((d1 / get1), 4);
                    tbxResults.Text = (wynik + " Dolarow ").ToString();
                    btnClear.IsEnabled = true;
                    break;
                case CashType1.EUR1:
                    var e1 = Convert.ToDouble(pl2.Text);
                    var get2 = Convert.ToDouble(tbRespons.Text);
                    var wynik2 = Math.Round((e1 / get2), 4);
                    tbxResults.Text = (wynik2 + " Euro ").ToString();
                    btnClear.IsEnabled = true;
                    break;
                default:
                    break;
            }
        }
        private void BtnCalculate_Click1(object sender, RoutedEventArgs e)
        {
            var wybierzhajs2 = (CashType2)w2.SelectedIndex;
            spResults.Visibility = Visibility.Visible;
            Clear.Text = (" Please click button 'Clear'. If you want change different currency").ToString();

            switch (wybierzhajs2)
            {
                case CashType2.PLN1:
                    var p1 = Convert.ToDouble(eu1.Text);
                    var get1 = Convert.ToDouble(tbRespons.Text);
                    var wynik = Math.Round((p1 * get1), 4);
                    tbxResults.Text = (wynik + " Zloty ").ToString();
                    btnClear.IsEnabled = true;
                    break;
                case CashType2.USD2:
                    var d2 = Convert.ToDouble(eu2.Text);
                    var get2 = Convert.ToDouble(tbRespons.Text);
                    var get3 = Convert.ToDouble(tbRespons1.Text);
                    var wynik1 = Math.Round((d2 * get2 / get3), 4);
                    tbxResults.Text = (wynik1 + " Dolarow ").ToString();
                    btnClear.IsEnabled = true;
                    break;
                default:
                    break;
            }
        }
        private void BtnCalculate_Click2(object sender, RoutedEventArgs e)
        {
            var wybierzhajs3 = (CashType3)w3.SelectedIndex;
            spResults.Visibility = Visibility.Visible;
            Clear.Text = (" Please click button 'Clear'. If you want change different currency").ToString();

            switch (wybierzhajs3)
            {
                case CashType3.PLN2:
                    var p2 = Convert.ToDouble(us1.Text);
                    var get1 = Convert.ToDouble(tbRespons1.Text);
                    var wynik = Math.Round((p2 * get1), 4);
                    tbxResults.Text = (wynik + " Zloty ").ToString();
                    btnClear.IsEnabled = true;
                    break;
                case CashType3.EUR2:
                    var e2 = Convert.ToDouble(us2.Text);
                    var get2 = Convert.ToDouble(tbRespons1.Text);
                    var get3 = Convert.ToDouble(tbRespons.Text);
                    var wynik1 = Math.Round((e2 * get2 / get3), 4);
                    tbxResults.Text = (wynik1 + " Euro ").ToString();
                    btnClear.IsEnabled = true;
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
                btnCalculate.IsEnabled = false;
                return;
            }
            btnCalculate.IsEnabled = true;
        }
        private void Liczba4Value_TextChanged(object sender, TextChangedEventArgs e)
        {
            double val;

            if (!double.TryParse(eu2.Text, out val))
            {
                btnCalculate.IsEnabled = false;
                return;
            }
            btnCalculate.IsEnabled = true;
        }
        private void Liczba5Value_TextChanged(object sender, TextChangedEventArgs e)
        {
            double val;

            if (!double.TryParse(us1.Text, out val))
            {
                btnCalculate.IsEnabled = false;
                return;
            }
            btnCalculate.IsEnabled = true;
        }
        private void Liczba6Value_TextChanged(object sender, TextChangedEventArgs e)
        {
            double val;

            if (!double.TryParse(us2.Text, out val))
            {
                btnCalculate.IsEnabled = false;
                return;
            }
            btnCalculate.IsEnabled = true;
        }

        private void Cash_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCash1 = (CashType1)w1.SelectedIndex;

            switch (selectedCash1)
            {
                case CashType1.USD1:
                    string a = url + "usd";
                    liczPL1.Visibility = Visibility.Visible;
                    liczPL2.Visibility = Visibility.Collapsed;
                    GetUsd(a);
                    valC2.Visibility = Visibility.Visible;
                    valC1.Visibility = Visibility.Collapsed;
                    Time2.Visibility = Visibility.Visible;
                    Time1.Visibility = Visibility.Collapsed;
                    w2.IsEnabled = false;
                    w3.IsEnabled = false;
                    break;
                case CashType1.EUR1:
                    string b = url + "eur";
                    liczPL1.Visibility = Visibility.Collapsed;
                    liczPL2.Visibility = Visibility.Visible;
                    GetEur(b);
                    valC1.Visibility = Visibility.Visible;
                    valC2.Visibility = Visibility.Collapsed;
                    Time1.Visibility = Visibility.Visible;
                    Time2.Visibility = Visibility.Collapsed;
                    w2.IsEnabled = false;
                    w3.IsEnabled = false;
                    break;
                default:
                    break;
            }
            ClearValues();

            var selectedCash2 = (CashType2)w2.SelectedIndex;

            switch (selectedCash2)
            {
                case CashType2.PLN1:
                    string a = url + "eur";
                    liczEU1.Visibility = Visibility.Visible;
                    liczEU2.Visibility = Visibility.Collapsed;
                    GetEur(a);
                    valC1.Visibility = Visibility.Visible;
                    valC2.Visibility = Visibility.Collapsed;
                    Time1.Visibility = Visibility.Visible;
                    Time2.Visibility = Visibility.Collapsed;
                    w1.IsEnabled = false;
                    w3.IsEnabled = false;
                    break;
                case CashType2.USD2:
                    string b = url + "eur";
                    string c = url + "usd";
                    liczEU1.Visibility = Visibility.Collapsed;
                    liczEU2.Visibility = Visibility.Visible;
                    GetEur(b);
                    valC1.Visibility = Visibility.Visible;
                    Time1.Visibility = Visibility.Visible;
                    GetUsd(c);
                    valC2.Visibility = Visibility.Visible;
                    Time2.Visibility = Visibility.Visible;
                    w1.IsEnabled = false;
                    w3.IsEnabled = false;
                    break;
                default:
                    break;
            }
            ClearValues();

            var selectedCash3 = (CashType3)w3.SelectedIndex;

            switch (selectedCash3)
            {
                case CashType3.PLN2:
                    string a = url + "usd";
                    liczUS1.Visibility = Visibility.Visible;
                    liczUS2.Visibility = Visibility.Collapsed;
                    GetUsd(a);
                    valC2.Visibility = Visibility.Visible;
                    valC1.Visibility = Visibility.Collapsed;
                    Time2.Visibility = Visibility.Visible;
                    Time1.Visibility = Visibility.Collapsed;
                    w2.IsEnabled = false;
                    w1.IsEnabled = false;
                    break;
                case CashType3.EUR2:
                    string b = url + "usd";
                    string c = url + "eur";
                    liczUS1.Visibility = Visibility.Collapsed;
                    liczUS2.Visibility = Visibility.Visible;
                    GetUsd(b);
                    valC2.Visibility = Visibility.Visible;
                    Time2.Visibility = Visibility.Visible;
                    GetEur(c);
                    valC1.Visibility = Visibility.Visible;
                    Time1.Visibility = Visibility.Visible;
                    w2.IsEnabled = false;
                    w1.IsEnabled = false;
                    break;
                default:
                    break;
            }
            ClearValues();
        }

        private void BtnClear(object sender, RoutedEventArgs e)
        {
            w1.SelectedIndex = -1; w2.SelectedIndex = -1; w3.SelectedIndex = -1;
            w1.IsEnabled = true; w2.IsEnabled = true; w3.IsEnabled = true;

            Clear.Text = string.Empty;

            liczPL1.Visibility = Visibility.Collapsed; liczPL2.Visibility = Visibility.Collapsed;
            liczEU1.Visibility = Visibility.Collapsed; liczEU2.Visibility = Visibility.Collapsed;
            liczUS1.Visibility = Visibility.Collapsed; liczUS2.Visibility = Visibility.Collapsed;

            tbRespons.Text = string.Empty; tbRespons1.Text = string.Empty;
            valC1.Visibility = Visibility.Collapsed; valC2.Visibility = Visibility.Collapsed;
            tDate1.Text = string.Empty; tDate2.Text = string.Empty;
            Time1.Visibility = Visibility.Collapsed; Time2.Visibility = Visibility.Collapsed;

            btnClear.IsEnabled = false;
            ClearValues();
        }
        private void ClearValues()
        {
            btnCalculate.IsEnabled = false;
            pl1.Text = string.Empty;
            pl2.Text = string.Empty;
            eu1.Text = string.Empty;
            eu2.Text = string.Empty;
            us1.Text = string.Empty;
            us2.Text = string.Empty;
            Clear.Text = string.Empty;
            tbxResults.Text = string.Empty;
            spResults.Visibility = Visibility.Collapsed;

        }

        private void GetDate()
        {
            var localDate = DateTime.Now;
            tDateLocal.Text = localDate.ToString();
        }

    }
}