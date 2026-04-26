int n, voto, numCand1, numCand2, votoCand1, votoCand2, nulo, branco;
do
{
    //Zerando as váriáveis dentro do loop para evitar problemas de acumulação
    votoCand1 = 0;
    votoCand2 = 0;
    nulo = 0;
    branco = 0;
    Console.WriteLine("Digite a quantidade de eleitores: ");
    n = int.Parse(Console.ReadLine());

    while (n < 10)
    {
        Console.WriteLine("Quantidade de eleitores inválida.");
        Console.WriteLine("Digite a quantidade de eleitores: ");
        n = int.Parse(Console.ReadLine());
    }
    Console.WriteLine($"Digite o número do candidato Teobaldo");
    numCand1 = int.Parse(Console.ReadLine());
    Console.WriteLine($"Digite o número do candidato Astrogildo");
    numCand2 = int.Parse(Console.ReadLine());

    //Evitando números iguais para os candidatos
    while (numCand1 == numCand2)
    {
        Console.WriteLine("Números iguais. Digite novamente o número do segundo candidato.");
        numCand2 = int.Parse(Console.ReadLine());
    }

    for (int i = 1; i <= n; i++)
    {
        Console.Write("Digite o número do seu voto: ");
        voto = int.Parse(Console.ReadLine());
        if (voto == numCand1)
        {
            votoCand1++;
        }
        else if (voto == numCand2)
        {
            votoCand2++;
        }
        else if (voto == 0)
        {
            branco++;
        }
        else
        {
            nulo++;
        }
    }
    if (votoCand1 > votoCand2)
    {
        Console.WriteLine($"Vitória do canditado Teobaldo com: {votoCand1} votos.");
    }
    else if (votoCand2 > votoCand1)
    {
        Console.WriteLine($"Vitória do canditado Astrogildo com: {votoCand2} votos.");
    }
    else
    {
        Console.WriteLine("Empate! Nova eleição deve ser realizada.");
    }
    Console.WriteLine($"O candidato Teobaldo obteve: {votoCand1} votos.");
    Console.WriteLine($"O candidato Astrogildo obteve: {votoCand2} votos.");
    Console.WriteLine($"A quantidade de votos nulos foi: {nulo}.");
    Console.WriteLine($"A quantidade de votos em branco foi: {branco}.");
} while (votoCand1 == votoCand2);

