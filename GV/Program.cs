namespace GV
{
    class Program
    {
        //Estrutura dos dados de Venda e Vendedores.

        //Vendedores
        struct Vendedores
        {
            public int codVendedor;
            public string nomVendedor;
            public decimal comissaoVendedor;
        }
        //Venda
        struct Vendas
        {
            public int codVenda;
            public string zonaVenda, dataVenda;
            public decimal valorVenda;
        }

        //Função para validar um numero.
        static int Validacao(int menor, int maior, bool msg)
        {
            int num;
            string valor;
            bool t, ok = false;

            //Ciclo de validação
            do
            {
                if (msg)
                    Console.Write($"Escrever um número entre {menor} e {maior}: ");

                valor = Console.ReadLine();

                //Testa o conteúdo da variável.
                t = int.TryParse(valor, out num);
                
                //Validação do intervalo númerico.
                if (!t || num < menor || num > maior)
                    Console.WriteLine("Valor inválido, insira novamente!");
                else
                    ok = true;
                
            } while (!ok);

            //Retorno do número validado.
            return num;
        }

        //Menu Principal
        static int MenuPrincipal()
        {
            Console.WriteLine("GV - Gestão de Vendas");
            Console.WriteLine("1. Vendedores");
            Console.WriteLine("2. Vendas");
            int op = Validacao(1, 2, true);

            if (op == 1)
                Console.WriteLine("Vendedores");
            if (op == 2)
                Console.WriteLine("Vendas");


        }
        
        
    }
}


            