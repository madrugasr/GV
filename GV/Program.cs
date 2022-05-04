namespace Gestor_Vendas
{
    class Program
    {
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


        //Estrutura dos dados de Venda e Vendedores.
        //Vendedores
        public struct Vendedor
        {
            public int codVendedor;
            public string nomVendedor;
            public decimal comissaoVendedor;
        }

        //Venda
        public struct Venda
        {
            public int codVenda;
            public string zonaVenda, dataVenda;
            public decimal valorVenda;
        }

        //Menu Principal
        static int MenuPrincipal()
        {
            Console.WriteLine("GESTÃO DE VENDAS");
            Console.WriteLine("\n1. Vendedor");
            Console.WriteLine("2. Venda");
            Console.WriteLine("\n0. Sair");
            return Validacao(0, 2, true);
        }


        static void Main()
        {
            int opçao;
            int codColab = 0;
            int i = 0;
            //Definição da estrutura para o Array Venda.
            Venda[] venda = new Venda[0];

            //Definição da estrutura para o Array Vendedor.
            Vendedor[] vendedor = new Vendedor[0];
            do
            {

                opçao = MenuPrincipal();
                switch (opçao)
                {
                    case 1:
                        MenuVendedor();
                        break;
                    case 2:
                        MenuVenda();
                        break;
                }
                Console.WriteLine("Prima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();


                // Função que valida se codigo de Venda existe.
                static bool ValidaCodExisteVenda(int codigo, Venda[] venda)
                {
                    //variaveis menu
                    decimal codigovendas = 0;
                    //Se encontrar passa a true.
                    bool encontrei = false;

                    int i = 0;

                    //Clico para encontrar se o número do Vendedor existe.
                    while (i < venda.Length && !encontrei)
                    {
                        if (venda[i].codVenda == codigo)
                            encontrei = true;
                        i++;
                    }
                    return encontrei;
                }

                //Valida se o número existe e
                //toma a decisão de aceitar ou não de acordo com o tipo.
                static int ValidaCodigoVenda(int limEsq, int limDir, Venda[] venda, string tipo)
                {
                    int codigo;
                    while (true)
                    {
                        codigo = Validacao(limEsq, limDir, true);

                        //ValidaCodExisteVendedor o código no array.
                        //True se encontra ou F se não encontra.
                        bool result = ValidaCodExisteVenda(codigo, venda);


                        if (result == true && tipo == "new")
                        {
                            Console.WriteLine($"Código {codigo} existe!");
                        }

                        else if (result == false && tipo == "new")
                        {
                            Console.WriteLine($"Código {codigo} não existe!");
                            break;
                        }

                        else if (result == true && tipo == "exist")
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
                //variaveis menu
                decimal codigovendas;
                //Variáveis Menu
                int codigoVendedor;

                //Função que valida se codigo do Vendedor existe.
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
                    int codigo;
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

                        else if (result == true && tipo == "exist")
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



                //Menu Vendedor
                static void MenuVendedor()
                {


                    //Operação Vendedor
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("GESTÃO DE VENDEDORES");
                        Console.WriteLine("\n1. Inserir");
                        Console.WriteLine("2. Consultar");
                        Console.WriteLine("3. Listar");
                        Console.WriteLine("4. Alterar");
                        Console.WriteLine("5. Eliminar");
                        Console.WriteLine("6. Comissão de Vendas");
                        Console.WriteLine("\n0. Voltar");
                        int opcaoVendedor = Validacao(0, 6, true);


                        switch (opcaoVendedor)
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
                                

                                break;

                            case 3: // Listar Vendedores
                                Console.Clear();
                                Console.WriteLine("LISTAR VENDEDOR");
                                for (int i = 1; i <= vendedor.Length; i++)
                                {

                                    Console.WriteLine($"Código: {vendedor[i - 1].codVendedor}, " +
                                                        $"Nome: {vendedor[i - 1].nomVendedor}, " +
                                                        $"Comissão: {vendedor[i - 1].comissaoVendedor}");
                                }
                                break;

                            case 4: //Alterar Vendedores
                                Console.Clear();
                                Console.WriteLine("ALTERAR VENDEDOR");
                                Console.WriteLine("\nCódigo do Vendedor:");
                                codigoVendedor = ValidaCodigoVendedor(1, 1000, vendedor, "exist");

                                for (int i = 0; i < vendedor.Length; i++)
                                
                                    if (codigoVendedor == vendedor[i].codVendedor)
                                    {
                                        Console.WriteLine($"Código: {vendedor[i].codVendedor}, " +
                                                            $"Nome: {vendedor[i].nomVendedor}, " +
                                                            $"Comissão: {vendedor[i].comissaoVendedor}");

                                        Console.WriteLine("ALTERAÇÃO");

                                        Console.Write("\nCódigo: ");
                                        vendedor[i].codVendedor = ValidaCodigoVendedor(1, 1000, vendedor, "new");

                                        Console.Write("Nome: ");
                                        vendedor[i].nomVendedor = Console.ReadLine();

                                        Console.Write("Comissão: ");
                                        vendedor[i].comissaoVendedor = Convert.ToDecimal(Console.ReadLine());
                                    }
                                

                                Console.WriteLine("\nVendedores alterados com sucesso!");
                                break;

                            case 5: //Eliminando Vendedor.
                                Console.Clear();
                                Console.WriteLine("DELETAR VENDEDOR");
                                Console.WriteLine("\nCódigo do Vendedor:");
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
                                        for (int k = i; k < vendedor.Length; k++)
                                        {
                                            vendedor[k].codVendedor = vendedor[k + 1].codVendedor;
                                            vendedor[k].nomVendedor = vendedor[k + 1].nomVendedor;
                                            vendedor[k].comissaoVendedor = vendedor[k + 1].comissaoVendedor;
                                        }
                                    }
                                }
                                Console.WriteLine("Dados eliminados com sucesso!");
                                break;

                            case 6: //calculo de comissoes
                                Console.Clear();
                                decimal comissao = 0;
                                Console.WriteLine("Calculo da comissão de vendas");
                                Console.WriteLine("\nCódigo do Vendedor:");
                                codigoVendedor = ValidaCodigoVendedor(1, 1000, vendedor, "exist");
                                Console.WriteLine("Mês das vendas?");
                                codigovendas = ValidaCodigoVenda(1, 12, venda, "exist");




                                for (int i = 0; i < vendedor.Length; i++)
                                {
                                    if (codigoVendedor == vendedor[i].codVendedor)
                                    {
                                        for (int k = 0; k < venda[k].codVenda; k++)
                                        {
                                            if (codigovendas == venda[k].valorVenda)
                                            {
                                                comissao = vendedor[i].comissaoVendedor * venda[k].valorVenda;
                                                Console.WriteLine($"A comissão do vendedor{vendedor[i].nomVendedor} é {comissao} €");
                                            }
                                        }
                                    }

                                }
                                break;
                        


                            case 0:
                                MenuPrincipal();
                                break;
                        }

                        Console.ReadKey();

                    } while (true);
                }






                //Menu Venda
                static void MenuVenda()
                {

                    //Declaração de variáveis.
                    int codigoVenda;

                    do
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
                        int opcaoVenda = Validacao(0, 9, true);


                        switch (opcaoVenda)
                        {
                            case 1: //Inserindo Venda.
                                Console.Clear();
                                Console.WriteLine("INSERIR VENDA");
                                Console.WriteLine("\nQuantos vendas quer adicionar?");
                                int numVenda = Validacao(1, 1000, true);

                                //Valida o tamanho antigo do Array Vendedor.
                                int tamanhoAntigo = venda.Length;

                                // Obtem o número total de índices do Array Vendedor.
                                int tamanhoAtual = tamanhoAntigo + numVenda;

                                // Redimensiona o comprimento do Array Vendedor para a nova dimensão.
                                Array.Resize(ref venda, tamanhoAtual);

                                for (int i = tamanhoAntigo; i < tamanhoAtual; i++)
                                {
                                    Console.WriteLine($"\nInserindo o {i + 1}º Venda");

                                    //Inserindo novos vendedores no Array Vendedor.
                                    Console.Write("\nCódigo: ");
                                    venda[i].codVenda = ValidaCodigoVenda(1, 1000, venda, "new");


                                    Console.Write("Zona: ");
                                    venda[i].zonaVenda = Convert.ToString(Console.ReadLine());

                                    Console.Write("Data: ");
                                    venda[i].dataVenda = Console.ReadLine();

                                    Console.Write("Valor: ");
                                    venda[i].valorVenda = Convert.ToDecimal(Console.ReadLine());

                                }

                                Console.WriteLine("\nVendedores inseridos com sucesso!");
                                break;

                            case 2: //Consultar Venda.
                                Console.Clear();
                                Console.WriteLine("CONSULTAR VENDA");
                                Console.WriteLine("\nCódigo de Venda:");
                                codigoVenda = ValidaCodigoVenda(1, 1000, venda, "exist");

                                for (int i = 0; i < venda.Length; i++)
                                    if (codigoVenda == venda[i].codVenda)
                                    {

                                        Console.WriteLine($"{venda[i].codVenda}," +
                                                            $"{venda[i].zonaVenda}," +
                                                            $"{venda[i].dataVenda}," +
                                                            $"{venda[i].valorVenda}");
                                    }
                                break;

                            case 3: // Listar Venda.
                                Console.Clear();
                                Console.WriteLine("LISTAR VENDA");
                                for (int i = 1; i <= venda.Length; i++)
                                {

                                    Console.WriteLine($"Código: {venda[i - 1].codVenda}, " +
                                                             $"Zona: {venda[i - 1].zonaVenda}, " +
                                                             $"Data: {venda[i - 1].dataVenda}, " +
                                                             $"Valor: {venda[i - 1].valorVenda}");
                                }
                                break;

                            case 4: //Alterar Venda.
                                Console.Clear();
                                Console.WriteLine("ALTERAR VENDA");
                                Console.WriteLine("\nCódigo de Venda:");
                                codigoVenda = ValidaCodigoVenda(1, 1000, venda, "exist");

                                for (int i = 0; i < venda.Length; i++)
                                    if (codigoVenda == venda[i].codVenda)
                                    {
                                        Console.WriteLine($"Código: {venda[i - 1].codVenda}, " +
                                                            $"Zona: {venda[i - 1].zonaVenda}, " +
                                                            $"Data: {venda[i - 1].dataVenda}, " +
                                                            $"Valor: {venda[i - 1].valorVenda}");

                                        Console.WriteLine("ALTERAÇÃO");

                                        Console.Write("\nCódigo: ");
                                        venda[i].codVenda = ValidaCodigoVenda(1, 1000, venda, "new");

                                        Console.Write("Zona: ", venda[i].zonaVenda = Console.ReadLine());
                                        //venda[i].zonaVenda = Console.ReadLine();

                                        Console.Write("Data: ");
                                        venda[i].dataVenda = Console.ReadLine();

                                        Console.Write("Valor: ");
                                        venda[i].valorVenda = Convert.ToDecimal(Console.ReadLine());

                                    }

                                Console.WriteLine("\nVendedores alterados com sucesso!");
                                break;

                            case 5: //Eliminando Venda.
                                Console.Clear();
                                Console.WriteLine("DELETAR VENDA");
                                Console.WriteLine("\nCódigo de Venda:");
                                codigoVenda = ValidaCodigoVenda(1, 1000, venda, "exist");

                                for (int i = 0; i < venda.Length; i++)
                                {
                                    if (codigoVenda == venda[i].codVenda)
                                    {

                                        Console.WriteLine($"Código: {venda[i - 1].codVenda}, " +
                                                          $"Zona: {venda[i - 1].zonaVenda}, " +
                                                          $"Data: {venda[i - 1].dataVenda}, " +
                                                          $"Valor: {venda[i - 1].valorVenda}");
                                    }

                                    Console.WriteLine("Eliminar venda? (S/n)");
                                    string eliminar = Console.ReadLine();

                                    if (eliminar == "S")
                                    {
                                        Console.WriteLine("Eliminando os dados...");
                                        for (int k = i; k < venda.Length - 1; k++)
                                        {
                                            venda[k].codVenda = venda[k + 1].codVenda;
                                            venda[k].zonaVenda = venda[k + 1].zonaVenda;
                                            venda[k].dataVenda = venda[k + 1].dataVenda;
                                            venda[k].valorVenda = venda[k + 1].valorVenda;

                                        }
                                    }
                                }
                                Console.WriteLine("Dados eliminados com sucesso!");
                                break;
                            case 6:
                                Console.Clear();
                                int soma_vend = 0;
                                Console.WriteLine("Total de vendas por vendedor");
                                int codigototalvend = Validacao(1, 1000, true);
                                int k = Convert.ToInt32(Console.ReadLine());

                                for (int i = 0; i < venda.Length; i++)
                                    if(codigototalvend == venda[k].codVenda)
                                    {
                                     soma_vend = soma_vend + Convert.ToInt32(venda[i].valorVenda);
                                    }
                                     

                                Console.WriteLine($"O vendedor {vendedor[k].nomVendedor} fez {soma_vend}€ em vendas");
                                break;
                            case 7:
                                Console.Clear();
                                string codigototalzona = "";
                                int soma_zona_north = 0;
                                int soma_zona_south = 0;
                                int soma_zona_east = 0;
                                int soma_zona_west = 0;
                                Console.WriteLine("Total de vendas por zona");

                                for (int i = 0; i < venda.Length; i++)
                                {
                                    if (venda[i].zonaVenda == "North")
                                    {
                                        soma_zona_north = soma_zona_north + Convert.ToInt32(venda[i].valorVenda);
                                    }
                                    else if (venda[i].zonaVenda == "South") 
                                    {
                                        soma_zona_south = soma_zona_south + Convert.ToInt32(venda[i].valorVenda);
                                    }
                                    else if (venda[i].zonaVenda == "East") 
                                    {
                                        soma_zona_east = soma_zona_east + Convert.ToInt32(venda[i].valorVenda);
                                    }
                                    else if (venda[i].zonaVenda == "West") 
                                    {
                                        soma_zona_west = soma_zona_west + Convert.ToInt32(venda[i].valorVenda);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zona Invalida!!");
                                        MenuVenda();
                                    }

                                }
                                Console.WriteLine($"North:{soma_zona_north}€" +
                                    $"South:{soma_zona_south}€" +
                                    $"East:{soma_zona_east}€" +
                                    $"West:{soma_zona_west}€");
                                break;
                            case 8:


                            case 0:
                                MenuPrincipal();
                                break;
                        }

                        Console.ReadKey();

                    } while (true);
                }
            }
        }
    
    }
}
    
        

    




