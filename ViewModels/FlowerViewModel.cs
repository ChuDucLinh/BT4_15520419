using MVVM_15520419.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MVVM_15520419.ViewModels
{
    class FlowerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Flower flower;

        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));

            }
        }


        public Flower SelectFlower
        {
            get { return flower; }
            set
            {
                flower = value;
                RaisePropertyChanged("SelectFlower");
            }
        }

        public int Id
        {
            get { return flower.Id; }
            set
            {
                flower.Id = Id;
                RaisePropertyChanged("Id");
            }
        }

        public int TypeId
        {
            get { return flower.TypeId; }
            set
            {
                flower.TypeId = value;
                RaisePropertyChanged("TypeId");
            }
        }

        public string Name
        {
            get { return flower.Name; }
            set
            {
                flower.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Image
        {
            get { return flower.Image; }
            set
            {
                flower.Image = value;
                RaisePropertyChanged("Image");
            }
        }

        public string Description
        {
            get { return flower.Description; }
            set
            {
                flower.Description = value;
                RaisePropertyChanged("Description");
            }
        }

        public double Price
        {
            get { return flower.Price; }
            set
            {
                flower.Price = value;
                RaisePropertyChanged("Price");
            }
        }
    }
}
