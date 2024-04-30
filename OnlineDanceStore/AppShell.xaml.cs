using OnlineDanceStore.Models;
using OnlineDanceStore.View;
using OnlineDanceStore.View.Categories;
using System.ComponentModel;

namespace OnlineDanceStore;

public partial class AppShell : Shell, INotifyPropertyChanged
{
    private bool isAdmin;
    
    public event PropertyChangedEventHandler PropertyChanged;

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

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}


