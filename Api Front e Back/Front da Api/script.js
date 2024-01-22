// GetCategoria();
// GetProduto();

async function GetCategoria() {
    
    linha = ''
    tabela = document.getElementById('CategoriaTb')
    tabela.innerHTML = ''
    
    await fetch('https://localhost:7291/api/Categorias')
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
    await fetch('https://localhost:7291/api/Categorias',
    {
        method:"post",
        headers:{'Content-Type': 'application/json'},
        body: JSON.stringify(objCategoria)
    }
    
    )
   
    GetCategoria();
    
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
    alert(objProduto)
    
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