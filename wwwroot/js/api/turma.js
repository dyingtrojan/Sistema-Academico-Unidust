const API_URL = "https://localhost:7173/api/Turmas"

async function procurarTurmas() {
    const result = await fetch(`${API_URL}`)
    const turmas  = await result.json()
    return turmas 
}

async function adicionarTurma() {
    const nomeTurma = document.getElementById("nomeTurma").value
    const anoLetivo = document.getElementById("anoLetivo").value
    const turno = document.getElementById("turno").value
    const disciplina = document.getElementById("disciplina")
    
    const disciplinasObjetos = Array.from(disciplina.selectedOptions).map(option => ({
        id: parseInt(option.value)
    }));
    
    try {
        const payload = {
            nomeTurma: nomeTurma,
            anoLetivo: parseInt(anoLetivo),
            turno: turno,
            disciplinas: valores
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
    var tabela = document.getElementById("tabela-turmas")
    const turmas = await procurarTurmas()

    tabela.innerHTML = ``

    for (const turma of turmas){
        tabela.innerHTML += `
        <tr>
            <td>${turma.id}</td>
            <td>${turma.nomeTurma}</td>
            <td>${turma.anoLetivo}</td>
            <td>${turma.turno}</td>
            <th><a>Editar</a></th>
            <th><a>Detalhes</a></th>
            <th><button class="delete" onclick=deletarTurma(${turma.id})>Delete</button></th>
        </tr>
        `
    }
}

async function deletarTurma(id){
    const confirmacao = confirm("Tem certeza que quer apagar a turma?")
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

async function procurarDisciplinas() {
    const response = await fetch("https://localhost:7173/api/Disciplinas")
    const disciplinas = await response.json()

    const disciplinaOption = document.getElementById("disciplina")
    disciplinaOption.innerHTML = ``

    for (const disciplina of disciplinas){
        disciplinaOption.innerHTML += `
            <option value="${disciplina.id}">${disciplina.nomeDisciplina} | ${disciplina.cargaHoraria} horas</option>
        `
    }
}