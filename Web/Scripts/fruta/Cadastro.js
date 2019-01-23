$(function () {
    $("#salvar").on("click", function () {
        $nome = $("#campo-nome").val();
        $preco = $("#campo-preco").val();
        $peso = $("#campo-peso").val();
        $.ajax({
            type: 'post',
            url: '/fruta/store',
            data: {
                nome: $nome,
                preco: $preco,
                peso: $peso
            },
            success: function (data) {
                var fim = JSON.parse(data)
            },
        });
    });
});