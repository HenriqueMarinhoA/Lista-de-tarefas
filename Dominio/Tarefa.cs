namespace ListaTarefasAPI.Dominio
{
    public class Tarefa
    {
        //Id da Tarefa
        public int Id { get; set; }  

        //Título da Tarefa
        public string Titulo { get; set; }  
        
        //Descrição da Tarefa
        public string Descricao { get; set; }

        //Data de criação da tarefa
        public DateTime DataCriacao { get; set; }

        //Data de conclusão
        public DateTime? DataConclusao { get; set; }

        //Status da tarefa  (Pendente, EmProgresso, Concluída)
        public StatusTarefa Status { get; set; }  
    }

    public enum StatusTarefa
    {
        Pendente,
        EmProgresso,
        Concluída
    }
}
