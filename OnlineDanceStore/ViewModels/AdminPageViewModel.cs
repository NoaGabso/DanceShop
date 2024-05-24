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
using Plugin.Media;
using System.Collections.ObjectModel;

namespace OnlineDanceStore.ViewModels
{
    public class AdminPageViewModel : ViewModel
    {
        #region Fields
        private Item NewItem;
        private string itemname;
        private string description;
        private int quantity;
        private double price;
        private string image;
        private Categories categories1;
        private SubCategory subcategory1;
        private Gender gender1;
        private SizeItem size1;
        private ColorItem color1;
       
        private ObservableCollection<Categories> categories;
        private ObservableCollection<SubCategory> subCategories;
        private ObservableCollection<ColorItem> colors;
        private ObservableCollection<SizeItem> sizeitem;
        private ObservableCollection<Gender> gender;
        private string imagepath;

        private FileResult photo;
        public string ImageLocation { get => image; set { if (value != image) { image = value; OnPropertyChange(); } } }
        public ImageSource PhotoImageSource { get; set; }

        public ObservableCollection<Categories> Categories1 { get => categories; set { if (value != categories) { categories = value; OnPropertyChange(); } } }
        public ObservableCollection<SubCategory> SubCategories1 { get => subCategories; set { if (value != subCategories) { subCategories = value; OnPropertyChange(); } } }
        public ObservableCollection<ColorItem> ColorItems1 { get => colors; set { if (value != colors) { colors = value; OnPropertyChange(); } } }
        public ObservableCollection<SizeItem> SizeItems1 { get => sizeitem; set { if (value != sizeitem) { sizeitem = value; OnPropertyChange(); } } }
        public ObservableCollection<Gender> Genders1 { get => gender; set { if (value != gender) { gender = value; OnPropertyChange(); } } }
        public SetUpData SetUpData {get; set; }
        public Categories newCategory { get => categories1; set { if (value != categories1) { categories1 = value; OnPropertyChange(); } } }
        public SubCategory newSubCategory { get => subcategory1; set { if (value != subcategory1) { subcategory1 = value; OnPropertyChange(); } } }
        public ColorItem newColor { get => color1; set { if (value != color1) { color1 = value; OnPropertyChange(); } } }
        public SizeItem newSize { get => size1; set { if (value != size1) { size1 = value; OnPropertyChange(); } } }
        public Gender newGender { get => gender1; set { if (value != gender1) { gender1 = value; OnPropertyChange(); } } }

        #endregion

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

        public async Task GetSetUpData()
        {
            try
            {
                var setup = await _service.GetSetUpData();
                Categories1 = new ObservableCollection<Categories>(setup.Categories);
               SubCategories1 = new ObservableCollection<SubCategory>(setup.SubCategories);
                ColorItems1 = new ObservableCollection<ColorItem>(setup.ColorItems);
                SizeItems1 = new ObservableCollection<SizeItem>(setup.SizeItems);
                Genders1 = new ObservableCollection<Gender>(setup.Genders);
                //להכניס לאובסרבסל

            }
            catch (Exception ex)
            { await Shell.Current.DisplayAlert("something went wrong", "Unable to get setup Data", "Ok"); }
        }
        #endregion
       

        private readonly OnlineDanceStoreServices _service;
        public ICommand NewItemCommand { get; protected set; }
        public ICommand UploadPhoto { get; protected set; }
        public ICommand TakePictureCommand { get; protected set; }
        public ICommand ChangePhoto { get; protected set; }
        public ICommand SetUpDataCommand { get; protected set; }

        //public bool IsButtonEnabled
        //{
        //    get { return ValidatePage(); }
        //}
      
