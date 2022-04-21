namespace GV
{
    class Program
    {

        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        //Estrutura dos dados de Venda e Vendedores.
        //Vendedores
        struct Vendedor
        {
            public int codVendedor;
            public string nomVendedor;
            public decimal comissaoVendedor;
        }
        
        //Venda
        struct Venda
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

            //Ciclo de validação.
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

        // Função que valida se codigo do Vendedor existe.
        static bool ValidaCodExisteVendedor(int codigo, Vendedor[] vendedor)
        {
            
            //Se encontrar passa a true.
            bool encontrei = false; 

            int i = 0;
          
            //Clico para encontrar se o número do Vendedor existe.
            while (i < vendedor.Length && !encontrei)
            {
                if (vendedor[i].codVendedor == codigo)
                    encontrei = true;
                i++; 
            }
            return encontrei;
        }

        //Valida se o número existe e
        //toma a decisão de aceitar ou não de acordo com o tipo.
        static int ValidaCodigoVendedor(int limEsq, int limDir, Vendedor[] vendedor, string tipo)
        {
            
            int codigo = 0;

            while (true)
            { 
                codigo = Validacao(limEsq, limDir, true);

                //ValidaCodExisteVendedor o código no array.
                //True se encontra ou F se não encontra.
                bool result = ValidaCodExisteVendedor(codigo, vendedor);

       
                if (result == true && tipo == "new")
                {
                    Console.WriteLine($"Código = {codigo} existe!");
                }
                
                else if (result == false && tipo == "new")
                {
                    Console.WriteLine($"Código = {codigo} não existe!");
                    break;
                }
                
                if (result == true && tipo == "exist")
                {
                    Console.WriteLine($"Código = {codigo} existe!");
                    break;
                }
               
                else if (result == false && tipo == "exist")
                {
                    Console.WriteLine($"Código = {codigo} não existe!");
                }
            }
            return codigo;
        }

        //Menu Principal
        static void MenuPrincipal()
        {
            byte opMenu = 1;

            while (opMenu != 0)
            {
                Console.Clear();
                Console.WriteLine("GV - GESTÃO DE VENDAS");
                Console.WriteLine("\n1. Vendedor");
                Console.WriteLine("2. Venda");
                Console.WriteLine("\n0. Sair");
                Console.Write("\nOpção: ");
                opMenu = Convert.ToByte(Console.Read());


                if (opMenu == 0)
                    break;

                //Menu Vendedor
                else if (opMenu == 1)
                {
                    Console.Clear();
                    Console.WriteLine("MENU VENDEDOR");
                    Console.WriteLine("\n1. Inserir");
                    Console.WriteLine("2. Consultar");
                    Console.WriteLine("3. Listar");
                    Console.WriteLine("4. Alterar");
                    Console.WriteLine("5. Eliminar");
                    Console.WriteLine("6. Comissão de Vendas");
                    Console.WriteLine("0. Voltar");

                    Console.Write("Opção: ");
                    byte op = Convert.ToByte(Console.Read());


                    //Definição da estrutura para o Array Vendedor.
                    Vendedor[] venda = new Vendedor[0];


                    switch (op)
                    {
                        //Inserindo Vendedores.
                        case 1:
                            Console.Write("INSERIR VENDEDOR");
                            Console.Write("Quantos vendedores quer adicionar? ");
                            int numVendedores = Validacao(1, 1000, true);

                            //Valida o tamanho antigo do Array Vendedor.
                            int tamanhoAntigo = venda.Length;

                            // Obtem o número total de índices do Array Vendedor.
                            int tamanhoAtual = tamanhoAntigo + numVendedores;

                            // Redimensiona o comprimento do Array Vendedor para a nova dimensão.
                            Array.Resize(ref venda, tamanhoAtual);

                            for (int i = tamanhoAntigo; i < tamanhoAtual; i++)
                            {
                                Console.WriteLine($"Inserindo o(a) {i + 1}º Vendedor(a)");

                                //Inserindo novos vendedores no Array Vendedor.
                                Console.Write("Código: ");
                                venda[i].codVendedor = ValidaCodigoVendedor(1, 1000, venda, "new");

                                Console.Write("Nome: ");
                                venda[i].nomVendedor = Console.ReadLine();

                                Console.Write("Comissão: ");
                                venda[i].comissaoVendedor = Console.ReadLine();
                            }
                            break;
                    }
                }

                //Menu Venda               
                else if (opMenu == 2)
                {
                    Console.Clear();
                    Console.WriteLine("MENU VENDA");
                    Console.WriteLine("\n1. Inserir");
                    Console.WriteLine("2. Consultar");
                    Console.WriteLine("3. Listar");
                    Console.WriteLine("4. Alterar");
                    Console.WriteLine("5. Eliminar");
                    Console.WriteLine("6. Total de vendas por Vendedor");
                    Console.WriteLine("7. Total de vendas por Zona");
                    Console.WriteLine("8. Total de vendas por Mês");
                    Console.WriteLine("9. Total de vendas por Mês para cada Vendedor");
                    Console.WriteLine("0. Voltar");

                    Console.ReadKey();


                }
                //Sair
                else if (opMenu == 0)
                    break;
            }
        } 

    }
}
    
        

    




