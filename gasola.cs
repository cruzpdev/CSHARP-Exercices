class Program
{
    static void Main(string[] args)
    {
        double precoGasolina, precoAlcool;

        do
        {
            Console.Write("Digite o preço da gasolina: R$ ");
            precoGasolina = double.Parse(Console.ReadLine());

            Console.Write("Digite o preço do álcool: R$ ");
            precoAlcool = double.Parse(Console.ReadLine());

            double relacaoConsumo = 0.7;

            double razaoPreco = precoAlcool / precoGasolina;

            if (razaoPreco < relacaoConsumo)
            {
                Console.WriteLine("Abasteça com álcool.");
            }
            else if (razaoPreco > relacaoConsumo)
            {
                Console.WriteLine("Abasteça com gasolina.");
            }
            else
            {
                Console.WriteLine("Tanto faz abastecer com álcool ou gasolina.");
            }

            Console.WriteLine();

            Console.Write("Deseja efetuar um novo cálculo? (S/N) ");
        } while (Console.ReadLine().ToUpper() == "S");
    }
}

//ou

