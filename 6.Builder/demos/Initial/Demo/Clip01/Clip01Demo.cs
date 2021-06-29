using System;

namespace Demo.Clip01
{
    class Clip01Demo : Common.Demo
    {
        protected override void Implementation()
        {
            string connString = "Data Source=localhost;Initial Catalog=DemoDB;User Id=my;Password=name";

            Console.WriteLine(connString);
        }
    }
}
