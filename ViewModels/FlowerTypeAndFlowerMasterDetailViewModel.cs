using MVVM_15520419.Interface;
using MVVM_15520419.Models;
using MVVM_15520419.Repositories;
using MVVM_15520419.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace MVVM_15520419.ViewModels
{
    class FlowerTypeAndFlowerMasterDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        private ObservableCollection<Flower> flowers;
        private ObservableCollection<FlowerType> flowerTypes;
        private FlowerType flowerTypeSelected;
        private IFlowerTypeRepository flowerTypeRepository;
        private IFlowerRepository flowerRepository;
        public ObservableCollection<Flower> Flowers
        {
            get { return flowers; }
            set
            {
                flowers = value;
                RaisePropertyChanged("Flowers");
            }
        }
        public ObservableCollection<FlowerType> FlowerTypes
        {
            get { return flowerTypes; }
            set
            {
                flowerTypes = value;
                RaisePropertyChanged("FlowerTypes");
            }
        }
        public FlowerType FlowerTypeSelected
        {
            get { return flowerTypeSelected; }
            set
            {
                flowerTypeSelected = value;
                RaisePropertyChanged("FlowerTypeSelected");
                GetFlowers();
            }
        }
        public FlowerTypeAndFlowerMasterDetailViewModel()
        {
            flowerTypeRepository = new FlowerTypeRepository();
            flowerRepository = new FlowerRepository();
            FlowerTypes = new ObservableCollection<FlowerType>();
            FlowerTypes = flowerTypeRepository.Gets();
            if (FlowerTypes.Count > 0)
            {
                FlowerTypeSelected = FlowerTypes[0];
            }
        }
        private void GetFlowers()
        {
            if (FlowerTypeSelected == null || FlowerTypeSelected.Id == 0)
                return;
            flowers = new ObservableCollection<Flower>();
            flowerRepository = new FlowerRepository();
            Flowers = flowerRepository.GetsByTypeId(FlowerTypeSelected.Id);
        }
    }
}
