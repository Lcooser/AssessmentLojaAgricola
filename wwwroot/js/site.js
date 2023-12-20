

$(document).ready(function () {

    getDatatable('#table-produtos');
    getDatatable('#table-usuarios');

})

function getDatatable(id) {
    $(id).DataTable({{
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ at&eacute; _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 at&eacute; 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLenghtMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carreghando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascenmdente",
                "sSortDescending": ": Ordenar colunas de forma descentende"
            }
        }
    });
}

$('.close-alert').click(function () {
    $(".alert").hide('hide');
});