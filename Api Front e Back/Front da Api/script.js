
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
}



async function GetCategoria() {
    
    linha = ''
    tabela = document.getElementById('CategoriaTb')
    tabela.innerHTML = ''
    
    const token = localStorage.getItem('token');
    console.log(token)
    await fetch('https://localhost:7291/api/Categorias',
    {
        method:"get",
        headers:{'Authorization': 'Bearer ' + token,
                 'Content-Type': 'application/json'
                },
        body: JSON.stringify(objCategoria)
    }
    
    )
    .then(data => data.json())
    .then(response => {
      response.forEach(item => {
            linha = `<tr><td class="bloco">${item.id}</td><td>${item.descricao}</td>
            <td id="botaotabela"><button onclick=""><img width="15" height="15" src="https://img.icons8.com/material-outlined/24/filled-trash.png" alt="filled-trash"/></button>
            <button onclick=""><img width="15" height="15" src="https://img.icons8.com/ios/50/edit--v1.png" alt="edit--v1"/></button>
            <button onclick=""><img width="15" height="15" src="https://img.icons8.com/ios-glyphs/30/apple-notes.png" alt="apple-notes"/></button></td></tr>`
            tabela.innerHTML += linha;
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






















