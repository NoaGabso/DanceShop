using OnlineDanceStore.Models;
using OnlineDanceStore.View;
using OnlineDanceStore.View.Categories;
using System.ComponentModel;
using System.Windows.Input;

namespace OnlineDanceStore;

public partial class AppShell : Shell, INotifyPropertyChanged
{
    private bool isAdmin;
    
    public event PropertyChangedEventHandler PropertyChanged;
    public ICommand LogOutCommand {  get; private set; }
    public bool IsAdmin
    {
        get => isAdmin;
        set
        {
            if (isAdmin != value)
            {
                isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            }
        }
    }

    public AppShell()
    {
       

        InitializeComponent();
        BindingContext = this;


        Routing.RegisterRoute("Register", typeof(RegisterPage));
        Routing.RegisterRoute("Login", typeof(LoginPage));
        IsAdmin = false;
       

    }

    public void SetIsAdmin(bool userIsAdmin)
    {
        IsAdmin = userIsAdmin;
    }

   private async void LogOutClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Login");
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}


