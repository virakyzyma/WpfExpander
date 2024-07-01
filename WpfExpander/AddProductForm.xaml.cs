using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfExpander
{
    /// <summary>
    /// Interaction logic for AddProductForm.xaml
    /// </summary>
    public partial class AddProductForm : Window
    {
        public event Action<Product> AddProduct;
        public AddProductForm()
        {
            InitializeComponent();
            addDatePicker.SelectedDate = DateTime.Now;
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }
            Product product = new Product(nameTextBox.Text, descriptionTextBox.Text, decimal.Parse(priceTextBox.Text), (DateTime)addDatePicker.SelectedDate);
            AddProduct(product);
            Close();
        }
        public bool ValidateFields()
        {
            if (string.IsNullOrEmpty(nameTextBox.Text) || string.IsNullOrEmpty(descriptionTextBox.Text) || string.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Поле продукта не указано");
                return false;
            }
            if (!decimal.TryParse(priceTextBox.Text, out decimal result))
            {
                MessageBox.Show("Неправильный формат цены");
                return false;
            }
            return true;
        }
    }
}