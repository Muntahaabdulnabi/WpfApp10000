using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
using WpfApp10000.Models;
using WpfApp10000.Services;

namespace WpfApp10000
{
    public partial class MainWindow : Window
    {
        private readonly CustomerService _customerService;
        private readonly ProductService _productService;
        public MainWindow(CustomerService customerService, ProductService productService)
        {
            InitializeComponent();
            _customerService = customerService;
            _productService = productService;
            PopulateCustomers().ConfigureAwait(false);
        }

        public async Task PopulateCustomers()
        {
            var collection = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (var customer in await _customerService.GetAll())
                collection.Add(new KeyValuePair<string, int>(customer.CustomerName, customer.Id));

            cb_customers.ItemsSource = collection;
        }

        public async Task PopulateProducts()
        {
            var collection = new ObservableCollection<KeyValuePair<string, Guid>>();
            foreach (var product in await _productService.GetAll())
                collection.Add(new KeyValuePair<string, int>(product.Name, product.Id));

            cb_customers.ItemsSource = collection;
        }
        private async void btn_save_Click(object sender, RoutedEventArgs e)
        {
            await
        }

    }
    }
}
