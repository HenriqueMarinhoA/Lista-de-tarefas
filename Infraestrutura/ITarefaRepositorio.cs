using ListaTarefasAPI.Dominio;

namespace ListaTarefasAPI.Infraestrutura
{
    public interface ITarefaRepositorio
    {
        Task<IEnumerable<Tarefa>> ObterTodasTarefasAsync();
        Task<Tarefa> ObterTarefaPorIdAsync(int id);
        Task AdicionarTarefaAsync(Tarefa tarefa);
        Task AtualizarTarefaAsync(Tarefa tarefa);
        Task DeletarTarefaAsync(int id);
    }
}
