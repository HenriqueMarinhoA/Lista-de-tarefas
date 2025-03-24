const apiUrl = 'http://localhost:5000/api/tarefas';

document.addEventListener('DOMContentLoaded', loadTasks);

document.getElementById('taskForm').addEventListener('submit', function (event) {
    event.preventDefault();
    const titulo = document.getElementById('titulo').value;
    const descricao = document.getElementById('descricao').value;
    const status = document.getElementById('status').value;

    const newTask = {
        titulo,
        descricao,
        status
    };

    createTask(newTask);
});

async function loadTasks() {
    const filterStatus = document.getElementById('filterStatus').value;
    let url = apiUrl;

    if (filterStatus) {
        url = `${url}?status=${filterStatus}`;
    }

    const response = await fetch(url);
    const tasks = await response.json();
    displayTasks(tasks);
}

function displayTasks(tasks) {
    const taskList = document.getElementById('taskList');
    taskList.innerHTML = '';

    tasks.forEach(task => {
        const taskElement = document.createElement('div');
        taskElement.classList.add('task');
        taskElement.innerHTML = `
            <h3>${task.titulo}</h3>
            <p>${task.descricao}</p>
            <p><strong>Status:</strong> ${task.status}</p>
        `;
        taskList.appendChild(taskElement);
    });
}

async function createTask(task) {
    console.log("Tentando criar tarefa com os dados: ", task);

    const response = await fetch(apiUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(task)
    });

    console.log("Status da resposta:", response.status);

    if (response.ok) {
        console.log("Tarefa criada com sucesso!");
        loadTasks(); // Carregar novamente as tarefas
    } else {
        const errorText = await response.text();
        console.log("Erro ao criar tarefa:", errorText);
        alert('Erro ao criar tarefa');
    }
}
