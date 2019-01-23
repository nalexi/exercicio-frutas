$(function () {

    atualizarTabela();

    function atualizarTabela() {
        $.ajax({
            type: 'get',
            url: '/fruta/obterdados',
            success: function (resultado) {
                var dados = JSON.parse(resultado);
                $("#tabela-fruta").empty();
                for (var i = 0; i < dados.length; i++) {
                    var fruta = dados[i];
                    adicionarLinha(fruta);
                }
            }
        });
    }

    $("#modal-cadastro-fruta-salvar").on("click", function () {
        salvar();
        $("#modal-cadastro-fruta").modal('hide');
    });

    function salvar() {
        
        $nome = $("#modal-cadastro-fruta-nome").val().trim();
        $preco = $("#modal-cadastro-fruta-preco").val();
        $peso = $("#modal-cadastro-fruta-peso").val();
        $.ajax({
            type: 'post',
            url: '/fruta/store',
            data: {
                //id_categoria : $idcategoria,
                nome : $nome,
                preco : $preco,
                peso : $peso
            },
            success: function (data) {
                var fruta = JSON.parse(data);
                adicionarLinha(fruta);
                $("#modal-cadastro-fruta-nome").val("");
                $("#modal-cadastro-fruta-preco").val("");
                $("#modal-cadastro-fruta-peso").val("");
            }
        });
    }

    function adicionarLinha(fruta) {
        $colunaCodigo = "<td>" + fruta.Id + "</td>";
        $colunaIdCategoria = "<td>" +  "</td>";
        $colunaNome = "<td>" + fruta.Nome + "</td>";
        $colunaPreco = "<td>" + fruta.Preco + "</td>";
        $colunaPeso = "<td>" + fruta.Peso + "</td>";
        $colunaAcao = "<td>\
                      <button class='btn btn-primary botao-editar' data-id='" + fruta.Id + "'>Editar</button>\
                      <button class=\"btn btn-danger botao-apagar\" data-id = '"+ fruta.Id + "'>Apagar</button>\
                      </td>";
        $linha = "<tr>" + $colunaCodigo + $colunaIdCategoria + $colunaNome + $colunaPreco + $colunaPeso + $colunaAcao + "</tr>";
        $("#tabela-fruta").append($linha);
    }

    $("#tabela-fruta").on("click", ".botao-editar", function () {
        $botao = $(this);
        $id = $botao.data("id");
        $.ajax({
            type: 'get',
            url: '/fruta/ObterPeloId',
            data: {
                id: $id
            },
            success: function (result) {
                var fruta = JSON.parse(result);
                $("#modal-editar-fruta-nome").val(fruta.Nome);
                $("#modal-editar-fruta-id").val(fruta.Id);
                $("#modal-editar-fruta-preco").val(fruta.Preco);
                $("#modal-editar-fruta-peso").val(fruta.Peso);
                $("#modal-editar-fruta").modal("show");
            }
        });
    });

    $("#modal-editar-fruta-alterar").on("click", function () {
        $id = $("#modal-editar-fruta-id").val();
        $nome = $("#modal-editar-fruta-nome").val();
        $preco = $("#modal-editar-fruta-preco").val();
        $peso = $("#modal-editar-fruta-peso").val();
        $.ajax({
            type: 'post',
            url: '/fruta/update',
            data: {
                id: $id,
                nome: $nome,
                preco: $preco,
                peso: $peso
            },
            success: function (result) {
                atualizarTabela();
                $("#modal-editar-fruta").modal("hide");
            }
        });
    });

});