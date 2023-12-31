﻿using CordobaBryan16.Services;
using CordobaBryan16.Views;
using CordobaBryan16.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CordobaBryan16.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        #region Services        
        private readonly ProductService dataServiceProducts;
        #endregion Services

        #region Attributes

        private ObservableCollection<Product> products;

        #endregion Attributes

        #region Properties


        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { SetValue(ref this.products, value); }
        }




        #endregion Properties

        #region Command

        public ICommand NewProductCommand
        {
            get
            {
                return new Command(NeWProduct);
            }
        }

        public ICommand LoadProductsCommand
        {
            get
            {
                return new Command(LoadProducts);
            }
        }
        
        public ICommand DeleteProductCommand
        {
            get
            {
                return new Command((x) =>
                {
                    var item = (x as Product);
                    DeleteProduct(item);
                });
            }
            //get;
            //set;
        }
        
        public ICommand UpdateProductCommand
        {
            get
            {
                return new Command(async (x) =>
                {
                    var item = (x as Product);
                    await UpdateProduct(item);
                });
            }
        }
        
        #endregion

        #region Constructor
        public ProductsViewModel()
        {
            this.dataServiceProducts = new ProductService();

            this.LoadProducts();

        }
        #endregion Constructor



        #region Methods
        
        private void NeWProduct()
        {
            Product product = new Product();
            //product.Id = 0;
            /*
            product.Name = "";
            product.Description = "";
            product.ExpirationDate = DateTime.Today;
            product.IsNew = false;
            */
            Application.Current.MainPage.Navigation.PushAsync(new ProductPage(product));

            LoadProducts();

        }
        
        private async Task UpdateProduct(Product product)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ProductPage(product));

        }
        
        private async void DeleteProduct(Product product)
        {
            var id = product.id;
            await this.dataServiceProducts.DeleteProductItemAsync(id);
            LoadProducts();
        }
        
        public async void LoadProducts()
        {
            var productsRest = await this.dataServiceProducts.RefreshDataAsync();
            this.Products = new ObservableCollection<Product>(productsRest);
            /*
            this.Products = new ObservableCollection<Product>();
            foreach (var item in productsRest)
                Products.Add(item);
            */
        }
        #endregion Methods
    }
}
