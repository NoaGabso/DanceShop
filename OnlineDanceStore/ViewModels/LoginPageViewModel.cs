using OnlineDanceStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OnlineDanceStore.Models;
using OnlineDanceStore.View;
using System.Text.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OnlineDanceStore.ViewModels
{
    public class LoginPageViewModels : ViewModel
    {
        #region Fields
        private bool tabisVisible;//הסתרת הטאב הנוכחי
        
        #endregion

        #region Properties
        public bool IsVisible
        {
            get => tabisVisible;
            set
            {
                if (tabisVisible != value)
                {
                    tabisVisible = value; OnPropertyChange();
                }
            }
        }
        #endregion

        #region Fields
        private string _email;//שם משתמש
        private bool _showEmailError;//האם להציג שדה שגיאת שם משתמש
        private string _emailErrorMessage;//תאור שגיאת שם משתמש
        private string _password;//סיסמה

        private bool _showPasswordError;//האם להציג שגיאת סיסמה
        private string _passwordErrorMessage;
        private bool _showLoginError;//
        private string _loginErrorMessage;
        #endregion

        #region Service component
        private readonly OnlineDanceStoreServices _service;
        #endregion

        #region Properties
        public string Email
        {
            get => _email;
            set { if (_email != value) { _email = value; if (!ValidateUser()) { _showEmailError = true; EmailErrorMessage = ErrorMessages.INVALID_Email; }
                    else { ShowEmailError = false; EmailErrorMessage = string.Empty; } OnPropertyChange(); OnPropertyChange(nameof(IsButtonEnabled)); } }
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
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value; if (!ValidatePassWord())
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

        public string EmailErrorMessage { get => _emailErrorMessage; set { if (_emailErrorMessage != value) { _emailErrorMessage = value; OnPropertyChange(); } } }


        public bool ShowPasswordError { get => _showPasswordError; set { if (_showPasswordError != value) { _showPasswordError = value; OnPropertyChange(); } } }
        public string PasswordErrorMessage { get => _passwordErrorMessage; set { if (_passwordErrorMessage != value) { _passwordErrorMessage = value; OnPropertyChange(); } } }

        public bool ShowLoginError { get => _showLoginError; set { if (_showLoginError != value) { _showLoginError = value; OnPropertyChange(); } } }
        public string LoginErrorMessage { get => _loginErrorMessage; set { if (_loginErrorMessage != value) { _loginErrorMessage = value; OnPropertyChange(); } } }

        //האם כפתור התחבר יהיה זמין
        public bool IsButtonEnabled { get { return ValidatePage(); } }
        #endregion

        #region Commands
        public ICommand LogInCommand { get; protected set; }
        public ICommand GoToRegister { get; protected set; }
        #endregion



        /// <summary>
        /// c'tor
        /// </summary>
        /// <param name="service">מקבלת באמצעות DI את אובייקט הAPI</param>

        public LoginPageViewModels(OnlineDanceStoreServices service)
        {
            _service = service;
            Email = string.Empty;
            Password = string.Empty;

            LogInCommand = new Command(async () =>
            {
                ShowLoginError = false;//הסתרת שגיאת לוגין
                try
                {
                    #region טעינת מסך ביניים
                    var lvm = new LoadingPageViewModel() { IsBusy = true };
                    await AppShell.Current.Navigation.PushModalAsync(new LoadingPage(lvm));
                    #endregion
                    var user = await _service.LoginAsync(Email, Password);

                    lvm.IsBusy = false;
                    await Shell.Current.Navigation.PopModalAsync();
                    if (!user.Success)
                    {
                        ShowLoginError = true;
                        LoginErrorMessage = user.Message;
                    }
                    else
                    {
                        await AppShell.Current.DisplayAlert("התחברת", "אישור כניסה לאתר", "אישור");
                        usera
                        await SecureStorage.Default.SetAsync("LoggedUser", JsonSerializer.Serialize(user.User));
                        IsVisible = true;

                        await AppShell.Current.GoToAsync("HomePage");
                    }



                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);

                    await AppShell.Current.Navigation.PopModalAsync();
                }


            });

            GoToRegister = new Command(async () =>
            {
                await AppShell.Current.GoToAsync("Register");
            });
        }
        #region פעולות עזר
        private bool ValidateUser()
        {
            return !(string.IsNullOrEmpty(_email) || _email.Length < 3);
        }
        private bool ValidatePassWord()
        {
            return !string.IsNullOrEmpty(Password);
        }

        private bool ValidatePage()
        {
            return ValidateUser() && ValidatePassWord();
        }
        #endregion
       
    }

}

