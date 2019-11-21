using MVVM_15520419.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MVVM_15520419.Interface
{
    interface IFlowerRepository
    {
        ObservableCollection<Flower> Gets();
        ObservableCollection<Flower> GetsByTypeId(int Maloai);
        Flower GetById(int Mahoa);
        bool Insert(Flower flower);
        bool Update(Flower flower);
        bool Delete(Flower flower);
    }
}
