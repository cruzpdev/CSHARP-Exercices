using System;
using System.Collections.Generic;

class Disco
{
    public string? Artista { get; set; }
    public string? Album { get; set; }
    public string? Categoria { get; set; }
    public string? Descricao { get; set; }
    public double Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
}

class ControleEstoque
{
    private List<Disco> discos = new List<Disco>();

    public void AdicionarDisco(Disco disco)
    {
        discos.Add(disco);
        Console.WriteLine("Disco adicionado!");
    }

    public void ListarDiscos()
    {
        for (int i = 0; i < discos.Count; i++)
        {
            var disco = discos[i];
            Console.WriteLine($"{i + 1}. {disco.Album} - {disco.Artista} ({disco.Preco:F2}) – {disco.QuantidadeEstoque} no estoque");
        }
    }

    public bool PosicaoValida(int posicao)
    {
        return posicao >= 1 && posicao <= discos.Count;
    }

    public void RemoverDisco(int posicao)
    {
        if (PosicaoValida(posicao))
        {
            Disco disco = discos[posicao - 1];
            discos.RemoveAt(posicao - 1);
            Console.WriteLine($"Disco '{disco.Album}' de '{disco.Artista}' removido do estoque.");
        }
        else
        {
            Console.WriteLine("Posição inválida.");
        }
    }

    public void MovimentoEstoque(int posicao, int quantidade, string acao)
    {
        if (PosicaoValida(posicao))
        {
            var disco = discos[posicao - 1];
            if (acao == "entrada")
            {
                disco.QuantidadeEstoque += quantidade;
                Console.WriteLine($"Foram adicionadas {quantidade} unidades do disco '{disco.Album}' de '{disco.Artista}' ao estoque.");
            }
            else if (acao == "saida")
            {
                if (disco.QuantidadeEstoque >= quantidade)
                {
                    disco.QuantidadeEstoque -= quantidade;
                    Console.WriteLine($"Foram vendidas {quantidade} unidades do disco '{disco.Album}' de '{disco.Artista}'.");
                }
                else
                {
                    Console.WriteLine($"Quantidade insuficiente do disco '{disco.Album}' de '{disco.Artista}' em estoque.");
                }
            }
        }
        else
        {
            Console.WriteLine("Posição inválida.");
        }
    }
}

class Program
{
    static void ExibirMenu()
    {
        string menu = "CONTROLE DE ESTOQUE - LOJA DE DISCOS\n" +
                      "[1] Novo\n" +
                      "[2] Listar Discos\n" +
                      "[3] Remover Discos\n" +
                      "[4] Entrada Estoque\n" +
                      "[5] Saída Estoque\n" +
                      "[0] Sair";
        Console.WriteLine(menu);
    }

    static void Main(string[] args)
    {
        ControleEstoque estoque = new ControleEstoque();

        while (true)
        {
            ExibirMenu();
            Console.Write("Escolha uma opção: ");
            string escolha = Console.ReadLine();

            if (escolha == "1")
            {
                Console.Write("Informe o artista: ");
                string? artista = Console.ReadLine();
                Console.Write("Informe o álbum: ");
                string? album = Console.ReadLine();
                Console.Write("Informe a categoria: ");
                string? categoria = Console.ReadLine();
                Console.Write("Informe a descrição: ");
                string? descricao = Console.ReadLine();

                Console.Write("Informe o preço do disco: ");
                string precoStr = Console.ReadLine();
                if (double.TryParse(precoStr, out double preco))
                {
                    Console.Write("Informe a quantidade em estoque: ");
                    string quantidadeStr = Console.ReadLine();
                    if (int.TryParse(quantidadeStr, out int quantidade))
                    {
                        Disco novoDisco = new Disco
                        {
                            Artista = artista!,
                            Album = album!,
                            Categoria = categoria!,
                            Descricao = descricao!,
                            Preco = preco,
                            QuantidadeEstoque = quantidade
                        };
                        estoque.AdicionarDisco(novoDisco);
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido para a quantidade em estoque.");
                    }
                }
                else
                {
                    Console.WriteLine("Valor inválido para o preço do disco.");
                }
            }
            else if (escolha == "2")
            {
                estoque.ListarDiscos();
            }
            else if (escolha == "3")
            {
                Console.Write("Informe a posição do disco a ser removido: ");
                int posicao = Convert.ToInt32(Console.ReadLine());
                estoque.RemoverDisco(posicao);
            }
            else if (escolha == "4" || escolha == "5")
            {
                Console.Write("Informe a posição do disco: ");
                int posicao = Convert.ToInt32(Console.ReadLine());
                Console.Write($"Informe a quantidade de {escolha.ToLower()}: ");
                int quantidade = Convert.ToInt32(Console.ReadLine());
                estoque.MovimentoEstoque(posicao, quantidade, escolha == "4" ? "entrada" : "saida");
            }
            else if (escolha == "0")
            {
                Console.WriteLine("Saindo do programa.");
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Escolha novamente.");
            }
        }
    }
}
