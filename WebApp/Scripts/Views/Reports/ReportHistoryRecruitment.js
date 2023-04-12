function ReportHistoryRecruitment() {
    this.tblRecruiterId = 'tblHistoryRecruitment';
    this.ctrlActions = new ControlActions();
    this.service = 'recruiter';
    this.columns = "RecruiterLogin,Name,Email,EntityAssociationName,UserActiveStatus";

    this.BindFields = function (data) {
        localStorage.setItem('selectedID', data["RecruiterUserID"]);
    }

    this.RetrieveAll = async function () {
        //this.ctrlActions.FillTable(this.service, this.tblRecruiterId, false);

        await this.ctrlActions.GetById('history/recruited/student', function (data) {
            var t = $('#tblHistoryRecruitment').DataTable({
                language: {
                    "decimal": "",
                    "emptyTable": "No hay registros",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Registros",
                    "infoEmpty": "Mostrando 0 de 0 Registros",
                    "infoFiltered": "(Filtrado de _MAX_ total registros)",
                    "infoPostFix": "",
                    "thousands": ",",
                    "lengthMenu": "Mostrar _MENU_ registros",
                    "loadingRecords": "Cargando...",
                    "processing": "Procesando...",
                    "search": "Buscar:",
                    "zeroRecords": "Sin resultados encontrados",
                    "paginate": {
                        "first": "Primero",
                        "last": "Ultimo",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                },
            });
           
            for (let i in data) {
                t.row.add([
                    data[i].Id,
                    data[i].FirstName + ' '+data[i].FirstLastName + '' + data[i].SecondLastName,
                    data[i].IdentificationNumber,
                    data[i].EntityUser,
                    data[i].RecruiterName,
                    data[i].CreateDate,
                    data[i].StatusEconomic,
                    data[i].StatusPsychometric,
                    data[i].StatusInterview,
                    data[i].StatusHired,
                    data[i].UpdateDate,
                    (data[i].FinishDate != '') ? data[i].FinishDate : 'En proceso'
                ]).draw(false);
            }
        });
    }
}

$(document).ready(function () {
    var report = new ReportHistoryRecruitment();
    report.RetrieveAll();
});