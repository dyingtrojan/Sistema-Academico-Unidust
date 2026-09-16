const API_URL = "https://localhost:7173/api/Atividades"

async function procurarAtividades() {
    const result = await fetch(`${API_URL}`)
    const atividades  = await result.json()
    return atividades 
}

async function adicionarAtividade() {
    const nome = document.getElementById("nome").value
    const descricao = document.getElementById("descricao").value
    const turma = document.getElementById("turma").value
    const professor = document.getElementById("professor").value
    const disciplina = document.getElementById("disciplina").value
    try {
        const payload = {
            nome: nome,
            descricao: descricao,
            TurmaID: parseInt(turma),
            ProfessorID: parseInt(professor),
            DisciplinaID: parseInt(disciplina)
        }
        const response = await fetch(API_URL, {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(payload)
        })
    } catch (error) {
        alert("Um Erro ocorreu. Tente novamente mais tarde")
    }
    alterarTabela()
}

async function alterarTabela() {
    var tabela = document.getElementById("tabela-atividades")
    const atividades = await procurarAtividades()

    tabela.innerHTML = ``

    for (const atividade of atividades){
        tabela.innerHTML += `
        <tr>
            <td>${atividade.id}</td>
            <td>${atividade.nome}</td>
            <td>${atividade.descricao}</td>
            <td>${atividade.turma.nomeTurma}</td>
            <td>${atividade.professor.nome}</td>
            <td>${atividade.disciplina.nomeDisciplina}</td>
            <th><a>Editar</a></th>
            <th><a>Detalhes</a></th>
            <th><button class="delete" onclick=deletarAtividade(${atividade.id})>Delete</button></th>
        </tr>
        `
    }
}

async function deletarAtividade(id){
    const confirmacao = confirm("Tem certeza que quer apagar a atividade?")
    if (!confirmacao){
        return
    }
    const response = await fetch(`${API_URL}/${id}`,{
        method: "DELETE",
        headers: {
            'Content-Type': 'application/json'
        }
    }
    )
    alterarTabela()
}
