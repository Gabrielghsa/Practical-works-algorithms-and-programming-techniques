using System;
using System.IO;
class Program
{
    static StreamReader arqEntrada = new StreamReader("eleicao_in.txt");
    static StreamWriter arqSaida = new StreamWriter("eleicao_out.txt");
    static int qtdCandidatos() //Função para validar o número de candidatos
    {
        int n;
        do
        {
            /* Console.Write("Informe a quantidade de candidatos: "); */
            n = int.Parse(arqEntrada.ReadLine());
        } while (n < 3);
        return n;
    }

    static void dadosCandidato(int[] numeroCandidato, string[] nomeCandidato) //Procedimento para armazenar o nome e o número do candidato
    {

        for (int i = 0; i < numeroCandidato.Length; i++)
        {
            /* Console.Write("Informe o número do candidato: "); */
            numeroCandidato[i] = int.Parse(arqEntrada.ReadLine());

            /* Console.Write("Informe o nome do candidato: "); */
            nomeCandidato[i] = arqEntrada.ReadLine();
        }
    }

    static int qtdEleitores() //Função para validar a qtd de eleitores
    {
        int m;
        do
        {
            /* Console.Write("Informe a quantidade de eleitores: "); */
            m = int.Parse(arqEntrada.ReadLine());
        } while (m < 10);
        return m;
    }

    static void dadosEleitor(int[] titulo, string[] nomeEleitor, string[] dataNasc, int[] idade, int[] votos) //Procedimento para armazenar os dados dos eleitores 
    {
        for (int i = 0; i < titulo.Length; i++)
        {
            /* Console.Write("Qual o título: "); */
            titulo[i] = int.Parse(arqEntrada.ReadLine());

           /*  Console.Write("Qual o nome: "); */
            nomeEleitor[i] = arqEntrada.ReadLine();

            /* Console.Write("Qual a data de nascimento: "); */
            dataNasc[i] = arqEntrada.ReadLine();

            /* Console.Write("Qual a idade: "); */
            idade[i] = int.Parse(arqEntrada.ReadLine());

            /* Console.Write("Qual o seu voto: "); */
            votos[i] = int.Parse(arqEntrada.ReadLine());

        }
    }

    static void ApurarVotos(int[] votos, int[] numeroCandidato, string[] nomeCandidato) //Procedimento para apuração e exibição dos votos
    {
        int votosBranco = 0, votosNulos = 0;
        int[] totalVotos = new int[numeroCandidato.Length];

        for (int i = 0; i < votos.Length; i++)
        {
            if (votos[i] == 0)
            {
                votosBranco++;
            }
            else
            {
                bool votoEncontrado = false;
                for (int j = 0; j < numeroCandidato.Length; j++)
                {
                    if (votos[i] == numeroCandidato[j])
                    {
                        totalVotos[j]++;
                        votoEncontrado = true;
                    }
                }
                if (!votoEncontrado)
                {
                    votosNulos++;
                }
            }
        }

        Console.WriteLine("\nResultado da eleição:");
        arqSaida.WriteLine("\nResultado da eleição:");

        for (int i = 0; i < numeroCandidato.Length; i++)
        {
            Console.WriteLine($"Candidato {nomeCandidato[i]} (n° {numeroCandidato[i]}): {totalVotos[i]} voto(s)");
            arqSaida.WriteLine($"Candidato {nomeCandidato[i]} (n° {numeroCandidato[i]}): {totalVotos[i]} voto(s)");
        }

        Console.WriteLine($"Votos brancos: {votosBranco}");
        arqSaida.WriteLine($"Votos brancos: {votosBranco}");
        Console.WriteLine($"Votos nulos: {votosNulos}"); 
        arqSaida.WriteLine($"Votos nulos: {votosNulos}");
    }

    static void Main()
    {
        
        int n = qtdCandidatos();

        int[] numeroCandidato = new int[n];
        string[] nomeCandidato = new string[n];

        dadosCandidato(numeroCandidato, nomeCandidato);
        int m = qtdEleitores();

        int[] titulo = new int[m];
        string[] nomeEleitor = new string[m];
        string[] dataNasc = new string[m];
        int[] idade = new int[m];
        int[] votos = new int[m];
        
        dadosEleitor(titulo, nomeEleitor, dataNasc, idade, votos);
        ApurarVotos(votos, numeroCandidato, nomeCandidato);

        arqEntrada.Close();
        arqSaida.Close();

    }
}