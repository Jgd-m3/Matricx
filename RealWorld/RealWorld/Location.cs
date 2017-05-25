using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealWorld
{
    class Location
    {
        //Static Attribute ------------------------------------------------------------------------------------------
        private static readonly String[] CITIES = {"C.Real", "Puertollano", "Valdepeñas", "Manzanares", "Daimiel"
                                                    , "Tomelloso", "Miguelturra", "Malagon", "Almagro", "Bolaños"
                                                    , "Piedrabuena", "Aldea Del Rey", "Villarrubia", "Navalpino", "Consuegra" };
        // Attributes + Getters & Setters ---------------------------------------------------------------------------
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public String City { get; set; }


        // Methods -------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor that creates random coordinates of province of Ciudad Real
        /// </summary>
        public Location()
        {
            Latitude = ((double)RandomNumber.random_Number(38511000, 39449000))/1000000;
            Longitude = ((double)RandomNumber.random_Number(-4682000, -2715500))/1000000;
            City = CITIES[RandomNumber.random_Number(0, CITIES.Length)];
        }


    }
}
