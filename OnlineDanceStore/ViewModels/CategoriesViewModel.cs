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

namespace OnlineDanceStore.ViewModels
{
    public class CategoriesViewModel : ViewModel
    {
        #region Fields
        private int _categoryid;
        private int _subcategoryid;
      
        #endregion
        #region Properties
        public int CategoryId { get=>_categoryid; set { _categoryid = value; } }
        public int SubCategoryId { get=>_subcategoryid; set { _subcategoryid = value; } }
        public ObservableCollection<Item> Items { get; set; }
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
        public CategoriesViewModel(OnlineDanceStoreServices service)
        {
            CategoryId =0;
            SubCategoryId =0;
            _service = service;
            GetItemByCategoryCommand = new Command(async () =>
            {
                try
                {
                    var listofitems = await _service.GetItemsByCategory(CategoryId);
                    Items = new ObservableCollection<Item>(listofitems);
                    OnPropertyChange(nameof(Items));
                }
                catch (Exception ex) { }
            });

            GetItemBySubCategoryCommand = new Command(async () =>
            {
                try
                {
                    var listofitems = await _service.GetItemsBySubCategory(CategoryId, SubCategoryId);
                    Items = new ObservableCollection<Item>(listofitems);
                    OnPropertyChange(nameof(Items));
                }
                catch (Exception ex) { }
            });

            GetItemsForWomenCommand = new Command(async () =>
            {
                try
                {
                    var listofitems = await _service.GetItemsForWomen();
                    Items = new ObservableCollection<Item>(listofitems);
                    OnPropertyChange(nameof(Items));
                }
                catch (Exception ex) { }
            });

            GetItemsForMenCommand = new Command(async () =>
            {
                try
                {
                    var listofitems = await _service.GetItemsForMen();
                    Items = new ObservableCollection<Item>(listofitems);
                    OnPropertyChange(nameof(Items));
                }
                catch (Exception ex) { }
            });

            GetAllLeotardsCommand = new Command(async () =>
            {
                try
                {
                    var listofitems = await _service.GetAllLeotards();
                    Items = new ObservableCollection<Item>(listofitems);
                    OnPropertyChange(nameof(Items));
                }
                catch (Exception ex) { }
            });

            GetAllDancingShoesCommand = new Command(async () =>
            {
                try
                {
                    var listofitems = await _service.GetAllDancingShoes();
                    Items = new ObservableCollection<Item>(listofitems);
                    OnPropertyChange(nameof(Items));
                }
                catch (Exception ex) { }
            });

            GetAllAccessoriesCommand = new Command(async () =>
            {
                try
                {
                    var listofitems = await _service.GetAllAccessories();
                    Items = new ObservableCollection<Item>(listofitems);
                    OnPropertyChange(nameof(Items));
                }
                catch (Exception ex) { }
            });


        }
    }
}
