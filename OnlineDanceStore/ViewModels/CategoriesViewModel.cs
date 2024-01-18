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

namespace OnlineDanceStore.ViewModels
{
    public class CategoriesViewModel : ViewModel
    {
        #region Commands
        public ICommand GetItemByCategory { get; protected set; }
        #endregion
        public CategoriesViewModel(OnlineDanceStoreServices service)
        { }
    }
}
