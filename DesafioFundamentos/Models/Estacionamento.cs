namespace DesafioFundamentos.Models
{
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
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string adicionarVeiculo = Console.ReadLine();
            veiculos.Add(adicionarVeiculo);
        }

        // Método remover veículo
        public void RemoverVeiculo()
        {
            // Pede para o usuário digitar a placa e armazenar na variável placa
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                // Pede para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado 
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                string quantidadeDeHoras = Console.ReadLine(); 

                // Verifica se o usuário inseriu um número do tipo inteiro          
                int horas = 0;
                while (true)
                {
                    try
                    {
                        horas = int.Parse(quantidadeDeHoras);
                        break; // Sai do loop se a conversão for bem-sucedida
                    }
                    catch
                    {
                        Console.WriteLine("Por favor, digite um número válido. Ou digite 'M' para voltar ao menu.");
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
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        // Método listar veículos
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // Realiza um laço de repetição, exibindo os veículos estacionados
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
