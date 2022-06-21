using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;


namespace Desafio2_Conversor_Moedas_API_REST
{
    public class Program
    {

        public static async Task Main()
        {
            string? moedaOrigem;
            string? moedaDestino;
            string? strvalor;
            float valor;
            string? opcao;
            bool sair = false;

            ValidaDadosEntrada validamoedas = new ValidaDadosEntrada();
            do
            {
                Console.Clear();
                Console.WriteLine("Conversor de Moedas");
                Console.WriteLine("1 - iniciar");
                opcao = Console.ReadLine();
                if (string.IsNullOrEmpty(opcao)) continue;
                int opcaoprincipal = Convert.ToInt16(opcao);
                switch (opcaoprincipal)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Deixe Moeda de Origem vazia para sair");
                        Console.Write("Moeda de Origem: ");
                        moedaOrigem = Console.ReadLine();
                        if (string.IsNullOrEmpty(moedaOrigem))
                        {
                            sair = true;
                            break;
                        }

                        Console.Write("Moeda de Destino: ");
                        moedaDestino = Console.ReadLine();

                        if (!validamoedas.ValidaMoedas(moedaOrigem, moedaDestino))
                        {
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            break;
                        }

                        Console.Write("Valor: ");
                        strvalor = Console.ReadLine();
                        if (!validamoedas.ValidaValor(strvalor))
                        {
                            do
                            {
                                Console.WriteLine("Pressione qualquer tecla para inserir o valor novamente!");
                                Console.ReadKey();
                                Console.Clear();
                                Console.Write("Valor: ");
                                strvalor = Console.ReadLine();
                            } while (!validamoedas.ValidaValor(strvalor));
                        }
                        valor = float.Parse(strvalor);


                        Resultado resultado = await RunAsync(moedaOrigem, moedaDestino, valor);

                        if (resultado.result == null) { Console.WriteLine("Erro"); }

                        Console.Clear();
                        Console.WriteLine("Moeda de Origem: " + moedaOrigem);
                        Console.WriteLine("Moeda de Destino: " + moedaDestino);
                        Console.WriteLine("Valor: " + strvalor);
                        Console.WriteLine();
                        Console.WriteLine(moedaOrigem + " " + valor + " => " + moedaDestino + " " + resultado.result.ToString());
                        Console.WriteLine("Taxa: " + resultado.info.rate.ToString());


                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            } while (!sair);
        }


        static async Task<Resultado> RunAsync(string from, string to, float amount)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var stringTask = await client.GetStringAsync(string.Format(@"https://api.exchangerate.host/convert?from={0}&to={1}&amount={2}", from, to, amount.ToString("0.00")));

                Resultado resultado = JsonSerializer.Deserialize<Resultado>(stringTask)!;

                return resultado;
            }
        }
    }
}