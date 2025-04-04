using System;
using System.Buffers;
using System.Transactions;
using System.Xml.Serialization;

namespace lesson
{
    public class Program
    {
        /// <summary>
        /// The main entrypoint of your application.
        /// </summary>
        /// <param name="args">The arguments passed to the program</param>


        public static void Main(string[] args)
        {
            //LessonInformation();

            Console.WriteLine("Ora gli esercizi:");

            //int[] array = LoadArray(10);
            //PrintArray(array);
            //Console.WriteLine("Esercizio 1;");
            //Exercise1();
            //Console.WriteLine("Esercizio 2;");
            //Exercise2();
            //Console.WriteLine("Esercizio 3;");
            //Exercise3();
            //Console.WriteLine("Esercizio 4;");
            //Exercise4();
            //PrintMatrix(LoadMatrix(2, 2));

            Exercise5();

            Console.WriteLine();
        }


        /// <summary>
        /// Carica un array di n celle, chiedendo in inputi tutti i valori
        /// </summary>
        /// <param name="n">Il numero di celle da creare nell'array</param>
        /// <returns>L'array risultato</returns>
        private static int[] LoadArray(int n)
        {
            if (n < 0)
            {
                Console.WriteLine($"N dve essere un numero positivo, {n} non lo è");
                return new int[] { };
            }
            else
            {
                Console.WriteLine($"Caricamento vettore di {n} elementi...");
                int[] result = new int[n];

                for (int i = 0; i < result.Length; i++)
                {
                    Console.Write($"array[{i}]= ");
                    result[i] = Convert.ToInt32(Console.ReadLine());
                }

                return result;
            }

        }


        /// <summary>
        /// Carica un array bi-dimensionale date colonne e righe, chidendo in input
        /// tutti i valori
        /// </summary>
        /// <param name="rows">Il numero di righe dell'array bi-dimensionale</param>
        /// <param name="columns">Il numero di colonne dell'array bi-dimensionale</param>
        /// <returns>L'array bi-dimensionale</returns>
        private static int[,] LoadMatrix(int rows, int columns)
        {
            if (rows < 0 || columns < 0)
            {
                Console.WriteLine($"Righe e colonne devono essere un numeri positivi");
                return new int[,] { };
            }
            else
            {
                int[,] result = new int[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write($"matrix[{i}, {j}] = ");
                        result[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }

                return result;
            }
        }
        /// <summary>
        /// Stampa gli elementi di un array, uno per riga, mettendo anche le
        /// informazioni sull'indice
        /// </summary>
        /// <param name="array">L'array da stampare a video</param>
        private static void PrintArray(int[] array)
        {
            Console.WriteLine($"Stampa di un array di {array.Length} elementi...");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"array[{i}] -> {array[i]}");
            }
        }

