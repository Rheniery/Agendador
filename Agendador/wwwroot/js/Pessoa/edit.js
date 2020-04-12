$(document).ready(function () {
    $("#DescTelefoneA").mask('(00)00000-0000');
    if ($("select[name='IndrTipoA'] option:selected").val() == "F") {
        $("#divPaciente").css("display", "block");
        $("#DescCpfcnpjA").mask('000.000.000-00');
        var checkedValue = $('input:radio[name="IndrConvenioA"]:checked').val();
        if (checkedValue == "S") {
            $("#divConveniado").css("display", "block");
        } else {
            $("#divConveniado").css("display", "none");
        }
    } else {
        $("#divClinica").css("display", "block");
        $("#DescCpfcnpjA").mask('00.000.000/0000-00')
    }

    $('#IndrTipoA').change(function () {
        var selectedValue = $(this).children("option:selected").val();
        if (selectedValue == "F") {
            $("#divPaciente").css("display", "block");
            $("#divClinica").css("display", "none");
            $("#DescCpfcnpjA").mask('000.000.000-00')
        } else if (selectedValue == "J") {
            $("#divClinica").css("display", "block");
            $("#divPaciente").css("display", "none");
            $("#DescCpfcnpjA").mask('00.000.000/0000-00')
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
});