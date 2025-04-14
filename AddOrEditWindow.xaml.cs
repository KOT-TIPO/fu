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
using System.Windows.Shapes;
using Yagnov.BDModel;

namespace Yagnov
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditWindow.xaml
    /// </summary>
    public partial class AddOrEditWindow 
    {

        ShopDBEntities _dbContext = new ShopDBEntities();
        private Products _product;
        public bool DialogResult { get; private set; }
        public AddOrEditWindow(Products selectedProduct, ShopDBEntities shopDB)
        {
            InitializeComponent();
            var _dbContext1 = _dbContext;
            if (_product != null)
            {
                NameTextBox.Text = _product.ProductName;
                PriceTextBox.Text = _product.Price.ToString();
                DescriptionTextBox.Text = _product.Description;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(NameTextBox.Text))
                {
                    MessageBox.Show("Введите название товара");
                    return;
                }
                if (!decimal.TryParse(PriceTextBox.Text, out decimal price))
                {
                    MessageBox.Show("Введите корректную цену товара.");
                    return;
                }
                if (_product == null)
                {
                    _product = new Products

                    {
                        ProductName = NameTextBox.Text,
                        price = price,
                        Description = DescriptionTextBox.Text
                    };
                    _dbContext.Products.Add(_product);
                }
                else
                {
                    _product.ProductName = NameTextBox.Text;
                    _product.Price = price;
                    _product.Description = DescriptionTextBox.Text;
                }
                _dbContext.SaveChanges();
                DialogResult = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении товара:{ex.Message}");
        }
    }
    }
}
