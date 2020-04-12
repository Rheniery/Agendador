$(document).ready(function () {
    $("#DescTelefoneA").mask('(00)00000-0000');

    $('#IndrTipoA').change(function () {
        var selectedValue = $(this).children("option:selected").val();
        if (selectedValue == "F") {
            $("#divPaciente").css("display", "block");
            $("#divClinica").css("display", "none");
            $("#DescCpfcnpjA").mask('000.000.000-00');
            $("#DescEnderecoA").val('');
        } else if (selectedValue == "J") {
            $("#divClinica").css("display", "block");
            $("#divPaciente").css("display", "none");
            $("#DescCpfcnpjA").mask('00.000.000/0000-00');
            $("input:radio[name='IndrConvenioA']").prop('checked', false);
            $("#DescConvenioA").val('');
            $("#DescNumconvenioA").val('');
            $("#DescEmailA").val('');
        } else {
            $("#divClinica").css("display", "none");
            $("#divPaciente").css("display", "none");
            $("#DescCpfcnpjA").mask("");
        }
    });

    $('input:radio[name="IndrConvenioA"]').change(function () {
        var checkedValue = $('input:radio[name="IndrConvenioA"]:checked').val();
        if (checkedValue == "S") {
            $("#divConveniado").css("display", "block");
        } else {
            $("#divConveniado").css("display", "none");
        }
    })


    $("form").submit(function (event) {
        if (!ValidaCampos()) {
            event.preventDefault()
        }
    });
});

function ValidaCampos() {
    if ($("select[name='IndrTipoA'] option:selected").val() == "F") {
        if (!validaCpfCnpj($("#DescCpfcnpjA").val())) {
            alert("CPF inválido, por favor corrija.");
            return false;
        }

        if (!$("input[name='IndrConvenioA']").is(':checked')) {
            alert("Selecione se o paciente tem convênio ou não!");
            return false;
        }

        if ($("#rbConvenioSim").is(":checked")) {
            if ($("#DescConvenioA").val() == "") {
                alert("Por favor, insira o nome do convênio.");
                return false;
            }
            if ($("#DescNumconvenioA").val() == "") {
                alert("Por favor, insira o número do convênio.");
                return false;
            }
        }
    } else if ($("select[name='IndrTipoA'] option:selected").val() == "J") {
        if (!validaCpfCnpj($("#DescCpfcnpjA").val())) {
            alert("CNPJ inválido, por favor corrija.");
            return false;
        }
    }

    return true;
}