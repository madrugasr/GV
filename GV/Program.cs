namespace Gestor_Vendas
{
    class Program
    {

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


        static void Main(string[] args)
        {
            MenuPrincipal();




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
                        Console.WriteLine($"Código {codigo} existe!");
                    }

                    else if (result == false && tipo == "new")
                    {
                        Console.WriteLine($"Código {codigo} não existe!");
                        break;
                    }

                    if (result == true && tipo == "exist")
                    {
                        Console.WriteLine($"Código {codigo} existe!");
                        break;
                    }

                    else if (result == false && tipo == "exist")
                    {
                        Console.WriteLine($"Código {codigo} não existe!");
                    }
                }
                return codigo;
            }

            //Menu Principal

            static void MenuPrincipal()
            {
                Console.Clear();
                Console.WriteLine("GESTÃO DE VENDAS");
                Console.WriteLine("\n1. Vendedor");
                Console.WriteLine("2. Venda");
                Console.WriteLine("\n0. Sair");
                int op = Validacao(0, 2, true);

                switch (op)
                {
                    case 1:
                        MenuVendedor();
                        break;
                    case 2:
                        MenuVenda();
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Obrigado por utilizar a nossa aplicação.");
                        Console.WriteLine("Tchau!");
                        Environment.Exit(0);
                        break;
                }
            }

            static void MenuVendedor()
            {
                Console.Clear();
                Console.WriteLine("MENU VENDEDOR");
                Console.WriteLine("\n1. Inserir");
                Console.WriteLine("2. Consultar");
                Console.WriteLine("3. Listar");
                Console.WriteLine("4. Alterar");
                Console.WriteLine("5. Eliminar");
                Console.WriteLine("6. Comissão de Vendas");
                Console.WriteLine("\n0. Voltar");
                int opMenu = Validacao(0, 6, true);


                //Definição da estrutura para o Array Vendedor.
                Vendedor[] vendedor = new Vendedor[0];

                //Variáveis Menu
                int codigoVendedor = 0;

                switch (opMenu)
                {
                    case 1: //Inserindo Vendedores.
                        Console.Clear();
                        Console.WriteLine("INSERIR VENDEDOR");
                        Console.WriteLine("\nQuantos vendedores quer adicionar?");
                        int numVendedores = Validacao(1, 1000, true);

                        //Valida o tamanho antigo do Array Vendedor.
                        int tamanhoAntigo = vendedor.Length;

                        // Obtem o número total de índices do Array Vendedor.
                        int tamanhoAtual = tamanhoAntigo + numVendedores;

                        // Redimensiona o comprimento do Array Vendedor para a nova dimensão.
                        Array.Resize(ref vendedor, tamanhoAtual);

                        for (int i = tamanhoAntigo; i < tamanhoAtual; i++)
                        {
                            Console.WriteLine($"\nInserindo o {i + 1}º Vendedor");

                            //Inserindo novos vendedores no Array Vendedor.
                            Console.Write("Código: ");
                            vendedor[i].codVendedor = ValidaCodigoVendedor(1, 1000, vendedor, "new");

                            Console.Write("Nome: ");
                            vendedor[i].nomVendedor = Console.ReadLine();

                            Console.Write("Comissão: ");
                            vendedor[i].comissaoVendedor = Convert.ToDecimal(Console.ReadLine());

                        }

                        Console.WriteLine("\nVendedores inseridos com sucesso!");
                        Console.ReadKey();
                        MenuVendedor();
                        break;


                    case 2: //Consultar Vendedor
                        Console.Clear();
                        Console.WriteLine("CONSULTAR VENDEDOR");
                        Console.WriteLine("\nCódigo do Vendedor:");
                        codigoVendedor = ValidaCodigoVendedor(1, 1000, vendedor, "exist");

                        for (int i = 0; i < vendedor.Length; i++)
                            if (codigoVendedor == vendedor[i].codVendedor)
                            {

                                Console.WriteLine($"Código: {vendedor[i].codVendedor}, " +
                                    $"Nome: {vendedor[i].nomVendedor}, " +
                                    $"Comissão: {vendedor[i].comissaoVendedor}");
                            }
                        
                        
                        MenuVendedor();
                        break;

                    case 3: // Listar Vendedores
                        Console.Clear();
                        Console.WriteLine("LISTAR VENDEDOR");
                        for (int i = 1; i <= vendedor.Length; i++)
                        {

                            Console.WriteLine($"Código: {vendedor[i - 1].codVendedor}, " +
                                $"Nome: {vendedor[i - 1].nomVendedor}, " +
                                $"Comissão: {vendedor[i - 1].comissaoVendedor}");

                            Console.WriteLine($"Codigo");

                        }

                        Console.ReadKey();
                        MenuVendedor();
                        break;

                    case 4: //Alterar Vendedores
                        Console.Clear();
                        Console.WriteLine("ALTERAR VENDEDOR");
                        Console.WriteLine("\nCódigo do Vendedor\n");
                        codigoVendedor = ValidaCodigoVendedor(1, 1000, vendedor, "exist");

                        for (int i = 0; i < vendedor.Length; i++)
                            if (codigoVendedor == vendedor[i].codVendedor)
                            {
                                Console.WriteLine($"Código: {vendedor[i].codVendedor}, " +
                                $"Nome: {vendedor[i].nomVendedor}, " +
                                $"Comissão: {vendedor[i].comissaoVendedor}");

                                Console.WriteLine("ALTERAÇÃO");

                                Console.Write("Código: ");
                                vendedor[i].codVendedor = ValidaCodigoVendedor(1, 1000, vendedor, "new");

                                Console.Write("Nome: ");
                                vendedor[i].nomVendedor = Console.ReadLine();

                                Console.Write("Comissão: ");
                                vendedor[i].comissaoVendedor = Convert.ToDecimal(Console.ReadLine());
                            }

                        Console.WriteLine("\nVendedores alterados com sucesso!");
                        Console.ReadKey();
                        MenuVendedor();
                        break;

                    case 5: //Eliminando colaborador.
                        Console.Clear();
                        Console.WriteLine("DELETAR VENDEDOR");
                        Console.WriteLine("\nCódigo do Vendedor\n");
                        codigoVendedor = ValidaCodigoVendedor(1, 1000, vendedor, "exist");

                        for (int i = 0; i < vendedor.Length; i++)
                        {
                            if (codigoVendedor == vendedor[i].codVendedor)
                            {

                                Console.WriteLine($"Código: {vendedor[i].codVendedor}, " +
                                    $"Nome: {vendedor[i].nomVendedor}, " +
                                    $"Comissão: {vendedor[i].comissaoVendedor}");
                            }

                            Console.WriteLine("Eliminar vendedor? (S/n)");
                            string eliminar = Console.ReadLine();

                            if (eliminar == "S")
                            {
                                Console.WriteLine("Eliminando os dados...");
                                for (int k = i; k < vendedor.Length - 1; k++)
                                {
                                    vendedor[k].codVendedor = vendedor[k + 1].codVendedor;
                                    vendedor[k].nomVendedor = vendedor[k + 1].nomVendedor;
                                    vendedor[k].comissaoVendedor = vendedor[k + 1].comissaoVendedor;
                                }
                            }
                        }
                        Console.WriteLine("Dados eliminados com sucesso!");
                        Console.ReadKey();
                        MenuVendedor();
                        break;

                    case 0:
                        MenuPrincipal();
                        break;
                }
            }

            static void MenuVenda()
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
                Console.WriteLine("\n0. Voltar");
                int opMenu = Validacao(0, 9, true);


                //Definição da estrutura para o Array Vendedor.
                Venda[] venda = new Venda[0];

                //Variáveis Menu
                int codigoVenda;


            }


        }
    }
}
    
        

    




