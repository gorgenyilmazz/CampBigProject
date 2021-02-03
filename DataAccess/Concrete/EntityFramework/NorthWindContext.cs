using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: Db tablolari ile proje classlarini baglamak
    //entityframeworkcore ile DbContext klassi gelir 
    //oncelikle db miz nerede onu soylememiz lazim.
    public class NorthWindContext:DbContext
    {
        //bu method senin projen hangi db ile iliskili onu belirtecegimiz yer.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //diyoruz ki sqlserver kullanicaz nasil baglanacagmizi belirtmemiz lazim simddi
            //aslinda bir connection string giriciez
            //ters slashin bir anlami var o yuzden ters slash kullandigimiz yerlerde cift ters clash kullaniriz
            //trusted conn true kullanici adi ve sifre gerektirmmez baglanirken dogru domain yonetimiyle boyle kullanilir doggrusu bu
            //domain yonetimi zayifsa kullanici adi ve sifrede goruruz.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=master; Trusted_Connection=true");

        }

        //hangi classim hangi tabloya?
        //madem bu baglantiyi da kurduk artik entityframework kullanarak urun katgori v mustreilerle ilgili kodlarimizi yazabiliriz.

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
