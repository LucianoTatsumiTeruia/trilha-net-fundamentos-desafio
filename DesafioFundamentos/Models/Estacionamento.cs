namespace DesafioFundamentos.Models
{
    using System.Text.RegularExpressions; // Diretiva para usar a classe "Regex" e o método "IsMatch"
    using System.Globalization; // Diretiva que permite utilizar a classe "CultureInfo"
    public class Estacionamento
    {
        // Propriedades
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        // Construtor
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }
        ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////

        // Métodos

        // Método adicionar veículo
        public void AdicionarVeiculo()
        {
            // Pede para o usuário digitar uma placa e adicionar na lista "veiculos"
            Console.WriteLine("\nDigite a placa do veículo para estacionar:");
            string adicionarVeiculo = Console.ReadLine().ToUpper();
            
            // Utilizei o Chat do Microsoft Bing para descobrir se existia algum jeito de utilizar as regras de nomeação 
            //de placas de carros dentro da linguagem C#. Ele me recomendou utilizar a classe Regex.

            // Regex é uma classe em C# usada para expressões regulares, que são padrões de string usados para combinar 
            //outras strings ou partes de strings. Para utilizar essa classe é necessário inserir a diretriz: 
            //System.Text.RegularExpressions.

            // A expressão regular @"^[A-Z]{3}[0-9][A-Z][0-9]{2}$" corresponde a uma string que começa com três letras 
            //maiúsculas, seguida por um número, uma letra maiúscula e dois números.
            Regex novo = new Regex(@"^[A-Z]{3}[0-9][A-Z][0-9]{2}$");

            Regex antigo = new Regex(@"^[A-Z]{3}[0-9]{4}$");

            // Verifica se o usuário inseriu uma placa válida
            while (true)
            {
                // O método IsMatch verifica se a string adicionarVeiculo corresponde ao padrão especificado pela expressão 
                //regular.
                
                // Se a string corresponder ao padrão, IsMatch retornará true. Caso contrário, retornará false.
                if (novo.IsMatch(adicionarVeiculo) || antigo.IsMatch(adicionarVeiculo))
                {
                    if (veiculos.Any(x => x.ToUpper() == adicionarVeiculo.ToUpper()))
                    {
                        Console.WriteLine("\nEsta placa já foi registrada, digite outra placa.");
                        Console.WriteLine("Digite 'M' para voltar ao menu ou tente digitar outra placa.");
                        adicionarVeiculo = Console.ReadLine().ToUpper();
                        if (adicionarVeiculo.ToUpper() == "M")
                        {
                            return; // Retorna ao menu se o usuário digitar 'M'
                        }
                    }
                    else
                    {
                        veiculos.Add(adicionarVeiculo);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("\nA placa inserida é inválida. As placas devem seguir o padrão Mercosul: " +
                                    "três letras, um número, uma letra e dois números (por exemplo, ABC1D23),\nou o " + 
                                    "modelo antigo do Brasil: três letras, seguidas de quatro números (por exemplo, ABC1234).");
                    Console.WriteLine("\nDigite 'M' para voltar ao menu ou tente novamente.");
                    adicionarVeiculo = Console.ReadLine().ToUpper();
                    if (adicionarVeiculo.ToUpper() == "M")
                    {
                        return; // Retorna ao menu se o usuário digitar 'M'
                    }
                }
    }
        }

        // Método remover veículo
        public void RemoverVeiculo()
        {
            // Pede para o usuário digitar a placa e armazenar na variável placa
            Console.WriteLine("\nDigite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            while(true)
            {
            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                // Pede para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado 
                Console.WriteLine("\nDigite a quantidade de horas que o veículo permaneceu estacionado:");
                string quantidadeDeHoras = Console.ReadLine(); 

                // Verifica se o usuário inseriu um número do tipo inteiro          
                int horas = 0;
                while (true)
                {
                    bool sucesso = int.TryParse(quantidadeDeHoras, out horas);
                    if (sucesso && horas >= 0)
                    {
                        break; // Sai do loop se a conversão for bem-sucedida
                    }
                    else
                    {
                        Console.WriteLine("\nPor favor, digite um número válido. Ou digite 'M' para voltar ao menu.");
                        quantidadeDeHoras = Console.ReadLine();
                        if (quantidadeDeHoras.ToUpper() == "M")
                        {
                            return; // Retorna ao menu se o usuário digitar 'M'
                        }
                    }
                }

                    // Realiza o cálculo do valor total a ser pago   
                    decimal valorTotal = 0; 
                    horas = int.Parse(quantidadeDeHoras);
                    valorTotal = precoInicial + precoPorHora * horas;

                    // Remove a placa digitada da lista de veículos
                    veiculos.Remove(placa);
                    CultureInfo cultura = new CultureInfo("pt-BR");
                    Console.WriteLine($"\nO veículo {placa} foi removido e o preço total foi de: " +
                                            $"R$ {valorTotal.ToString("C2", cultura)}");
                    break; // Sai do loop
                }
                else
                {
                    Console.WriteLine("\nDesculpe, esse veículo não está estacionado aqui. " +
                                                "Confira se digitou a placa corretamente");
                    Console.WriteLine("Digite 'M' para voltar ao menu ou tente novamente.");
                    placa = Console.ReadLine().ToUpper();
                    if (placa.ToUpper() == "M")
                    {
                        return; // Retorna ao menu se o usuário digitar 'M'
                    }
                }
            }
        }

        // Método listar veículos
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("\nOs veículos estacionados são:");
                // Realiza um laço de repetição, exibindo os veículos estacionados
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("\nNão há veículos estacionados.");
            }
        }
    }
}
