var campoFilto = document.querySelector("#filtro");

campoFilto.addEventListener("input", function () {
    console.log(this.value);
    var temas = document.querySelectorAll(".tema");

    for (var i = 0; i < temas.length; i++) {
        var tema = temas[i];
        var tdNome = tema.querySelector(".nome");
        var nome = tdNome.textContent;
        var expressao = new RegExp(this.value, "i");

        if (!expressao.test(nome)) {
            tema.classList.add("invisivel")
        } else {
            tema.classList.remove("invisivel")
        }

        if (campoFilto.value == "") {
            tema.classList.remove("invisivel")
        }
    }
});