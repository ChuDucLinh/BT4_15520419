using MVVM_15520419.Interface;
using MVVM_15520419.Models;
using MVVM_15520419.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM_15520419.ViewModels
{
    class FlowerTypeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        private FlowerType flowerType;
        ObservableCollection<FlowerType> flowerTypes;
        public IFlowerTypeRepository flowerTypeRepository;
        public ICommand AddFlowerType { get; private set; }
        public ICommand UpdateFlowerType { get; private set; }
        public ICommand DeleteFlowerType { get; private set; }
        public ICommand SelectFlowerType { get; private set; }

        public FlowerTypeViewModel()
        {
            flowerTypeRepository = new FlowerTypeRepository();
            LoadFlowerTypes();
            AddFlowerType = new Command(Insert);
            UpdateFlowerType = new Command(Update, CanExe);
            DeleteFlowerType = new Command(Delete, CanExe);
            SelectFlowerType = new Command(Select);
            flowerType = new FlowerType();
        }

        private void Select()
        {

        }

        private void Delete()
        {
            flowerTypeRepository.Delete(FlowerType);
            LoadFlowerTypes();
        }

        private bool CanExe()
        {
            if (FlowerType == null || FlowerType.Id == 0)
                return false;
            else
                return true;
        }

        private void Update()
        {
            flowerTypeRepository.Update(FlowerType);
            LoadFlowerTypes();
        }

        public FlowerType FlowerType
        {
            get { return flowerType; }
            set
            {
                flowerType = value;
                RaisePropertyChanged("FlowerType");
                ((Command)UpdateFlowerType).ChangeCanExecute();

            }
        }

        private void Insert()
        {
            flowerTypeRepository.Insert(FlowerType);
            LoadFlowerTypes();
        }

        public int Id
        {
            get { return flowerType.Id; }
            set
            {
                flowerType.Id = value;
                RaisePropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return flowerType.Name; }
            set
            {
                flowerType.Name = value;
                RaisePropertyChanged("Name");
            }
        }


        public ObservableCollection<FlowerType> FlowerTypes
        {
            get { return flowerTypes; }
            set
            {
                flowerTypes = value;
                RaisePropertyChanged("flowerTypes");
            }
        }

        void LoadFlowerTypes()
        {
            flowerTypes = flowerTypeRepository.Gets();
        }
    }
}
