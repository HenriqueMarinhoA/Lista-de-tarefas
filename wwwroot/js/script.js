const apiUrl = 'http://localhost:5000/api/tarefas';

// Carrega as tarefas ao carregar a página
document.addEventListener('DOMContentLoaded', loadTasks);

// Verifica se o formulário existe antes de adicionar o evento
const taskForm = document.getElementById('taskForm');
if (taskForm) {
    taskForm.addEventListener('submit', async function (event) {
        event.preventDefault();
        console.log("Evento submit acionado!");

        const titulo = document.getElementById('titulo').value.trim();
        const descricao = document.getElementById('descricao').value.trim();
        const status = document.getElementById('status').value;

        // Verifica se o campo de título não está vazio
        if (!titulo) {
            alert("O título da tarefa é obrigatório!");
            return;
        }

        const newTask = {
            titulo,
            descricao,
            status
        };

        console.log("Nova tarefa a ser enviada:", newTask);
        await createTask(newTask);
    });
} else {
    console.error("Erro: Formulário não encontrado!");
}

async function loadTasks() {
    try {
        const filterStatus = document.getElementById('filterStatus').value;
        let url = apiUrl;

        if (filterStatus) {
            url = `${url}?status=${filterStatus}`;
        }

        const response = await fetch(url);
        if (!response.ok) throw new Error("Erro ao carregar tarefas");

        const tasks = await response.json();
        displayTasks(tasks);
    } catch (error) {
        console.error("Erro ao carregar tarefas:", error);
    }
}

function displayTasks(tasks) {
    const taskList = document.getElementById('taskList');
    taskList.innerHTML = '';

    tasks.forEach(task => {
        const taskElement = document.createElement('div');
        taskElement.classList.add('task');
        taskElement.innerHTML = `
            <h3>${task.titulo}</h3>
            <p>${task.descricao || 'Sem descrição'}</p>
            <p><strong>Status:</strong> ${task.status}</p>
            <button onclick="deleteTask(${task.id})">Excluir</button>
        `;
        taskList.appendChild(taskElement);
    });
}


async function createTask(task) {
    try {
        console.log("Enviando tarefa para a API...");

        // Mapeando o status para um número
        const statusMap = {
            "Pendente": 0,
            "EmProgresso": 1,
            "Concluída": 2
        };

        const formattedTask = {
            titulo: task.titulo,
            descricao: task.descricao,
            dataCriacao: new Date().toISOString(), // Gera data atual no formato correto
            dataConclusao: null, // Deixa como null inicialmente
            status: statusMap[task.status] // Converte o status para número
        };

        const response = await fetch(apiUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formattedTask)
        });

        console.log("Status da resposta:", response.status);

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(errorText || "Erro desconhecido");
        }

        console.log("Tarefa criada com sucesso!");
        loadTasks(); // Recarregar lista de tarefas
    } catch (error) {
        console.error("Erro ao criar tarefa:", error);
        alert('Erro ao criar tarefa: ' + error.message);
    }
}

async function deleteTask(taskId) {
    try {
        console.log("Excluindo tarefa com ID:", taskId);

        const response = await fetch(`${apiUrl}/${taskId}`, {
            method: 'DELETE',
        });

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(errorText || "Erro desconhecido");
        }

        console.log("Tarefa excluída com sucesso!");
        loadTasks(); // Recarregar lista de tarefas após exclusão
    } catch (error) {
        console.error("Erro ao excluir tarefa:", error);
        alert('Erro ao excluir tarefa: ' + error.message);
    }
}
