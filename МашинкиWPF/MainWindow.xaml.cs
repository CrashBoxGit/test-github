using System;
using System.Windows;
using System.Windows.Controls;

namespace МашинкиWPF
{
    public partial class MainWindow : Window
    {
        // Вынесем переменные за пределы метода
        double generalTime;
        double generalSpeed;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Обработчик изменения текста
        }

        private void Рассчитать_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение данных из TextBox'ов
                double distance = double.Parse(РасстояниеКм.Text);
                double fuelPrice = double.Parse(ЦенаБензина.Text);

                double speed1 = double.Parse(СкоростьКмЧ.Text);
                double acceleration1 = double.Parse(Ускорение.Text);
                double consumption1 = double.Parse(Расход100Км.Text);

                double speed2 = double.Parse(СкоростьКмЧ2.Text);
                double acceleration2 = double.Parse(Ускорение2.Text);
                double consumption2 = double.Parse(Расход100Км2.Text);

                double Yskorenie2 = acceleration2;

                generalSpeed = speed1 + speed2;
                generalTime = distance / generalSpeed;

                if (acceleration1 == 0 && acceleration2 == 0)
                {
                    // Расчет времени, если ускорение равно 0
                    timeall.Text = generalTime.ToString("0.00");
                }
                else
                {
                    // Расчет времени с учетом ускорения


                    // Рассчитываем расстояние, которое проедет каждая машина
                    double Yskorenie = acceleration1 + acceleration2;
                    Yskorenie = (Yskorenie + Yskorenie2) * -1;

                    double GeneralSpeed2 = Math.Pow(generalSpeed, 2);
                    double prom = Math.Sqrt(Math.Abs(GeneralSpeed2 - (4 * Yskorenie * distance) / 2));

                    double r = generalSpeed - prom;
                    double meetingTime = (r / (2 * (Yskorenie / 2)));
                    timeall.Text = meetingTime.ToString("0.00");
                }

                put1.Text = (speed1 * generalTime).ToString("0.00");
                rashod1.Text = (((speed1 * generalTime) / 100) * consumption1).ToString("0.00");

                put2.Text = (speed2 * generalTime).ToString("0.00");
                rashod2.Text = (((speed2 * generalTime) / 100) * consumption2).ToString("0.00");

                double itog1 = tydasuda.IsChecked == true
                    ? CalculateTotalCost(((speed1 * generalTime) / 100) * consumption1, fuelPrice) * 2
                    : CalculateTotalCost(((speed1 * generalTime) / 100) * consumption1, fuelPrice);

                double itog2 = tydasuda.IsChecked == true
                    ? CalculateTotalCost(((speed2 * generalTime) / 100) * consumption2, fuelPrice) * 2
                    : CalculateTotalCost(((speed2 * generalTime) / 100) * consumption2, fuelPrice);

                firstprice.Text = itog1.ToString("0.00");
                secondprice.Text = itog2.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private double CalculateTotalCost(double fuel, double fuelPrice)
        {
            return fuel * fuelPrice;
        }

        private void Выход_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void СтоимостьТудаОбратно2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
