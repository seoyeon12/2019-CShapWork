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

namespace SkideMark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Double skidMark;
        Double friction;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            skidMark = double.Parse(InputSkidMark.Text);
            friction = double.Parse(InputFriction.Text);

            Double result = Math.Round(Calculate(skidMark, friction), 2);

            TextBlock recodeBlock = new TextBlock();
            recodeBlock.Text = result.ToString();

            Recode.Children.Add(recodeBlock);
            NowCalculationResult.Text = result.ToString() + " km/h";

            //if (intCheck(skidMark) && intCheck(friction))
            //{
            //    Double result = Math.Round(Calculate(skidMark, friction), 2);

            //    TextBlock recodeBlock = new TextBlock();
            //    recodeBlock.Text = result.ToString();

            //    Recode.Children.Add(recodeBlock);
            //    NowCalculationResult.Text = result.ToString() + " km/h";
            //    return;
            //}
            //else
            //{
            //    MessageBox.Show(" 다시 입력해주십시오. ");
            //    InputSkidMark.Clear();
            //    InputFriction.Clear();
            //}
        }

        private Double Calculate(Double skidMark, Double friction)
        {
            return Math.Sqrt(254 * skidMark * friction);
        }

        //private Boolean intCheck(Double cont)
        //{
        //    string strNum;
        //    strNum = Regex.Replace(cont.ToString(), @"\d", "");
        //    //입력받은 값 중에 문자만 받아오기
        //    if (strNum != "") //문자가 있다면 false을 반환
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        private void InputCheck(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (e.Key == Key.OemPeriod)
            {
                if (txt.Text.Contains("."))
                {
                    MessageBox.Show("소수점이 이미 존재합니다.");
                    e.Handled = true;
                }
                return;
            }

            if (!(((Key.D0 <= e.Key) && (e.Key <= Key.D9)) || e.Key == Key.Back))
            {
                MessageBox.Show("숫자만 입력해 주십시오");
                e.Handled = true;
            }
        }
    }
}
