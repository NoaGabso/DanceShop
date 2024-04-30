using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OnlineDanceStore.Models;
using OnlineDanceStore.View;
using OnlineDanceStore.Services;
using System.Text.Json;
using System.Diagnostics;
using static Java.Util.Jar.Attributes;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;

namespace OnlineDanceStore.ViewModels
{
  public  class AdminPageViewModel: ViewModel
    {
        #region Fields
     
        private string itemname;
        private string description;
        private int quantity;
        private double price;
        private string image;
        private Categories categories;
        private int categoriesid;
        private string categoriesname;
        private Gender gender;
        private int genderid;
        private string gendername;
        private SizeItem size;
        private int sizeid;
        private string sizename;
        private ColorItem color;
        private int colorid;
        private string colorname;

        public string ItemName
        {
            get => itemname;
            set
            {
                if (itemname != value)
                {
                    itemname = value;
                    OnPropertyChange(); OnPropertyChange(nameof(IsButtonEnabled));
                }
            }
        }

        public int ItemQuantity
        {
            get => quantity;
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChange(); OnPropertyChange(nameof(IsButtonEnabled));
                }
            }
        }

        public double ItemPrice
        {
            get => price;
            set
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChange(); OnPropertyChange(nameof(IsButtonEnabled));
                }
            }
        }

        public string ItemImage
        {
            get => image;
            set
            {
                if (image != value)
                {
                    image = value;
                    OnPropertyChange(); OnPropertyChange(nameof(IsButtonEnabled));
                }
            }
        }

        public int ItemCategoryId
        {
            get => categoriesid;
            set
            {
                if (categoriesid != value)
                {
                    categoriesid = value;
                    OnPropertyChange(); OnPropertyChange(nameof(IsButtonEnabled));
                }
            }
        }

        public string ItemCategoryName
        {
            get => categoriesname;
            set
            {
                if (categoriesname != value)
                {
                    categoriesname = value;
                    OnPropertyChange(); OnPropertyChange(nameof(IsButtonEnabled));
                }
            }
        }

        public string ItemGenderName
        {
            get => gendername;
            set
            {
                if (gendername != value)
                {
                    gendername = value;
                    OnPropertyChange(); OnPropertyChange(nameof(IsButtonEnabled));
                }
            }
        }

        public string ItemSizeName
        {
            get => sizename;
            set
            {
                if (sizename != value)
                {
                    sizename = value;
                    OnPropertyChange(); OnPropertyChange(nameof(IsButtonEnabled));
                }
            }
        }

        public string ItemColorName
        {
            get => colorname;
            set
            {
                if (colorname != value)
                {
                    colorname = value;
                    OnPropertyChange(); OnPropertyChange(nameof(IsButtonEnabled));
                }
            }
        }


        #endregion

        private readonly OnlineDanceStoreServices _service;

        public bool IsButtonEnabled
        {
            get { return ValidatePage(); }
        }
        public AdminPageViewModel(OnlineDanceStoreServices service)
        {
            Item NewItem = new Item();
            _service = service;
            itemname = string.Empty;
            gendername = string.Empty;
            

            categories = new Categories(categoriesid, categoriesname);
            { if (gendername == "men")
                    genderid = 1;
                else
                    genderid = 2;
            }
            gender = new Gender(genderid, gendername);

            


        }

        private bool ValidateUser()
        {
            return !(string.IsNullOrEmpty(email) || email.Length < 3);
        }
        private bool ValidateName()
        {

            return !(string.IsNullOrEmpty(itemname) || itemname.Length < 3);
        }
        private bool ValidatePassWord()
        {
            return !(string.IsNullOrEmpty(password) || password.Length < 3);
        }

        private bool ValidatePage()
        {
            return ValidateName() && ValidatePassWord() && ValidateUser();
        }

    }
}
