function enableListDouble() {

    $("[name='AddButton'],[name='RemoveButton']").bind("click", function (event) {
        var id = $(event.target).attr("name");
        var selectFrom = id == "AddButton" ? ".listaFonte" : ".listaAlvo";
        var moveTo = id == "AddButton" ? ".listaAlvo" : ".listaFonte";
        var selectedItems = $(selectFrom + " :selected").toArray();
        $(moveTo).append(selectedItems);
        selectedItems.remove;
    });
}


 