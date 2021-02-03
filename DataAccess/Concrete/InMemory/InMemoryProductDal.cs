using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        //bu class icin global degisken altcizgi kullanilir
        List<Product> _products;
        public InMemoryProductDal()
        {
            //sanki bu veriler oracle, sqlserver, postgresql den geliyormus gibi simule ediyoruz.
            _products = new List<Product> {
                new Product{ProductID=1, CategoryID=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15 },
                new Product{ProductID=2, CategoryID=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3 },
                new Product{ProductID=3, CategoryID=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2 },
                new Product{ProductID=4, CategoryID=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65 },
                new Product{ProductID=5, CategoryID=2, ProductName="Fare", UnitPrice=85, UnitsInStock=1 }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //businessdan gelen productin referansi farkli bir ref olacagi icin silmez. remove ile

            //Linq kullanmadigimizi varsayalim
            //linq kullanmadan ustteki listeyi tek tek donup gelen parametrenin hangi product oldugunu bilmek lazim silmek icin mesela
            /*
                        Product productToDelete = null;
                        foreach (var p in _products)
                        {
                            if (product.ProductID == p.ProductID) {

                                productToDelete = p;
                            }

                        }
                        _products.Remove(productToDelete);
            */
            //linq ile bu liste bazli yapilari sql gibi filtreleyebiliyoruz
            
            Product productToDelete = null;
            //tek bi eleman bulmaya yarar bizim yerimize products i tek tek dolasir
            //alttaki lambda foreach i yapar
            productToDelete = _products.SingleOrDefault(p=>p.ProductID == product.ProductID); 


        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //Gonderdigim urun idsine sahip olan listedeki urunu bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;


        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //where icindeki sarta uyan her elemani yeni bi listeye atip onu dondurur
           return  _products.Where(p => p.CategoryID == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
