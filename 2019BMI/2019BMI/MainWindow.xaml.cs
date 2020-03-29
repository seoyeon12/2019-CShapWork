using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace _2019BMI
{
    public partial class MainWindow : Window
    {
        Double weight = 0.0f;
        Double height = 0.0f;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BMILineClear();
            height = double.Parse(InputHeight.Text);
            weight = double.Parse(InputWeight.Text);

            Double result = Calculate(height / 100f,weight);
            CheckingBMI(result);
        }
        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            InputHeight.Text = "";
            InputWeight.Text = "";
            resultBMI.Text = "";
            BMILineClear();
        }
        private Double Calculate(Double height, Double weight)
        {
            return Math.Round(weight / (height * height),2);
        }
        private void CheckingBMI(Double result)
        {
            if(result <= 18.5)
            {
                resultBMI.Text = result + "( 저체중 )";
                resultBMI.Foreground = Brushes.DarkSalmon;
                minerWeight.Visibility = Visibility;
            }
            else if(result > 18.5 && result <= 23)
            {
                resultBMI.Text = result + "( 정상 )";
                resultBMI.Foreground = Brushes.Green;
                okWeight.Visibility = Visibility;
            }
            else if(result > 23 && result <= 25)
            {
                resultBMI.Text = result + "( 과체중 )";
                resultBMI.Foreground = Brushes.Orange;
                overWeight.Visibility = Visibility;
            }
            else if (result > 25 && result <= 30)
            {
                resultBMI.Text = result + "( 비만 )";
                resultBMI.Foreground = Brushes.Red;
                majerWeight.Visibility = Visibility;
            }
            else if(result > 30 && result <= 35)
            {
                resultBMI.Text = result + "( 고도비만 )";
                resultBMI.Foreground = Brushes.Red;
                upMajerWeight.Visibility = Visibility;
            }
            else if(result > 35 && result <= 40)
            {
                resultBMI.Text = result + "( 초고도비만 )";
                resultBMI.Foreground = Brushes.Red;
                upupMajerWeight.Visibility = Visibility;
            }
        }
        private void BMILineClear()
        {
            minerWeight.Visibility = Visibility.Hidden;
            okWeight.Visibility = Visibility.Hidden;
            overWeight.Visibility = Visibility.Hidden;
            majerWeight.Visibility = Visibility.Hidden;
            upMajerWeight.Visibility = Visibility.Hidden;
            upupMajerWeight.Visibility = Visibility.Hidden;
        }
    }
}
