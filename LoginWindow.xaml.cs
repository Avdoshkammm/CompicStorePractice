using NewCompicStore.Infrastructure;
using NewCompicStore.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NewCompicStore
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        bool verify = true;
        int verifyCheck = 0;

        public LoginWindow()
        {
            InitializeComponent();
        }

        async void disableButton()
        {
            LoginBut.IsEnabled = false;
            await Task.Delay(TimeSpan.FromSeconds(10));
            LoginBut.IsEnabled = true;
        }

        private void LoginBut_Click(object sender, RoutedEventArgs e)
        {
            using(KompicDbContext db = new KompicDbContext())
            {
                if(captchaBlock.Visibility == Visibility.Visible)
                {
                    if (captchaBlock.Text == captchaBox.Text)
                    {
                        verify = true;
                    }
                }

                User user = db.Users.Where(u => u.Login == loginBox.Text && u.Password == passwordBox.Password).FirstOrDefault() as User;

                if(user != null)
                {
                    MessageBox.Show("Успешная авторизация");
                    MainWindow main = new MainWindow(null);
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Авторизация была некорректной. Проверьте правильность написания логина/пароля и повторите попытку");
                    verifyCheck += 1;

                    // captcha view
                    captchaBox.Visibility = Visibility.Visible;
                    captchaBlock.Visibility = Visibility.Visible;
                    captchaBlock.Text = CaptchaBuilder.Refresh();
                    verify = false;

                    if (verifyCheck > 1)
                    {
                        disableButton();
                        captchaBlock.Text = CaptchaBuilder.Refresh();
                    }
                }
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
