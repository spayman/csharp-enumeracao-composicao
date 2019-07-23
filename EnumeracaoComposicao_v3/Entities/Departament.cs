namespace EnumeracaoComposicao_v3.Entities
{
    class Departament
    {
        // Definição dos atributos
        public string Name { get; set; }
        // Definição do contrutor padrão
        public Departament()
        {
        }
        // Definição do contrutor personalizado
        public Departament(string name)
        {
            Name = name;
        }
    }   
}
