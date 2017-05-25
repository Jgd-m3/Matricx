using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealWorld
{
    class Utils
    {

        /**
         * Method to Insert neo Character in the matrix
         */
        public static void insertNeo(Character[,] matrix, Neo input)
        {
            int size = matrix.GetLength(0);
            matrix[RandomNumber.random_Number(0, size), RandomNumber.random_Number(0, size)] = input;
        }
        
        /**
         * Method to insert Smith in the matrix
         */
        public static void insertSmith(Character[,] matrix, Smith input)
        {
            int i, j, size = matrix.GetLength(0);

            do
            {
                i = RandomNumber.random_Number(0, size);
                j = RandomNumber.random_Number(0, size);
            } while (matrix[i, j] != null);

            matrix[i, j] = input;
        }

        /**
         * Method to fill the matrix of characters
         */
        public static void fillMatrix(Character [,] matrix, Character_List list)
        {
            int size = matrix.GetLength(0);

            for(int i = 0, j = 0; i < size && j < size;)
            {
                if(matrix[i,j] == null)
                {
                    matrix[i, j] = list.Get_First();
                    list.Remove_First();
                }

                j++;
                if( j == size && i < size)
                {
                    j = 0;
                    i++;
                }
            }
        }

        /**
         * Method to move neo in the matrix
         */
        public static void moveNeo(Character[,] matrix, Neo neo)
        {
            int i, j, k, l, size = matrix.GetLength(0);
            Character aux;

            //looking for a character random in matrix that doesn't be Neo
            do
            {
                i = RandomNumber.random_Number(0, size);
                j = RandomNumber.random_Number(0, size);
            } while (matrix[i, j] != null && matrix[i, j].GetType() == neo.GetType());
            
            //saving character to move
            aux = matrix[i, j];

            // looking for Neo's Position
            lookingCharacter(matrix, neo, out k, out l);
            //changing positions
            matrix[i, j] = neo;
            matrix[k, l] = aux;
        }


        /**
         * Method to looking for a specific character returns the i and j in the matrix
         */
        public static void lookingCharacter(Character[,] matrix, Character pj, out int i, out int j)
        {
            int size = matrix.GetLength(0);
            bool find = false;

            for (i = 0, j = -1; !find;)
            {
                j++;
                find = (matrix[i, j] == pj);

                if (!find && j == size - 1 && i < size)
                {
                    j = -1;
                    i++;
                }
            }
        }
    }
}
