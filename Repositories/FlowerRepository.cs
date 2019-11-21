using MVVM_15520419.Helper;
using MVVM_15520419.Interface;
using MVVM_15520419.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MVVM_15520419.Repositories
{
    class FlowerRepository : IFlowerRepository
    {
        Database db;

        public FlowerRepository()
        {
            db = new Database();
        }

        public bool Delete(Flower flower)
        {
            return db.DeleteFlower(flower);
        }

        public ObservableCollection<Flower> Gets()
        {
            List<Flower> lsthoa = db.GetFlowers();
            return new ObservableCollection<Flower>(lsthoa);
        }

        public Flower GetById(int Mahoa)
        {
            Flower h;
            h = db.GetFlowerById(Mahoa);
            return h;
        }

        public ObservableCollection<Flower> GetsByTypeId(int typeId)
        {
            List<Flower> lsthoa = db.GetFlowersByTypeId(typeId);
            return new ObservableCollection<Flower>(lsthoa);
        }

        public bool Insert(Flower flower)
        {
            return db.InsertFlower(flower);
        }

        public bool Update(Flower flower)
        {
            return db.UpdateFlower(flower);
        }
    }
}
