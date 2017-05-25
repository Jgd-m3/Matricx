using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealWorld
{
    class Program
    {
        // static attribute -----------------------------------------------------------------------
        static private readonly int MATRIX_SIZE_DEF = 5;
        // Attributes ----------------------------------------------------------------------------
        Character_List list;
        Neo neo;
        Smith smith;
        Character[,] matrix;



        // Program itself
        private void execution()
        {
            bool fin = false;
            Console.WriteLine("############ Simulation starts #############");

            for (int i = 1; i <= 20 && !fin; i++)
            {
                Console.WriteLine("\n------\n {0}\"\n------", i);
                oneSecond();
                printMatrix();
                if (i % 2 == 0) twoSeconds();
                if (i % 5 == 0) fiveSeconds();

                if(!(fin = isEmpty())) Thread.Sleep(1000);
                
            }   
            Console.WriteLine("\n############ Simulation ends #############\n");
            Console.WriteLine("\nFinal Matrix's situation:\n");
            printMatrix();
            if (fin) Console.WriteLine("\tSmith: \"It was inevitable, Mr Anderson...\"");
            else Console.WriteLine("\tHumanity lives.... at the moment.");
            Console.ReadKey();

        }


        /**
         * method to execute each second
         */
        public void oneSecond()
        {
            int size = matrix.GetLength(0);
            Character aux;

            for (int i = 0, j = 0; i < size && j < size; j++)
            {
                aux = matrix[i, j];
                if (aux != null && aux != neo && aux != smith && aux.getChances() > 7) matrix[i, j] = new RealWorld.Character();
                else if (aux != null && aux != neo && aux != smith) matrix[i, j].increaseChances();

                if(j == size-1 && i < size - 1)
                {
                    j = -1;
                    i++;
                }
            }
        }

        /**
         * method to execute each 2 seconds
         */
        private void twoSeconds()
        {
            Console.Write("\nSmith is moving on...");
            kill();
        }

        /**
         * method to execute each 5 seconds
         */
        private void fiveSeconds()
        {
            neo.changeFaith();
            if (neo.Believe)
            {
                int i, j;
                Utils.lookingCharacter(matrix, neo, out i, out j);
                resurrection(i, j);
            }
            Utils.moveNeo(matrix, neo);
        }

        /**
         * method to make the resurrections
         */
        private void resurrection(int i, int j)
        {
            Console.Write("\nNeo relives this time....");
            for(int k = i-1, l = j-1; k <i+2 && l < j+2; l++)
            {
                if (k > -1 && k < matrix.GetLength(0) && l > -1 && l < matrix.GetLength(1) && matrix[k, l] == null)
                {
                    matrix[k, l] = list.Get_First();
                    list.Remove_First();
                    Console.Write(" {0}.", matrix[k, l].Name);
                }

                
                if(l == j+1 && k < i + 1)
                {
                    k++;
                    l = j - 2;
                }
            }
            Console.WriteLine("\n** new matrix stat: ");
            printMatrix();
        }

        /**
         * method where Smith kills
         */
        private void kill()
        {
            int kills = RandomNumber.random_Number(1, smith.getMaxChances() + 1);
            Console.Write(" and want to kill {0} characters\n", kills);
            Character_List futureKills = giveMeTheListSlow();

            for (int i = 0, j = 0, k = 0; k < kills && i < matrix.GetLength(0); j++)
            {

                if (futureKills.Get_First() == null) return;

                if (matrix[i,j] == futureKills.Get_First())
                {
                   // Console.WriteLine("TRAZE: pj's chances = {0}",matrix[i,j].getChances() );
                    matrix[i, j] = null;
                    futureKills.Remove_First();
                    i = 0;
                    j = -1;
                    k++;
                }
                if(j == matrix.GetLength(1)-1 && i < matrix.GetLength(0))
                {
                    i++;
                    j = -1;
                }
            }            
        }

        /**
         * method to show the results
         */
        private void printMatrix()
        {
            StringBuilder bar = new StringBuilder();
            Character aux;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                bar.Append("-----");
            }
            //bar.Append("\n");
            Console.WriteLine(bar);
            for(int i = 0, j = 0; i< matrix.GetLength(0) && j < matrix.GetLength(1); j++)
            {
                aux = matrix[i, j];
                if (aux == null) Console.Write("|   |");
                else if (aux.GetType() == typeof(Neo)) Console.Write("| N |");
                else if (aux.GetType() == typeof(Smith)) Console.Write("| S |");
                else Console.Write("| {0} |", aux.getChances());

                if(j == matrix.GetLength(1)-1 && i < matrix.GetLength(0))
                {
                    Console.WriteLine();
                    i++;
                    j = -1;
                    Console.WriteLine(bar);
                }
            }
        }

        /**
         * method to know if the matrix is empty
         */
        private bool isEmpty()
        {
            Character_List a = giveMeTheListFast(matrix);
            return a.Is_Empty();
        }

        /**
         * ITERATIVE method to get a matix's characters_list faster & efficient
         */
        public Character_List giveMeTheListFast(Character[,] matrix)
        {
            Character_List a = new Character_List();

            foreach (Character b in matrix)
            {
                if (b!= null && b.GetType() != typeof(Neo) && b.GetType() != typeof(Smith)) a.Add_First(b);
            }
            a.sortC_list();
            return a;
        }


        /**
         * Method to get a sorted list to kills characters
         */
        public Character_List giveMeTheListSlow()
        {
            Character_List a = new Character_List();
            //looking for Smith
            int iS, jS;
            Utils.lookingCharacter(matrix, smith, out iS, out jS);
            //calling the recursive method
            search(iS, jS, iS - 1, jS - 1, 0, 1, 0, a);
            a.sortC_list();
            return a;
        }


        /**
         * RECURSIVE method to get a matix's characters_list
         */
        public void search(int iS, int jS, int i, int j, int stage, int wave, int visits, Character_List list)
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
                stage += (i == iS - wave || i == iS + wave) ? wave * 2 + 1 : 1;
                if (i < 0)
                {
                    search(iS, jS, ++i, j, stage, wave, visits,list);
                    return;
                }
                else
                {
                    search(iS, jS, iS - (wave + 1), jS - (wave + 1), stage, wave, visits, list);
                    return;
                }
            }
            else if (j < 0 || j >= matrix.GetLength(1))
            {
                if (i == iS - wave || i == iS + wave)
                {
                    stage += (j < 0) ? j * (-1) : jS + wave - matrix.GetLength(1);
                    search(iS, jS, i, 0, stage, wave, visits,list);
                    return;
                }

                else stage++;

                if (j < 0)
                {
                    search(iS, jS, i, j + wave * 2, stage, wave, visits,list);
                    return;
                }
                else
                {
                    search(iS, jS, ++i, jS - wave, stage, wave, visits,list);
                    return;
                }
            }

            //getting Characters
            if (matrix[i, j] == null) visits++;
            else if (matrix[i, j].GetType() != typeof(Neo))
            {
                //Console.WriteLine("TRAZA: CHAR {1} añadido: {0}", matrix[i, j].Name, stage);
                list.Add_First(matrix[i, j]);
                visits++;
            }
            stage++;

            //asking for another characters
            if ((i == iS - wave || i == iS + wave) && j < jS + wave) search(iS, jS, i, ++j, stage, wave, visits, list);
            else if (i < iS + wave && j < jS) search(iS, jS, i, j + wave * 2, stage, wave, visits,list);
            else if (i < iS + wave && j > jS) search(iS, jS, ++i, jS - wave, stage, wave, visits, list);
            else if (i == iS + wave && j == jS + wave) search(iS, jS, iS - (wave + 1), jS - (wave + 1), stage, wave, visits, list);
            return;

        }


        // Constructors ------------------------------------------------------------------------------------------
        public Program() : this(MATRIX_SIZE_DEF) { }

        public Program(int size)
        {
            //init
            neo = new Neo();
            smith = new Smith();
            list = new Character_List();
            for (int i = 0; i < 200; i++) list.Add_Last(new Character());
            matrix = new Character[size,size];

            Utils.insertNeo(matrix, neo);
            Utils.insertSmith(matrix, smith);
            Utils.fillMatrix(matrix, list);

            // exec
            execution();
        }

        // Main ---------------------------------------------------------------------------------------------------
        static void Main(string[] args)
        {
            new Program();
           //new Tests();
        }
    }
}
