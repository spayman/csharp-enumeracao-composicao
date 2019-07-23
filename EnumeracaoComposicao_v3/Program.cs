using System;
using System.Globalization;
using EnumeracaoComposicao_v3.Entities;
using EnumeracaoComposicao_v3.Entities.Enums;

namespace EnumeracaoComposicao_v3
{
    class Program
    {
        static void Main(string[] args)
        {
            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=---=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=--=-=-=-=-=-=-=-=--=-=-=-
            // Solicita dados do trabalhador para o usuário
            Console.Write("Digite o nome do departamento: ");
            string depart = Console.ReadLine();
            Console.WriteLine("Informe abaixo os dados do funcionário");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Nivel (Junior/MidLevel/Senior): ");
            // Converte a string do usuário em objeto WorkerLevel tipo Enumeração
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Salário base: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            // Aqui após instanciar, passa os valores de argumento na chamada >> Departament(depart);
            Departament departament = new Departament(depart);
            // Aqui após instanciar, passa os valores de argumento na chamada >> Worker(name,level,baseSalary,departament)
            Worker worker = new Worker(name,level, baseSalary, departament);
            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=---=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=--=-=-=-=-=-=-=-=--=-=-=-
            // Solicita informações do contrato para o usuário
            Console.Write("Quantos Contratos para este funcionário?: ");
            int qtd = int.Parse(Console.ReadLine());
            // Instancia a quantidade de contratos informado pelo usuário
            for (int i = 1; i <= qtd; i++)
            {
                Console.Write($"Infome os dados do {i}º contrato");
                Console.Write("Data do contrato (dd/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor da hora trabalhada?: ");
                double valorPerHour = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.Write("Horas trabalhada?: ");
                int hours = int.Parse(Console.ReadLine());
                // Passa os parametros para o novo contrato
                HourContract contract = new HourContract(date, valorPerHour, hours);
                // Faz a chamada para adição
                worker.AddContract(contract);
            }
            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=---=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=--=-=-=-=-=-=-=-=--=-=-=-
            // Imprime o resultado
            Console.WriteLine();
            Console.Write("Informe o mês e ano para calcular o pagamento (MM/YYYY): ");
            string mesAno = Console.ReadLine();
            int mes = int.Parse(mesAno.Substring(0, 2));
            int ano = int.Parse(mesAno.Substring(3,4));
            double tot = worker.Income(mes, ano);
            Console.WriteLine("Nome: " + worker.Name);
            Console.WriteLine("Departamento: " + worker.Departament.Name);
            Console.WriteLine($"Pagamento referênte a {mesAno}: " 
                + worker.Income(ano,mes).ToString("F2", CultureInfo.InvariantCulture));
            // Fim
            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=---=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=--=-=-=-=-=-=-=-=--=-=-=-

        }
    }
}
