const API_URL = "https://localhost:7173/api"


async function adicionarPessoa() {
    const nome = document.getElementById("nome").value
    const idade = document.getElementById("idade").value
    const email = document.getElementById("email").value
    const cpf = document.getElementById("cpf").value
    const tipoPessoa = document.getElementById("tipoUsuario").value

    switch (tipoPessoa) {    
        case "Professor":
            try{
                const formacoes = document.getElementById("formacoes").value
                const cargo = document.getElementById("cargo").value

                const payload = {
                    nome: nome,
                    idade: idade,
                    email: email,
                    cpf: cpf,
                    cargo: cargo,
                    formacoes: formacoes,
                    hashSenha: "12345678",
                    tipoPessoa: tipoPessoa
                }
                const resposta = await fetch(`${API_URL}/Professores`,{
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(payload)
                }
                )
            } catch(error){
                alert("Um erro ocorreu. Tente mais tarde.")
            }
            break;

        case "Administrador":
            try{
                const payload = {
                    nome: nome,
                    idade: idade,
                    email: email,
                    cpf: cpf,
                    hashSenha: "12345678",
                    tipoPessoa: tipoPessoa
                }
                const resposta = await fetch(`${API_URL}/Administradores`,{
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(payload)
                }
                )
            } catch(error){
                alert("Um erro ocorreu. Tente mais tarde.")
            }
            break;
    }
}

async function procurarPessoas() {
    const result = await fetch(`${API_URL}/Pessoas`)
    const pessoas  = await result.json()
    return pessoas 
}

async function alterarTabela() {
    var tabela = document.getElementById("tabela-pessoas")
    const pessoas = await procurarPessoas()

    tabela.innerHTML = ``

    for (const pessoa of pessoas){
        tabela.innerHTML += `
        <tr>
            <td>${pessoa.id}</td>
            <td>${pessoa.nome}</td>
            <td>${pessoa.idade}</td>
            <td>${pessoa.cpf}</td>
            <td>${pessoa.email}</td>
            <td>${pessoa.tipoPessoa}</td>
            <th><a>Editar</a></th>
            <th><a>Detalhes</a></th>
            <th><button class="delete" onclick=deletarPessoa(${pessoa.id})>Delete</button></th>
        </tr>
        `
    }
}

async function deletarPessoa(id) {
    const confirmacao = confirm("Tem certeza que quer apagar o usuario?")
    if (!confirmacao){
        return
    }
    const response = await fetch(`${API_URL}/Pessoas/${id}`,{
        method: "DELETE",
        headers: {
            'Content-Type': 'application/json'
        }
    }
    )
    alterarTabela()
}

function alterarDiv(){
    const tipoPessoa = document.getElementById("tipoUsuario").value
    const div_professor = document.getElementById("professor-div")
    const div_administrador = document.getElementById("administrador-div")
    switch (tipoPessoa) {
        case "Professor":
            div_professor.style.display = "block"
            div_administrador.style.display = "none"
            break;
    
        case "Administrador":
            div_professor.style.display = "none"
            div_administrador.style.display = "block"
            break;
        case "null":
            div_professor.style.display = "none"
            div_administrador.style.display = "none"
            break
    }
}

async function fazerLogin() {
    const email = document.getElementById("email").value
    const senha = document.getElementById("senha").value

    try {
        const login_response = await fetch(`${API_URL}/Auth/login`,{
            method: 'POST',
            headers:{
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({email: email, senha: senha})
        }
        )
        const data = await login_response.json()
        if (login_response.ok){
            alert("Login realizado.")
            localStorage.setItem("tipoUsuario", data.role);
            localStorage.setItem("dataUsuario", JSON.stringify(data.usuario));
            history.back()
        }
    } catch (error) {
        alert("Um erro ocorreu: ",error)
    }
}

