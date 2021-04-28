using System;

//namespace CSharp.Capitulo01.ValeTransporte
//{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
            Inicio:

            Console.Write("Informe o nome do funcionário: ");
            var nome = Console.ReadLine();

            Console.Write("Informe o salário do funcionário: ");
            var salario = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Informe o valor gasto com transporte: ");
            var gastoComTransporte = Convert.ToDecimal(Console.ReadLine());

            var descontoMaximo = salario * 6 / 100;

            var descontoVT = gastoComTransporte > descontoMaximo ? descontoMaximo : gastoComTransporte;

            var resultado = $"\nFuncionário: {nome}" +
                $"\nSalário: {salario}" +
                Environment.NewLine +
                $"Desconto VT: {descontoVT}";

            Console.WriteLine(resultado);

            Console.WriteLine("\nPressione Enter para novo cálculo ou Esc para sair.");

            var comando = Console.ReadKey();

            if (comando.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }

            Console.Clear();

            //Main(args);

            goto Inicio;
    //    }
    //}
//}