        /// <summary>
        /// Stampa gli elementi di un array, riga per riga
        /// </summary>
        /// <param name="array">L'array bi-dimensionale da stampare a video</param>
        private static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            Console.WriteLine($"Stampa di una matrice con {rows} righe e {columns} colonne...");

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            
        }


        /// <summary>
        /// Copia gli elementi di un array caricato in input in un secondo array,
        /// poi li stampa emtrambi
        /// </summary>
        private static void Exercise1()
        {
            Console.WriteLine("Inserire N: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arrayA = LoadArray(n);
            int[] arrayB = new int[n];

            //copia arrayA dentro arrayB
            for (int i = 0; i < n; i++)
            {
                arrayB[i] = arrayA[i];
            }

            //stampiamo i 2 array
            Console.WriteLine("arrayA");
            PrintArray(arrayA); //uguale come il ciclo for da ^
            Console.WriteLine("arrayB");
            PrintArray(arrayB); //uguale come il ciclo for da ^^
        }


        /// <summary>
        /// Copia gli elementi di un array caricato in input in un secondo array,
        /// invertendoli, poi li stampa emtrambi
        /// </summary>
        private static void Exercise2() 
        {
            Console.WriteLine("Inserire N: ");
            int n = Convert.ToInt32(Console.ReadLine());
        int[] arrayA = LoadArray(n);
        int[] arrayB = new int[n];

            //copia arrayA dentro arrayB
            for(int i = 0; i<n;i++)
            {
                arrayB[arrayB.Length - 1 - i] = arrayA[i];
            }

    //stampiamo i 2 array
    Console.WriteLine("arrayA");
            PrintArray(arrayA); //uguale come il ciclo for da ^
    Console.WriteLine("arrayB");
            PrintArray(arrayB); //uguale come il ciclo for da ^^
        
        }

        /// <summary>
        /// Invertire gli elementi di un array, senza usare un secondo array
        /// </summary>
        private static void Exercise3()
        {
            Console.WriteLine("Inserire N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arrayA = LoadArray(n);
            Console.WriteLine("Prima dell'inversione");
            PrintArray(arrayA);

            for(int i = 0; i < n; i++)
            {
                int temp = arrayA[i];
                arrayA[i] = arrayA[n - i - 1];
                arrayA[n - i - 1] = temp;
            }

            Console.WriteLine("Dopo l'inversione");
            PrintArray(arrayA);
        }
                                        

        /// <summary>
        /// Determina il valore maggiore e il valore minore in un array in input
        /// </summary>
        private static void Exercise4()
        {
            Console.WriteLine("Inserire N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arrayA = LoadArray(n);

            if (n == 0)
            {
                Console.WriteLine("Non posso trovare massimo e minimo in un array vuoto");
            }
            else
            {
                int max = arrayA[0];
                int min = arrayA[0];

                for(int i = 0;i < n; i++)
                {
                    if (arrayA[i] > max)
                    {
                        max = arrayA[i];
                    }
                    else if (arrayA[i] < min) 
                    {
                        min = arrayA[i];
                    }
                }

                Console.WriteLine($"Il valore maggiore è {max}");
                Console.WriteLine($"Il valore minore è {min}");
            }
        }

        /// <summary>
        /// Calcolare la somma di due matrici richieste in input
        /// </summary>
        private static void Exercise5()
        {
            Console.WriteLine("Inserire il numero di colonne:");
            int columns= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Inserire il numero di righe: ");
            int rows = Convert.ToInt32(Console.ReadLine());

            int[,] matrixA = LoadMatrix(rows, columns);
            int[,] matrixB = LoadMatrix(rows, columns); 
            
            int[,] matrixResult = new int[rows, columns];
            
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    matrixResult[i ,j] = matrixA[i ,j] + matrixB[i, j];
                }
            }
            //stampiamo il risultato
            Console.WriteLine("Matrice somma:");
            PrintMatrix(matrixResult);
        }


        private static CodeIdentifier Exercise6()
        {
            Console.WriteLine("Inserire il numero di colonne:");
            int columns = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Inserire il numero di righe: ");
            int rows = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Inserire il numero da cercare: ");
            int x = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = LoadMatrix(rows, columns);

            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] == x)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine($"Il valore {x} compare esattamente {count} volte della matrice");
        }

        

        /// <summary>
        /// Contiene le infermazioni relative alla lezione
        /// </summary>
        private static void LessonInformation()
        {

            Console.WriteLine("Esrcitazione 3 - .NET Console");

            Console.WriteLine("I tipi primitivi: [Limitati]");
            Console.WriteLine(@"I tipi di dato primitivo sono quei tipi di dato elementare\n
            che non possono essere scomposti in tipi più semplici. Rientrano in questa 
            categoria i seguenti tipii di dato:
            -bool
            -byte, short, int, long
            -float, double, decimal
            -char
            -string");

            Console.WriteLine("I tipi derivati [Infiniti]");
            Console.WriteLine(@"I tipi di dato derivati sono quei tipi di dato non 
            elementare che si creano componendo i tipi primitivi in diverser maniere.
            Rientrano in questo categoria i seguenti tipi di dato:
            -gli array (su qualsiasi dimensione) [vettori] -tipi primitivi allocati in maniera omogenea
            -le struct -tipi primitivi allocati in maniera non omogenea
            -le classi -tipi primitivi allocati in maniera non omogenea, che seguono le regole della 
            programmazione a oggetti (Object Oriented Programming -OOP)");

            Console.WriteLine("Gli array: ");
            Console.WriteLine(@"Definiamo array una variabile che consiste nell'allocazione contigua
            (tutto attacato) di celle di memoria che contengono valori appartenenti allo stesso tipo
               primitivo.
            Tipicamente noi conosciamo gli array mono-dimensionali, e chiamiamo 'matrici' gli array
            multi-dimensionali");

            //Inizializzazione diretta con questa inizializzaione impostiamo tutti e valori delle
            //cellle dell'array e solo quelle (non ne aggiungiamo altre vuote          
            int[] array = { 1, 2, 3, 4 };


            //Inizializzazione array vuoto di dimensione 10 con questa inizializzazione impostiamo
            //le 10 celle a zero. Non ne aggiungiamo altre vuote
            int[] array2 = new int[10];


            //La dimensione non deve essere per forza definita come costante: le variabili vanno
            //anche bene
            int n = 10;
            int[] array3 = new int[n];


            //Il metodo Array.Resize ridimensiona un array mono-dimensionale dandogli una nuova dimensione
            //
            //Se la nuova dimensione è maggiore della precedente, aggiunge nuove celle impostando lo zero-value
            //
            //Se la nuova dimensione è della precedente, gli ultimi elementi verranno eliminati per fare spazio
            //
            //La parola chiave "ref" serve a passare per referenza (inidirizzo / parola con la p) la variabile
            Array.Resize(ref array, n * 2);


            //Buffer Overflow Attack - RESEARCH

            Console.WriteLine(@"Per accedere a una cella di un array, usiamo la notazione 'a indice' (array[indice]).
            Questo si può fare sia per la lettura che per l'impostazione / assegnamento");


            //imposto
            array[0] = 10;

            //leggo
            Console.WriteLine(array[0]);

            //l'indice può anche essere una variabile
            int x = 1;
            Console.WriteLine($"array[{x}] -> {array[x]}");

            //è possibile scorrere un array di qualsiasi tipo con uno o più cicli
            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"array[{i}] -> {array[i]}");
            }

            Console.WriteLine(@"Definiamo matrice (a N dimensioni) un array multi-dimensionale avente
            esattamente N dimensioni.");


            //inizializzazione diretta
            int[,] matrix2D =
            {
                { 1, 2 },
                { 3, 4 },
            };


            //inizializzazione con zero-values
            int[,] matrix2DZero = new int[10, 10];


            //assegnamento
            matrix2DZero[0, 1] = 1;
            matrix2DZero[1, 2] = 2;


            //lettura
            x = 1;
            int y = 1;
            Console.WriteLine($"matrix2DZero[{x}, {y}] -> {matrix2DZero[x, y]}");


            //inizializzazione diretta di una matrice a 3 dimensioni
            int[,,] matrix3D =
            {
                {
                    { 1, 2 },
                    { 3, 4 },
                },
                {
                { 5, 6 },
                { 7, 8 },
                },
            };


            //lettura
            int z = 0;
            Console.WriteLine($"matrix3D[{x}, {y}, {z}] -> {matrix3D[x, y, z]}");

            Console.WriteLine("Nelle matrici, il .Length contiene il totale di celle");
            Console.WriteLine(@"Per ottenere gli elementi in una determinata dimensione,
            usiamo il metodo .GetLength(dimensione)");

            int rows = matrix2D.GetLength(0);
            int columns = matrix2D.GetLength(1);

            Console.WriteLine($"matrix2D ha {rows} righe e {columns} colonne");

            for(int i = 0;i < rows;i++)
            {
                for(int j = 0;j < columns;j++)
                {
                    Console.WriteLine($"matrix[{i}, {j}] -> {matrix2D[i,j]}");
                }
            }
        }
    }
}
