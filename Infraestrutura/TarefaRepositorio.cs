using ListaTarefasAPI.Dominio;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefasAPI.Infraestrutura
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly AppDbContext _context;

        public TarefaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> ObterTodasTarefasAsync()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task<Tarefa> ObterTarefaPorIdAsync(int id)
        {
            return await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AdicionarTarefaAsync(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarTarefaAsync(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarTarefaAsync(int id)
        {
            var tarefa = await ObterTarefaPorIdAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
