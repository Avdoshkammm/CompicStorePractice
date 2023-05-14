# NewCompicStore
# Первое - создание приложения.
### Создать wpf(Майкрософт)
# Второе - Создать базу данных и таблицы в ней
### Если в приложении используются картинки, то мы должны изменить им следующие свойства:
### "Действия при сборке" - "Ресурс"
### "Копировать в выходной каталог" - "Копировать более новую версию"
# Второе - nuget пакеты
##
* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Tools
### Далее мы должны создать подключение к бд
### Что бы его осуществить, мы должны создать config-файл
###<add
###			name="LocalDBConnection"
###			connectionString="Server=(localdb)\mssqllocaldb;Database=NameDB;Trusted_Connection=True;"
###			providerName="System.Data.SqlClient"/>
##
### Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=NameOfDataBase;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
# LoginWindow
#### После мы должны подключить базу данных в коде для дальнейшего взаимодействия следующим образом:
## using(NameOfDBContext db = new NameOfDBContext())
### Если в приложении предусмотрена авторизация, то выполняем следующий запрос:
### название класса(наприемр User)
##
## User user = db.Users.Where(u => u.Login == loginbox.Text && u.Password == passwordBox.Password).FirstOrDefault() as User;
##
## if(user != null)
## {
##	MainWindow main = new MainWindow(null[тут так же можно использовать user, если во втором окне оно используется]);
##   main.Show();
##   this.Close();
## }
#
### MainWindow 
#
# Есть 2 способа вывода. Это или плитками, как в SportStore, или же списком как диспетчер задач. 
# Они отличаются тем, что в listviev можон добавлять картинки. А datagrid в своё время поле разбивается на колонки, 
# названия которых указываются в названии столбцов БД
#
# Кстати, лучше использовать stackpanel. Вот её примерный код:
#
#
# <StackPanel
#                        VerticalAlignment="Center"
#                        HorizontalAlignment="Center"
#                        Grid.Column="0">
#
# </StaclPanel>
#
# Что оно делает? Оно разбивает окно на своебразные полоски. Ими можно спамить до бесконечности, в пределах разумного
#
# Теперь вернемся к 2-м типам вывода данных.
#
#					 <Grid Background="Lavender">
#                        <DataGrid Grid.Row="1" x:Name="ordersGrid" AutoGenerateColumns="True" IsReadOnly="True"/>
#                    </Grid>
#
# В данном случае показан пример вывода диспетчера задач. Что бы его использовать, не нужно в разметке указывать поля с бд
#
# ordersGrid.ItemsSource = db.Orders.ToList();
#
# Теперь по-подробнее о каждом элементе. 
# ordersGrid - название 
# ItemsSource - просто обозначение, что вот оно будет выводиться на экран в таком формате.
# db - мы указывали когда использовали контекст базы данных
#
#