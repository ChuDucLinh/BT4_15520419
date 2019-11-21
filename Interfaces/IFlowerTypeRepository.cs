using MVVM_15520419.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MVVM_15520419.Interface
{
    interface IFlowerTypeRepository
    {
        ObservableCollection<FlowerType> Gets();
        FlowerType GetById(int Maloai);
        bool Insert(FlowerType flowerType);
        bool Update(FlowerType flowerType);
        bool Delete(FlowerType flowerType);
    }
}