        public AdminPageViewModel(OnlineDanceStoreServices service)
        {
            
            _service = service;
            itemname = string.Empty;
            description = string.Empty;
            image = string.Empty;

            UploadPhoto = new Command(async () => { await Shell.Current.DisplayAlert("g", "g", "ok"); });
            TakePictureCommand = new Command(TakePicture);
            ChangePhoto = new Command(TakePicture);

    
            
            NewItemCommand = new Command(async () =>
            {
                try
                {
                    #region טעינת מסך ביניים
                    var lvm = new LoadingPageViewModel() { IsBusy = true };
                    await AppShell.Current.Navigation.PushModalAsync(new LoadingPage(lvm));
                    #endregion



                    NewItem = new Item();
                    { NewItem.ItemName = itemname;
                        NewItem.ItemDescription = description;
                        NewItem.Categories = newCategory;
                        NewItem.SubCategory= newSubCategory;
                        NewItem.Quantity = quantity;
                        NewItem.Price = price;
                        NewItem.ItemImage = image;
                        NewItem.Gender = newGender;
                        NewItem.SizeItem = newSize;
                        NewItem.ColorItem = newColor;
                }
                    await Upload(photo);
                    var it = await _service.UploadFile( photo, NewItem);
                    lvm.IsBusy = false;

                    if (it==null)
                    {
                       await Shell.Current.DisplayAlert("לא נתמך", "המוצר לא הועלה", "אישור");
                    }
                    else
                    {
                        await AppShell.Current.DisplayAlert("הוסף", "אישור הכנסת מוצר", "אישור");
                        imagepath = it.ItemImage;
                        if (!string.IsNullOrEmpty(imagepath))
                        {
                            await ShowImageAsync();
                        }

                    }

                }
                //    var it = await _service.NewItem(item,photo);

                //lvm.IsBusy = false;
                //await Shell.Current.Navigation.PopModalAsync();
                //// if (!it.Success)
                //{
                //    //ShowRegisterError = true;
                //    //RegisterErrorMessage = u.Message;
                //}
                //     else
                //{
                //    await AppShell.Current.DisplayAlert("הוסף", "אישור הכנסת מוצר", "אישור");
                //    //  await SecureStorage.Default.SetAsync("RegistedUser", JsonSerializer.Serialize(u.User));

                //}

                catch (Exception ex)
                {

                    Debug.WriteLine(ex.Message);

                    //await AppShell.Current.Navigation.PopModalAsync();
                }


            });
        }
        public async Task<string> ShowImageAsync()
        {
            // כאן תכלול את הלוגיקה למציאת והחזרת נתיב התמונה
            // נניח שהשיטה הזו עושה עבודה כלשהי שהיא אסינכרונית
            await Task.Delay(100); // סימולציה של פעולה אסינכרונית
            return imagepath;
        }
        private async Task PickPhoto()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                // Display an error message or handle the case where picking a photo is not supported
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;

            // Save the file path or do something with the image
            string filePath = file.Path;
        }
        private async void TakePicture()
        {
            try
            {
                

                //אם יש תמיכה במצלמה
                //יש לשים לב שעל מנת שיהיה ניתן להשתמש במצלמה צריך לתת הרשאות
                //https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/device-media/picker?tabs=android#tabpanel_1_android

                if (MediaPicker.Default.IsCaptureSupported)
                {
                    //חייבים להריץ ב
                    //UI
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        photo = await MediaPicker.Default.CapturePhotoAsync();
                       
                        #region מסך טעינה
                        var lvm = new LoadingPageViewModel() { IsBusy = true };
                        await Task.Delay(1000);
                        await Shell.Current.Navigation.PushModalAsync(new LoadingPage(lvm));
                        #endregion

                        //הצגת התמונה במסך ושליחתה לממשק.
                        await LoadPhoto(photo);

                        #region סגירת מסך טעינה
                        lvm.IsBusy = false;
                        await Shell.Current.Navigation.PopModalAsync();
                        #endregion

                    });
                }
                else
                    Shell.Current.DisplayAlert("לא נתמך", "כרגע לא ניתן להשתמש", "אישור");

            }
            catch(Exception ex) {  }

             

        }

        private async Task LoadPhoto(FileResult photo)
        {
            try
            { 
                var stream = await photo.OpenReadAsync();
                PhotoImageSource = ImageSource.FromStream(() => stream);
                OnPropertyChange(nameof(PhotoImageSource));
               // await Upload(photo);


            }
            catch (Exception ex) { }
        }
        private async Task Upload(FileResult file)
        {

            try
            { //bool success = await _service.UploadPhoto(file);
                NewItem = await _service.UploadFile(file, NewItem);
                if (NewItem!=null)
                {
                    ImageLocation = await _service.GetImage() + $"{NewItem.ItemName}.jpg";
                }
                else
                    Shell.Current.DisplayAlert("אין קשר לשרת", "לא הצלחתי להעלות את התמונה. נסה שוב", "אישור");
            }
            catch (Exception ex) { }

        }
      

    }


    #region validate
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
    #endregion

}
