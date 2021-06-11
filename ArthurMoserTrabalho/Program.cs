using System;
using System.Collections.Generic;


namespace Arthur_Moser
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lista = new List<string>();

            int[][] matriz_1 = GeraMatriz(1);
            int[][] matriz_2 = GeraMatriz(2);
            int[][] matriz_3 = GeraMatriz(3);
            int[][] matriz_4 = GeraMatriz(4);

            Console.WriteLine("                                        ↓ Inicialização de estoque ↓ \n");

            VizualizaMatriz(matriz_1, matriz_2, matriz_3, matriz_4);


            int dias = 0;

            while (true)
            {


                //Condicional 6 dias encerra programa
                Console.WriteLine("\n");
                if ((dias + 1) < 7)
                {
                    Console.WriteLine("                                   ↓ Aperte enter para simular Dia |" + (dias + 1) + "| ↓");

                }
                else
                {
                    break;
                }

                Console.ReadLine();

                Console.WriteLine("-----------------------------------------------/RELATÓRIO DIA " + (dias + 1) + "/--------------------------------------\n");
                //Entrada Pacotes p/ guardar em estoque
                for (int i = 0; i < Geradores.Qtd(); i++)
                {
                    lista = Geradores.GeraEntrada();
                    Console.Write("                    Entrada Pkg|" + (i + 1) + "|: ");
                    foreach (var item in lista)
                    {
                        Console.Write("[" + item + "]");
                    }


                    //Confere se há espaço em estoque e adiciona na matriz
                    lista = AddLivres(matriz_1, lista);
                    lista = AddLivres(matriz_2, lista);
                    lista = AddLivres(matriz_3, lista);
                    lista = AddLivres(matriz_4, lista);

                    //Itens não armazenados na matriz
                    Console.Write("      → Devolução Pkg|" + (i + 1) + "|: ");
                    foreach (var item in lista)
                    {
                        Console.Write("[" + item + "]");
                    }
                    Console.WriteLine("\n");
                }
                Console.WriteLine("\n---------------------------------------------------/Entradas/-----------------------------------------\n");
                VizualizaMatriz(matriz_1, matriz_2, matriz_3, matriz_4);
                Console.WriteLine("\n------------------------------------------------------//-----------------------------------------------\n");
                VizualizaEnvio(matriz_1, matriz_2, matriz_3, matriz_4);
                dias++;
                Console.WriteLine("\n");
                Console.WriteLine("\n---------------------------------------------------/Saidas/-------------------------------------------\n");

                VizualizaMatriz(matriz_1, matriz_2, matriz_3, matriz_4);
                Console.WriteLine("\n------------------------------------------------------//----------------------------------------------\n");
            }


            Console.WriteLine("Aperte enter p/ encerrar o programa\n");
            Console.ReadLine();
        }
        public static void VizualizaEnvio(int[][] matriz_1, int[][] matriz_2, int[][] matriz_3, int[][] matriz_4)
        {
            string ordem = Geradores.OrdemDeServico();

            int[] vetor = TamanhoVetorOrdem(matriz_1, matriz_2, matriz_3, matriz_4, ordem);

            Console.WriteLine("\n                    Ordem de Serviço: " + ordem + "\n");
            Console.Write("                    Ordem de Serviço em vetor: ");
            for (int i = 0; i < vetor.Length; i++)
            {
                Console.Write("[" + vetor[i] + "]");

            }
            Console.WriteLine("\n");
            vetor = VetorEnvio(matriz_1, matriz_2, matriz_3, matriz_4, vetor);
            Console.Write("                    Itens enviados: ");

            for (int i = 0; i < vetor.Length; i++)
            {
                if (vetor[i] == 0)
                {
                    Console.Write("[0] ");
                }
                else
                {
                    Console.Write("[" + vetor[i] + "]");
                }
            }
        }
        public static int[][] GeraMatriz(int id)
        {
            int[][] matriz = new int[6][];

            for (int i = 0; i < matriz.Length; i++)
            {
                matriz[i] = new int[6];
            }

            //Contador elementos
            int cont = 0;

            //Preenche Matriz
            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz[i].Length; j++)
                {
                    cont++;

                    //Condiciona Matriz(6x6) = 36 elementos / 2 = 18 (Metade da matriz)
                    if (cont <= 18)
                    {
                        matriz[i][j] = id;
                    }
                    else
                    {
                        matriz[i][j] = 0;
                    }

                }
            }
            return matriz;
        }
        public static void VizualizaMatriz(int[][] matriz_1, int[][] matriz_2, int[][] matriz_3, int[][] matriz_4)
        {

            //Vizualização de Matriz
            Console.WriteLine("                              |Estoque 1|  |Estoque 2|  |Estoque 3|  |Estoque 4| \n");
            for (int i = 0; i < matriz_1.Length; i++)
            {

                if (i == 0)
                {
                    Console.Write("                    Saidas →");
                }
                else if (i == 5)
                {
                    Console.Write("                  Entradas →");
                }
                else
                {
                    Console.Write("                            ");
                }
                Console.Write("| ");
                for (int k = 0; k < matriz_1[i].Length; k++)
                {
                    int temp;
                    temp = matriz_1[i][k];
                    Console.Write(temp + " ");
                }
                Console.Write(" ");
                for (int l = 0; l < matriz_2[i].Length; l++)
                {
                    int temp;
                    temp = matriz_2[i][l];
                    Console.Write(temp + " ");
                }
                Console.Write(" ");
                for (int m = 0; m < matriz_3[i].Length; m++)
                {
                    int temp;
                    temp = matriz_3[i][m];
                    Console.Write(temp + " ");
                }
                Console.Write(" ");
                for (int n = 0; n < matriz_4[i].Length; n++)
                {
                    int temp;
                    temp = matriz_4[i][n];
                    Console.Write(temp + " ");
                }
                Console.Write("|\n");

            }
            Console.WriteLine("\n                              |Qtd    " + Estoque(matriz_1) + "|  |Qtd    " + Estoque(matriz_2) + "|  |Qtd    " + Estoque(matriz_3) + "|  |Qtd    " + Estoque(matriz_4) + "| \n");

        }
        public static int IdentificaId(int[][] matriz)
        {
            //Identifica o id pela matriz
            int id = 0;
            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz[i].Length; j++)
                {
                    if (matriz[i][j] != 0)
                    {
                        id = matriz[i][j];
                        i = matriz.Length;
                        break;

                    }
                }
            }
            return id;

        }
        public static int Estoque(int[][] matriz)
        {
            //Quantidade de itens na Matriz Estoque
            string id = Convert.ToString(IdentificaId(matriz));
            int qtd = 0;
            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz[i].Length; j++)
                {
                    if (matriz[i][j] == Convert.ToInt32(id))
                    {
                        qtd++;
                    }
                }
            }
            return qtd;
        }
        public static int QtdLista(int[][] matriz, List<string> lista)
        {
            //Quantidade de itens na lista recebida
            int id = IdentificaId(matriz);
            int cont = 0;
            foreach (var item in lista)
            {

                if (item == id.ToString())
                {
                    cont++;

                }
            }
            return cont;
        }
        public static List<string> AddLivres(int[][] matriz, List<string> lista)
        {

            string id = Convert.ToString(IdentificaId(matriz));
            int cont = 0, contIni = 0, qtdEstoque = 0;
            bool verifica = false;

            cont = QtdLista(matriz, lista);
            qtdEstoque = Estoque(matriz);
            contIni = cont;


            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz[i].Length; j++)
                {
                    if (cont > 0)
                    {
                        if (matriz[i][j] == 0)
                        {
                            matriz[i][j] = Convert.ToInt32(id);
                            lista.Remove(id);
                            cont--;
                            qtdEstoque++;
                            if (qtdEstoque >= 36)
                            {
                                return lista;
                            }
                        }

                        if (cont == 0)
                        {
                            if (verifica)
                            {
                                i = matriz.Length;
                                break;
                            }
                        }
                    }
                }
            }


            return lista;


        }
        public static bool RemoveEstoque(int[][] matriz)
        {
            int id = IdentificaId(matriz);
            bool verifica = false;

            if (Estoque(matriz) > 0)
            {
                for (int i = 0; i < matriz.Length; i++)
                {
                    for (int j = 0; j < matriz[i].Length; j++)
                    {

                        if (matriz[i][j] != 0)
                        {
                            matriz[i][j] = 0;
                            verifica = true;
                            return verifica;
                        }

                    }
                }
            }
            return verifica;
        }
        public static int[] TamanhoVetorOrdem(int[][] matriz, int[][] matriz2, int[][] matriz3, int[][] matriz4, string ordem)
        {
            int cont1 = 0, cont2 = 0, cont3 = 0, cont4 = 0, cont0 = 0, total = 0;



            for (int i = 0; i < ordem.Length; i++)
            {
                switch (ordem[i])
                {
                    case '1':
                        if (RemoveEstoque(matriz))
                        {
                            cont1++;
                        }

                        break;
                    case '2':
                        if (RemoveEstoque(matriz2))
                        {
                            cont2++;
                        }
                        break;
                    case '3':
                        if (RemoveEstoque(matriz3))
                        {
                            cont3++;
                        }
                        break;
                    case '4':
                        if (RemoveEstoque(matriz4))
                        {
                            cont4++;
                        }
                        break;
                    default:

                        cont0++;
                        break;
                }
            }
            total = cont1 + cont2 + cont3 + cont4;

            if (total > 8)
            {
                total = 10;
            }
            else if (total > 6)
            {
                total = 8;
            }
            else
            {
                total = 6;
            }
            int[] vetor = new int[total];

            for (int i = 0; i < vetor.Length; i++)
            {
                vetor[i] = Convert.ToInt32(ordem[i].ToString());
            }


            return vetor;
        }
        public static int[] VetorEnvio(int[][] matriz, int[][] matriz2, int[][] matriz3, int[][] matriz4, int[] vetor)
        {

            for (int i = 0; i < vetor.Length; i++)
            {
                switch (vetor[i])
                {
                    case '1':
                        if (!RemoveEstoque(matriz))
                        {
                            vetor[i] = 0;
                        }


                        break;
                    case '2':
                        if (!RemoveEstoque(matriz2))
                        {
                            vetor[i] = 0;
                        }

                        break;
                    case '3':
                        if (!RemoveEstoque(matriz3))
                        {
                            vetor[i] = 0;
                        }

                        break;
                    case '4':
                        if (!RemoveEstoque(matriz4))
                        {
                            vetor[i] = 0;
                        }

                        break;
                    default:
                        break;
                }
            }

            return vetor;
        }



    }



}


