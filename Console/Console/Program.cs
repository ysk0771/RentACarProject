using Business.Concrete;
using DataAccesses.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Descriptions+" "+car.ModelYear+" "+car.Id);
            }
        }
    }
}
