if ($('#ItemModel_Value_Nome').val() != "")
    $('#ItemModel_Value_Descricao').focus();
else
    $('#ItemModel_Value_Nome').focus();

$("#Adicionar").click(function () {
    var cargo = $("#GrupoCargoDet_IdGrupoCargoCab").val();

    if (cargo == "") {

        alert("Insira um valor no campo Cargo!");
    } else {

        if ($("#accordion").accordion("option", "active", 0) !== false) {
            $(".tituloAccordion").addClass('mantemTitulo');
            $("#accordion").accordion("option", "collapsible", 0);
        }
    }
    return false;
});

$("#accordion").accordion({
    active: true,
    collapsible: true,
    heightStyle: "content"
});