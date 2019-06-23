using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace ConsoleApp54
{
    class EulerCircuit
    {
        Stack tempPath = new Stack();
        ArrayList finalPath = new ArrayList();//Сохраняем окончательные пути
        char[] nodeList;//Хранение узлов
        char[,] GraphMatrix;
        int total, count;
        private void GetInput()
        {
            Console.WriteLine("Введите количество узлов");
            try
            {
                total = int.Parse(Console.ReadLine());
                GraphMatrix = new char[total, total];
                nodeList = new char[total];

                Console.WriteLine("Введите узлы");
              
                for (int i = 0; i < total; i++)
                {
                    nodeList[i] = char.Parse(Console.ReadLine());
                }

                Console.WriteLine("Представление графика в матрице");
                Console.WriteLine("Если между вершинами есть ребро, введите 'y' иначе 'n'");
             
                for (int i = 0; i < total; i++)
                {

                    for (int j = 0; j < total; j++)
                    {
                        Console.Write("{0}----{1}==> ", nodeList[i], nodeList[j]);
                        GraphMatrix[i, j] = char.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("");
                }
            }
            catch
            {
                Console.WriteLine("Неверный формат");
            }
        }

     
        private int GetDegree(int i)
        {
            int j, deg = 0;
            for (j = 0; j < total; j++)
            {
                if (GraphMatrix[i, j] == 'y') deg++;
            }
            return deg;
        }
   
        private int FindRoot()
        {
            int root = 1; 
            count = 0;
            for (int i = 0; i < total; i++)
            {
                if (GetDegree(i) % 2 != 0)
                {
                    count++;
                    root = i;
                }
            }
           
            if (count != 0 && count != 2)
            {
                return 0;
            }
            else return root;
        }
        
        private int GetIndex(char c)
        {
            int index = 0;
            while (c != nodeList[index])
                index++;
            return index;
        }

       

        private Boolean AllVisited(int node)
        {
            for (int l = 0; l < total; l++)
            {
                if (GraphMatrix[node, l] == 'y')
                    return false;
            }
            return true;
        }

        
        private void FindEuler(int root)
        {
            int ind;
            tempPath.Clear();
            
            tempPath.Push(nodeList[root]);
            while (tempPath.Count != 0)
            {
                
                ind = GetIndex((char)tempPath.Peek());
                if (AllVisited(ind))
                {
                    
                    finalPath.Add(tempPath.Pop());
                }
                else
                {
                    
                    for (int j = 0; j < total; j++)
                    {
                        if (GraphMatrix[ind, j] == 'y')
                        {
                            GraphMatrix[ind, j] = 'n';
                            GraphMatrix[j, ind] = 'n';
                            tempPath.Push(nodeList[j]);
                            break;
                        }
                    }
                }
            }
        }

       
        public void FindEulerCircuit()
        {
           
            GetInput();
           
            int root = FindRoot();
           
            if (root != 0)
            {
                if (count != 0) Console.WriteLine("Доступный путь Эйлера");
                else Console.WriteLine("Доступная схема Эйлера");
               
                FindEuler(root);
               
                PrintEulerCircuit();
            }
            else
            {
                Console.WriteLine("Путь Эйлера или схема невозможна");
            }

        }

        public void PrintEulerCircuit()
        {
            for (int i = 0; i < finalPath.Count; i++)
            {
                Console.Write("{0}--->", finalPath[i]);
            }
        }
    }

    class ExecuteEulerCircuit
    {
        static void Main(string[] args)
        {
           
            EulerCircuit ec = new EulerCircuit();
            ec.FindEulerCircuit();

            Console.ReadKey();
        }
    }

}







  




