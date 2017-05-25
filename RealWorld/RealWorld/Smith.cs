using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealWorld
{
    class Smith : Character, Implementations
    {

        // Static Attribute, maxChances By default
        static private readonly int MAXCHANCES_DEFAULT = 5;
        // Attributes ---------------------------------------------------------------------------------
        private int maxChances;



        // Methods  -----------------------------------------------------------------------------------

        /**
         * Constructores
         */
        public Smith() : this(MAXCHANCES_DEFAULT) { }
        
        public Smith(int chances)
        {
            maxChances = chances;
            Name = "TERMINATOR";
        }


        /**
         * getter of the maxChances
         */
        public int getMaxChances() { return maxChances; }




        // Implement Methods --------------------------------------------------------------------------
        
        // generate() is not implemented here because it's not defined, so, i didn't it virtual in base.class
        
        override public void prompt()
        {
            base.prompt();
            do
            {
                Console.WriteLine("Insert the infect's Max Chances of Smith: ");
            } while (!(int.TryParse(Console.ReadLine(), out maxChances)) || maxChances < 1);
        }
        override public void print()
        {
            Console.WriteLine("SMITH: {0}; {1} years, from {2}: [{3}, {4}] can kill {5}"
                                , Name, Age, Loc.City, Loc.Latitude, Loc.Longitude, maxChances);
        }
    }
}
