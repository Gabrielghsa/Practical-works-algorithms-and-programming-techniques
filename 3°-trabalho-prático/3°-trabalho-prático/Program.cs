int n, i, linha, coluna, contElementos;
char op;
double[,] temperaturas;
string[] cidades;
string registCid;
double media, soma = 0;

Console.Write("Informe o número de cidades: ");
n = int.Parse(Console.ReadLine());
cidades = new string[n];
temperaturas = new double[n, 8];

for (i = 0; i < cidades.Length; i++)
{
    Console.Write($"Informe o nome da {i + 1}° cidade: ");
    cidades[i] = Console.ReadLine();
}

do
{
    Console.WriteLine("Escolha uma das opções abaixo: ");
    Console.WriteLine("Digite 'A' para registrar a temperatura de uma cidade;");
    Console.WriteLine("Digite 'B' para exibir as temperaturas de uma cidade;");
    Console.WriteLine("Digite 'C' para exibir as temperaturas gerais; ");
    Console.WriteLine("Digite 'D' para exibir a temperatura média de uma cidade; ");
    Console.WriteLine("Digite 'E' para exibir as temperaturas médias gerais;");
    Console.WriteLine("Digite 'F' para sair");
    op = char.Parse(Console.ReadLine());

    switch (op)
    {
        case 'A':
            Console.Write("Qual o nome da cidade que você deseja adicionar temperaturas? ");
            registCid = Console.ReadLine();
            for (linha = 0; linha < cidades.Length; linha++)
            {
                if (cidades[linha] == registCid)
                {
                    for (coluna = temperaturas.GetLength(1) - 1; coluna > 0; coluna--) //Começando pelo último indice das colunas
                    {
                        temperaturas[linha, coluna] = temperaturas[linha, coluna - 1]; //Atribuindo o valor anterior para o atual 
                    }
                    Console.Write("Digite a nova temperatura: ");
                    temperaturas[linha, 0] = double.Parse(Console.ReadLine()); //Adicionando novo valor 
                }
            }
            break;

        case 'B':
            Console.Write("De qual cidade você quer que as temperaturas sejam exibidas: ");
            registCid = Console.ReadLine();

            for (linha = 0; linha < cidades.Length; linha++)
            {
                if (cidades[linha] == registCid)
                {
                    for (coluna = 0; coluna < temperaturas.GetLength(1); coluna++)
                    {
                        Console.Write(temperaturas[linha, coluna] + "  ");
                    }
                }
            }
            break;

        case 'C':

            for (linha = 0; linha < temperaturas.GetLength(0); linha++)
            {
                Console.Write($"{cidades[linha],-10}");
                for (coluna = 0; coluna < temperaturas.GetLength(1); coluna++)
                {
                    Console.Write($"{temperaturas[linha, coluna],8}");
                }
                Console.WriteLine();
            }
            break;

        case 'D':
            Console.Write("Qual o nome da cidade que você deseja saber a média das temperaturas? ");
            registCid = Console.ReadLine();
            for (linha = 0; linha < cidades.Length; linha++)
            {
                soma = 0;
                contElementos = 0;
                if (cidades[linha] == registCid)
                {
                    for (coluna = 0; coluna < temperaturas.GetLength(1); coluna++)
                    {
                        if (temperaturas[linha, coluna] > 0){
                            soma = soma + temperaturas[linha, coluna];
                            contElementos++;
                            }
                    }
                }
                if (contElementos > 0)
                {
                    media = (double)soma / contElementos;
                    Console.WriteLine($"A média de temperaturas da cidade {registCid} é: {media}");
                }
            }

            break;

        case 'E':
            for (linha = 0; linha < temperaturas.GetLength(0); linha++)
            {
                soma = 0;
                contElementos = 0;
                for (coluna = 0; coluna < temperaturas.GetLength(1); coluna++)
                {
                    if (temperaturas[linha, coluna] > 0)
                    {
                        soma = soma + temperaturas[linha, coluna];
                        contElementos++;
                    }
                }

                if (contElementos > 0)
                {
                    media = (double)soma / contElementos;
                    Console.WriteLine($"A média da cidade {cidades[linha]} é: {media:f2}");
                }
                else
                {
                    Console.WriteLine($"A cidade {cidades[linha]} não possui temperaturas registradas.");
                }
            }
            break;
    }
} while (op != 'F');
Console.ReadKey();
