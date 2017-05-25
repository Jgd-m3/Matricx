using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealWorld
{
    class Character : Implementations
    {
        // Static Attribute -------------------------------------------------------------------------
        private static readonly String[] NAMES = { "Javi-Pc15", "Edi", "Bacho", "Cristian", "FranVerde", "Jesus", "Paloma"
                                                    , "Alex", "Elena", "Cere", "Fernando", "Marcilla", "Fran", "Edu", "Ivan" };
        // Atributos ---------------------------------------------------------------------------------
        private int chancesOfDie;

        public int Age { get; set; }
        public String Name { get; set; }
        public Location Loc { get; set; }

        // Methods ------------------------------------------------------------------------------------
        
        /**
         * Constructor
         */
        public Character()
        {
            Age = RandomNumber.random_Number(0, 76);
            Name = NAMES[RandomNumber.random_Number(0, NAMES.Length)];
            Loc = new Location();
            chancesOfDie = RandomNumber.random_Number(0, 8);
        }

        /**
         * method to increase the death's chances (setter)
         */
        public void increaseChances() { chancesOfDie += 1; }
        /**
         * getter of the chances
         */
        public int getChances() { return chancesOfDie; }

        



        // Implement Methods --------------------------------------------------------------------------

        public void generate() { /* NOT IMPLEMENTED */ }

        /**
         * Implemented method to ask for the characters datas
         */
        public virtual void prompt()
        {

            int ag;
            double lat;
            String classType = this.GetType().ToString();
            classType = classType.Substring(classType.IndexOf('.')+1);

            // asking the name
            Console.WriteLine("Insert the name of the {0}: ", classType);
            Name = Console.ReadLine();

            // asking the age
            do
            {
                Console.WriteLine("Insert the age of the {0}: ", classType);
            }while(!(int.TryParse(Console.ReadLine(), out ag)) || ag < 0);
            Age = ag;

            // asking the chances of die ONLY IF is a Character
            if (this.GetType() == typeof(Character))
            {
                do {
                    Console.WriteLine("Insert the Chances of Die of the {0}: ", classType);
                } while (!(int.TryParse(Console.ReadLine(), out ag)) || ag < 0 || ag > 7);
                chancesOfDie = ag;
            }

            //asking the location - city
            Console.WriteLine("Insert the city of the {0}: ", classType);
            Loc.City = Console.ReadLine();
            // * - latitude
            Console.WriteLine("Insert the latitude of the location of the {0}: ", classType);
            while (!(double.TryParse(Console.ReadLine(), out lat))) Console.WriteLine("Insert the latitude of the location of the character: ");
            Loc.Latitude = lat;
            // * - longitude
            Console.WriteLine("Insert the longitude of the location of the {0}: ", classType);
            while (!(double.TryParse(Console.ReadLine(), out lat))) Console.WriteLine("Insert the longitude of the location of the character: ");
            Loc.Longitude = lat;
            

        }
        /**
         * method to to print the characters datas
         */
        public virtual void print()
        {
            Console.WriteLine("PJ: {0}; {1} years, from {2}: [{3}, {4}] has {5}% of die"
                                ,Name , Age, Loc.City, Loc.Latitude, Loc.Longitude, chancesOfDie*10);
        }
    }
}
