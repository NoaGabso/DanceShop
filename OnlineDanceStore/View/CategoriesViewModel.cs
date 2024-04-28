using OnlineDanceStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OnlineDanceStore.Models;
using OnlineDanceStore.View.Categories;
using System.Text.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;

namespace OnlineDanceStore.ViewModels
{
    public class CategoriesViewModel : ViewModel
    {
        #region Fields
        private int _categoryid;
        private int _subcategoryid;
        private string _shoesize;

        private bool _showSizeError;//האם להציג שגיאת סיסמה
        private string _sizeErrorMessage;
        #endregion
        #region Properties
        public int CategoryId { get => _categoryid; set { _categoryid = value; } }
        public int SubCategoryId { get => _subcategoryid; set { _subcategoryid = value; } }
        public bool ShowPasswordError { get => _showSizeError; set { if (_showSizeError != value) { _showSizeError = value; OnPropertyChange(); } } }
        public string PasswordErrorMessage { get => _sizeErrorMessage; set { if (_sizeErrorMessage != value) { _sizeErrorMessage = value; OnPropertyChange(); } } }
        public string ShoeSize
        {
            get => _shoesize;
            set
            {
                if (_shoesize != value)
                {
                    _shoesize = value; if (!ValidateSize())
                    {
                        ShowPasswordError = true;
                        PasswordErrorMessage = ErrorMessages.INVALID_PASSWORD;
                    }
                    else
                    {
                        PasswordErrorMessage = string.Empty;
                        ShowPasswordError = false;
                    };
                    OnPropertyChange();
                    OnPropertyChange(nameof(IsButtonEnabled));
                }
            }
        }
        public bool IsButtonEnabled { get { return ValidateSize(); } }

        private ShoppingCart ShoppingCart;
        public ObservableCollection<Item> Items { get; set; }

        public List<Item> filsterlist { get; set; }
        public List<Item> listofitems { get; set; }
    
        #endregion
        #region Service component
        private readonly OnlineDanceStoreServices _service;
        #endregion
        #region Commands
        public ICommand GetItemByCategoryCommand { get; protected set; }
        public ICommand GetItemBySubCategoryCommand { get; protected set; }
        public ICommand GetItemsForWomenCommand { get; protected set; }
        public ICommand GetItemsForMenCommand { get; protected set; }
        public ICommand GetAllLeotardsCommand { get; protected set; }
        public ICommand GetAllDancingShoesCommand { get; protected set; }
        public ICommand GetAllAccessoriesCommand { get; protected set; }
        #endregion
        public ICommand AddToCartCommand { get; protected set; }
        public ICommand FilterBySizeCommand { get; protected set; }
        public ICommand FilterByGenderCommand { get; protected set; }

        public CategoriesViewModel(OnlineDanceStoreServices service, Models.ShoppingCart cart)
        {
            ShoppingCart = cart;
            CategoryId = 0;
            SubCategoryId = 0;
            _service = service;
            GetItemByCategoryCommand = new Command(async () =>
            {
                try
                {
                    listofitems = await _service.GetItemsByCategory(CategoryId);

                    Items = new ObservableCollection<Item>(listofitems);
                    OnPropertyChange(nameof(Items));
                }
                catch (Exception ex) { }
            });

            GetItemBySubCategoryCommand = new Command(async () =>
            {
                try
                {
                    listofitems = await _service.GetItemsBySubCategory(CategoryId, SubCategoryId);
                    Items = new ObservableCollection<Item>(listofitems);
                    OnPropertyChange(nameof(Items));
                }
                catch (Exception ex) { }
            });

            GetItemsForWomenCommand = new Command(async () =>
            {
                try
                {
                    listofitems = await _service.GetItemsByGender(2);
                    Items = new ObservableCollection<Item>(listofitems);
                    OnPropertyChange(nameof(Items));
                }
                catch (Exception ex) { }
            });

            GetItemsForMenCommand = new Command(async () =>
            {
                try
                {
                    listofitems = await _service.GetItemsByGender(1);
                    Items = new ObservableCollection<Item>(listofitems);
                    OnPropertyChange(nameof(Items));
                }
                catch (Exception ex) { }
            });

            GetAllLeotardsCommand = new Command(async () =>
            {
                try
                {
                    listofitems = await _service.GetItemsByCategory(1);
                    //foreach(var item in listofitems)
                    //{
                    //    item.ItemImage = $"{service.IMAGE_URL}{item.ItemImage}";
                    //}
                    Items = new ObservableCollection<Item>(listofitems);
                    OnPropertyChange(nameof(Items));
                }
                catch (Exception ex) { }
            });

            GetAllDancingShoesCommand = new Command(async () =>
            {
                try
                {
                    listofitems = await _service.GetItemsByCategory(2);
                    Items = new ObservableCollection<Item>(listofitems);
                    OnPropertyChange(nameof(Items));
                }
                catch (Exception ex) { }
            });

            GetAllAccessoriesCommand = new Command(async () =>
            {
                try
                {
                    listofitems = await _service.GetItemsByCategory(3);
                    Items = new ObservableCollection<Item>(listofitems);
                    OnPropertyChange(nameof(Items));
                }
                catch (Exception ex) { }
            });

            AddToCartCommand = new Command<Item>(async (item) =>
            {
                ShoppingCart.Cart.Add(item); await AppShell.Current.DisplayAlert("המוצר  נוסף בהצלחה", "", "אישור");

            });
          

            FilterBySizeCommand = new Command<string>(async (x) => await FilterBySize(x));
            FilterByGenderCommand = new Command<string>(async (x) => await FilterByGender(x));
        }
       private async Task FilterBySize(string size)
        {
            filsterlist = listofitems;
            filsterlist= listofitems.Where(x=> x.SizeItem.SizeName==size).ToList();
            Items.Clear();
            foreach (var item in filsterlist)
            {
               Items.Add(item);
            }
            OnPropertyChange(nameof(Items));
        }
        private async Task FilterByGender(string gender)
        {
            filsterlist = listofitems;
            filsterlist = listofitems.Where(x => x.Gender.GenderName == gender).ToList();
            Items.Clear();
            foreach (var item in filsterlist)
            {
                Items.Add(item);
            }
            OnPropertyChange(nameof(Items));
        }
        private bool ValidateSize()
        {
         
            return !string.IsNullOrEmpty(ShoeSize) && (ShoeSize.StartsWith("3") || ShoeSize.StartsWith("4"))
                && (ShoeSize.Length == 2);

        }
      
    }
}
