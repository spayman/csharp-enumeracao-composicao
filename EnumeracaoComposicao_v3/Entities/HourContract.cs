using System;
using System.Collections.Generic;
using System.Text;

namespace EnumeracaoComposicao_v3.Entities
{
    class HourContract
    {
        // Definição dos atributos
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }
        // Definição do contrutor padrão
        public HourContract()
        {
        }
        // Definição do contrutor personalizado
        public HourContract(DateTime date,double valuePerHour,int hours)
        {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }
        // Definição do metodo
        public double TotalValue()
        {
            return ValuePerHour * Hours;
        }
    }
}
