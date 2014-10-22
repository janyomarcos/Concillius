﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿/// <reference path="jquery-1.7.2.min.js" />

/* Helpers----------------------------------------------------------------------------------------- */

function autocomplete(node) {
	$(node + ".autocomplete").each(function (index) {
		var url = $(this).attr("data-url");
		var objautocomplete = $(this);

		$(this).autocomplete({
			minLength: $(this).attr("data-length"),
			source: function (request, callback) {
				$.ajax({
					async: false,
					dataType: "json",
					url: url,
					data: objautocomplete.closest('form').serialize(),
					success: function (data) {
						callback(data);
					}
				});
			},
			select: function (event, ui) {
				$('#' + $(this).attr('data-hidden-id')).val(ui.item.id);
			}
		});
	});
}


function maskMap() {
    $('input:text').setMask();
    $.mask.masks = {
        'hora'              :{ mask: ('29:59' )},
        'tempo'             :{ mask: ('999:59' )},
        'data'              :{ mask: ('99/99/9999')},
        'telefone'          :{ mask: ("99999-9999")},
        'telefonecomddd'    :{ mask: ('(99) 9999-9999') },
        'cep'               :{ mask: ('99999-999' )},
        'cpf'               :{ mask: ('999.999.999-99')},
        'cnpj'              :{ mask: ('99.999.999/9999-99')},
        'numero'            :{ mask: '9', type : 'repeat', 'maxLength': '100' },
        'decimal'           :{ mask: '99,999', type : 'reverse' },
        'ddd'               :{ mask: ("99")},
        'prazo'             :{ mask: '999', type: 'reverse', defaultValue: '+' }
    };
}

function registerMask(node) {
    maskMap();    
	$(node + ".cpf").setMask("cpf");
    $(node + ".cnpj").setMask("cnpj");
    $(node + ".data").setMask("data");
	$(node + ".telefoneddd").setMask("telefonecomddd");
    $(node + ".cep").setMask("cep");
    $(node + ".numero").setMask("numero");
    $(node + ".decimal").setMask("decimal");
    $(node + ".prazo").setMask("prazo");
    $(node + ".ddd").setMask("ddd");
    $(node + ".hora").setMask("hora");
    $(node + ".tempo").setMask("tempo");

//    $(node + ".hora").setMask("hora").live('focusout', function(event) {
//        var exp = /\^(20|21|22|23|[01]\d|\d)(([:][0-5]\d){1,2})$/g;

//        var result = exp.test($(this).val());
//        
//        if (!result) {
//            $(this).val('');
//        }

//    });

    $(node + ".telefone").setMask("telefone").live('focusout', function(event) {
        var target, phone, element;
        target = (event.currentTarget) ? event.currentTarget : event.srcElement;
        phone = target.value.replace( /\D/g , '');
        element = $(target);
        element.unsetMask();
        if (phone.length > 8) { 
            element.setMask("99999-9999");
        } else {
            element.setMask("9999-99999");
        }
    });
    
    $(node + ' .caixaalta').keyup(function(event) {
		$(this).val($(this).val().toUpperCase());
	});
    
}

function bindCheckSimNao() {
    $("#myCheckBox").click(function() {
        var isChecked = $(this).is(":checked");

        $("#_stringBool").val(isChecked ? "T" : "F");
    });
}

function bindDivErrors() {
    $("#messages").empty();
	var html = $("#validations-container").html();
    //var html  = $("#modal").html();
    if ($("#modal").dialog("isOpen") == true) {

        $("#modal-messages").remove();

        $("#modal").prepend(
            $('<div />').attr('id', 'modal-messages').append(html)
        );

    }
    else {
        $("#messages").html(html);
    }
    
    $("#validations").remove();
    
    $('span.closeMessage').click(function() {
        $(this).closest('div').hide("slow");
    });
}

function enableListDouble(node) {
	$(node + "[name='AddButton'], " + node + " [name='RemoveButton']").bind("click", function (event) {
		var id = $(event.target).attr("name");
		var selectFrom = id == "AddButton" ? ".listaFonte" : ".listaAlvo";
		var moveTo = id == "AddButton" ? ".listaAlvo" : ".listaFonte";
		var selectedItems = $(selectFrom + " :selected").toArray();
		$(moveTo).append(selectedItems);
		selectedItems.remove;
	});
}

function enableButton(checkBoxId, idButton) {
	if ($("#" + checkBoxId).closest('div.grid').find('.grid-checkbox').is(':checked')) {
		$("#" + idButton).removeAttr('disabled');
		$("#" + idButton).removeClass('disableBtAzul');
	} else {
		$("#" + idButton).attr('disabled', 'disabled');
		$("#" + idButton).addClass('disableBtAzul');
	}
}

function enableTabs(node) {
	$(node + " .tabs").each(function(index) {
		$(this).tabs();
	});
}


function enableGridActionButton(node) {
	var prefix = "data-";
	$(node + " .gridActionButton").each(function (index) {
		$(this).click(function () {
            var button = $(this);
			var updatedata = eval($(this).attr("data-update-button"));
			var dataAttributes = {};
			$($(this)[0].attributes).each(function() { 
				if(this.nodeName.substring(0, prefix.length) == prefix) {
					dataAttributes[this.nodeName] = this.nodeValue;
				}
			});

			$.each(updatedata, function (i, item) {
                $('input[id=selectedindex]').val(item.index);
                var data = button.closest('form').serialize();

				$.ajax({
					url: item.url,
					data: data,
					success: function (result) {
						var updateIdSelector = '#' + item.updateId;
						
                        $(updateIdSelector).empty().html(result);

						loadApp(updateIdSelector);

						if (updateIdSelector == "#modal") {
							showModalPopUp(dataAttributes);
						}

						if (item.closeModal == "True") {
							closeModalPopUp();
						}
					}
				});


			});
		});
	});
}


