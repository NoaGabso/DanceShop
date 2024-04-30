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

namespace OnlineDanceStore.ViewModels
{
    public class RegisterPageViewModel:ViewModel
    {
        #region Fields
        private string name;
        private string lastname;
        private string password;
        private string email;

        private bool _showEmailError;
        private string _emailErrorMessage;

        private bool _showPasswordError;//האם להציג שגיאת סיסמה
        private string _passwordErrorMessage;

        private bool _showRegisterError;//
        private string _registerErrorMessage;

        private bool _showNameError;//האם להציג שדה שגיאת שם משתמש
        private string _nameErrorMessage;//תאור שגיאת שם משתמש

       
        #endregion
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value; if (!ValidateName()) { _showNameError = true; NameErrorMessage = ErrorMessages.INVALID_Name; }
                    else { ShowNameError = false; NameErrorMessage = string.Empty; }
                    OnPropertyChange(); OnPropertyChange(nameof(IsButtonEnabled));
                }
            }
        }
        public bool ShowNameError
        {
            get => _showNameError; set
            {
                if (_showNameError != value)
                {
                    _showNameError = value; OnPropertyChange();
                }
            }
        }
        public string NameErrorMessage
        {
            get => _nameErrorMessage; set
            {
                if (_nameErrorMessage != value)
                { _nameErrorMessage = value; OnPropertyChange(); }
            }
        }

        public string LastName
        {
            get => lastname;
            set
            {
                if (lastname != value)
                {
                    lastname = value; if (!ValidateName()) { _showNameError = true; NameErrorMessage = ErrorMessages.INVALID_LastName; }
                    else { ShowNameError = false; NameErrorMessage = string.Empty; }
                    OnPropertyChange(); OnPropertyChange(nameof(IsButtonEnabled));
                }
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                {
                    email = value; if (!ValidateUser()) { _showEmailError = true; EmailErrorMessage = ErrorMessages.INVALID_Email; }
                    else { ShowEmailError = false; EmailErrorMessage = string.Empty; }
                    OnPropertyChange();
                }
            }
        }

        public bool ShowEmailError
        {
            get => _showEmailError; set
            {
                if (_showEmailError != value)
                {
                    _showEmailError = value; OnPropertyChange();
                }
            }
        }
        public string EmailErrorMessage { get => _emailErrorMessage; set { if (_emailErrorMessage != value) { _emailErrorMessage = value; OnPropertyChange(); } } }

        public string Password
        {
            get { return password; }
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
                    OnPropertyChange(); OnPropertyChange(nameof(IsButtonEnabled));
                }
            }
        }

        public bool ShowPasswordError { get => _showPasswordError; set 
            { if (_showPasswordError != value) 
                { _showPasswordError = value; OnPropertyChange(); } } }

        public string PasswordErrorMessage { get => _passwordErrorMessage; set
            { if (_passwordErrorMessage != value)
                { _passwordErrorMessage = value; OnPropertyChange(); } } }

        public bool ShowRegisterError { get => _showRegisterError; set
            { if (_showRegisterError != value)
                { _showRegisterError = value; OnPropertyChange(); } } }
        public string RegisterErrorMessage { get => _registerErrorMessage; set
            { if (_registerErrorMessage != value) 
                { _registerErrorMessage = value; OnPropertyChange(); } } }



        private readonly OnlineDanceStoreServices _service;
        #region Commands
        public ICommand RegisterCommand { get; protected set; }
        public ICommand GoToLogin { get; protected set; }
        public bool IsButtonEnabled
        {
            get { return ValidatePage(); }
        }
        #endregion
        public RegisterPageViewModel(OnlineDanceStoreServices service)
        {
            _service = service;
            email = string.Empty;
            password = string.Empty;
            name = string.Empty;
            lastname = string.Empty;    

            RegisterCommand = new Command(async () =>
            {
                ShowRegisterError = false; //הסתרת שגיאת לוגין
                try
                {
                    #region טעינת מסך ביניים
                    var lvm = new LoadingPageViewModel() { IsBusy = true };
                    await AppShell.Current.Navigation.PushModalAsync(new LoadingPage(lvm));
                    #endregion
                    User user = new User();
                    {
                        user.Email = email;
                      user.UserPswd = Password;
                        user.FirstName = name;
                        user.LastName= lastname;
                    }
                  var   u = await _service.RegisterUser(user);

                    lvm.IsBusy = false;
                    await Shell.Current.Navigation.PopModalAsync();
                    if (!u.Success)
                    {
                        ShowRegisterError = true;
                       RegisterErrorMessage = u.Message;
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

                    Debug.WriteLine(ex.Message);

                    await AppShell.Current.Navigation.PopModalAsync();
                }


            });
            GoToLogin = new Command(async () =>
            {
                await AppShell.Current.GoToAsync("Login");
            });
        }
        #region פעולות עזר
        private bool ValidateUser()
        {
            return !(string.IsNullOrEmpty(email) || email.Length < 3);
        }
        private bool ValidateName()
    {
   
        return !(string.IsNullOrEmpty(name) || name.Length < 3);
    }
        private bool ValidatePassWord()
        {
            return !(string.IsNullOrEmpty(password)||password.Length<3);
    }

    private bool ValidatePage()
    {
            return ValidateName() && ValidatePassWord() && ValidateUser();
    }
    #endregion

}
}
