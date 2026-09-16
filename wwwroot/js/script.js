const API_URL_ATIVIDADE = "https://localhost:7173/api/Atividades"

async function carregarAtividades() {
    const result = await fetch(API_URL_ATIVIDADE)
    const atividades = await result.json()

    const atividades_div = document.getElementById("atividades")
    atividades_div.innerHTML = ``
    for (var atividade of atividades){
        atividades_div.innerHTML += `
            <h1>${atividade.nome}</h1>
            <p>Descrição: ${atividade.descricao}</p>
            <p>Professor(a): ${atividade.professor.nome}</p>
            <p>Disciplina: ${atividade.disciplina.nomeDisciplina}</p>
        `
    }
}

async function fazerLogout() {
    localStorage.removeItem("tipoUsuario")
    localStorage.removeItem("dataUsuario")
    window.location.reload()
}

async function carregarUsuario() {
    const tipoUsuario = localStorage.getItem("tipoUsuario")
    const dataUsuario = JSON.parse(localStorage.getItem("dataUsuario"))

    const div_info = document.getElementById("login-info")
    const professor_Div = document.getElementById("professor")
    const div_aluno = document.getElementById("div-aluno")
    const info_aluno_div = document.getElementById("info-aluno")
    const admin_div = document.getElementById("administrativo")

    div_info.innerHTML = `<button onclick='window.location.href="html/conta/login.html"'>Fazer Login</button>`
    if (tipoUsuario == "Professor"){
        professor_Div.style.display = "block"
    }else if(tipoUsuario == "Admininistrador"){
        admin_div.style.display = "block"
    }else if (tipoUsuario == "Aluno"){

        const response_aluno = await fetch(`https://localhost:7173/api/Alunos/${dataUsuario.id}/`)
        const info_aluno = await response_aluno.json()
        div_aluno.style.display = "block"
        
        document.getElementById("priv-access").style.border = "none"

        info_aluno_div.innerHTML = `
        <h1>Informações do aluno</h1>
        <br>
        <p>Nome: ${info_aluno.nome}</p>
        <br>
        <p>Turma: ${info_aluno.turma.nomeTurma} | ${info_aluno.turma.turno}</p>
        <br>
        <p>Status: ${info_aluno.status}</p>
        `
    }

    if (dataUsuario !== null){
        div_info.innerHTML = `
        <p>Bem vindo, ${dataUsuario.nome} | Cargo: ${tipoUsuario}</p>
        <button class="delete" onclick="fazerLogout()">Fazer logout</button>
        `
    }
}