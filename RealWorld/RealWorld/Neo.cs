using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealWorld
{
    class Neo : Character, Implementations
    {

        // Attributes ---------------------------------------------------------------------------------
        public bool Believe { get; set; }




        // Methods  -----------------------------------------------------------------------------------

        /**
         * Constructor
         */
        public Neo()
        {
            Name = "Son Goku";
            Believe = (RandomNumber.random_Number(0, 2) == 1);
        }

        /**
         * method to change neo's faith
         */
        public void changeFaith() { Believe = (RandomNumber.random_Number(0, 2) == 1); }



        // Implement Methods --------------------------------------------------------------------------

        // generate() is not implemented here because it's not defined, so, i didn't it virtual in base.class

        override public void prompt()
        {
            base.prompt();

            char read;
            String input;
            do
            {
                Console.WriteLine("Insert if Neo believes himself (y/n)");
                input = Console.ReadLine();
                read = (input.Length > 0) ? input.ElementAt(0) : 'a';

            }while (read != 'y'&& read != 'Y' && read != 'n' && read != 'N');

            Believe = (read == 'y' || read == 'Y');
        }
        override public void print()
        {
            Console.WriteLine("NEO: {0}; {1} years, from {2}: [{3}, {4}] & {5}"
                                , Name, Age, Loc.City, Loc.Latitude, Loc.Longitude, (Believe) ? "believes" : "Doesn't believe");
        }
       
    }
}
