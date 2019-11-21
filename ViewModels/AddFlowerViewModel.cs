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
    class AddFlowerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public ICommand AddFlower { get; private set; }
        public IFlowerTypeRepository flowerTypeRepository;
        public IFlowerRepository flowerRepository;
        private ObservableCollection<FlowerType> flowerTypes;
        private ObservableCollection<Flower> flowers;
        private FlowerType flowerType;
        private Flower flower;

        public AddFlowerViewModel()
        {
            flowerTypeRepository = new FlowerTypeRepository();
            flowerRepository = new FlowerRepository();
            flowerTypes = flowerTypeRepository.Gets();
            flowers = flowerRepository.Gets();
            flowerType = new FlowerType();
            flower = new Flower();
            AddFlower = new Command(Insert);
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

        public FlowerType SelectedFlowerType
        {
            get { return flowerType; }
            set
            {
                flowerType = value;
                flower.TypeId = flowerType.Id;
                GetFlowersByTypeId();
                RaisePropertyChanged("SelectedFlowerType");
            }
        }

        void GetFlowersByTypeId()
        {
            if (SelectedFlowerType != null && SelectedFlowerType.Id > 0)
                Flowers = flowerRepository.GetsByTypeId(SelectedFlowerType.Id);
            else
                Flowers = flowerRepository.Gets();
        }

        public Flower Flower
        {
            get { return flower; }
            set
            {
                flower = value;
                RaisePropertyChanged("Flower");
            }

        }

        public ObservableCollection<Flower> Flowers
        {
            get { return flowers; }
            set
            {
                flowers = value;
                RaisePropertyChanged("Flowers");
            }
        }

        public void Insert()
        {
            flowerRepository.Insert(flower);
        }
    }
}
