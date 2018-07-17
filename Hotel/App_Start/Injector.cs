using HotelService.Class;
using HotelService.Interface;
using Injection;
using Injection.Interfaces;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace Hotel.App_Start
{
    public class Injector
    {
        public static IInjectionContainer Container { get; set; }

        static Injector()
        {
            Container = new Container(); 
        }
        public static void Configure()
        {
            Container.Register<IUserService,UserService>().Singleton();
            Container.Register<ICustomerService, CustomerService>().Singleton();
            Container.Register<IRoomsService, RoomService>().Singleton();
        }
    }
}