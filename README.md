# NewCompicStore
# ������ - �������� ����������.
### ������� wpf(����������)
# ������ - ������� ���� ������ � ������� � ���
### ���� � ���������� ������������ ��������, �� �� ������ �������� �� ��������� ��������:
### "�������� ��� ������" - "������"
### "���������� � �������� �������" - "���������� ����� ����� ������"
# ������ - nuget ������
##
* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Tools
### ����� �� ������ ������� ����������� � ��
### ��� �� ��� �����������, �� ������ ������� config-����
###<add
###			name="LocalDBConnection"
###			connectionString="Server=(localdb)\mssqllocaldb;Database=NameDB;Trusted_Connection=True;"
###			providerName="System.Data.SqlClient"/>
##
### Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=NameOfDataBase;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
# LoginWindow
#### ����� �� ������ ���������� ���� ������ � ���� ��� ����������� �������������� ��������� �������:
## using(NameOfDBContext db = new NameOfDBContext())
### ���� � ���������� ������������� �����������, �� ��������� ��������� ������:
### �������� ������(�������� User)
##
## User user = db.Users.Where(u => u.Login == loginbox.Text && u.Password == passwordBox.Password).FirstOrDefault() as User;
##
## if(user != null)
## {
##	MainWindow main = new MainWindow(null[��� ��� �� ����� ������������ user, ���� �� ������ ���� ��� ������������]);
##   main.Show();
##   this.Close();
## }
#
### MainWindow 
#
# ���� 2 ������� ������. ��� ��� ��������, ��� � SportStore, ��� �� ������� ��� ��������� �����. 
# ��� ���������� ���, ��� � listviev ����� ��������� ��������. � datagrid � ��� ����� ���� ����������� �� �������, 
# �������� ������� ����������� � �������� �������� ��
#
# ������, ����� ������������ stackpanel. ��� � ��������� ���:
#
#
# <StackPanel
#                        VerticalAlignment="Center"
#                        HorizontalAlignment="Center"
#                        Grid.Column="0">
#
# </StaclPanel>
#
# ��� ��� ������? ��� ��������� ���� �� ����������� �������. ��� ����� ������� �� �������������, � �������� ���������
#
# ������ �������� � 2-� ����� ������ ������.
#
#					 <Grid Background="Lavender">
#                        <DataGrid Grid.Row="1" x:Name="ordersGrid" AutoGenerateColumns="True" IsReadOnly="True"/>
#                    </Grid>
#
# � ������ ������ ������� ������ ������ ���������� �����. ��� �� ��� ������������, �� ����� � �������� ��������� ���� � ��
#
# ordersGrid.ItemsSource = db.Orders.ToList();
#
# ������ ��-��������� � ������ ��������. 
# ordersGrid - �������� 
# ItemsSource - ������ �����������, ��� ��� ��� ����� ���������� �� ����� � ����� �������.
# db - �� ��������� ����� ������������ �������� ���� ������
#
#