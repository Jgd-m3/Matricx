using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealWorld
{
    class Tests
    {
        
        /*
        public Tests()
        {

            /*      Test of locations
            Location a;

            for (int i = 0; i < 15; i++)
            {
                a = new Location();
                Console.WriteLine("La location: {0} coords: {1}, {2}", a.City, a.Latitude, a.Longitude);
            }
            */
            /*
            // Character b= null;
               Character_List a = new Character_List();
               Character[,] matrix = new Character[5, 5];

                       // a.Add_First(null);
                       // a.Add_First(null);
                        for (int i = 0; i < 30; i++) 
                        {
                            a.Add_Last(new Character());
                          //  a.Add_Last(null);

                        }
                   /*     Console.WriteLine("traza: empieza el deleteNulls, size: " + a.elements());
                        a.deleteNulls();
                    Console.WriteLine("Traza: acaba el deleteNulls, size: " + a.elements());
           // a.sortC_list();
            
                        
                        Neo c = new Neo();
                        Smith d = new Smith();

                        Utils.insertNeo(matrix, c);
                        Utils.insertSmith(matrix, d);
                        Utils.fillMatrix(matrix, a);
            /*
                        Utils.moveNeo(matrix, c);
                        matrix[1, 0] = null;
                        matrix[1, 1] = null;
                        matrix[1, 2] = null;
                        Character[] n = Utils.sortCharacters(matrix, 8);
                        /*
                        Program.oneSecond(matrix, c, d);
                        Program.oneSecond(matrix, c, d);
                        Program.oneSecond(matrix, c, d);
                        */
            /*   c.print();
               d.print();


                b.prompt();
                Console.WriteLine("El character: {0} age: {1} lives in {2}", b.Name, b.Age, b.Loc.City);
   /* testing Prompts()
                c.prompt();
                Console.WriteLine("\nEl Neo: {0} age: {1} lives in {2} and belive? {3}", c.Name, c.Age, c.Loc.City, c.Belive);
                d.prompt();

                Console.WriteLine("El Smith: {0} age: {1} lives in {2} and maxChances: {3}", d.Name, d.Age, d.Loc.City, d.getMaxChances()); 
          
            // fin del test*/
            /*
            //test de la recursividad:
            int iS, jS;
            Utils.lookingCharacter(matrix, d, out iS, out jS);
            Character_List listaRecuperada = new Character_List();

             recursive(iS, jS, iS - 1, jS - 1, 0, 1, 0, matrix, listaRecuperada);
            //recur(matrix, listaRecuperada, (Int16) iS, (Int16) jS);

            Console.WriteLine("NO HA SALTADO EXCEPCION? (breakpointer)");


            Console.ReadKey();
           
        }

        public void recursive(int iS, int jS, int i, int j, int stage, int wave, int visits, Character[,] matrix, Character_List list)
        {

            if (stage % ((8 * wave) + 1) == 0)
            {
                int aux = wave;
                wave = wave + (stage / ((8 * wave) + 1));
                stage = 1;
            } 
            

            //base case
            if (visits == matrix.Length - 2) return;

            //prunning IndexOutOfRanges
            if (i < 0 || i >= matrix.GetLength(0))
            {
                stage += (i == iS - wave || i == iS + wave) ?wave * 2 + 1: 1;
                if (i < 0)
                {
                    recursive(iS, jS, ++i, j, stage, wave, visits, matrix, list);
                    return;
                }
                else
                {
                    recursive(iS, jS, iS - (wave + 1), jS - (wave + 1), stage, wave, visits, matrix, list);
                    return;
                }
            }
            else if (j < 0 || j >= matrix.GetLength(1))
            {
                if (i == iS - wave || i == iS + wave)
                {
                    stage += (j < 0) ? j * (-1) : jS + wave - matrix.GetLength(1);
                    recursive(iS, jS, i, 0, stage, wave, visits, matrix, list);
                    return;
                }
                    
                else stage++;

                if (j < 0)
                {
                    recursive(iS, jS, i, j + wave * 2, stage, wave, visits, matrix, list);
                    return;
                }
                else
                {
                    recursive(iS, jS, ++i, jS - wave, stage, wave, visits, matrix, list);
                    return;
                }
            }
            */
            //getting Characters
            /* 
             * TRAZA: JUGANDOMELA A QUE NO SE HA COLADO NINGUN INDEXOUTOFRANGES
             *//*
            if (matrix[i, j] == null) visits++;
            else if (matrix[i, j].GetType() != typeof(Neo))
            {
                Console.WriteLine("TRAZA: CHAR {1} añadido: {0}", matrix[i, j].Name, stage
                    );
                list.Add_First(matrix[i, j]);
                visits++;
            }
            stage++;

            //asking for another characters
            if ((i == iS - wave || i == iS + wave) && j < jS + wave) recursive(iS, jS, i, ++j, stage, wave, visits, matrix, list);
            else if (i < iS + wave && j < jS) recursive(iS, jS, i, j + wave * 2, stage, wave, visits, matrix, list);
            else if (i < iS + wave && j > jS) recursive(iS, jS, ++i, jS - wave, stage, wave, visits, matrix, list);
            else if (i == iS + wave && j == jS + wave) recursive(iS, jS, iS - (wave + 1), jS - (wave + 1), stage, wave, visits, matrix, list);
            return;

        }*/
    }
}
