
function openModal(data) {

    var element = '#modal';

    var title = $(element).find('div.conteudo-modal').attr('data-modal-title');

    if (title == undefined) {
        title = data['data-modal-title'];
        
        if (title) {
            title = title.replace(/_/g, ' ');
        }
    }

    var height = data['data-modal-height'];
    var width = data['data-modal-width'];

    $(element).dialog({
        width: width ? width : 900,
        height: height ? height : 600,
        position: 'center',
        modal: true,
        draggable: true,
        resizable: true,
        closeOnEscape: false,
        title: title ? title : 'Cosmos - Titulo não definido',
        close: function (event, ui) {
            $(this).dialog('destroy');
        }
    });
}

function confirmModal(message, callbackNao, callbackSim, context) {

    message = message.replace(/_/g, ' ');

    $('#confirm').empty();
    $('#confirm').html(message);

    $('#confirm').dialog({
        height: 140,
        title: 'Confirmação',
        resizable: false,
        modal: true,
        draggable: false,
        resizable: false,
        closeOnEscape: false,
        buttons: {
            'Sim': function () {
                $(this).dialog('close');

                if (callbackSim != null) {
                    callbackSim(context);
                }
            },
            'Não': function () {
                $(this).dialog('close');

                if (callbackNao != null) {
                    callbackNao(context);
                }
            }
        }
    });
}

function alertModal(message) {
    $('#dialog').empty();
    $('#dialog').html(message);

    $('#dialog').dialog({
        height: 140,
        title: 'Alerta',
        resizable: false,
        modal: true,
        draggable: false,
        resizable: false,
        closeOnEscape: false,
        buttons: {
            "Ok": function () {
                $(this).dialog('close');
            }
        }
    });
}

function openNpttModal(options, elementId) {
    $('#' + elementId).dialog(options).dialog('open');
}

function closeModal(context) {
    $('#modal').dialog('destroy');

    if (context !== undefined) {
        if (context.dataAttributes["data-event-on-sucess"]) {
            eval(context.dataAttributes["data-event-on-sucess"]);
        }
    }
}