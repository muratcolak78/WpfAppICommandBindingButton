using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppICommandBindingButton.ViewModels;

namespace WpfAppICommandBindingButton.Models
{
    class Essen:ViewModelBase
    {
        private string _id;
        private string _name;
        private string _description;

        public string Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }

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

        public Essen(string id, string name, string description)
        {
            _id = id;
            _name = name;
            _description = description;
        }

        public override string ToString()
        {
            return $"{Id}  {Name}  {Description}";
        }
    }
}
