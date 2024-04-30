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
        public ICommand NewItemCommand { get; protected set; }

        //public bool IsButtonEnabled
        //{
        //    get { return ValidatePage(); }
        //}
        public AdminPageViewModel(OnlineDanceStoreServices service)
        {
            Item NewItem = new Item();
            _service = service;
            itemname = string.Empty;
            gendername = string.Empty;


            
            { if (gendername == "men")
                    genderid = 1;
                else
                    genderid = 2;
            }

            switch (categoriesname)
            {
                case "Leotards":
                    categoriesid = 1; break;
                case "DanceShoes":
                    categoriesid = 2; break;
                case "Accessories":
                    categoriesid = 3; break;
                case "DanceClothes":
                    categoriesid = 4; break;
            }   
                    categories = new Categories();
            {
                categories.CategoryId = categoriesid;
                categories.CategoriesName = categoriesname;
            }

            gender = new Gender();
            { gender.GenderId = genderid;
                gender.GenderName = gendername;
            }

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

            size = new SizeItem();
            {
                size.SizeItemId = sizeid;
                size.SizeName=sizename;
            }

            switch (colorname)
            {
                case "Black":
                    sizeid = 1; break;
                case "White":
                    sizeid = 2; break;
                case "Maroon":
                    sizeid = 3; break;
                case "DeepBlue":
                    sizeid = 4; break;
                case "Olive":
                    sizeid = 5; break;
                case "BabyPink":
                    sizeid = 6; break;
                case "LightPurple":
                    sizeid = 7; break;
                case "LightBlue":
                    sizeid = 8; break;
            }

            color = new ColorItem();
            { color.ColorName = colorname;
                color.ColorItemId = colorid;
            }
        

            NewItemCommand = new Command(async () =>
            {
                try
                {
                    //#region טעינת מסך ביניים
                    //var lvm = new LoadingPageViewModel() { IsBusy = true };
                    //await AppShell.Current.Navigation.PushModalAsync(new LoadingPage(lvm));
                    //#endregion
                    Item item = new Item();
                    {
                        item.ItemName = itemname;
                        item.ItemDescription = description;
                        item.Categories = categories;
                        item.Quantity = quantity;
                        item.Price = price;
                        item.ItemImage = image;
                        item.Gender = gender;
                        item.SizeItem = size;
                        item.ColorItem = color;
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



                }
                catch (Exception ex)
                {

                    Debug.WriteLine(ex.Message);

                    await AppShell.Current.Navigation.PopModalAsync();
                }


            });


        }

        //private bool ValidateUser()
        //{
        //    return !(string.IsNullOrEmpty(email) || email.Length < 3);
        //}
        //private bool ValidateName()
        //{

        //    return !(string.IsNullOrEmpty(itemname) || itemname.Length < 3);
        //}
        //private bool ValidatePassWord()
        //{
        //    return !(string.IsNullOrEmpty(password) || password.Length < 3);
        //}

        //private bool ValidatePage()
        //{
        //    return ValidateName() && ValidatePassWord() && ValidateUser();
        //}

    }
}
