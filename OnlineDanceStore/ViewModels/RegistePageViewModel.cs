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


namespace OnlineDanceStore.ViewModels
{
    public class RegisterPageViewModel:ViewModel
    {
        private string name;
        private string lastname;
        private string password;
        private string email;

        private bool _showPasswordError;//האם להציג שגיאת סיסמה
        private string _passwordErrorMessage;
        private bool _showLoginError;//
        private string _loginErrorMessage;
        private bool _showUserNameError;//האם להציג שדה שגיאת שם משתמש
        private string _userErrorMessage;//תאור שגיאת שם משתמש
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value && ValidateName())
                { name = value; OnPropertyChange(); }
                else
                    name = ""; ShowUserNameError = true;
            }
        }
                
        public string LastName
        {
            get { return lastname; }
            set
            {
                if (lastname != value && ValidateName())
                { name = value; OnPropertyChange(); }
                else
                    lastname = ""; ShowUserNameError = true;
            }
        }
        public string Password { get { return password; }
            set
            {
                if (password != value)
                {
                    password = value; if (!ValidatePassWord())
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
                   
                }
            }
        }

        public string Email { get { return email; } set { email = value; } }

        public string UserErrorMessage { get => _userErrorMessage; set
            { if (_userErrorMessage != value)
                { _userErrorMessage = value; OnPropertyChange(); } } }

        public bool ShowUserNameError
        {
            get => _showUserNameError; set
            {
                if (_showUserNameError != value)
                {
                    _showUserNameError = value; OnPropertyChange();
                }
            }
        }
        public bool ShowPasswordError { get => _showPasswordError; set 
            { if (_showPasswordError != value) 
                { _showPasswordError = value; OnPropertyChange(); } } }
        public string PasswordErrorMessage { get => _passwordErrorMessage; set
            { if (_passwordErrorMessage != value)
                { _passwordErrorMessage = value; OnPropertyChange(); } } }

        public bool ShowLoginError { get => _showLoginError; set
            { if (_showLoginError != value)
                { _showLoginError = value; OnPropertyChange(); } } }
        public string LoginErrorMessage { get => _loginErrorMessage; set
            { if (_loginErrorMessage != value) 
                { _loginErrorMessage = value; OnPropertyChange(); } } }

        private readonly OnlineDanceStoreServices _service;
        #region Commands
        public ICommand IRegisterCommand { get; protected set; }
        public bool IsButtonEnabled
        {
            get { return ValidatePage(); }
        }
        #endregion
        public RegisterPageViewModel(OnlineDanceStoreServices service)
        {
            _service = service;
            Email = string.Empty;
            Password = string.Empty;
            name = string.Empty;
            lastname = string.Empty;    

            IRegisterCommand = new Command(async () =>
            {
                /*ShowLoginError = false;*///הסתרת שגיאת לוגין
                try
                {
                    #region טעינת מסך ביניים
                    var lvm = new LoadingPageViewModel() { IsBusy = true };
                    await AppShell.Current.Navigation.PushModalAsync(new LoadingPage(lvm));
                    #endregion
                    User user = new User();
                    {
                        user.Email = Email;
                      user.UserPswd = Password;
                        user.FirstName = name;
                        user.LastName= lastname;
                    }
                  var   u = await _service.RegisterUser(user);

                    lvm.IsBusy = false;
                    await Shell.Current.Navigation.PopModalAsync();
                    if (!u.Success)
                    {
                        ShowLoginError = true;
                        LoginErrorMessage = u.Message;
                    }
                    else
                    {
                        await AppShell.Current.DisplayAlert("התחברת", "אישור כניסה לאתר", "אישור");
                        await SecureStorage.Default.SetAsync("RegistedUser", JsonSerializer.Serialize(u.User));
                        await AppShell.Current.GoToAsync("HomePage");
                    }



                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);

                    await AppShell.Current.Navigation.PopModalAsync();
                }


            });
        }
        #region פעולות עזר
        private bool ValidateName()
    {
   
        return !(string.IsNullOrEmpty(name) || name.Length < 3);
    }
        private bool ValidatePassWord()
        {
            return !(string.IsNullOrEmpty(password)||password.Length>=4);
    }

    private bool ValidatePage()
    {
        return ValidateName() && ValidatePassWord();
    }
    #endregion

}
}
