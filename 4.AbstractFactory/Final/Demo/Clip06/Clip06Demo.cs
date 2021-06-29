using System;
using Demo.Clip06.CheapDb;
using Demo.Clip06.Data;
using Demo.Clip06.FastDb;

namespace Demo.Clip06
{
    class Clip06Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 6;

        protected override void Implementation()
        {
            string connectionString =
                @"Data Source=localhost;Initial Catalog=DemoDB;User Id=my;Password=name";
            IDataAccess gateway1 = new FastDataAccess();
            new HeadHunter(connectionString, gateway1).AddEmployee("Joe");

            Console.WriteLine("-------------------");
            IDataAccess gateway2 = new CheapDataAccess();
            new HeadHunter(connectionString, gateway2).AddEmployee("Joe");
        }
    }
}
