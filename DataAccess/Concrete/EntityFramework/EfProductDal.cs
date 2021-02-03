using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //csharpa ozel biz bi klassi newledigimizede Garbage collector brlli bir zaman sonra duzenli olarak onu atar
            //using icindeki nesneler using bitince aninda garbage collectora derki beni at cunku context nesnesi biraz pahali
            //IDisposable Pattern Implementation of C#
            using (NorthWindContext context=new NorthWindContext())
            {
                //git veri kaynagindan gonderdigim productan bir nesneye eslestir ama yeni ekleme oldugu icin direkt ekler
                //bu referansi yakalama
                var addedEntity = context.Entry(entity);
                //Simdi bu nesneyi napacagiz?
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                //git veri kaynagindan gonderdigim productan bir nesneye eslestir ama yeni ekleme oldugu icin direkt ekler
                //bu referansi yakalama
                var deletedEntity = context.Entry(entity);
                //Simdi bu nesneyi napacagiz?
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                //arka planda select* from products calistirir ve tolist e cevirir
                //filtre olarak gonderecegimiz sey bir lambda
                return filter == null ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();

            }
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                //git veri kaynagindan gonderdigim productan bir nesneye eslestir ama yeni ekleme oldugu icin direkt ekler
                //bu referansi yakalama
                var updatedEntity = context.Entry(entity);
                //Simdi bu nesneyi napacagiz?
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
