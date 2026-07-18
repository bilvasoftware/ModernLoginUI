using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Diagnostics;

namespace CuteLoginUI
{
    public partial class MainWindow : Window
    {
        private bool isPasswordVisible = false;
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation floatAnimation = new DoubleAnimation
            {
                From = -8,
                To = 8,
                Duration = TimeSpan.FromSeconds(2),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };

            TranslateTransform transform =
                (TranslateTransform)CharacterImage.RenderTransform;

            transform.BeginAnimation(
                TranslateTransform.YProperty,
                floatAnimation);
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Login Button Clicked");
        }

        private void EyeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isPasswordVisible)
            {
                txtPasswordVisible.Text = txtPassword.Password;

                txtPassword.Visibility = Visibility.Collapsed;
                txtPasswordVisible.Visibility = Visibility.Visible;

                imgEye.Source = new BitmapImage(
                    new Uri("Assets/Icons/EyeOpen.png", UriKind.Relative));

                isPasswordVisible = true;
            }
            else
            {
                txtPassword.Password = txtPasswordVisible.Text;

                txtPassword.Visibility = Visibility.Visible;
                txtPasswordVisible.Visibility = Visibility.Collapsed;

                imgEye.Source = new BitmapImage(
                    new Uri("Assets/Icons/EyeClosed.png", UriKind.Relative));

                isPasswordVisible = false;
            }
        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
                txtUsername.Foreground = Brushes.Black;
            }
        }

        private void txtUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Username";
                txtUsername.Foreground = Brushes.Gray;
            }
        }


        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPasswordPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Password))
            {
                txtPasswordPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void Google_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://accounts.google.com/",
                UseShellExecute = true
            });
        }

        private void Apple_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://appleid.apple.com/",
                UseShellExecute = true
            });
        }

        private void Facebook_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.facebook.com/login/",
                UseShellExecute = true
            });
        }

        private void ForgotPassword_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("Forgot Password feature coming soon!",
                            "Forgot Password",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }

        private void SignUp_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("Sign Up feature coming soon!",
                            "Sign Up",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }


        private void BilvaLogo_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/bilvasoftware",
                UseShellExecute = true
            });
        }

    }
}