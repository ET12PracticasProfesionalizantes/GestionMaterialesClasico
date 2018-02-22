﻿var baseURL = window.location.protocol + "//" + window.location.host + "/"
var tablaPersonal;

$(document).ready(function () {
    $('#btn_crearPersonal').tooltip();

    var requestPersonal = $.ajax({
        url: baseURL + "/Personal/GetPersonal",
        type: 'GET',
        contentType: 'application/json; charset=utf-8'
    });

    requestPersonal.done(function (data) {
        //console.log(data.Response);
        tablaPersonal = $('#grdPersonal').DataTable({
            //"dom": "lfrtip",
            "aaData": data.Response,
            "aoColumnDefs": [{
                "targets": [0],
                "visible": false,
                "sType": "html",
                "aTargets": [4]
            }],
            "aoColumns": [
                {
                    "data": "idPersonal"
                },
                {
                    "data": "nombre"
                },
                {
                    "data": "dni"
                },
                {
                    "data": "fichaCensal"
                },
                {
                    "mRender": function (dato, type, row) {
                        //console.log(row);

                        var editarHtml = '<div class="row"><div title="Editar Personal" class="col-2 offset-1"><a href="/Personal/Editar/' + row.idPersonal + '"><i class="fas fa-pencil-alt"></i></a></div>';

                        var borrarHtml = '<div title="Borrar Personal" class="offset-1"><a href="" data-toggle="modal" data-target="#myModal-' + row.idPersonal + '"><i class="fas fa-trash-alt"></i></a><div class="modal fade" id= "myModal-' + row.idPersonal + '" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" >' +
                            '<div class="modal-dialog modal-dialog-centered" role="document">'+
                                    '<div class="modal-content">'+
                                        '<div class="modal-header"><h4 class="modal-title" id="myModalLabel">Borrar Personal</h4></div>'+
                                            '<div class="modal-body">' +
                                        '<p>¿Desea borrar la siguiente persona del sistema?</p>' +
                                            '<p><strong>Nombre y Apellido:</strong> ' + row.nombre + '</p>' +
                                            '<p><strong>Ficha Censal:</strong> ' + row.fichaCensal + '</p>' +
                                            '<p><strong>DNI:</strong> ' + row.dni + '</p>' +
                                            '</div>' +
                                        '<div class="modal-footer">' +
                                        '<a href="/Personal/Borrar/'+ row.idPersonal + '" type="button" class="btn btn-danger">Aceptar</a>' +
                                        '<button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>' +
                                        '</div></div></div></div></div></div>';
                        return editarHtml + borrarHtml;
                    }
                }],
            "language": {
                "decimal": "",
                "emptyTable": "No hay información disponible para mostrar",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ entradas",
                "infoEmpty": "No hay personas para mostrar",
                "infoFiltered": "(filtrados de _MAX_ personas totales)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Ver _MENU_ personas por página",
                "loadingRecords": "Cargando...",
                "processing": "En proceso...",
                "search": "Buscar",
                "zeroRecords": "No hay personas que coincidan con el filtro",
                "paginate": {
                    "first": "Primera",
                    "last": "Última",
                    "next": "Siguiente",
                    "previous": "Anterior"
                }
            }
        });
    });

    requestPersonal.fail(function (data) {
        alert(data.Response);
    });
})