function enableBulkGridActionButton(node) {

	$(node + " .bulkGridActionButton").each(function (index) {
		$(this).click(function () {

			var data = $(this).closest('form').serialize();
			var updatedata = eval($(this).attr("data-update-button"));

			$.each(updatedata, function (i, item) {

                var message = item.confirmMessage;
                var grid = "#" + item.gridId;

                var selecteds = $(grid + ' input:checked').length;

                if (selecteds == undefined || selecteds == 0) {                
	                alert("É necessário selecionar um item para realizar a operação.");
	                return false;
                }

                if (!confirm(message)) {
	                return false;
                }

				$.ajax({
					url: item.url,
					data: data,
					success: function (result) {
						var updateIdSelector = '#' + item.updateId;
						
                        $(updateIdSelector).empty().html(result);

						loadApp(updateIdSelector);

						if (updateIdSelector == "#modal") {
							showModalPopUp(dataAttributes);
						}

						if (item.closeModal == "True") {
							closeModalPopUp();
						}
					},
                    complete: function() { bindDivErrors(); }
				});
			});
		});
	});
}



function enableUploadButton(node) {
	$(node + " .uploadButton").each(function (index) {
		$(this).click(function () {

			var data = $(this).closest('form').serializeArray();
			var url = $(this).attr("data-url");
			var updateId = $(this).attr("data-update-id");
			var file = $(this).attr("data-file-input");

			$.ajaxFileUpload(
				{
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
		});
	});
}

function enableDropDown(node) {
	$(node + " .cascade-dropdownlist").each(function (index, item) {
		var url = $(item).attr("data-url");
		var childId = "#" + $(item).attr("data-child-id");
		var childSelected = $(item).attr("data-child-selected");

		var containsValue = false;

        if (childSelected == undefined || childSelected == "false") {

		    $(childId).find("option").each(function() {
			    if ($(item).val() > 0) {
				    containsValue = true;       
			    }
		    });

		    if (!containsValue) {
			    loadDropDownListChilds($(item).val(), url, childId);
		    }
        }
	});

	$(node + " .cascade-dropdownlist").change(function () {
		var url = $(this).attr("data-url");
		var childId = "#" + $(this).attr("data-child-id");

		loadDropDownListChilds($(this).val(), url, childId);
	});
}


function loadDropDownListChilds(value, url, childId) {
	if (value == 'null' || value == undefined) {
		$(childId).empty();
		$(childId).append("<option value=''>Selecione</option>");
		return;
	}

	$.ajax({
		url: url,
		dataType: 'json',
		data: { value: value },
		success: function (json) {
			$(childId).find('option').each(function(index2) {
				if ($(this).val() > 0) {
					$(this).remove();
				}
			});

			$(json).each(function (index3, item) {
				var opt = $("<option/>").attr('value', item.Value).text(item.Text);
				$(childId).append(opt);
			});
		}
	});
}

function configureAjaxSetup() {
    $.ajaxSetup({ cache: false, type: "POST" });
    
    $("#loading").bind("ajaxSend", function () {
        $(this).show();
         
    }).bind("ajaxComplete", function () {
        $(this).hide();
        //bindDivErrors();

    }).ajaxError(function (event, jqXHR, ajaxSettings, thrownError) {
        alert('Ocorreu um erro, procure o administrador do sistema.');
    });
}

function loadApp(parent) {

	var node = "* ";
	if (parent) {
		node = parent + " ";
	} else {
	    configureAjaxSetup();
	}

    
    enableTabs(node);
    //registerMask(node);
	//autocomplete(node);
	enableListDouble(node);
	enableUpdateButton(node);
	enableUploadButton(node);
	enableDropDown(node);
    enableGridActionButton(node);
    enableBulkGridActionButton(node);
    bindCheckSimNao();

    //triggerLayout();
}

/* functions para eventos do request feito pelos helpers nptt, que abre um modal */

function onBeginOpenModal(jqXHR, settings) {
}

function onFailureModal(jqXHR, textStatus, errorThrown) {
	alert(errorThrown);
}

function onSuccessModal(data, textStatus, jqXHR) {
	showModalPopUp();
	bindDivErrors();
	loadApp("#modal");
}

function onCompleteModal(jqXHR, textStatus) {
}

/* functions para eventos do request feito pelo asp.net mvc */

function onSuccess(data, textStatus, jqXHR) {
	loadApp();
    bindDivErrors();
}

function onSuccessFormModal() {
    loadApp("#modal");
	bindDivErrors();
}

function onBegin(jqXHR, settings) {
}

function onComplete() {
    $('#loading').hide();
}

function onFailure(jqXHR, textStatus, errorThrown) {
	loadApp();
	alert(errorThrown);
}

function showModalPopUp(data) {
	
	var title = $("#modal").find(".conteudo-modal").attr("data-modal-title");
	var height = $("#modal").find(".conteudo-modal").attr("data-height");
	var width = $("#modal").find(".conteudo-modal").attr("data-width");
	
	if (!title) title = data["data-modal-title"];
	if (!height) height = data["data-height"];
	if (!width) width = data["data-width"];

	$("#modal").dialog({
		width: width ? width : 1000,
		height: height ? height : 600,
		position: 'center',
		modal: true,
		draggable: true,
		resizable: true,
		closeOnEscape: false,
		title: title ? title : "Detalhes",
		close: function(event, ui) {
			$(this).dialog("destroy");
		}
	});
}

function closeModalPopUp() {
	$("#modal").dialog("destroy");
}

function cancelarModal() {
    if (confirm('Os dados informados não serão Salvos. Deseja prosseguir com o cancelamento?')) {
        closeModalPopUp();
    }
}
