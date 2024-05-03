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
using System.Reflection;

namespace OnlineDanceStore.ViewModels
{
    public class AdminPageViewModel : ViewModel
    {
        #region Fields

        private string itemname;
        private string description;
        private int quantity;
        private double price;
        private string image;
        //private Categories categories;
        private int categoriesid;
        private string categoriesname;
        //private Gender gender;
        private int genderid;
        private string gendername;
        //private SizeItem size;
        private int sizeid;
        private string sizename;
        //private ColorItem color;
        private int colorid;
        private string colorname;

        #region רגיל
        public string ItemName
        {
            get => itemname;
            set
            {
                if (itemname != value)
                {
                    itemname = value;
                    OnPropertyChange(); /*OnPropertyChange(nameof(IsButtonEnabled));*/
                }
            }
        }
        public string ItemDescription
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChange(); /*OnPropertyChange(nameof(IsButtonEnabled));*/
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
                    OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
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
                    OnPropertyChange(); /*OnPropertyChange(nameof(IsButtonEnabled));*/
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
                    OnPropertyChange(); /*OnPropertyChange(nameof(IsButtonEnabled));*/
                }
            }
        }
        #endregion

        #region category
        public string ItemCategoryName
        {
            get => categoriesname;
            set
            {
                if (categoriesname != value)
                {
                    categoriesname = value;
                    OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
                    ItemCategoryId = GetCategoryIdFromName(categoriesname);
                    //ItemCategory = GetCategory(categoriesid, categoriesname);
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
                    OnPropertyChange();
                }
            }
        }

        //public Categories ItemCategory
        //{
          
        //    get => categories;
        //    set
        //    {

        //        if (categories != value)
        //        {
        //            {
        //                categories = new Categories();
        //                categories.CategoryId = categoriesid;
        //                categories.CategoriesName = categoriesname;
        //            }
        //            categories = value;
        //            OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
        //        }
        //    }
        //}

        #endregion
        #region gender
        public string ItemGenderName
        {
            get => gendername;
            set
            {
                if (gendername != value)
                {
                    gendername = value;
                    OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
                    ItemGenderId = GetGenderIdFromName(value);
                }
            }
        }
        public int ItemGenderId
        {
            get => genderid;
            set
            {
                if (genderid != value)
                {
                    genderid = value;
                    OnPropertyChange();
                }
            }
        }

        //public Gender ItemGender
        //{
        //    get => gender; set
        //    {
               
        //        if (gender != value)
        //        {
        //            { gender.GenderId = genderid; gender.GenderName = gendername; }
        //            gender = value;
        //            OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
        //        }
        //    }
        //}
        #endregion
        #region size
        public string ItemSizeName
        {
            get => sizename;
            set
            {
                if (sizename != value)
                {
                    sizename = value;
                    OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
                    ItemSizeId = GetSizeIdFromName(value);
                }
            }
        }
        public int ItemSizeId
        {
            get => sizeid;
            set
            {
                if (sizeid != value)
                {
                    sizeid = value;
                    /*OnPropertyChange(nameof(IsButtonEnabled));*/
                    OnPropertyChange();
                }
            }
        }
    

        //public SizeItem ItemSize
        //{
        //    get => size;
        //    set
        //    {
                
        //        if (size != value)
        //        {
        //            size.SizeItemId = sizeid;
        //            size.SizeName = sizename;
        //            size = value;
        //            OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
        //        }
        //    }
        //}
        #endregion
        #region color
        public string ItemColorName
        {
            get => colorname;
            set
            {
                if (colorname != value)
                {
                    colorname = value;
                    OnPropertyChange(); /*OnPropertyChange(nameof(IsButtonEnabled));*/
                    ItemColorId = GetColorIdFromName(value);
                }
            }
        }
        public int ItemColorId
        {
            get => colorid;
            set
            {
                if (colorid != value)
                {
                    colorid = value;
                    // Add logic to set colorname based on colorid, similar to other properties
                    OnPropertyChange();
                }
            }
        }

        //public ColorItem ItemColor
        //{ get => color;
        //set
        //    {

        //        if (color != value)
        //        {
        //            color.ColorName = colorname;
        //            color.ColorItemId = colorid;
        //            color = value;
        //            OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
        //        }
        //    }
        //     }
        #endregion

        #endregion
        #region פעולות עזר
        private int GetGenderIdFromName(string name)
        {
            // Implement logic to map gender name to id
            // For example:
            switch (name.ToLower())
            {
                case "men":
                    return 1;
                case "women":
                    return 2;
                default:
                    return 0; // Default value or handle invalid name
            }
        }

        private int GetCategoryIdFromName(string name)
        {
            // Implement logic to map category name to id
            // For example:
            switch (name.ToLower())
            {
                case "leotards":
                    return 1;
                case "danceshoes":
                    return 2;
                case "accessories":
                    return 3;
                case "danceclothes":
                    return 4;
                default:
                    return 0; // Default value or handle invalid name
            }
        }
        private int GetSizeIdFromName(string name)
        {
            // Implement logic to map size name to id
            // For example:
            switch (name.ToLower())
            {
                case "small":
                    return 1;
                case "medium":
                    return 2;
                case "large":
                    return 3;
                case "35":
                    return 4;
                case "36":
                    return 5;
                case "37":
                    return 6;
                case "38":
                    return 7;
                case "39":
                    return 8;
                case "40":
                    return 9;
                case "41":
                    return 10;
                case "42":
                    return 11;
                case "43":
                    return 12;
                case "44":
                    return 13;
                default:
                    return 0; // Default value or handle invalid name
            }
        }

        private int GetColorIdFromName(string name)
        {
            // Implement logic to map color name to id
            // For example:
            switch (name.ToLower())
            {
                case "black":
                    return 1;
                case "white":
                    return 2;
                case "maroon":
                    return 3;
                case "deepblue":
                    return 4;
                case "olive":
                    return 5;
                case "babypink":
                    return 6;
                case "lightpurple":
                    return 7;
                case "lightblue":
                    return 8;
                default:
                    return 0; // Default value or handle invalid name
            }
        }
        #endregion

        private readonly OnlineDanceStoreServices _service;
        public ICommand NewItemCommand { get; protected set; }

        //public bool IsButtonEnabled
        //{
        //    get { return ValidatePage(); }
        //}
        //public AdminPageViewModel() { }
        public AdminPageViewModel(OnlineDanceStoreServices service)
        {

            _service = service;
            itemname = string.Empty;
            description = string.Empty;
            categoriesname = string.Empty;
            gendername = string.Empty;
            sizename = string.Empty;
            colorname = string.Empty;
            image = string.Empty;


            NewItemCommand = new Command(async () =>
            {
                try
                {
                    //#region טעינת מסך ביניים
                    //var lvm = new LoadingPageViewModel() { IsBusy = true };
                    //await AppShell.Current.Navigation.PushModalAsync(new LoadingPage(lvm));
                    //#endregion

                    Categories category = new Categories();
                    {
                        category.CategoryId = categoriesid;
                        category.CategoriesName = categoriesname;}

                    Gender gender = new Gender();
                    { gender.GenderId = genderid; gender.GenderName = gendername; }

                    SizeItem size= new SizeItem();
                    {
                        size.SizeItemId = sizeid;
                        size.SizeName = sizename;}

                    ColorItem color= new ColorItem();
                    {
                        color.ColorName = colorname;
                       color.ColorItemId = colorid;}

                        Item NewItem = new Item();
                    { NewItem.ItemName = itemname;
                        NewItem.ItemDescription = description;
                        NewItem.Categories = category;
                        NewItem.Quantity = quantity;
                        NewItem.Price = price;
                        NewItem.ItemImage = image;
                        NewItem.Gender = gender;
                        NewItem.SizeItem = size;
                        NewItem.ColorItem = color;
                }
               
                }
                // //var it = await _service.NewItem(item);

                // lvm.IsBusy = false;
                // await Shell.Current.Navigation.PopModalAsync();
                //// if (!it.Success)
                // {
                //     //ShowRegisterError = true;
                //     //RegisterErrorMessage = u.Message;
                // }
                // else
                // {
                //     await AppShell.Current.DisplayAlert("הוסף", "אישור הכנסת מוצר", "אישור");
                //   //  await SecureStorage.Default.SetAsync("RegistedUser", JsonSerializer.Serialize(u.User));

                // }

                catch (Exception ex)
                {

                    Debug.WriteLine(ex.Message);

                    //await AppShell.Current.Navigation.PopModalAsync();
                }


            });
        }

        //    //private bool ValidateUser()
        //    //{
        //    //    return !(string.IsNullOrEmpty(email) || email.Length < 3);
        //    //}
        //    //private bool ValidateName()
        //    //{

        //    //    return !(string.IsNullOrEmpty(itemname) || itemname.Length < 3);
        //    //}
        //    //private bool ValidatePassWord()
        //    //{
        //    //    return !(string.IsNullOrEmpty(password) || password.Length < 3);
        //    //}

        //    //private bool ValidatePage()
        //    //{
        //    //    return ValidateName() && ValidatePassWord() && ValidateUser();
        //    //}

        //}
    }
}
