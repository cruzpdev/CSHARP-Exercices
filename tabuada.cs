using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite um número para ver sua tabuada: ");
        int numero = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Tabuada de {numero}:");
        MostrarTabuada(numero, 1);
    }

    static void MostrarTabuada(int numero, int multiplicador)
    {
        if (multiplicador <= 10)
        {
            Console.WriteLine($"{numero} x {multiplicador} = {numero * multiplicador}");
            MostrarTabuada(numero, multiplicador + 1);
        }
    }
}
