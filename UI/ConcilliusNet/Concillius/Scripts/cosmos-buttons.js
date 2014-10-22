
function getDataAttributes(obj) {
    var prefix = "data-";
    var dataAttributes = {};
    $(obj.attributes).each(function () {
        if (this.nodeName.substring(0, prefix.length) == prefix) {
            dataAttributes[this.nodeName] = this.nodeValue;
        }
    });
    return dataAttributes;
}

function enableUpdateButton(node) {
    
    triggerLayout(node);

    $(node + " .updateButton").each(function (index) {
        $(this).click(function () {

            var button = $(this);
            var data = $(this).closest('form').serializeArray();
            var updatedata = eval($(this).attr('data-update-button'));
            var dataAttributes = getDataAttributes($(this)[0]);

            $.each(updatedata, function (i, item) {

                var updateIdSelector = '#' + item.updateId;

                var context = {
                    dataAttributes: dataAttributes,
                    button: button,
                    item: item,
                    updateIdSelector: updateIdSelector,
                    data: data
                };

                if (!triggerCancelar(context)) {
                    return false;
                }

                if (!triggerGridToolbar(context, sendForm)) {
                    return false;
                }

                triggerGridRow(context);

                sendForm(context);
            });
        });
    });
}

function sendForm(context) {
    $.ajax({
        url: context.item.url,
        data: context.data,
        success: function (result) {
            context.result = result;

            triggerAppendResult(context);
            triggerLoadApp(context);
            triggerModal(context);
            triggerEvent(context);
        },
        complete: function () {
            bindDivErrors();
            triggerEvent(context);
        }
    });
}

function tiggerUpload(context) {
    
	var url = context.dataAttributes["data-url"];
	var updateId = context.dataAttributes["data-update-id"];
	var file = context.dataAttributes["data-file-input"];


	$.ajaxFileUpload({
			url: url,
			data: data,
			secureuri: false,
			fileElementId: file,
			dataType: 'html',
			success: function (result) {
				var updateIdSelector = '#' + updateId;

				$(updateIdSelector).empty().html(result);

				loadApp(updateIdSelector);
			}
		}
	);
}

function triggerEvent(context) {
    var active = context.dataAttributes['data-event-enabled'];

    if (active != undefined) {
        var complete = context.dataAttributes['data-event-complete'];
        var sucess = context.dataAttributes['data-event-sucess'];
    }    
}

function triggerAppendResult(context) {
    var updateIdSelector = context.updateIdSelector;
    var result = context.result;

    $(updateIdSelector).html('').empty().html(result);
}

function triggerLoadApp(context) {
    var updateIdSelector = context.updateIdSelector;
    loadApp(updateIdSelector);
}

function triggerModal(context) {
    var updateIdSelector = context.updateIdSelector;
    var closeModalAttr = context.dataAttributes['data-modal-close'];

    if (closeModalAttr == undefined) {
        if (updateIdSelector == "#modal" || updateIdSelector == "#inner-modal") {
            openModal(context.dataAttributes);
        }
    } else if (closeModalAttr == "true") {
        closeModal(context);
    }
}

function triggerLayout(context) {
    var prefixIcon = "data-layout-icon";
    var prefixIconOnly = "data-layout-text-only";

    $('.btAzul').button();

    var icons = ['cancelar', 'salvar', 'adicionar', 'excluir', 'voltar', 'status', 'filtrar', 'detalhes', 'incluir', 'alterar', 'selecionar', 'gerenciar'];

    for (var i = 0; i < icons.length; i++) {

        var currentIcon = icons[i];

        var selector = '*[data-layout-icon="' + currentIcon + '"]';
        var cssClass = 'ui-icon-colored-' + currentIcon;

        $(selector).button({ icons: { primary: cssClass} });

        // iconOnly
        selector += '[' + prefixIconOnly + '="true"]';

        $(selector).button({ icons: { primary: cssClass }, text: false });
    }
}

function triggerGridToolbar(context, callbackSim) {
    var enabled = context.dataAttributes['data-grid-toolbar-enabled'];

    if (enabled == 'true') {

        var confirmMessage = context.dataAttributes['data-grid-toolbar-confirm-message'];
        var gridId = context.dataAttributes['data-grid-toolbar-grid-id'];

        if (gridId != undefined) {
            var selecteds = $('#' + gridId + ' input:checked').length;

            if (selecteds == undefined || selecteds == 0) {
                alertModal('É necessário selecionar um item para realizar a operação.');
                return false;
            }
        }

        if (confirmMessage != undefined) {
            confirmModal(confirmMessage, null, sendForm, context);
            return false;
        }
    }

    return true;
}

function triggerGridRow(context) {
    var enabled = context.dataAttributes['data-grid-row-enabled'];

    if (enabled == 'true') {
        var selectedIndexId = context.dataAttributes['data-grid-row-update-index'];
        var index = context.dataAttributes['data-grid-row-index'];

        $.each(context.data, function (i, field) {
            if (field.name == selectedIndexId) {
                field.value = index;
                return false;
            }
        });

        context.data[selectedIndexId] = index;
    }
}

function triggerCancelar(context) {
    var message = 'Os dados informados não serão salvos. Deseja prosseguir com o cancelamento?';

    var enabled = context.dataAttributes['data-layout-icon'];
    var closeModalAttr = context.dataAttributes['data-modal-close'];

    if (enabled == 'cancelar') {
        confirmModal(message, null, function () {
            if (closeModalAttr == 'true') {
                closeModal(context);
            } else {
                window.location = context.item.url;
            }
        }, context);

        return false;
    }

    return true;
}