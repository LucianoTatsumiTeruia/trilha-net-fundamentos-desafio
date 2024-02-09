using DesafioFundamentos.Models;
using System.Globalization; // Diretiva que permite utilizar a classe "CultureInfo"

// Coloca o "CultureInfo" do Brasil para utilizar no precoInicial e no precoPorHora
CultureInfo culturePt = new CultureInfo("pt-BR");

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
// Inicialização do Sistema

// Declaração de variáveis
decimal precoInicial = 0;
string stringPrecoInicial = "";
decimal precoPorHora = 0;
string stringPrecoPorHora = "";

// Mensagem de "bem vindo" + solicitação do preço inicial
Console.Clear();
Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial:");
stringPrecoInicial = Console.ReadLine();
// Verifica se o usuário inseriu um número do tipo "decimal"
while (true)
{
    // Substitui todos os pontos por vírgulas
    stringPrecoInicial = stringPrecoInicial.Replace('.', ',');
    bool sucesso = Decimal.TryParse(stringPrecoInicial, NumberStyles.Number, culturePt, out precoInicial);
    if (sucesso && precoInicial >= 0)
    {
        break; // Sai do loop se a conversão for bem-sucedida
    }
    else
    {
        Console.WriteLine("Por favor, digite um número válido.");
        stringPrecoInicial = Console.ReadLine();
    }
}

// Solicitação do preço por hora
Console.WriteLine("Agora digite o preço por hora:");
stringPrecoPorHora = Console.ReadLine();
// Verifica se o usuário inseriu um número do tipo "decimal"
while (true)
{
    // Substitui todos os pontos por vírgulas
    stringPrecoPorHora = stringPrecoPorHora.Replace('.', ',');
    bool sucesso = Decimal.TryParse(stringPrecoPorHora, NumberStyles.Number, culturePt, out precoPorHora);
    if (sucesso && precoPorHora >= 0)
    {
        break; // Sai do loop se a conversão for bem-sucedida
    }
    else
    {
        Console.WriteLine("Por favor, digite um número válido.");
        stringPrecoPorHora = Console.ReadLine();
    }
}
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
// Dentro do Sistema

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

// Declaração de variáveis
string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("\nPressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
