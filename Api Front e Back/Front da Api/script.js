var login;
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
    login = objUserDto
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




async function preencherCategorias() {
    const selectCategoria = document.getElementById('categoriaInput');
    const token = localStorage.getItem('token');

    const response = await fetch('https://localhost:7291/api/Categorias', {
        method: 'get',
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        }
    });

   
        const categorias = await response.json();

        // Limpe as opções existentes
        selectCategoria.innerHTML = '<option value=""></option>';

        // Preencha as opções com as categorias obtidas
        categorias.forEach(categoria => {
            const option = document.createElement('option');
            option.value = JSON.stringify({ id: categoria.id, descricao: categoria.descricao });
            option.textContent = categoria.descricao;

            selectCategoria.appendChild(option);
        });
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
async function deleteProduto(id){
    var token = localStorage.getItem('token');
    const options = {
        method: 'delete',
        headers: {
            'Authorization': 'Bearer ' + token,
        }
    }

    await fetch(`https://localhost:7291/api/TodoProdutos/${id}`, options);

    GetTodoProduto();
}

async function deleteUser(id) {
    var token = localStorage.getItem('token');
    const options = {
        method: 'delete',
        headers: {
            'Authorization': 'Bearer ' + token,
        }
    }

    await fetch(`https://localhost:7291/api/Users/${id}`, options);

    GetUsuario();
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
    

    let objCategoriaEditId = document.getElementById('categoriaInputID').value;
    let objCategoriaEditDescricao = document.getElementById('categoriaInputDESCRICAO').value;

    aparecer.classList.replace('AparecerEdit', 'SumirEdit')

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


function editProdutoField(id) {
     
     var aparecer = document.getElementById('editProduto')
     aparecer.classList.replace('SumirEdit', 'AparecerEdit')
     let objProdutoEditId = document.getElementById('produtoInputID');
     objProdutoEditId.value = id
     preencherCategorias();
 
 }
 async function editProduto() {
     var aparecer = document.getElementById('editProduto')
     
 
     let objProdutoEditId = document.getElementById('produtoInputID').value;
     let objProdutoEditDescricao = document.getElementById('produtoInput').value;
 
     let objProdutoEditValor = document.getElementById('valorInput').value;
     let objProdutoEditCategoria = document.getElementById('categoriaInput').value;

     aparecer.classList.replace('AparecerEdit', 'SumirEdit')
 
     objProdutoEdit = {
         id: objProdutoEditId,
         produto: objProdutoEditDescricao,
         valor: objProdutoEditValor,
         categoria:{
             id:objProdutoEditCategoria
         }
     }
     var token = localStorage.getItem('token');
 
     const options = {
         method: 'put',
         headers: {
             'Authorization': 'Bearer ' + token,
             'Content-Type': 'application/json'
         },
         body: JSON.stringify(objProdutoEdit)
     }
 
     await fetch(`https://localhost:7291/api/TodoProdutos/${objProdutoEditId}`, options);
 
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

async function GetTodoProduto() {
    

    linha = ''
    tabela = document.getElementById('produtoTb')
    linha = document.createElement('tr')
    tabela.innerHTML = ''
    
    var token = localStorage.getItem('token');

    console.log(token)
    await fetch('https://localhost:7291/api/TodoProdutos',
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

            
            var colunaProduto = document.createElement('td')
            colunaProduto.textContent = `${item.produto}`
            linha.appendChild(colunaProduto)

            var colunaValor = document.createElement('td')
            colunaValor.textContent = `${item.valor}`
            linha.appendChild(colunaValor)

            var colunaCategoria = document.createElement('td')
            colunaCategoria.textContent = `${item.categoria.descricao}`
            linha.appendChild(colunaCategoria)

            var colunaFuncoes = document.createElement('td')
            var button = document.createElement('button')
            
            button.addEventListener('click', function() {
                
                deleteProduto(item.id);
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
                
                editProdutoField(item.id);
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



async function GetUsuario(){
    linha = ''
    tabela = document.getElementById('UserTb')
    linha = document.createElement('tr')
    tabela.innerHTML = ''
    
    var token = localStorage.getItem('token');

    
    await fetch('https://localhost:7291/api/Users',
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
            colunaId.textContent = `${item.username}`
            linha.appendChild(colunaId)

            
            var colunaDescricao = document.createElement('td')
            colunaDescricao.textContent = `${item.role}`
            linha.appendChild(colunaDescricao)

            var colunaFuncoes = document.createElement('td')
            var button = document.createElement('button')
            
            button.addEventListener('click', function() {
                
                deleteUser(item.id);
            });

            var icon = document.createElement('img')
            icon.src = "https://img.icons8.com/material-outlined/24/filled-trash.png"
            icon.width = 15
            icon.height = 15
            icon.alt = 'Delete'

            button.appendChild(icon)

            colunaFuncoes.appendChild(button)


            linha.appendChild(colunaFuncoes)

            tabela.appendChild(linha);

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

async function PostTodoProdutos() {

    let ProdutoInputValor = document.getElementById('ProdutoInput').value;
    let ValorProdutoValor = document.getElementById('ValorProdutoInput').value;
    let CategoriaDescricaoValor = document.getElementById('ProdutoCategoriaInput').value;
    alert(ProdutoInputValor)
    alert(ValorProdutoValor)
    alert(CategoriaDescricaoValor)
    
    let objTodoProduto = {
        produto: ProdutoInputValor,
        valor: ValorProdutoValor,
        Categoria:{
            id: CategoriaDescricaoValor
        }

    }
    alert(objTodoProduto)
    console.log(objTodoProduto)
    const token = localStorage.getItem('token');
    await fetch('https://localhost:7291/api/TodoProdutos',
    {
        method:"post",
        headers:{'Authorization': 'Bearer ' + token,
                 'Content-Type': 'application/json'
                },
        body: JSON.stringify(objTodoProduto)
        
        
    }
    
    )
    GetTodoProduto();
    
}

async function PostUsuario() {
    let usernameInputValor = document.getElementById('cadastroUsername').value;
    let passwordInputValor = document.getElementById('cadastroPassword').value;
    let roleInputValor = document.getElementById('role').value;
    let objUser = {
        username: usernameInputValor,
        password: passwordInputValor,
        role: roleInputValor
    }
    const token = localStorage.getItem('token');
    await fetch('https://localhost:7291/api/Users',
    {
        method:"post",
        headers:{'Authorization': 'Bearer ' + token,
                 'Content-Type': 'application/json'
                },
        body: JSON.stringify(objUser)
    }
    
    )
   
    GetUsuario();
    
}




















