using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace MVVM_15520419.Models
{
    class FlowerTypeWithFlower : INotifyPropertyChanged
    {
        private FlowerType flowerType;
        private ObservableCollection<Flower> flowers;
        public FlowerType FlowerType
        {
            get { return flowerType; }
            set
            {
                flowerType = value;
                RaisePropertyChanged("flowerType");
            }
        }
        public ObservableCollection<Flower> Flowers
        {
            get { return flowers; }
            set
            {
                flowers = value;
                RaisePropertyChanged("flowers");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
