$(document).ready(function () {
    $('input:radio[name="rdFiltros"]').change(function () {
        if ($('#rdFiltroDatas').is(":checked")) {
            $("#filtroIntervaloData").css("display", "block");
            $("#filtroPorClinica").css("display", "none");
            $("select[name='ClinicaId']").val("");
            $("input[name='DataConsulta']").val("");
        } else {
            $("#filtroPorClinica").css("display", "block");
            $("#filtroIntervaloData").css("display", "none");
            $("select[name='IndrStatusN']").val("");
            $("input[name='DataInicioD']").val("");
            $("input[name='DataFimD']").val("");
        }
    });

    $("form").submit(function (event) {
        var valida = true;
        if ($('#rdFiltroDatas').is(":checked")) {
            if ($("input[name='DataInicioD']").val() == "" && $("input[name='DataFimD']").val() == "" && $("select[name='IndrStatusN']").val() == "") {
                alert("Por favor, escolha ao menos um filtro.");
                valida = false;
            } else if ($("input[name='DataInicioD']").val() != "" && $("input[name='DataFimD']").val() == ""
                || $("input[name='DataInicioD']").val() == "" && $("input[name='DataFimD']").val() != "") {
                alert("Por favor, insira as duas datas do intervalo.");
                valida = false;
            }
        } else if ($('#rdFiltroClinica').is(":checked")) {
            if ($("select[name='ClinicaId']").val() == "") {
                alert("Por favor, selecione uma clínica e uma data de consulta.");
                valida = false;
            } else if ($("input[name='DataConsulta']").val() == "") {
                alert("Por favor, insire uma data de consulta para o filtro.");
                valida = false;
            }
        }

        if (!valida)
            event.preventDefault()
    });
});