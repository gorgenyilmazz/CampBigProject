using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        //yaptigimiz tek hareket inmemoryproductdali efproductdala cevirmek
        //SOLIDIN O PRRENSIBI YAZILIMA YENI BIR OZELLIK EKLIYORSAN DIGER KODLARA DOKUNULMADAN BUNUN YAPILABILMESI LAZIM
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetByUnitPrice(40, 100))
            {

                Console.WriteLine(product.ProductName);
            
            }
            

            
        }
    }
}
