using NewCompicStore.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace NewCompicStore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(User user)
        {
            InitializeComponent();
            using (KompicDbContext db = new KompicDbContext())
            {
                if (user != null)
                {
                    MessageBox.Show($"Ты авторизовался под пользователем: {user.Surname} {user.Name} {user.Patronymic}");
                }

                //ordersGrid.ItemsSource = db.Orders.ToList();
            }
        }
        public void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (KompicDbContext db = new KompicDbContext())
            {
                ordersGrid.ItemsSource = db.Orders.ToList();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }

        private void searchBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            using (KompicDbContext db = new KompicDbContext())
            {
                if (searchBox.Text.Length > 0)
                {
                    ordersGrid.ItemsSource = db.Orders.Where(db => db.SurnameClient.Contains(searchBox.Text) || db.Description.Contains(searchBox.Text)).ToList();
                }

            }
        }

        private void EditProduct_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            using (KompicDbContext db = new KompicDbContext())
            {

                if (sender is ListView listView && listView.SelectedItem != null)
                {
                  try
                    {
                      Order o = listView.SelectedItem as Order;
                       new AddOrderWindow(o).ShowDialog();
                   }
                   catch (Exception ex)
                   {
                        MessageBox.Show($"Ошибка: {ex.Message}");
                   }
                    db.SaveChanges();
                }
            }
        }

        private void сlearButton_Click(object sender, RoutedEventArgs e)
        {
            searchBox.Text = "";
            MainWindow main = new MainWindow(null);
            this.Close();
            main.Show();
        }

        private void addOrderButtonClick(object sender, RoutedEventArgs e)
        {
            new AddOrderWindow(null).ShowDialog();
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            using (KompicDbContext db = new KompicDbContext())
            {
                var order = (ordersGrid.SelectedItem) as Order;

                if (order != null)
                {

                    if (MessageBox.Show($"Вы точно хотите удалить {order.NameClient}", "Внимание!",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        db.Orders.Remove(order);
                        db.SaveChanges();
                        MessageBox.Show($"Товар {order.NameClient} удален!");
                        ordersGrid.ItemsSource = db.Orders.ToList();
                    }

                }
            }
        }
    }
}
