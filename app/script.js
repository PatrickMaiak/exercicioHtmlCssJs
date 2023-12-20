function trocaSinal(item){
    let s = item.value
    s = s.replace(',','.')
    item.value = s
 }


 function calcularimc() {
      let peso = parseFloat(document.getElementById("peso").value)
      let altura = parseFloat(document.getElementById("altura").value)
      

      var calc = peso/(altura*altura)
     
      
     console.log(peso)
     console.log(altura)
     console.log(calc);

     if (isNaN(peso) || isNaN(altura) || peso < 0 || altura < 0 ) {
         document.getElementById("resultadomedia").innerHTML = "erro! verifique se os campos estão preenchidos corretamente"                      
      }
      else if (calc < 17  ) {
         document.getElementById("resultadomedia").innerHTML = "Muito abaixo do peso"                      
      }
      else if (calc >= 17 || calc <= 18.99) {
          document.getElementById("resultadomedia").innerHTML = "Abaixo do peso"
      }                     
      else if (calc >= 18.5 || calc <= 24.99) {
          document.getElementById("resultadomedia").innerHTML = "Peso normal"
      }                    
      else if (calc >=  25 || calc <=  29.99) {
          document.getElementById("resultadomedia").innerHTML = "Acima do peso"
      }                    
      else if (calc >= 30 || calc <= 34.99) {
          document.getElementById("resultadomedia").innerHTML = "Obesidade I"
      }
      else if (calc >= 35 || calc <= 39.99) {
          document.getElementById("resultadomedia").innerHTML = "Obesidade II (severa)"
      }
      else if(calc >  40) {
          document.getElementById("resultadomedia").innerHTML = "Obesidade III (mórbida)"
      }
      
      
     
      
 }


 function calcularidade() {
    let n1 = parseInt(document.getElementById("n1").value)
    
    if (isNaN(n1) || n1 < 0) {
       document.getElementById("resultadoidade").innerHTML = "selecione um idade valida"
    }
   else if (n1 > 17) {
       document.getElementById("resultadoidade").innerHTML = n1 + " vocé é maior de idade"
    }

    else{
       document.getElementById("resultadoidade").innerHTML = n1 + " vocé é menor de idade"
    }
    
    
}


function calcularnota() {
    let n1 = parseFloat(document.getElementById("n1").value)
    let n2 = parseFloat(document.getElementById("n2").value)
    let n3 = parseFloat(document.getElementById("n3").value)

    let calc = (n1 + n2 + n3 )/3
  
    let fq = parseInt(document.getElementById("fq").value)
     
    if (n1 > 10 || n2 > 10 || n3 > 10 || fq > 100 || n1 < 0 || n2 < 0 || n3 < 0 || fq < 0 ||isNaN(n1) || isNaN(n2) || isNaN(n3) || isNaN(fq)) {
        document.getElementById("resultadoSITU").innerHTML = "  NUMEROS INVALIDOS CERTIFIQUE-SE QUE NOTA ESTA ENTRE 0 E 10 E FREQUENCIA ENTRE 0 E 100"
        document.getElementById("resultadomedia").innerHTML = " ERRO! "
        return false
     }
    else if (calc < 7 || fq < 75 || fq != "") {
        document.getElementById("resultadomedia").innerHTML = "SUA MEDIA É " + calc.toFixed(2) + " E SUA FREQUENCIA É DE "+ fq+ "%"
        document.getElementById("resultadoSITU").innerHTML = "SUTUAÇÃO: REPROVADO"
     }
    else if (calc >= 7 || fq >= 75 || fq != 0){
        document.getElementById("resultadomedia").innerHTML = "SUA MEDIA É " + calc.toFixed(2) + " E SUA FREQUENCIA É DE "+ fq+ "%"
        document.getElementById("resultadoSITU").innerHTML = "SUTUAÇÃO: APROVADO"
     }  
    else{
        document.getElementById("resultadomedia").innerHTML = "digite um valor valido "
    } 
}

function calcularaumento() {
    let cargo = String(document.getElementById("cargo").value)
    let salario = parseFloat(document.getElementById("salario").value)

    if (cargo == "gerente" & salario > 0) {
       let calc = salario * 0.05

       document.getElementById("resultadomedia").innerHTML = "voce teve um aumento de 5% (" + salario +"+"+ "5%) = " + (calc+salario)+"R$"
      
    }
    else if (cargo == "supervisores" & salario > 0) {
       let calc = salario * 0.08

       document.getElementById("resultadomedia").innerHTML = "voce teve um aumento de 8% (" + salario +"+"+ "8%) = " + (calc+salario)+"R$"
      
    }
    else if (cargo == "operadores" & salario > 0) {
       let calc = salario * 0.09

       document.getElementById("resultadomedia").innerHTML = "voce teve um aumento de 9% (" + salario +"+"+ "9%) = " + (calc+salario)+"R$"
      
    }
    else if (cargo == "demais colaboradores" & salario > 0) {
       let calc = salario * 0.1

       document.getElementById("resultadomedia").innerHTML = "voce teve um aumento de 10% (" + salario +"+"+ "10%) = " + (calc+salario)+"R$"
      
    }
    else{
      

       document.getElementById("resultadomedia").innerHTML = "selecione um cargo e um salario válido"
      
    }

}




