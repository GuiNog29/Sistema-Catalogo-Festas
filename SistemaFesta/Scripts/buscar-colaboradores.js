var botao = document.querySelector("#chamar-colaboradores");

botao.addEventListener("click", function () {
    var xhr = new XMLHttpRequest();
    var url = "dbo.PessoasJuridicas"
    xhr.open("GET", url, true);

    xhr.addEventListener("load", function () {
        var resposta = xhr.responseText;
        var colaboradores = JSON.parse(resposta)
    })
    xhr.send();
})