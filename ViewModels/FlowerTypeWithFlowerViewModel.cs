using MVVM_15520419.Interface;
using MVVM_15520419.Models;
using MVVM_15520419.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace MVVM_15520419.ViewModels
{
    class FlowerTypeWithFlowerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<FlowerTypeWithFlower> flowerTypeWithFlowers;
        private IFlowerTypeRepository flowerTypeRepository;
        private IFlowerRepository flowerRepository;
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        public ObservableCollection<FlowerTypeWithFlower> FlowerTypeWithFlowers
        {
            get { return flowerTypeWithFlowers; }
            set
            {
                flowerTypeWithFlowers = value;
                RaisePropertyChanged("flowerTypeWithFlowers");
            }
        }

        void LoadData()
        {
            flowerTypeRepository = new FlowerTypeRepository();
            flowerRepository = new FlowerRepository();
            flowerTypeWithFlowers = new ObservableCollection<FlowerTypeWithFlower>();
            ObservableCollection<FlowerType> list = flowerTypeRepository.Gets();

            foreach (FlowerType item in list)
            {
                FlowerTypeWithFlower temp = new FlowerTypeWithFlower();
                temp.FlowerType = item;

                temp.Flowers = flowerRepository.GetsByTypeId(item.Id);
                flowerTypeWithFlowers.Add(temp);
            }
        }
        public FlowerTypeWithFlowerViewModel()
        {
            LoadData();

        }
    }
}
