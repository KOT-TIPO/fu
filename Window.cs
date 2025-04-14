using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Yagnov.BDModel;

namespace Yagnov
{
    /// <summary>
    /// Логика взаимодействия для Window.xaml
    /// </summary>
    public partial class Window 
    {
        public Window()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reg mainWindow = new Reg();
            mainWindow.Show();
        }
        ShopDBEntities dbContext = new ShopDBEntities();

        private List<IProduct> _products = new List<IProduct>();
        public object ProductsDataGrid;
        private Users currentUser;
        public Window(Users currentUser)
        {
            InitializeComponent();
            LoadData();
            this.currentUser = currentUser;
            MessageBox.Show(currentUser.Role.Role_Name);
                }

        private void LoadData()
        {
            try
            {
                var products = dbContext.Products.ToList();
                Product.ItemSourse = products;
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
    
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}

