using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja_Imoveis.dominio;

namespace Loja_Imoveis
{
    class Program
    {
        public static List<Produto> produtos = new List<Produto>();
        public static List<Pedido> pedidos = new List<Pedido>();

        static void Main(string[] args)
        {

            int opcao = 0;

            produtos.Add(new Produto(1001, "Cadeira Simples", 500.00));
            produtos.Add(new Produto(1002, "Cadeira acolchoada", 900.00));
            produtos.Add(new Produto(1003, "Sofá de Três lugares", 2000.00));
            produtos.Add(new Produto(1004, "Mesa Retangular", 1500.00));
            produtos.Add(new Produto(1005, "Mesa Retangular", 2000.00));
            produtos.Sort();
            
            while (opcao != 5)
            {
                Console.Clear();
                Tela.mostrarMenu();
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro inesperado" + e.Message);
                    opcao = 0;
                }
                Console.WriteLine();

                if(opcao == 1)
                {
                    Tela.mostrarProdutos();
                }
                else if( opcao == 2){
                    try
                    {
                        Tela.cadastrarProduto();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Erro inesperado" + e.Message);
                        opcao = 0;
                    }                   
                }
                else if (opcao == 3)
                {
                    try
                    {
                        Tela.cadastrarPedido();
                    }
                    catch (ModelExeption e)
                    {
                        Console.WriteLine("Erro de Negócio: " + e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Erro inesperado" + e.Message);
                        opcao = 0;
                    }
                }
                else if (opcao == 4)
                {
                    try
                    {
                        Tela.mostrarPedido();
                    }
                    catch (ModelExeption e)
                    {
                        Console.WriteLine("Erro de Negócio: " + e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Erro inesperado" + e.Message);
                        opcao = 0;
                    }
                }
                else if (opcao == 5)
                {
                    Console.WriteLine("Fim do programa!");
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                }
                Console.ReadLine();
            }
           

            
        }
    }
}
