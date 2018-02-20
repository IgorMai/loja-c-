using System;
using System.Globalization;
using Loja_Imoveis.dominio;
namespace Loja_Imoveis
{
    class Tela
    {
        public static void mostrarMenu()
        {
            Console.WriteLine("1 - Listar produtos ordenadamente");
            Console.WriteLine("2 - Cadastrar Produto");
            Console.WriteLine("3 - Cadastrar Pedido");
            Console.WriteLine("4 - Mostrar dados de um pedido");
            Console.WriteLine("5 - Sair");
            Console.Write("Digite uma Opção: ");
        }
        public static void mostrarProdutos()
        {
            Console.WriteLine("Listagem de Produtos");

            for(int i=0; i<Program.produtos.Count; i++)
            {
                Console.WriteLine(Program.produtos[i]);
            }
        }

        public static void cadastrarProduto()
        {
            Console.WriteLine("Digite os dados do produto: ");
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.WriteLine("Descrição: ");
            string descricao = Console.ReadLine();
            Console.Write("preco: ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Produto P = new Produto(codigo, descricao, preco);
            Program.produtos.Add(P);
            Program.produtos.Sort();
        }

        public static void cadastrarPedido()
        {
            Console.WriteLine("Digite os dados do pedido: ");
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Dia: ");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("Mês: ");
            int mes = int.Parse(Console.ReadLine());
            Console.Write("Ano: ");
            int ano = int.Parse(Console.ReadLine());
            Pedido P = new Pedido(codigo, dia, mes, ano);
            Console.Write("Quantos itens tem o pedido? ");
            int N = int.Parse(Console.ReadLine());
            for( int i=1; i<=N; i++)
            {
                Console.Write("Digite os dados do " + i + "º item: ");
                Console.Write("Produto (código): ");
                int codProduto = int.Parse(Console.ReadLine());
                int pos = Program.produtos.FindIndex(x => x.codigo == codProduto);
                if (pos == -1)
                {
                    throw new ModelExeption("Código de produto não encontrado: " + codProduto);
                }
                Console.Write("Quantidade: ");
                int qte = int.Parse(Console.ReadLine());
                Console.Write("Porcentagem de desconto: ");
                double porcent = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                ItemPedido ip = new ItemPedido(qte, porcent, P, Program.produtos[pos]);
                P.itens.Add(ip);
            }
            Program.pedidos.Add(P);
        }

        public static void mostrarPedido()
        {
            Console.Write("Digite o Codigo do pedido: ");
            int codpedido = int.Parse(Console.ReadLine());
            int pos = Program.pedidos.FindIndex(x => x.codigo == codpedido);
            if (pos == -1)
            {
                throw new ModelExeption("Código de pedido não encontrado: " + codpedido);
            }
            Console.WriteLine(Program.pedidos[pos]);
            Console.WriteLine();
        }
    }
}
