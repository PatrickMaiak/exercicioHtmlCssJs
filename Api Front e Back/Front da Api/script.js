
async function Login() {
    let loginUsername = document.getElementById('username').value;
    let loginPassword = document.getElementById('password').value;
    let objUserDto = {
        username: loginUsername,
        password: loginPassword
    }
    await fetch('https://localhost:7291/api/Users/login',
    {
        method:"post",
        headers:{'Content-Type': 'application/json'},
        body: JSON.stringify(objUserDto)
    })
    .then(data => data.json())
    .then(response =>

        
        localStorage.setItem("token", response.token)
    
    )
    decodificar()
}

function parseJwt(token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
}

function decodificar() {
    let token = localStorage.getItem('token')
    let parsed = parseJwt(token)
    console.log(parsed.role)
    if (parsed.role == "root" || parsed.role == "admin"  ) {
        var aparecer = document.getElementById('cadastro')
        aparecer.classList.replace('SumirCadastro', 'AparecerCadastro')
    }
    else{
        var aparecer = document.getElementById('cadastro')
        aparecer.classList.replace('AparecerCadastro', 'SumirCadastro')
    }
}



async function deleteCategoria(id) {
    var token = localStorage.getItem('token');
    const options = {
        method: 'delete',
        headers: {
            'Authorization': 'Bearer ' + token,
        }
    }

    await fetch(`https://localhost:7291/api/Categorias/${id}`, options);

    GetCategoria();
}


function editCategoriaField(id) {
   //alert(id)
    var aparecer = document.getElementById('edit')
    aparecer.classList.replace('SumirEdit', 'AparecerEdit')
    let objCategoriaEditId = document.getElementById('categoriaInputID');
    objCategoriaEditId.value = id

}

async function editCategoria() {
    var aparecer = document.getElementById('edit')
    aparecer.classList.replace('AparecerEdit', 'SumirEdit')

    let objCategoriaEditId = document.getElementById('categoriaInputID').value;
    let objCategoriaEditDescricao = document.getElementById('categoriaInputDESCRICAO').value;

    objCategoriaEdit = {
        id: objCategoriaEditId,
        descricao: objCategoriaEditDescricao
    }
    var token = localStorage.getItem('token');

    const options = {
        method: 'put',
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(objCategoriaEdit)
    }

    await fetch(`https://localhost:7291/api/Categorias/${objCategoriaEditId}`, options);

    GetCategoria();
}



async function GetCategoria() {
    
    linha = ''
    tabela = document.getElementById('CategoriaTb')
    linha = document.createElement('tr')
    tabela.innerHTML = ''
    
    var token = localStorage.getItem('token');

    console.log(token)
    await fetch('https://localhost:7291/api/Categorias',
    {
        method:"get",
        headers:{'Authorization': 'Bearer ' + token,
                 'Content-Type': 'application/json'
                }
       
    }
    
    )
    .then(data => data.json())
    .then(response =>  {
      response.forEach(item => {
            linha = document.createElement('tr')
           
            var colunaId = document.createElement('td')
            colunaId.classList.add('bloco')
            colunaId.textContent = `${item.id}`
            linha.appendChild(colunaId)

            
            var colunaDescricao = document.createElement('td')
            colunaDescricao.textContent = `${item.descricao}`
            linha.appendChild(colunaDescricao)

            var colunaFuncoes = document.createElement('td')
            var button = document.createElement('button')
            
            button.addEventListener('click', function() {
                
                deleteCategoria(item.id);
            });

            var icon = document.createElement('img')
            icon.src = "https://img.icons8.com/material-outlined/24/filled-trash.png"
            icon.width = 15
            icon.height = 15
            icon.alt = 'Delete'

            button.appendChild(icon)

            colunaFuncoes.appendChild(button)

            var button = document.createElement('button')
            
            button.addEventListener('click', function() {
                
                editCategoriaField(item.id);
            });

            var icon = document.createElement('img')
            icon.src = "https://img.icons8.com/ios/50/edit--v1.png"
            icon.width = 15
            icon.height = 15
            icon.alt = 'Edit'

            button.appendChild(icon)

            colunaFuncoes.appendChild(button)


            linha.appendChild(colunaFuncoes)

            tabela.appendChild(linha);



            console.log(item.descricao);
            console.log(item.id);
        });
    })
 
}

async function GetProduto() {
    
    linha = ''
    tabela = document.getElementsByTagName('tbody')[1]
    tabela.innerHTML = ''
    
    await fetch('https://localhost:7291/api/TodoProdutos')
    .then(data => data.json())
    .then(response => {
      response.forEach(item => {
            linha = `<tr><td>${item.id}</td><td>${item.produto}</td><td>${item.valor}</td><td>${item.categoria.descricao}</td>
            <td id="botaotabela"><button onclick=""><img width="15" height="15" src="https://img.icons8.com/material-outlined/24/filled-trash.png" alt="filled-trash"/></button>
            <button onclick=""><img width="15" height="15" src="https://img.icons8.com/ios/50/edit--v1.png" alt="edit--v1"/></button>
            <button onclick=""><img width="15" height="15" src="https://img.icons8.com/ios-glyphs/30/apple-notes.png" alt="apple-notes"/></button></td></tr>`
            tabela.innerHTML += linha;
            console.log(item.descricao);
            console.log(item.id);
        });
    })
 
}

//--------------------------------------------------------

async function PostCategoria() {
    let categoriaInputValor = document.getElementById('categoriaInput').value;
    let objCategoria = {
        descricao: categoriaInputValor
    }
    const token = localStorage.getItem('token');
    await fetch('https://localhost:7291/api/Categorias',
    {
        method:"post",
        headers:{'Authorization': 'Bearer ' + token,
                 'Content-Type': 'application/json'
                },
        body: JSON.stringify(objCategoria)
    }
    
    )
   
   // GetCategoria();
    
}

async function PostProduto() {
    let ProdutoInputValor = document.getElementById('ProdutoInput').value;
    let ValorProdutoValor = document.getElementById('ValorProdutoInput').value;
    let CategoriaDescricaoValor = document.getElementById('ProdutoCategoriaInput').value;

    let objProduto = {
        produto: ProdutoInputValor,
        valor: ValorProdutoValor,
        categoria: {
            descricao: CategoriaDescricaoValor
        }
    }
    console.log(objProduto)
    await fetch('https://localhost:7291/api/TodoProdutos',
    {
        method:"post",
        headers:{'Content-Type': 'application/json'},
        body: JSON.stringify(objProduto)
        
        
    }
    
    )
    GetProduto();
    
}






















