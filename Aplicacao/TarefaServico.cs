using ListaTarefasAPI.Dominio;
using ListaTarefasAPI.Infraestrutura;

namespace ListaTarefasAPI.Aplicacao
{
    public class TarefaServico
    {
        private readonly ITarefaRepositorio _repositorio;

        public TarefaServico(ITarefaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefasAsync() => await _repositorio.ObterTodasTarefasAsync();

        public async Task<Tarefa> ObterTarefaAsync(int id) => await _repositorio.ObterTarefaPorIdAsync(id);

        public async Task AdicionarTarefaAsync(Tarefa tarefa)
        {
            if (tarefa.Titulo.Length > 100)
                throw new ArgumentException("O título da tarefa não pode exceder 100 caracteres.");

            if (tarefa.DataConclusao.HasValue && tarefa.DataConclusao.Value < tarefa.DataCriacao)
                throw new ArgumentException("A data de conclusão não pode ser anterior à data de criação.");

            await _repositorio.AdicionarTarefaAsync(tarefa);
        }

        public async Task AtualizarTarefaAsync(Tarefa tarefa) => await _repositorio.AtualizarTarefaAsync(tarefa);

        public async Task DeletarTarefaAsync(int id) => await _repositorio.DeletarTarefaAsync(id);
    }
}
