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

        public string ItemCategoryName
        {
            get => categoriesname;
            set
            {
                if (categoriesname != value)
                {
                    categoriesname = value;
                    OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
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
                    OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
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
                    OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
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
                    OnPropertyChange(); /*OnPropertyChange(nameof(IsButtonEnabled));*/
                }
            }
        }

        
          public int ItemGenderId
        { get => genderid;
            set
            {
                {
                    if (gendername == "men")
                        genderid = 1;
                    else
                        genderid = 2;
                }
                if (genderid != value)
                {
                    genderid = value;
                    OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
                }
            }
        }

        public Gender ItemGender
        { get => gender; set
            {
                { gender.GenderId = genderid; gender.GenderName = gendername; }
                if (gender != value)
                {
                    gender = value;
                    OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
                }
            }
            }

        public int ItemCategortId
        {
            get => categoriesid;
            set
            {
                switch (categoriesname)
                {
                    case "Leotards":
                        categoriesid = 1;
                        OnPropertyChange(); break;
                    case "DanceShoes":
                        categoriesid = 2; break;
                    case "Accessories":
                        categoriesid = 3; break;
                    case "DanceClothes":
                        categoriesid = 4; break;
                }
                
                if (categoriesid != value)
                {
                    categoriesid = value;
                    OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
                }
            }
        }
           public Categories ItemCategory
        {
            get => categories;
            set
            {
                {
                    categories.CategoryId = categoriesid;
                    categories.CategoriesName = categoriesname;
                }
                if (categories != value)
                {
                    categories = value;
                    OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
                }
            }
            }

        public int ItemSizeId
        {
            get => sizeid;
            set
            {
                switch (sizename)
                {
                    case "Small":
                        sizeid = 1; break;
                    case "Medium":
                        sizeid = 2; break;
                    case "Large":
                        sizeid = 3; break;
                    case "35":
                        sizeid = 4; break;
                    case "36":
                        sizeid = 5; break;
                    case "37":
                        sizeid = 6; break;
                    case "38":
                        sizeid = 7; break;
                    case "39":
                        sizeid = 8; break;
                    case "40":
                        sizeid = 9; break;
                    case "41":
                        sizeid = 10; break;
                    case "42":
                        sizeid = 11; break;
                    case "43":
                        sizeid = 12; break;
                    case "44":
                        sizeid = 13; break;
                }
                if (sizeid != value)
                {
                    sizeid = value;
                    OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
                }

            }
        }

        public SizeItem ItemSize
        {
            get=> size;
            set
            {
                size.SizeItemId = sizeid;
                size.SizeName = sizename;
                if (size != value)
                {
                    size = value;
                    OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
                }
            } 
        }

        public int ItemColorId
        {
            get => colorid;
            set
            {
                switch (colorname)
                {
                    case "Black":
                        colorid = 1; break;
                    case "White":
                        colorid = 2; break;
                    case "Maroon":
                        colorid = 3; break;
                    case "DeepBlue":
                        colorid = 4; break;
                    case "Olive":
                        colorid = 5; break;
                    case "BabyPink":
                        colorid = 6; break;
                    case "LightPurple":
                        colorid = 7; break;
                    case "LightBlue":
                        colorid = 8; break;
                }
                if (colorid != value)
                {
                    colorid = value;
                    OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
                }
            }
        }

        public ColorItem ItemColor
        { get => color;
        set
            {
                color.ColorName = colorname;
                color.ColorItemId = colorid;
                if (color != value)
                {
                    color = value;
                    OnPropertyChange();  /*OnPropertyChange(nameof(IsButtonEnabled));*/
                }
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
                    Item NewItem = new Item();
                    { NewItem.ItemName = itemname;
                        NewItem.ItemDescription = description;
                        NewItem.Categories = categories;
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
