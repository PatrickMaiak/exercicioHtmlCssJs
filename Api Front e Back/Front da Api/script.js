GetCategoria();
async function GetCategoria() {
    
    linha = ''
    tabela = document.getElementsByTagName('tbody')[0]
    tabela.innerHTML = ''
    
    await fetch('https://localhost:7291/api/Categorias')
    .then(data => data.json())
    .then(response => {
      response.forEach(item => {
            linha = `<tr><td>${item.id}</td><td>${item.descricao}</td>
            <td><button onclick=""><img width="15" height="15" src="https://img.icons8.com/material-outlined/24/filled-trash.png" alt="filled-trash"/></button>
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
    tabela = document.getElementsByTagName('tbody')[0]
    tabela.innerHTML = ''
    
    await fetch('https://localhost:7291/api/Produto')
    .then(data => data.json())
    .then(response => {
      response.forEach(item => {
            linha = `<tr><td>${item.id}</td><td>${item.Produto}</td><td>${item.Valor}</td><td>${item.Categoria}</td>
            <td><button onclick=""><img width="15" height="15" src="https://img.icons8.com/material-outlined/24/filled-trash.png" alt="filled-trash"/></button>
            <button onclick=""><img width="15" height="15" src="https://img.icons8.com/ios/50/edit--v1.png" alt="edit--v1"/></button>
            <button onclick=""><img width="15" height="15" src="https://img.icons8.com/ios-glyphs/30/apple-notes.png" alt="apple-notes"/></button></td></tr>`
            tabela.innerHTML += linha;
            console.log(item.descricao);
            console.log(item.id);
        });
    })
 
}

//--------------------------------------------------------

async function Post() {
    let categoriaInputValor = document.getElementById('categoriaInput').value;
    let obj = {
        descricao: categoriaInputValor
    }
    await fetch('https://localhost:7291/api/Categorias',
    {
        method:"post",
        headers:{'Content-Type': 'application/json'},
        body: JSON.stringify(obj)
    }
    
    )
    GetCategoria();
    
}
async function PostProduto() {
    let categoriaInputValor1 = document.getElementById('categoriaInput1').value;
    let categoriaInputValor2 = document.getElementById('categoriaInput2').value;
    let categoriaInputValor3 = document.getElementById('categoriaInput3').value;
    let obj = {
        produto: categoriaInputValor1,
        valor: categoriaInputValor2,
        categoriaid: categoriaInputValor3
    }
    await fetch('https://localhost:7291/api/Produto',
    {
        method:"post",
        headers:{'Content-Type': 'application/json'},
        body: JSON.stringify(obj)
    }
    
    )
    GetProduto();
    
}






















// fetch('https://ubahthebuilder.tech/posts/1')
// .then(data => {
// return data.json();
// })
// .then(post => {
// console.log(post.title);
// });

// async function fetchProducts() {
//     try {
//         const response = await fetch('https://localhost:7291/api/Categorias');
//         const produtos = await response.json();

       
//         const productsString = JSON.stringify(produtos, null, 2);

        
//         const productInfo = document.getElementById('product-info');
//         productInfo.textContent = productsString;
//     } catch (error) {
//         console.error('Erro ao buscar produtos:', error);
//     }
// }

// // Chama a função ao carregar a página
// fetchProducts();