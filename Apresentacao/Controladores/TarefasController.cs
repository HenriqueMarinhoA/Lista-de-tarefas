using Microsoft.AspNetCore.Mvc;
using ListaTarefasAPI.Aplicacao;
using ListaTarefasAPI.Dominio;

namespace ListaTarefasAPI.Apresentacao.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly TarefaServico _tarefaServico;

        public TarefasController(TarefaServico tarefaServico)
        {
            _tarefaServico = tarefaServico;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodasTarefas([FromQuery] string status)
        {
            var tarefas = await _tarefaServico.ObterTarefasAsync();

            if (!string.IsNullOrEmpty(status))
            {
                tarefas = tarefas.Where(t => t.Status.ToString() == status).ToList();
            }

            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterTarefa(int id)
        {
            var tarefa = await _tarefaServico.ObterTarefaAsync(id);
            if (tarefa == null) return NotFound();
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> CriarTarefa([FromBody] Tarefa tarefa)
        {
            await _tarefaServico.AdicionarTarefaAsync(tarefa);
            return CreatedAtAction(nameof(ObterTarefa), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarTarefa(int id, [FromBody] Tarefa tarefa)
        {
            if (id != tarefa.Id) return BadRequest();
            await _tarefaServico.AtualizarTarefaAsync(tarefa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarTarefa(int id)
        {
            await _tarefaServico.DeletarTarefaAsync(id);
            return NoContent();
        }
    }
}
