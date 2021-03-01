using Business.Concrete;
using Business.Constants;
using DataAccesses.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.GetAll();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.ColorName+ " /" + car.Id );
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
