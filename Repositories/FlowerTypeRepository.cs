using MVVM_15520419.Helper;
using MVVM_15520419.Interface;
using MVVM_15520419.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MVVM_15520419.Repositories
{
    class FlowerTypeRepository : IFlowerTypeRepository
    {
        Database db;

        public FlowerTypeRepository()
        {
            db = new Database();
        }

        public FlowerType GetById(int id)
        {
            return db.GetFlowerTypeById(id);
        }

        public ObservableCollection<FlowerType> Gets()
        {
            return new ObservableCollection<FlowerType>(db.GetFlowerTypes());
        }

        public bool Insert(FlowerType flowerType)
        {
            return db.InsertFlowerType(flowerType);
        }

        public bool Update(FlowerType flowerType)
        {
            return db.UpdateFlowerType(flowerType);
        }

        public bool Delete(FlowerType flowerType)
        {
            return db.DeleteFlowerType(flowerType);
        }
    }
}
