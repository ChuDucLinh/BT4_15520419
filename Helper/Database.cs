using MVVM_15520419.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Internals;

namespace MVVM_15520419.Helper
{
    class Database
    {
        string folder = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public Database()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "flower_management.db")))
                {
                    connection.CreateTable<FlowerType>();
                    connection.CreateTable<Flower>();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Warning("SQLiteEx", ex.Message);
            }
        }

        #region Flower
        public List<Flower> GetFlowers()
        {
            try
            {
                using (var connection = new SQLiteConnection
                    (System.IO.Path.Combine(folder, "flower_management.db")))
                {
                    return connection.Table<Flower>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Warning("SQLiteEx", ex.Message);
                return null;
            }
        }

        public List<Flower> GetFlowersByTypeId(int typeId)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "flower_management.db")))
                {

                    var flowers = from fls in connection.Table<Flower>().ToList()
                                  where fls.TypeId == typeId
                                  select fls;
                    return flowers.ToList<Flower>();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Warning("SQLiteEx", ex.Message);
                return null;
            }
        }

        public Flower GetFlowerById(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection
                    (System.IO.Path.Combine(folder, "flower_management.db")))
                {

                    var flowers = from fls in connection.Table<Flower>().ToList()
                                  where fls.Id == id
                                  select fls;
                    return flowers.ToList<Flower>().FirstOrDefault();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Warning("SQLiteEx", ex.Message);
                return null;
            }
        }

        public bool InsertFlower(Flower flower)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "flower_management.db")))
                {
                    connection.Insert(flower);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Warning("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool UpdateFlower(Flower flower)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "flower_management.db")))
                {
                    connection.Update(flower);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Warning("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool DeleteFlower(Flower flower)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "flower_management.db")))
                {
                    connection.Delete(flower);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Warning("SQLiteEx", ex.Message);
                return false;
            }
        }
        #endregion

        #region "Flower Type"
        public List<FlowerType> GetFlowerTypes()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "flower_management.db")))
                {
                    return connection.Table<FlowerType>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Warning("SQLiteEx", ex.Message);
                return null;
            }
        }
        public FlowerType GetFlowerTypeById(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "flower_management.db")))
                {
                    var flowerTypes = from fts in connection.Table<FlowerType>().ToList()
                                      where fts.Id == id
                                      select fts
                          ;
                    return flowerTypes.ToList<FlowerType>().FirstOrDefault();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Warning("SQLiteEx", ex.Message);
                return null;
            }
        }
        public bool InsertFlowerType(FlowerType flowerType)
        {
            try
            {
                using (var connection = new
                    SQLiteConnection(System.IO.Path.Combine(folder, "flower_management.db")))
                {
                    connection.Insert(flowerType);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Warning("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool UpdateFlowerType(FlowerType flowerType)
        {
            try
            {
                using (var connection = new
                    SQLiteConnection(System.IO.Path.Combine(folder, "flower_management.db")))
                {
                    connection.Update(flowerType);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Warning("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool DeleteFlowerType(FlowerType flowerType)
        {
            try
            {
                using (var connection = new
                    SQLiteConnection(System.IO.Path.Combine(folder, "flower_management.db")))
                {
                    connection.Delete(flowerType);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Warning("SQLiteEx", ex.Message);
                return false;
            }
        }
        #endregion
    }
}
