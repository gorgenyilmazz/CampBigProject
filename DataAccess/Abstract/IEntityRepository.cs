using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //herkes istedigi t yi yazamasin bunu kisitlayalim(Generic Constraint)
    //where T:class deigimiz icin bu referans tip olabilir demek mesela int vs olamaz artik
    //tamam da biz istiyoruz ki herhangi bir class yazamasin sadece IEntity classlari olsun
    //yani artik dedik ki T miz referans tipi olacak ve sadece IEntity i implement alan referans tipleri yazabiliriz demek ya da IEntity in kendisini de yazabiilriz
    //Su an ama soyut bir nesne bizim isimizi gormuyor o yudzen IEntity i tek basina kabul etmemesi icin sadece newlenebilir yapilari verebiliriz
    //yani artik T:class,IEntity,new() ile sadece Concrete Entity leri verebiliyoruz ve istedigimiz de tam buydu! Bir standart olusturduk.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //filtre=null filtre vermeyedebilir demek filtre gonderilmezse hepsini doner
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        //filter zorunlu demek alttaki syntax p=>p.CategoryId == 2 gibi filtreler yazilmasini saglar
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAllByCategory(int categoryId);
    }
}
