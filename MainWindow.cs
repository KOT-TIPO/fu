using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
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
using Yagnov.BDModel;

namespace Yagnov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        ShopDBEntities dbContext = new ShopDBEntities();

        public object ProductsDataGrid { get; private set; }
        private Users currentUser;
        public MainWindow(Users currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            MessageBox.Show(currentUser.Role.Role_Name);
        }



        private void LoadData()
        {

            try
            {
                var products = dbContext.Products.ToList();
                ProductDataGrid.ItemsSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ProductDataGrid.SelectedItem as Products;
            if (selectedProduct == null)
            {
                MessageBox.Show("Выберете товар для редактирования.");
                return;
            }
            AddOrEditWindow editWindow = new AddOrEditWindow(selectedProduct, dbContext);
            if (editWindow.ShowDialog() == true)
            {
                LoadData();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            AddOrEditWindow editWindow = new AddOrEditWindow(null, dbContext);
            if (editWindow.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ProductDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}


      