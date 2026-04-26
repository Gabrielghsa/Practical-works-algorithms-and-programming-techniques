using System;
class Program
{
    static void Main()
    {
        // Declaração de variáveis (duas strings e duas decimais (decimal é mais precisa para guardar valores monetários))
        string formaPag, tipoClien;
        decimal valCompra, descPorcen = 0, valfinal, valdesc;

        //Entrada de dados
        Console.WriteLine("Qual o valor total da compra?: ");
        valCompra = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Qual a forma de pagamento?: D ou C");
        formaPag = Console.ReadLine();
        Console.WriteLine("Qual é o tipo de cliente?: N ou F");
        tipoClien = Console.ReadLine();

        //Pagamento em dinheiro
        if (formaPag == "D")
        {
            if (valCompra <= 100)
            {
                descPorcen = 5;
            }
            else
            {
                descPorcen = 10;
            }
        }

        //Pagamento em cartão
        if (formaPag == "C")
        {
            if (valCompra <= 100)
            {
                descPorcen = 0;
            }
            else if (valCompra <= 300)
            {
                descPorcen = 5;
            }
            else
            {
                descPorcen = 10;
            }
        }

        //Benefício adicional pelo tipo de cliente 
        if (tipoClien == "F")
        {
            if (valCompra > 200)
            {
                descPorcen += 5;
            }
            if (formaPag == "D")
            {
                descPorcen += 2;
            }
        }
        //limitando o valor da porcentagem do desconto
        if (descPorcen > 15)
        {
            descPorcen = 15;
        }

        //calculos do valor do desconto e do valor final a ser pago 
        valdesc = valCompra * descPorcen / 100;
        valfinal = valCompra - valdesc;

        //saída de dados 
        Console.WriteLine("--------------------------------------");
        Console.WriteLine($"O valor original da compra é: R${valCompra:f2}");
        Console.WriteLine($"O percentual de desconto é: {descPorcen}%");
        Console.WriteLine($"O valor do desconto é: R${valdesc:f2}");
        Console.WriteLine($"O valor final para pagar é: R${valfinal:f2}");
        Console.ReadKey();
    }
}
