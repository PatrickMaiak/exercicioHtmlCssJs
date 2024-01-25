const token = localStorage.getItem('token');

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

        
        selectCategoria.innerHTML = '<option value=""></option>';

        
        categorias.forEach(categoria => {
            const option = document.createElement('option');
            option.value = categoria.id
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



//------------nao consegui resover o bug a baixo ele não esta atualizando a tabela de produtos-----

//---------DIFICULDADES-----------------

//--------------ELE ESTA ENVIANDO ATUALIZADO POREM A CATEGORIA ESTA INDO COMO NULL------



 async function editProduto() {
    var aparecer = document.getElementById('editProduto')
     
    let idDOLink = document.getElementById('IdentificadorDeIdDeProdutoCategoria').value

     objProdutoEdit = {
         id: document.getElementById('produtoInputID').value,
         produto: document.getElementById('produtoInput').value,
         valor: document.getElementById('valorInput').value,
         categoria:{id: idDOLink}
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
 
     await fetch(`https://localhost:7291/api/TodoProdutos/${idDOLink}`, options);

     aparecer.classList.replace('AparecerEdit', 'SumirEdit')

     //GetCategoria();
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
    // let categoriaInputValor = document.getElementById('categoriaInput').value;
    const objCategoria = {
        descricao: document.getElementById('PostCategoriainpu').value
    }
    console.log(objCategoria)
    const token = localStorage.getItem('token');
    await fetch('https://localhost:7291/api/Categorias',
    {
        method:"post",
        headers:{
                'Authorization': 'Bearer ' + token,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(objCategoria)
    }
    
    )
   
GetCategoria();
    
}

async function PostTodoProdutos() {
   
    const objTodoProduto = {
        produto : document.getElementById('ProdutoInputPost').value,
        valor : document.getElementById('ValorProdutoInput').value,
        Categoria:{id : document.getElementById('categoriaIdInputChaveEstrangeira').value}
    }

    await fetch('https://localhost:7291/api/TodoProdutos',
    {
        method:"POST",
        headers:{'Authorization': 'Bearer ' + token,
                 'Content-Type': 'application/json'
                },
        body: JSON.stringify(objTodoProduto)       
    }
    
    )
    await GetTodoProduto();
    
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




















