using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfAppICommandBindingButton.Command;
using WpfAppICommandBindingButton.Models;

namespace WpfAppICommandBindingButton.ViewModels;

class MainViewModel:ViewModelBase
{
    private string _name;
    private string _description;
    private string _id;

    public string Name
    {
        get { return _name; }
        set { _name = value; OnPropertyChanged(); }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; OnPropertyChanged(); }
    }

    public string Id
    {
        get { return _id; }
        set { _id = value; OnPropertyChanged(); }
    }

    private ObservableCollection<Essen> _essenes;

    public ICommand ShowNameCommand { get; }
    public ICommand NewFensterCommand { get; }
    public ICommand AddEssenCommand { get; }
    public ICommand DeleteEssenCommand { get; }

    public ObservableCollection<Essen> Essenes
    {
        get { return _essenes; }
        set { _essenes = value; OnPropertyChanged(); }
    }

    public MainViewModel()
    {
        ShowNameCommand = new RelayCommand(ShowName);
        NewFensterCommand = new RelayCommand(ShowNewFenster);
        AddEssenCommand = new RelayCommand(AddEssen);
        Essenes = new ObservableCollection<Essen>();
        DeleteEssenCommand = new RelayCommand(DeleteEssen);
        LoadVieleEssen();
    }

    private void ShowName()
    {
        MessageBox.Show($"Your name is: {Name}");
    }

    private void ShowNewFenster()
    {
        MessageBox.Show($"Merhaba {Name}");
    }

    private void AddEssen()
    {
        Essenes.Add(new Essen(Id, Name, Description));
        MessageBox.Show("Yemek eklendi");
        // OnPropertyChanged(nameof(Essenes)); // Gerekli değil, çünkü ObservableCollection kendisi değişiklikleri bildirir.
    }

    private void LoadVieleEssen()
    {
        Essenes.Add(new Essen("1", "a", "b"));
        Essenes.Add(new Essen("2", "a", "b"));
        Essenes.Add(new Essen("3", "a", "b"));
        Essenes.Add(new Essen("4", "a", "b"));
        Essenes.Add(new Essen("5", "a", "b"));

        // OnPropertyChanged(nameof(Essenes)); // Gerekli değil, çünkü ObservableCollection kendisi değişiklikleri bildirir.
    }
    public void DeleteEssen(object parameter)
    {
        if (parameter is Essen essen)
        {
            Essenes.Remove(essen);
        }
    }
    private bool CanDeleteEssen(object parameter)
    {
        return parameter is Essen;
    }
}
