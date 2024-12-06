using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double _currentValue = 0;
        private double _storedValue = 0;
        private char _operation = ' ';

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string number = button.Content.ToString();

            if(txtDisplay.Text == "0" && number != ".")
            {
                txtDisplay.Text = number;
            }
            else
            {
                txtDisplay.Text += number;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
            _currentValue = 0;
            _storedValue = 0;
            _operation = '\0';
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            _operation = button.Content.ToString()[0];
            _storedValue = double.Parse(txtDisplay.Text);
            txtDisplay.Text = "0";
        }

        private void SumButton_Click(object sender, RoutedEventArgs e)
        {
            _currentValue = double.Parse(txtDisplay.Text);
            switch (_operation)
            {
                case '+':
                    _currentValue = _storedValue + _currentValue;
                    break;

                case '-':
                    _currentValue = _storedValue - _currentValue;
                    break;
                case '*':
                    _currentValue = _storedValue * _currentValue;
                    break;
                case '/':
                    if (_currentValue != 0)
                    {
                        _currentValue = _storedValue / _currentValue;
                    }
                    else
                    {
                        MessageBox.Show("На ноль делить нельзя");
                    }
                    break;
            }

            txtDisplay.Text = _currentValue.ToString();
            _operation = '\0';
        }

        private void ButtonMouse_Click(object sender, MouseEventArgs e)
        {
            popupik.IsOpen = true;
        }

        private void Sum_MouseLeave(object sender, MouseEventArgs e)
        {
            popupik.IsOpen= false;
        }
    }
}