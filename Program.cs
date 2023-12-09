class Graph
{
    static void Main(string[] args)
    {
        int n, m;
        Console.Write("Введiть кiлькiсть вершин n: ");
        n = int.Parse(Console.ReadLine());
        Console.Write("Введiть кiлькiсть ребер m: ");
        m = int.Parse(Console.ReadLine());
        Console.WriteLine("Граф орієнтовний/неорієнтовний? Напишіть:" +
                        "\n+ якщо граф орієнтовний " +
                        "\n- якщо граф неорієнтовний.");
        char type = char.Parse(Console.ReadLine());
        Console.WriteLine("Введiть початкову та кiнцеву вершини через кому(приклад: 1, 2)");

        int[,] Matrix = new int[m, 2];

        // Парсимо дані
        for (int i = 0; i < m; i++)
        {
            string s = Console.ReadLine();
            string[] subs = s.Split(", ");
            Matrix[i, 0] = int.Parse(subs[0]);
            Matrix[i, 1] = int.Parse(subs[1]);
        }

        int[] V = GetUniqueVertices(Matrix);

        int[,] MatrixAdj = CreateAdjacencyMatrix(Matrix, V, type, m);

        WriteMatrix("Матриця сумiжностi", MatrixAdj);
        Console.Write("Введiть вершину,з якої буде виконаний пошук в ширину:");
        int startV = int.Parse(Console.ReadLine());
        BreadthFirstSearch(startV, MatrixAdj, V);
        Console.ReadKey();
    }
    static void BreadthFirstSearch(int startVertex,int[,] adjacencyMatrix,int [] V)
    {
       
        int j = 0;
        int []deepSearch=new int[V.Length];
        deepSearch[j] = startVertex;
        startVertex--;
        bool used=false;
 
        for (int element=1;element < deepSearch.Length; element++)
        {
            for (int i = 0; i < adjacencyMatrix.GetLength(1); i++)
            {
                if (adjacencyMatrix[startVertex, i] == 1)
                {
                    for (int k = 0; k < deepSearch.Length; k++)
                    {
                        if (deepSearch[k] == V[i])
                        {
                            used = true;
                        }
                    }
                    if (used == false)
                    {
                        j++;
                        deepSearch[j] = V[i]; 
                        Console.Write(deepSearch[j] + " ");
                    }
                }
                used = false;
            }
 
            startVertex = deepSearch[element]-1;
        }


        //Console.WriteLine();
        //for (int i = 0; i < deepSearch.Length; i++)
        //{
        //    Console.Write(deepSearch[i] + " ");
        //}
    }

    static int[] GetUniqueVertices(int[,] matrix)
    {
        HashSet<int> uniqueChars = new HashSet<int>();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            uniqueChars.Add(matrix[i, 0]);
            uniqueChars.Add(matrix[i, 1]);
        }
        int[] V = new int[uniqueChars.Count];
        uniqueChars.CopyTo(V);
        Array.Sort(V); // Сортуємо вершини
        return V;
    }

    static int[,] CreateAdjacencyMatrix(int[,] matrix, int[] V, char type, int m)
    {
        int n = V.Length;
        int[,] MatrixAdj = new int[n, n];
        for (int i = 0; i < m; i++)
        {
            int vertex1 = matrix[i, 0];
            int vertex2 = matrix[i, 1];

            int index1 = Array.IndexOf(V, vertex1);
            int index2 = Array.IndexOf(V, vertex2);

            MatrixAdj[index1, index2] = 1;
            if (type == '-')
            {
                MatrixAdj[index2, index1] = 1;
            }
        }

        return MatrixAdj;
    }

    static void WriteMatrix(string text, int[,] Matrix)
    {
        Console.WriteLine(text);
        for (int i = 0; i < Matrix.GetLength(0); i++)
        {
            for (int j = 0; j < Matrix.GetLength(1); j++)
            {
                Console.Write(Matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

   
    
  

   
}