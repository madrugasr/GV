using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace Gestor_Vendas
{
    class Program
    {
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

                switch (tipo)
                {
                    case "new":
                        if (result == true)
                        {
                            Console.WriteLine($"Código {codigo} existe!");
                        }

                        else if (result == false)
                        {
                            Console.WriteLine($"Código {codigo} não existe!");
                            break;
                        }
                        break;

                    case "exist":
                        if (result == true)
                        {
                            Console.WriteLine($"Código {codigo} existe!");
                            break;
                        }

                        else if (result == false)
                        {
                            Console.WriteLine($"Código {codigo} não existe!");
                        }
                        break;
                }

                return codigo;

            }
        }

        //Salvar dados de Vendedores.
        public static void SalvarVendedor(Vendedor[] vendedor)
        {
            //Escrita de chars corretos ã e ê, etc.
            Console.OutputEncoding = Encoding.UTF8;

            //Definição do caminho do Arquivo.
            string arquivo = @"C:\Users\daniel.marques\Documents\Engenharia Informática\FP\C#\Gestor de Vendas\GV\Save\Vendedor\Vendedor.csv";


            using (StreamWriter escrita = new(arquivo))
            {
                //Adicionando configuração CSV
                CsvConfiguration csvConfigOut = new(CultureInfo.CurrentCulture)
                {
                    Comment = '#',
                    //AllowComments = true,
                    //Delimiter = "; ",
                };

                CsvWriter escrever = new(escrita, csvConfigOut);

                //Adicionando Cabeçalho
                escrever.WriteField("Código");
                escrever.WriteField("Nome");
                escrever.WriteField("Comissão");
                escrever.NextRecord();

                for (int i = 0; i < vendedor.Length; i++)
                {
                    escrever.WriteField(vendedor[i].codVendedor);
                    escrever.WriteField(vendedor[i].nomVendedor);
                    escrever.WriteField(vendedor[i].comissaoVendedor);
                    escrever.NextRecord();
                }
            }

            Console.ReadKey();
        }


        // Função que valida se codigo de Venda existe.
        static bool ValidaCodExisteVenda(int codigo, Venda[] venda)
        {

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


        //Valida se o número existe.
        //Toma a decisão de aceitar ou não de acordo com o tipo.
        static int ValidaCodigoVenda(int limEsq, int limDir, Venda[] venda, string tipo)
        {
            int codigo;
            while (true)
            {
                codigo = Validacao(limEsq, limDir, true);

                //ValidaCodExisteVendedor o código no array.
                //True se encontra ou F se não encontra.
                bool result = ValidaCodExisteVenda(codigo, venda);


                switch (tipo)
                {
                    case "new":
                        if (result == true)
                        {
                            Console.WriteLine($"Código {codigo} existe!");
                        }

                        else if (result == false)
                        {
                            Console.WriteLine($"Código {codigo} não existe!");
                            break;
                        }
                        break;

                    case "exist":
                        if (result == true)
                        {
                            Console.WriteLine($"Código {codigo} existe!");
                            break;
                        }

                        else if (result == false)
                        {
                            Console.WriteLine($"Código {codigo} não existe!");
                        }
                        break;

                }
                return codigo;

            }
        }



        //Salvando dados de Vendas.
        public static void SalvarVenda(Venda[] venda)
        {

            //Escrita de chars corretos ã e ê, etc.
            Console.OutputEncoding = Encoding.UTF8;

            //Definição de Variável
            string arquivo = @"C:\Users\daniel.marques\Documents\Engenharia Informática\FP\C#\Gestor de Vendas\GV\Save\Venda\Venda.csv";

            //Usar a Classe StreamWrite para acesso ao ficheiro para a escrita.
            using (StreamWriter escrita = new(arquivo))
            {
                //Adicionando configuração CSV
                CsvConfiguration csvConfigOut = new(CultureInfo.CurrentCulture)
                {
                    Comment = '#',
                    AllowComments = true,
                    Delimiter = ";",
                };

                CsvWriter escrever = new(escrita, csvConfigOut);

                //Adicionando Cabeçalho
                escrever.WriteField("Código");
                escrever.WriteField("Zona");
                escrever.WriteField("Data");
                escrever.WriteField("Valor");
                escrever.NextRecord();

                for (int i = 0; i < venda.Length; i++)
                {
                    escrever.WriteField(venda[i].codVenda);
                    escrever.WriteField(venda[i].zonaVenda);
                    escrever.WriteField(venda[i].dataVenda);
                    escrever.WriteField(venda[i].valorVenda);
                    escrever.NextRecord();
                }
            }

        }



        //Função para validar um numero.
        static int Validacao(int menor, int maior, bool msg)
        {

            int num;
            bool ok = false;

            //Ciclo de validação.
            do
            {

                if (msg)
                    Console.Write($"Escrever um número entre {menor} e {maior}: ");

                string? valor = Console.ReadLine();

                //Testa o conteúdo da variável.
                bool t = int.TryParse(valor, out num);

                //Validação do intervalo númerico.
                if (!t || num < menor || num > maior)
                    Console.WriteLine("Valor inválido, insira novamente!");
                else
                    ok = true;

            } while (!ok);

            //Retorno do número validado.
            return num;
        }


        static void Main()
        {

            //Definição da estrutura para o Array Venda.
            Venda[] venda = Array.Empty<Venda>();

            //Definição da estrutura para o Array Vendedor.
            Vendedor[] vendedor = Array.Empty<Vendedor>();

            //Menu Principal
            Menu();

            void Menu()
            {
                Console.WriteLine("GESTÃO DE VENDAS");
                Console.WriteLine("\n1. Vendedor");
                Console.WriteLine("2. Venda");
                Console.WriteLine("\n0. Sair");
                Console.Write("\nEscolha sua Opção: ");
                int opcao = Validacao(0, 2, true);


                switch (opcao)
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
                    default:
                        Console.WriteLine("Opção Inválida!");
                        Console.ReadKey();
                        Menu();
                        break;
                }


                //Menu Vendedor.
                void MenuVendedor()
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
                        Console.WriteLine("\n7. Carregar Dados");

                        Console.WriteLine("\n0. Voltar");

                        Console.Write("\nEscolha sua Opção: ");
                        int opcaoVendedor = Validacao(0, 7, true);


                        switch (opcaoVendedor)
                        {
                            case 1: //Inserindo Vendedores.
                                Console.Clear();
                                Console.WriteLine("INSERIR VENDEDOR");
                                Console.Write("\nQuantos vendedores quer adicionar? ");
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
                                    Console.Write("\nCódigo: ");
                                    vendedor[i].codVendedor = ValidaCodigoVendedor(1, 1000, vendedor, "new");

                                    Console.Write("Nome: ");
                                    vendedor[i].nomVendedor = Console.ReadLine();

                                    Console.Write("Comissão: ");
                                    vendedor[i].comissaoVendedor = Convert.ToDecimal(Console.ReadLine()) / 100;

                                }

                                Console.WriteLine("\nVendedores inseridos com sucesso!");
                                break;

                            case 2: //Consultar Vendedor
                                Console.Clear();
                                Console.WriteLine("CONSULTAR VENDEDOR");
                                Console.WriteLine("\nCódigo:");
                                int codigoVendedorcons = ValidaCodigoVendedor(1, 1000, vendedor, "exist");

                                for (int i = 0; i < vendedor.Length; i++)

                                    if (codigoVendedorcons == vendedor[i].codVendedor)
                                    {

                                        Console.WriteLine($"\nCódigo: {vendedor[i].codVendedor}" +
                                                            $"\nNome: {vendedor[i].nomVendedor}" +
                                                            $"\nComissão: {vendedor[i].comissaoVendedor * 100}");
                                    }
                                break;

                            case 3: // Listar Vendedores
                                Console.Clear();
                                Console.WriteLine("LISTAR VENDEDOR");
                                for (int i = 1; i <= vendedor.Length; i++)
                                {

                                    Console.WriteLine($"\nCódigo: {vendedor[i - 1].codVendedor}" +
                                                        $"\nNome: {vendedor[i - 1].nomVendedor}" +
                                                        $"\nComissão: {vendedor[i - 1].comissaoVendedor * 100}");

                                }
                                break;

                            case 4: //Alterar Vendedores
                                Console.Clear();
                                Console.WriteLine("ALTERAR VENDEDOR");
                                Console.WriteLine("\nCódigo:");
                                int codigoVendedoralt = ValidaCodigoVendedor(1, 1000, vendedor, "exist");

                                for (int i = 0; i < vendedor.Length; i++)

                                    if (codigoVendedoralt == vendedor[i].codVendedor)
                                    {

                                        Console.WriteLine($"\nCódigo: {vendedor[i].codVendedor}" +
                                                            $"\nNome: {vendedor[i].nomVendedor}" +
                                                            $"\nComissão: {vendedor[i].comissaoVendedor * 100}");

                                        Console.WriteLine("\nALTERAÇÃO");

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
                                Console.WriteLine("\nCódigo:");
                                int codigoVendedor = ValidaCodigoVendedor(1, 1000, vendedor, "exist");

                                for (int i = 0; i < vendedor.Length; i++)
                                {
                                    if (codigoVendedor == vendedor[i].codVendedor)
                                    {

                                        Console.WriteLine($"\nCódigo: {vendedor[i].codVendedor}" +
                                                            $"\nNome: {vendedor[i].nomVendedor}" +
                                                            $"\nComissão: {vendedor[i].comissaoVendedor * 100}");
                                    }

                                    Console.Write("\nEliminar Vendedor? (S/n) ");
                                    string eliminar = Console.ReadLine();

                                    if (eliminar == "S")
                                    {

                                        for (int k = i; k < vendedor.Length - 1; k++)
                                        {
                                            vendedor[k].codVendedor = vendedor[k + 1].codVendedor;
                                            vendedor[k].nomVendedor = vendedor[k + 1].nomVendedor;
                                            vendedor[k].comissaoVendedor = vendedor[k + 1].comissaoVendedor;

                                            Array.Resize(ref vendedor, vendedor.Length - 1);

                                        }
                                        Console.WriteLine("Vendedor eliminados com sucesso!");
                                    }
                                    else
                                        Console.WriteLine("\nVendedor não Eliminado!");

                                }
                                break;

                            case 6: //Cálculos de Comissões

                                Console.Clear();
                                Console.WriteLine("COMISSÃO DE VENDAS");
                                Console.WriteLine("\nCódigo do Vendedor:");
                                int codigoVendedorComissao = ValidaCodigoVendedor(1, 1000, vendedor, "exist");

                                //decimal comissao = 0;
                                for (int t = 0; t < vendedor.Length; t++)
                                {
                                    if (codigoVendedorComissao == vendedor[t].codVendedor)
                                    {
                                        for (int k = 0; k < venda.Length; k++)
                                        {
                                            if (codigoVendedorComissao == venda[k].codVenda)
                                            {
                                                decimal comissao = vendedor[t].comissaoVendedor * venda[k].valorVenda;
                                                Console.WriteLine($"Comissão do Vendedor: {comissao}€");
                                            }
                                            else
                                                Console.WriteLine("Nenhuma venda Encontrada!!");
                                        }
                                    }
                                    else
                                        Console.WriteLine("Codigo Inválido");
                                }
                                Console.ReadKey();
                                break;

                            //Ler dados de Vendedores.
                            case 7:
                                Array.Resize(ref vendedor, 0);

                                //Definição do caminho do Arquivo.
                                string arquivoL = @"C:\Users\daniel.marques\Documents\Engenharia Informática\FP\C#\Gestor de Vendas\GV\Save\Vendedor\Vendedor.csv";

                                //Lendo os dados do Arquivo.
                                using (StreamReader leitura = new(arquivoL))
                                {
                                    //Adicionando configuração CSV
                                    CsvConfiguration csvConfigIn = new(CultureInfo.CurrentCulture)
                                    {
                                        //Comment = '#',
                                        //AllowComments = true,
                                        Delimiter = ";",
                                    };

                                    CsvReader ler = new(leitura, csvConfigIn);

                                    //Adicionando Cabeçalho
                                    ler.Read();

                                    //Lendo os dados do Arquivo.
                                    for (int i = 0; i < vendedor.Length; i++)
                                    {
                                        vendedor[i].codVendedor = ler.GetField<int>("Código");
                                        vendedor[i].nomVendedor = ler.GetField<string>("Nome");
                                        vendedor[i].comissaoVendedor = ler.GetField<decimal>("Comissão");
                                        ler.Read();
                                    }

                                }

                                Console.WriteLine("\nDados de Vendedores Lidos com Sucesso!");
                                break;

                            case 0:
                                Console.Clear();
                                Menu();
                                break;
                        }


                        SalvarVendedor(vendedor);

                    } while (true);
                }

                //Menu Venda
                void MenuVenda()
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
                        Console.WriteLine("6. Total de Vendas por Vendedor");
                        Console.WriteLine("7. Total de Vendas por Zona");
                        Console.WriteLine("8. Total de Vendas por Mês");
                        Console.WriteLine("9. Total de Vendas por Mês para cada Vendedor");

                        Console.WriteLine("\n10. Carregar Dados");

                        Console.WriteLine("\n0. Voltar");

                        Console.Write("\nEscolha sua Opção: ");
                        int opcaoVenda = Validacao(0, 10, true);


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

                                    //Inserindo novas vemdas no Array Venda.
                                    Console.Write("\nCódigo: ");
                                    int verificaCodVendedor = ValidaCodigoVendedor(1, 1000, vendedor, "exist");
                                    venda[i].codVenda = verificaCodVendedor;

                                    Console.Write("Zona: ");
                                    venda[i].zonaVenda = Console.ReadLine();

                                    Console.WriteLine("\nData");
                                    Console.Write("Dia: ");
                                    int dia = Convert.ToInt32(Validacao(1, 31, true));

                                    Console.Write("Mês: ");
                                    int mes = Convert.ToInt32(Validacao(1, 12, true));
                                    venda[i].dataVenda = $"{dia}/{mes}/2021";


                                    Console.Write("\nValor: ");
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

                                        Console.WriteLine($"\nCódigo: {venda[i].codVenda}" +
                                                            $"\nZona: {venda[i].zonaVenda}" +
                                                            $"\nData: {venda[i].dataVenda}" +
                                                            $"\nValor: {venda[i].valorVenda}");
                                    }
                                break;

                            case 3: // Listar Venda.
                                Console.Clear();
                                Console.WriteLine("LISTAR VENDA");
                                for (int i = 1; i <= venda.Length; i++)
                                {

                                    Console.WriteLine($"\nCódigo: {venda[i - 1].codVenda}" +
                                                             $"\nZona: {venda[i - 1].zonaVenda}" +
                                                             $"\nData: {venda[i - 1].dataVenda}" +
                                                             $"\nValor: {venda[i - 1].valorVenda}");
                                }
                                break;

                            case 4: //Alterar Venda

                                Console.Clear();
                                Console.WriteLine("ALTERAR VENDA");
                                Console.WriteLine("\nCódigo de Venda:");
                                codigoVenda = ValidaCodigoVenda(1, 1000, venda, "exist");

                                for (int i = 0; i < venda.Length; i++)
                                    if (codigoVenda == venda[i].codVenda)
                                    {
                                        Console.WriteLine($"\nCódigo: {venda[i].codVenda}" +
                                                            $"\nZona: {venda[i].zonaVenda}" +
                                                            $"\nData: {venda[i].dataVenda}" +
                                                            $"\nValor: {venda[i].valorVenda}");

                                        Console.WriteLine("\nALTERAÇÃO");

                                        Console.Write("\nCódigo: ");
                                        venda[i].codVenda = ValidaCodigoVenda(1, 1000, venda, "new");


                                        Console.Write("Zona: ");
                                        venda[i].zonaVenda = Console.ReadLine();

                                        Console.WriteLine("\nData");
                                        Console.Write("Dia: ");
                                        int dia = Convert.ToInt32(Validacao(1, 31, true));

                                        Console.Write("Mês: ");
                                        int Mes = Convert.ToInt32(Validacao(1, 12, true));
                                        venda[i].dataVenda = $"{dia}/{Mes}/2021";

                                        Console.Write("\nValor: ");
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

                                        Console.WriteLine($"\nCódigo: {venda[i].codVenda}" +
                                                          $"\nZona: {venda[i].zonaVenda}" +
                                                          $"\nData: {venda[i].dataVenda}" +
                                                          $"\nValor: {venda[i].valorVenda}");
                                    }

                                    Console.Write("Eliminar venda? (S/n)");
                                    string eliminar = Console.ReadLine();

                                    if (eliminar == "S")
                                    {

                                        for (int e = i; e < venda.Length - 1; e++)
                                        {
                                            venda[e].codVenda = venda[e + 1].codVenda;
                                            venda[e].zonaVenda = venda[e + 1].zonaVenda;
                                            venda[e].dataVenda = venda[e + 1].dataVenda;
                                            venda[e].valorVenda = venda[e + 1].valorVenda;

                                            Array.Resize(ref venda, venda.Length - 1);


                                        }
                                        Console.WriteLine("Dados eliminados com sucesso!");


                                    }
                                    else
                                        Console.WriteLine("Venda não Eliminada!");

                                }
                                break;

                            //Total de vendas por Vendedor.
                            case 6:
                                Console.Clear();

                                Console.WriteLine("TOTAL DE VENDAS POR VENDEDOR");
                                Console.WriteLine("Código do Vendedor: ");
                                codigoVenda = Validacao(1, 1000, true);

                                int totalVendas = 0;
                                for (int i = 0; i < venda.Length; i++)
                                {
                                    if (codigoVenda == venda[i].codVenda)
                                        totalVendas += Convert.ToInt32(venda[i].valorVenda);
                                    else
                                    {
                                        Console.WriteLine("Codigo não Encontrado");
                                        break;
                                    }
                                }

                                Console.WriteLine($"Vendedor {codigoVenda} fez {totalVendas}€ em vendas.");
                                break;


                            //Total de venda por Zona    
                            case 7:
                                Console.Clear();

                                Console.WriteLine("TOTAL DE VENDAS POR ZONA");
                                Console.Write("Zona: ");
                                string? vendaZona = Console.ReadLine();

                                for (int i = 0; i < venda.Length; i++)
                                {
                                    if (vendaZona == venda[i].zonaVenda)
                                    {

                                        switch (vendaZona)
                                        {
                                            case "Norte" or "N":
                                                int totalZonaNorte = 0;
                                                totalZonaNorte += Convert.ToInt32(venda[i].valorVenda);
                                                Console.WriteLine($"\n{vendaZona}: {totalZonaNorte}€");
                                                break;
                                            case "Sul" or "S":
                                                int totalZonaSul = 0;
                                                totalZonaSul += Convert.ToInt32(venda[i].valorVenda);
                                                Console.WriteLine($"\n{vendaZona}: {totalZonaSul}€");
                                                break;
                                            case "Leste" or "L":
                                                int totalZonaLeste = 0;
                                                totalZonaLeste += Convert.ToInt32(venda[i].valorVenda);
                                                Console.WriteLine($"\n{vendaZona}: {totalZonaLeste}€");
                                                break;
                                            case "Oeste" or "O":
                                                int totalZonaOeste = 0;
                                                totalZonaOeste += Convert.ToInt32(venda[i].valorVenda);
                                                Console.WriteLine($"\n{vendaZona}: {totalZonaOeste}€");
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zona não Encontrada");
                                        break;
                                    }
                                }
                                break;


                            //Total de Vendas por Mês para todos os Vendedores.
                            case 8:
                                Console.Clear();
                                Console.WriteLine("TOTAL DE VENDA POR MÊS PARA TODOS OS VENDEDORES");
                                Console.Write("Mês: ");
                                string? vendaMes = Console.ReadLine();

                                for (int i = 0; i < venda.Length; i++)
                                {
                                    if (vendaMes == venda[i].dataVenda)
                                    {
                                        switch (vendaMes)
                                        {
                                            case "1":
                                                int totalJaneiro = 0;
                                                totalJaneiro += Convert.ToInt32(venda[i].valorVenda);
                                                Console.WriteLine($"\n{vendaMes}: {totalJaneiro}€");
                                                break;
                                            case "2":
                                                int totalFevereiro = 0;
                                                totalFevereiro += Convert.ToInt32(venda[i].valorVenda);
                                                Console.WriteLine($"\n{vendaMes}: {totalFevereiro}€");
                                                break;
                                            case "3":
                                                int totalMarco = 0;
                                                totalMarco += Convert.ToInt32(venda[i].valorVenda);
                                                Console.WriteLine($"\n{vendaMes}: {totalMarco}€");
                                                break;
                                            case "4":
                                                int totalAbril = 0;
                                                totalAbril += Convert.ToInt32(venda[i].valorVenda);
                                                Console.WriteLine($"\n{vendaMes}: {totalAbril}€");
                                                break;
                                            case "5":
                                                int totalMaio = 0;
                                                totalMaio += Convert.ToInt32(venda[i].valorVenda);
                                                Console.WriteLine($"\n{vendaMes}: {totalMaio}€");
                                                break;
                                            case "6":
                                                int totalJunho = 0;
                                                totalJunho += Convert.ToInt32(venda[i].valorVenda);
                                                Console.WriteLine($"\n{vendaMes}: {totalJunho}€");
                                                break;
                                            case "7":
                                                int totalJulho = 0;
                                                totalJulho += Convert.ToInt32(venda[i].valorVenda);
                                                Console.WriteLine($"\n{vendaMes}: {totalJulho}€");
                                                break;
                                            case "8":
                                                int totalAgosto = 0;
                                                totalAgosto += Convert.ToInt32(venda[i].valorVenda);
                                                Console.WriteLine($"\n{vendaMes}: {totalAgosto}€");
                                                break;
                                            case "9":
                                                int totalSetembro = 0;
                                                totalSetembro += Convert.ToInt32(venda[i].valorVenda);
                                                Console.WriteLine($"\n{vendaMes}: {totalSetembro}€");
                                                break;
                                            case "10":
                                                int totalOutubro = 0;
                                                totalOutubro += Convert.ToInt32(venda[i].valorVenda);
                                                Console.WriteLine($"\n{vendaMes}: {totalOutubro}€");
                                                break;
                                            case "11":
                                                int totalNovembro = 0;
                                                totalNovembro += Convert.ToInt32(venda[i].valorVenda);
                                                Console.WriteLine($"\n{vendaMes}: {totalNovembro}€");
                                                break;
                                            case "12":
                                                int totalDezembro = 0;
                                                totalDezembro += Convert.ToInt32(venda[i].valorVenda);
                                                Console.WriteLine($"\n{vendaMes}: {totalDezembro}€");
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Mês não Encontrado");
                                        break;
                                    }
                                }
                                break;


                            //Total de Vendas por Mês para cada Vendedor
                            case 9:
                                Console.Clear();
                                Console.WriteLine("TOTAL DE VENDA POR MÊS PARA CADA VENDEDOR");
                                Console.WriteLine("Código do Vendedor:");
                                codigoVenda = ValidaCodigoVenda(1, 1000, venda, "exist");
                                Console.Write("Mês: ");
                                string? vendedorMes = Console.ReadLine();


                                for (int p = 0; p < venda.Length; p++)
                                {
                                    if (codigoVenda != venda[p].codVenda)
                                    {
                                        Console.WriteLine("Código Invalido");
                                        break;
                                    }
                                    else
                                    {
                                        //Calcular a soma dos valores das vendas por mês do Vendedor
                                        for (int i = 0; i < venda.Length; i++)
                                        {
                                            DateTime Data = DateTime.Parse(venda[i].dataVenda);

                                            switch (vendedorMes)
                                            {
                                                case "1":
                                                    int totalVendedorJaneiro = 0;
                                                    totalVendedorJaneiro += Convert.ToInt32(venda[i].valorVenda);
                                                    Console.WriteLine($"\n{vendedorMes}: {totalVendedorJaneiro}€");
                                                    break;
                                                case "2":
                                                    int totalVendedorFevereiro = 0;
                                                    totalVendedorFevereiro += Convert.ToInt32(venda[i].valorVenda);
                                                    Console.WriteLine($"\n{vendedorMes}: {totalVendedorFevereiro}€");
                                                    break;
                                                case "3":
                                                    int totalVendedorMarco = 0;
                                                    totalVendedorMarco += Convert.ToInt32(venda[i].valorVenda);
                                                    Console.WriteLine($"\n{vendedorMes}: {totalVendedorMarco}€");
                                                    break;
                                                case "4":
                                                    int totalVendedorAbril = 0;
                                                    totalVendedorAbril += Convert.ToInt32(venda[i].valorVenda);
                                                    Console.WriteLine($"\n{vendedorMes}: {totalVendedorAbril}€");
                                                    break;
                                                case "5":
                                                    int totalVendedorMaio = 0;
                                                    totalVendedorMaio += Convert.ToInt32(venda[i].valorVenda);
                                                    Console.WriteLine($"\n{vendedorMes}: {totalVendedorMaio}€");
                                                    break;
                                                case "6":
                                                    int totalVendedorJunho = 0;
                                                    totalVendedorJunho += Convert.ToInt32(venda[i].valorVenda);
                                                    Console.WriteLine($"\n{vendedorMes}: {totalVendedorJunho}€");
                                                    break;
                                                case "7":
                                                    int totalVendedorJulho = 0;
                                                    totalVendedorJulho += Convert.ToInt32(venda[i].valorVenda);
                                                    Console.WriteLine($"\n{vendedorMes}: {totalVendedorJulho}€");
                                                    break;
                                                case "8":
                                                    int totalVendedorAgosto = 0;
                                                    totalVendedorAgosto += Convert.ToInt32(venda[i].valorVenda);
                                                    Console.WriteLine($"\n{vendedorMes}: {totalVendedorAgosto}€");
                                                    break;
                                                case "9":
                                                    int totalVendedorSetembro = 0;
                                                    totalVendedorSetembro += Convert.ToInt32(venda[i].valorVenda);
                                                    Console.WriteLine($"\n{vendedorMes}: {totalVendedorSetembro}€");
                                                    break;
                                                case "10":
                                                    int totalVendedorOutubro = 0;
                                                    totalVendedorOutubro += Convert.ToInt32(venda[i].valorVenda);
                                                    Console.WriteLine($"\n{vendedorMes}: {totalVendedorOutubro}€");
                                                    break;
                                                case "11":
                                                    int totalVendedorNovembro = 0;
                                                    totalVendedorNovembro += Convert.ToInt32(venda[i].valorVenda);
                                                    Console.WriteLine($"\n{vendedorMes}: {totalVendedorNovembro}€");
                                                    break;
                                                case "12":
                                                    int totalVendedorDezembro = 0;
                                                    totalVendedorDezembro += Convert.ToInt32(venda[i].valorVenda);
                                                    Console.WriteLine($"\n{vendedorMes}: {totalVendedorDezembro}€");
                                                    break;
                                                default:
                                                    Console.WriteLine("Mês Invalido!!");
                                                    break;
                                            }

                                        }
                                    }
                                }

                                break;

                            //Salvando dados de Vendas.
                            case 10:
                                Array.Resize(ref vendedor, 0);

                                //Definição do caminho do Arquivo.
                                string arquivo = @"C:\Users\daniel.marques\Documents\Engenharia Informática\FP\C#\Gestor de Vendas\GV\Save\Venda\Venda.csv";

                                //Lendo os dados do Arquivo.
                                using (StreamReader leitura = new(arquivo))
                                {
                                    //Adicionando configuração CSV
                                    CsvConfiguration csvConfigIn = new(CultureInfo.CurrentCulture)
                                    {
                                        //Comment = '#',
                                        //AllowComments = true,
                                        Delimiter = "; ",
                                    };

                                    CsvReader ler = new(leitura, csvConfigIn);

                                    //Adicionando Cabeçalho
                                    ler.Read();

                                    //Lendo os dados do Arquivo.
                                    for (int i = 0; i < vendedor.Length; i++)
                                    {
                                        venda[i].codVenda = ler.GetField<int>("Código");
                                        venda[i].zonaVenda = ler.GetField<string>("Zona");
                                        venda[i].dataVenda = ler.GetField<string>("Data");
                                        venda[i].valorVenda = ler.GetField<decimal>("Valor");
                                        ler.Read();
                                    }

                                }
                                Console.WriteLine("\nDados de Vendas Lidos com Sucesso!");
                                break;


                            case 0:
                                Console.Clear();
                                Menu();
                                break;
                        }


                        Console.ReadKey();
                        SalvarVenda(venda);

                    } while (true);
                }

            }
        }
    }
}






