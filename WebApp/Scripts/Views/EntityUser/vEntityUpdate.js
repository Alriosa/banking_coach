function vEntityUpdate() {
    this.ctrlActions = new ControlActions();
    var EntityData = {};
    EntityData = getCookie('user');;
    if (EntityData != null) {
        EntityData = localStorage.getItem('selectedID');
    }


    this.GetData = function () {
        var idEntity = document.getElementById("txtIdEntity").value;
        if (idEntity != 'null') {
            this.ctrlActions.GetById("entity/" + idEntity, this.FillData);
        }
    }

    this.FillData = function (data) {
        document.querySelector('#txtName').value = data['Name'];
        document.querySelector('#txtId').value = data['Id'];
        document.querySelector('#txtQuantity').value = data['Quantity'];
    }

    this.Update = function () {

        var entityData = {};

        entityData = this.ctrlActions.GetDataForm('frmEntityUpdate');
        this.ctrlActions.PutToAPI('entity', entityData, function () {
            resetForm();
        });
    }


    this.ValidateInputs = function () {
        if ($("#frmEntityUpdate").valid()) {
            this.Update();
            resetForm();
        }
    }

  
}

RulesValidateUpdate = function () {

 

    $("#frmEntityUpdate").validate({
        lang: 'es',
        errorClass: "is-invalid",
        messages: {
            /*txtLogin: {
                required: "Ingrese un nombre representativo",
                minlength: "El nombre de usuario debe contener mínimo 6 caracteres",
                maxlength: "El nombre de usuario debe contener máximo 20 caracteres",
                regex: "Solo se permiten minusculas, numeros y el _",
            },*/
            /*txtName: {
                required: "Ingrese un nombre",
                minlength: "El nombre de usuario debe contener mínimo 6 caracteres",
                maxlength: "El nombre de usuario debe contener máximo 20 caracteres",
                regex: "Solo se permiten minusculas y espacios",
            },*/
            /*txtEmail: {
                required: "Ingrese un nombre de usuario",
                minlength: "El nombre de usuario debe contener mínimo 6 caracteres",
                maxlength: "El nombre de usuario debe contener máximo 20 caracteres",
                regex: "Solo se permiten minusculas, numeros y el _",
            },*/
        },
        rules: {
          //  txtLogin: { required: true, regex: /^[a-z0-9_]+$/, minlength: 6, maxlength: 20 },
           //txtName: { required: true, regex: /^[a-zA-ZñÑáéíóúÁÉÍÓÚ ]+$/, minlength: 6, maxlength: 20 },
            // txtEmail: { required: true, regex: /^[a-z0-9_]+$/, minlength: 6, maxlength: 20 },
        }
    });

}


$(document).ready(function () {

    RulesValidateUpdate();

});