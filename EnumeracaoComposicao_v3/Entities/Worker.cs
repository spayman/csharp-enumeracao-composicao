using System.Collections.Generic;
using EnumeracaoComposicao_v3.Entities.Enums;
using EnumeracaoComposicao_v3.Entities;


namespace EnumeracaoComposicao_v3.Entities
{
    class Worker
    {
        // Definição dos atributos
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Departament Departament { get; set; }
        public List<HourContract> Contracts { get; private set; } = new List<HourContract>();
        // Definição do contrutor padrão
        public Worker()
        {
        }
        // Definição do contrutor personalizado
        public Worker(string name, WorkerLevel level, double baseSalary, Departament departament)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Departament = departament;
            // Campos do lado muitos como Contracts, não e informado aqui
        }         
        // Definição dos métodos
        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }
        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }
    }
}