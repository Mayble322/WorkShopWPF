using System;
using WorkShopWPF.DataAccess;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkShopWPF.Model;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace WorkShopWPF.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        List<string> _GetList;
        public List<string> GetList
        {
            get => _GetList;
            set
            {
                _GetList = value;
                OnPropertyChanged("GetList");
            }
        }

        string _RecipeName;
        public string RecipeName
        {
            get => _RecipeName;
            set
            {
                _RecipeName = value;
            }
        }

        int _RecipeQuantity;
        public int RecipeQuantity
        {
            get => _RecipeQuantity;
            set
            {
                _RecipeQuantity = value;
            }
        }

        string _GetAnswer;
        public string GetAnswer
        {
            get => _GetAnswer;
            set
            {
                _GetAnswer = value;
                OnPropertyChanged("GetAnswer");
            }
        }


        RelayCommand _GetListCommand;
        public ICommand GetListCommand
        {
            get
            {
                if (_GetListCommand == null)
                    _GetListCommand = new RelayCommand(ExecuteGetListCommand, CanExecuteGetListCommand);
                return _GetListCommand;
            }
        }
        private void ExecuteGetListCommand(object parameter)
        {
            Loader.LoadRecipeFromTxt(WorkShop.Recipes);
            Loader.LoadMaterialsFromTxt(WorkShop.MaterialsInStorage);
            GetList = Order.GetRecipes();;
        }
        private bool CanExecuteGetListCommand(object parameter)
        {
            return true;
        }

        RelayCommand _AddOrderCommand;
        public ICommand AddOrderCommand
        {
            get
            {

                if (_AddOrderCommand == null)
                    _AddOrderCommand = new RelayCommand(ExecuteAddOrderCommand, CanExecuteAddOrderCommand);
                return _AddOrderCommand;
            }
        }

        private void ExecuteAddOrderCommand(object parameter)
        {
            Order.AddOrder(RecipeName, RecipeQuantity);
        }

        private bool CanExecuteAddOrderCommand(object parameter)
        {
            return true;
        }


        RelayCommand _TreatmentCommand;
        public ICommand TreatmentCommand
        {
            get
            {
                if (_TreatmentCommand == null)
                    _TreatmentCommand = new RelayCommand(ExecuteTreatmentCommand, CanExecuteTreatmentCommand);
                return _TreatmentCommand;
            }
        }
        private void ExecuteTreatmentCommand(object parameter)
        {
            GetAnswer = Order.Treatment();           
            Order.ClearBasket();

        }
        private bool CanExecuteTreatmentCommand(object parameter)
        {
            return true;
        }
  

      
    }
}
