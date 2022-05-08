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

                string valor = Console.ReadLine();

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

        static void Main(string[] args)
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
                        Console.WriteLine("8. Salvar Dados");


                        Console.WriteLine("\n0. Voltar");
                        int opcaoVendedor = Validacao(0, 8, true);


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

                            //Leitura de Ficheiro.
                            case 7:
                                Console.Clear();
                                Console.WriteLine("LEITURA DE ARQUIVOS");

                                Array.Resize(ref vendedor, 0);

                                string arquivoLer = @"C:\Users\daniel.marques\Documents\Engenharia Informática\FP\C#\Gestor de Vendas\GV\Save\Vendedor\Vendedor.csv";
                                

                                StreamReader textoLeitura = new(arquivoLer);
                                CsvConfiguration csvConfigIn = new (CultureInfo.CurrentCulture)
                                {
                                    Comment = '#',
                                    AllowComments = true,
                                    Delimiter = ";",
                                };
                                
                                CsvReader ler = new (textoLeitura, csvConfigIn);

                                int l = 0;
                                while (ler.Read())
                                {
                                    if (l > 0)
                                    {
                                        //incremento = vendedor.Leght + 1;
                                        Array.Resize(ref vendedor, vendedor.Length + 1);

                                        vendedor[l - 1].codVendedor = Convert.ToInt32(ler.GetField(0));
                                        vendedor[l - 1].nomVendedor = ler.GetField(1);
                                        vendedor[l - 1].comissaoVendedor = Convert.ToDecimal(ler.GetField(2));
                                    }
                                }


                                textoLeitura.Close();
                                Console.WriteLine("\nFicheiro Carregado com Sucesso!");
                                break;


                            //Salvando Dados dos Vendedores.
                            case 8:
                                Console.Clear();
                                Console.WriteLine("SALVANDO DADOS DE VENDEDORES");

                                //Escrita de chars corretos ã e ê, etc.
                                Console.OutputEncoding = Encoding.UTF8;

                                //Definição de Variável
                                string arquivoSalvar = @"C:\Users\daniel.marques\Documents\Engenharia Informática\FP\C#\Gestor de Vendas\GV\Save\Vendedor\Vendedor.csv";

                                //Usar a Classe StreamWrite para acesso ao ficheiro para a escrita.
                                StreamWriter textoEscrita = new(arquivoSalvar);
                                

                                CsvConfiguration csvConfig = new (CultureInfo.CurrentCulture)
                                {
                                    Comment = '#',
                                    AllowComments = true,
                                    Delimiter = ";",
                                };

                                CsvWriter escrita = new (textoEscrita, csvConfig);


                                //Escreve cabeçalho do Ficheiro.
                                escrita.WriteField("Código");
                                escrita.WriteField("Nome");
                                escrita.WriteField("Comissão");
                                escrita.NextRecord();


                                for (int i = 0; i < vendedor.Length; i++)
                                { 
                                    escrita.WriteField(vendedor[i].codVendedor);
                                    escrita.WriteField(vendedor[i].nomVendedor);
                                    escrita.WriteField(vendedor[i].comissaoVendedor);
                                    escrita.NextRecord();
                                }
                                
                                textoEscrita.Close();
                                Console.WriteLine("\nDados Salvos com Sucesso!");
                                break;

                            case 0:
                                Console.Clear();
                                Menu();
                                break;
                        }

                        Console.ReadKey();

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
                        Console.WriteLine("11. Salvar Dados");
                        
                        Console.WriteLine("\n0. Voltar");
                        int opcaoVenda = Validacao(0, 11, true);


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

                                    var data = $"{dia}/{mes}/2021";
                                    venda[i].dataVenda = data;

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
                                        int mes = Convert.ToInt32(Validacao(1, 12, true));

                                        var data = $"{dia}/{mes}/2021";
                                        venda[i].dataVenda = data;

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
                                            venda[e].zonaVenda = venda[e +  1].zonaVenda;
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

                                Console.WriteLine("Total de vendas por vendedor");
                                Console.WriteLine("Qual o codigo do vendedor cujas vendas pertende verificar?");
                                int codigoTotalVendas = Validacao(1, 1000, true);

                                int somaVendas = 0;
                                for (int i = 0; i < venda.Length; i++)
                                {
                                    if (codigoTotalVendas == venda[i].codVenda)
                                        somaVendas += Convert.ToInt32(venda[i].valorVenda);
                                    else
                                    {
                                        Console.WriteLine("Codigo não Encontrado");
                                        break;
                                    }
                                }
                                
                                Console.WriteLine($"O vendedor {codigoTotalVendas} fez {somaVendas}€ em vendas");
                                break;


                            //Total de venda por Zona    
                            case 7:
                                Console.Clear();
                                
                                int somaZonaNorte = 0, somaZonaSul = 0, somaZonaLeste = 0, somaZonaOeste = 0;

                                Console.WriteLine("TOTAL DE VENDAS POR ZONA");

                                for (int i = 0; i < venda.Length; i++)
                                {

                                    switch (venda[i].zonaVenda)
                                    {
                                        case "Norte":
                                            somaZonaNorte += Convert.ToInt32(venda[i].valorVenda);
                                            break;

                                        case "Sul":
                                            somaZonaSul += Convert.ToInt32(venda[i].valorVenda);
                                            break;

                                        case "Leste":
                                            somaZonaLeste += Convert.ToInt32(venda[i].valorVenda);
                                            break;

                                        case "Oeste":
                                            somaZonaOeste += Convert.ToInt32(venda[i].valorVenda);
                                            break;

                                        default:
                                            Console.WriteLine("Zona Invalida!!");
                                            MenuVenda();
                                            break;
                                    }

                                }
                                
                                Console.WriteLine($"\nNorth: {somaZonaNorte}€" +
                                                    $"\nSouth: {somaZonaSul}€" +
                                                    $"\nEast: {somaZonaLeste}€" +
                                                    $"\nWest: {somaZonaOeste}€");
                                break;

                                //Total de Vendas por Mês
                            case 8:
                                Console.Clear();
                                Console.WriteLine("TOTAL DE VENDA POR MÊS");

                                int somaJaneiro = 0;
                                int somaFevereiro = 0;
                                int somaMarco = 0;
                                int somaAbril = 0;
                                int somaMaio = 0;
                                int somaJunho = 0;
                                int somaJulho = 0;
                                int somaAgosto = 0;
                                int somaSetembro = 0;
                                int somaOutubro = 0;
                                int somaNovembro = 0;
                                int somaDezembro = 0;

                                for (int i = 0; i < venda.Length; i++)
                                {
                                    DateTime Data = DateTime.Parse(venda[i].dataVenda);

                                    switch (Data.Month)
                                    {
                                        case 1:
                                            somaJaneiro += Convert.ToInt32(venda[i].valorVenda);
                                            break;
                                        case 2:
                                            somaFevereiro += Convert.ToInt32(venda[i].valorVenda);
                                            break;
                                        case 3:
                                            somaMarco += Convert.ToInt32(venda[i].valorVenda);
                                            break;
                                        case 4:
                                            somaAbril += Convert.ToInt32(venda[i].valorVenda);
                                            break;
                                        case 5:
                                            somaMaio += Convert.ToInt32(venda[i].valorVenda);
                                            break;
                                        case 6:
                                            somaJunho += Convert.ToInt32(venda[i].valorVenda);
                                            break;
                                        case 7:
                                            somaJulho += Convert.ToInt32(venda[i].valorVenda);
                                            break;
                                        case 8:
                                            somaAgosto += Convert.ToInt32(venda[i].valorVenda);
                                            break;
                                        case 9:
                                            somaSetembro += Convert.ToInt32(venda[i].valorVenda);
                                            break;
                                        case 10:
                                            somaOutubro += Convert.ToInt32(venda[i].valorVenda);
                                            break;
                                        case 11:
                                            somaNovembro += Convert.ToInt32(venda[i].valorVenda);
                                            break;
                                        case 12:
                                            somaDezembro += Convert.ToInt32(venda[i].valorVenda);
                                            break;

                                        default:
                                            Console.WriteLine("Mês Invalido!!");
                                            MenuVenda();
                                            break;

                                    }
                                }

                                Console.WriteLine($"\nJaneiro: {somaJaneiro}€" +
                                                    $"\nFevereiro: {somaFevereiro}€" +
                                                    $"\nMarço: {somaMarco}€" +
                                                    $"\nAbril: {somaAbril}€" +
                                                    $"\nMaio: {somaMaio}€" +
                                                    $"\nJunho: {somaJunho}€" +
                                                    $"\nJulho: {somaJulho}€" +
                                                    $"\nAgosto: {somaAgosto}€" +
                                                    $"\nSetembro: {somaSetembro}€" +
                                                    $"\nOutubro: {somaOutubro}€" +
                                                    $"\nNovembro: {somaNovembro}€" +
                                                    $"\nDezembro: {somaDezembro}€");

                                Console.ReadKey();
                                break;

                            //Total de Venda por Zona
                            case 9:
                                
                                Console.Clear();
                                Console.WriteLine("TOTAL DE VENDA POR MÊS");
                                
                                int somaVendasJaneiro = 0;
                                int somaVendasFevereiro = 0;
                                int somaVendasMarco = 0;
                                int somaVendasAbril = 0;
                                int somaVendasMaio = 0;
                                int somaVendasJunho = 0;
                                int somaVendasJulho = 0;
                                int somaVendasAgosto = 0;
                                int somaVendasSetembro = 0;
                                int somaVendasOutubro = 0;
                                int somaVendasNovembro = 0;
                                int somaVendasDezembro = 0;

                                Console.WriteLine("Código do Vendedor:");
                                codigoVenda = ValidaCodigoVenda(1, 1000, venda, "exist");

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

                                            switch (Data.Month)
                                            {
                                                case 1:
                                                    somaVendasJaneiro += Convert.ToInt32(venda[i].valorVenda);
                                                    break;
                                                case 2:
                                                    somaVendasFevereiro += Convert.ToInt32(venda[i].valorVenda);
                                                    break;
                                                case 3:
                                                    somaVendasMarco += Convert.ToInt32(venda[i].valorVenda);
                                                    break;
                                                case 4:
                                                    somaVendasAbril += Convert.ToInt32(venda[i].valorVenda);
                                                    break;
                                                case 5:
                                                    somaVendasMaio += Convert.ToInt32(venda[i].valorVenda);
                                                    break;
                                                case 6:
                                                    somaVendasJunho += Convert.ToInt32(venda[i].valorVenda);
                                                    break;
                                                case 7:
                                                    somaVendasJulho += Convert.ToInt32(venda[i].valorVenda);
                                                    break;
                                                case 8:
                                                    somaVendasAgosto += Convert.ToInt32(venda[i].valorVenda);
                                                    break;
                                                case 9:
                                                    somaVendasSetembro += Convert.ToInt32(venda[i].valorVenda);
                                                    break;
                                                case 10:
                                                    somaVendasOutubro += Convert.ToInt32(venda[i].valorVenda);
                                                    break;
                                                case 11:
                                                    somaVendasNovembro += Convert.ToInt32(venda[i].valorVenda);
                                                    break;
                                                case 12:
                                                    somaVendasDezembro += Convert.ToInt32(venda[i].valorVenda);
                                                    break;
                                                default:
                                                    Console.WriteLine("Mês Invalido!!");
                                                    break;
                                            }
                                            
                                        }
                                    }
                                }


                                //Apresentação das vendas de todos os meses do Vendedor.
                                Console.WriteLine(  $"\nJaneiro: {somaVendasJaneiro}€" +
                                                    $"\nFevereiro: {somaVendasFevereiro}€" +
                                                    $"\nMarço: {somaVendasMarco}€" +
                                                    $"\nAbril: {somaVendasAbril}€" +
                                                    $"\nMaio: {somaVendasMaio}€" +
                                                    $"\nJunho: {somaVendasJunho}€" +
                                                    $"\nJulho: {somaVendasJulho}€" +
                                                    $"\nAgosto: {somaVendasAgosto}€" +
                                                    $"\nSetembro: {somaVendasSetembro}€" +
                                                    $"\nOutubro: {somaVendasOutubro}€" +
                                                    $"\nNovembro: {somaVendasNovembro}€" +
                                                    $"\nDezembro: {somaVendasDezembro}€");

                                
                                break;
                                

                            //Leitura Dados de Vendas.
                            case 10:
                                Console.Clear();
                                Console.WriteLine("LENDO DADOS DE VENDAS");

                                Array.Resize(ref venda, 0);

                                string arquivoLer = @"C:\Users\daniel.marques\Documents\Engenharia Informática\FP\C#\Gestor de Vendas\GV\Save\Venda\Venda.csv";

                                StreamReader textoLeitura = new(arquivoLer);
                                CsvConfiguration csvConfigIn = new(CultureInfo.CurrentCulture)
                                {
                                    Comment = '#',
                                    AllowComments = true,
                                    Delimiter = ";",
                                };

                                CsvReader ler = new (textoLeitura, csvConfigIn);

                                int l = 0;
                                while (ler.Read())
                                {
                                    if (l > 0)
                                    {
                                        //incremento = vendedor.Leght + 1;
                                        Array.Resize(ref venda, venda.Length + 1);


                                        venda[l - 1].codVenda = Convert.ToInt32(ler.GetField(0));
                                        venda[l - 1].zonaVenda = ler.GetField(1);
                                        venda[l - 1].dataVenda = ler.GetField(2);
                                        venda[l - 1].valorVenda = Convert.ToInt32(ler.GetField(3));

                                    }
                                }


                                textoLeitura.Close();
                                Console.WriteLine("\nFicheiro Carregado com Sucesso!");
                                break;


                            //Salvando Dados dos Venda.
                            case 11:
                                Console.Clear();
                                Console.WriteLine("SALVANDO DADOS DE VENDAS");

                                //Escrita de chars corretos ã e ê, etc.
                                Console.OutputEncoding = Encoding.UTF8;

                                //Definição de Variável
                                string arquivoSalvar = @"C:\Users\daniel.marques\Documents\Engenharia Informática\FP\C#\Gestor de Vendas\GV\Save\Venda\Venda.csv";

                                //Usar a Classe StreamWrite para acesso ao ficheiro para a escrita.
                                StreamWriter textoEscrita = new(arquivoSalvar);


                                CsvConfiguration csvConfig = new(CultureInfo.CurrentCulture)
                                {
                                    Comment = '#',
                                    AllowComments = true,
                                    Delimiter = ";",
                                };

                                CsvWriter escrita = new (textoEscrita, csvConfig);


                                //Escreve cabeçalho do Ficheiro.
                                escrita.WriteField("Código");
                                escrita.WriteField("Zona");
                                escrita.WriteField("Data");
                                escrita.WriteField("Valor de Venda");
                                escrita.NextRecord();

                                
                                for (int i = 0; i < venda.Length; i++)
                                {
                                    escrita.WriteField(venda[i].codVenda);
                                    escrita.WriteField(venda[i].zonaVenda);
                                    escrita.WriteField(venda[i].dataVenda);
                                    escrita.WriteField(venda[i].valorVenda);
                                    escrita.NextRecord();
                                }

                                textoEscrita.Close();
                                Console.WriteLine("\nDados Salvos com Sucesso!");
                                break;

                            case 0:
                                Console.Clear();
                                Menu();
                                break;
                        }

                        Console.ReadKey();

                    } while (true);
                }

            }
        }
    }
}


      
