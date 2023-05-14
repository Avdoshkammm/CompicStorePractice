using NewCompicStore.Models;
using System;
using System.Text;
using System.Windows;

namespace NewCompicStore
{
    /// <summary>
    /// Логика взаимодействия для AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        public AddOrderWindow(Order o)
        {
            InitializeComponent();
            Order? currentOrder;
            this.Title = "Добавление заказа";

            using (KompicDbContext db = new KompicDbContext())
            {
                
            }

            Order order = new Order();

            if (order != null)
            {
                currentOrder = order;
                this.Title = "Редактирование товара";
                DataContext = currentOrder;
            }

        }

        private void saveProductButtonClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(nameBox.Text))
                errors.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(surnameBox.Text))
                errors.AppendLine("Укажите фамилию");
            if (string.IsNullOrWhiteSpace(costBox.Text))
                errors.AppendLine("Укажите цену");
            if (string.IsNullOrWhiteSpace(phonenumBox.Text))
                errors.AppendLine("Укажите номер телефона");
            if (string.IsNullOrWhiteSpace(Status.Text))
                errors.AppendLine("Укажите статус (готов/не готов)");
            if (string.IsNullOrWhiteSpace(descriptionBox.Text))
                errors.AppendLine("Укажите описание");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            using (KompicDbContext db = new KompicDbContext())
            {
                DateTime dt = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                //Console.WriteLine(DateTime.Now.ToLongDateString());
                try
                {
                    Order order = new Order()
                    {
                        NameClient = nameBox.Text,
                        SurnameClient = surnameBox.Text,
                        FinalPrice = Convert.ToDecimal(costBox.Text),
                        PhoneNumber = Convert.ToInt32(phonenumBox.Text),
                        Status = Status.Text,
                        Description = descriptionBox.Text,
                        DataOrder = dt,
                    };
                    db.Orders.Add(order);
                    db.SaveChanges();
                    MessageBox.Show("Заказ был успешно добавлен");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                }
            }
            this.Close();
        }
    }
}
