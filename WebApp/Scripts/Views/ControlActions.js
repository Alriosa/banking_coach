﻿var editor;


function ControlActions() {

	this.URL_API = "http://localhost:57056/api/";

	this.GetUrlApiService = function (service) {
		return this.URL_API + service;
	}

	this.GetTableColumsDataName = function (tableId) {
		var val = $('#' + tableId).attr("ColumnsDataName");

		return val;
	}

	this.FillTable = function (service, tableId,refresh) {

		if (!refresh) {
			columns = this.GetTableColumsDataName(tableId).split(',');
			var arrayColumnsData = [];


			$.each(columns, function (index, value) {
				var obj = {};
				obj.data = value;
				arrayColumnsData.push(obj);
			});
			
			var table = $('#' + tableId).DataTable({
				"processing": true,
				"ajax": {
					"url": this.GetUrlApiService(service),
					dataSrc: 'Data'
				},
				"columns": arrayColumnsData,
				"language": {
					"url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json",
				},
			});

			$('#' + tableId + ' tbody').on('click', 'tr', function () {
				var data = table.row(this).data();
				sessionStorage.setItem(tableId + '_selected', JSON.stringify(data));
			});
		} else {
			//RECARGA LA TABLA
			$('#' + tableId).DataTable().ajax.reload();
		}
		
	}



	this.GetSelectedRow = function () {
		var data = sessionStorage.getItem(tableId + '_selected');

		return data;
	};

	this.BindFields = function (formId, data) {
		$('#' + formId +' *').filter(':input').each(function (input) {
			var columnDataName = $(this).attr("ColumnDataName");
			this.value = data[columnDataName];
		});
	}

	this.GetDataForm = function (formId) {
		var data = {};
		
		$('#' + formId + ' *').filter(':input').each(function (input) {
			var columnDataName = $(this).attr("ColumnDataName");
			data[columnDataName] = this.value;
		});

		return data;
	}

	this.ShowMessage = function (type,message) {
		if (type == 'E') {
			$("#alert_container").removeClass("alert alert-success alert-dismissable")
			$("#alert_container").addClass("alert alert-danger alert-dismissable");
			$("#alert_message").text(message);
		} else if (type == 'I') {
			$("#alert_container").removeClass("alert alert-danger alert-dismissable")
			$("#alert_container").addClass("alert alert-success alert-dismissable");
			$("#alert_message").text(message);
		}
		$('.alert').show();
	};

	this.PostToAPI = function (service, data, callBackFunction) {
		var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
			var ctrlActions = new ControlActions();
			if (response.Data == "error") {
				ctrlActions.ShowMessage('E', response.Message);
				document.body.scrollTop = 0;
				document.documentElement.scrollTop = 0;
				callBackFunction(response);
			} else {
				ctrlActions.ShowMessage('I', response.Message);
				callBackFunction(response);

			}
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
				console.log(data);
				callBackFunction("error data")
			})
	};

	this.PutToAPI = function (service, data, callBackFunction) {
		var jqxhr = $.put(this.GetUrlApiService(service), data, function (response) {
			var ctrlActions = new ControlActions();
			ctrlActions.ShowMessage('I', response.Message);
			if (response.Data == "error") {
				ctrlActions.ShowMessage('E', response.Message);
				document.body.scrollTop = 0;
				document.documentElement.scrollTop = 0;
				callBackFunction(response);
			} else {
				ctrlActions.ShowMessage('I', response.Message);
				callBackFunction(response);

			}
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
				console.log(data);
			})
	};

	this.PutToAPIMyData = function (service, data, callBackFunction) {
		var jqxhr = $.put(this.GetUrlApiService(service), data, function (response) {
			var ctrlActions = new ControlActions();
			ctrlActions.ShowMessage('I', response.Message);
			if (response.Data == "error") {
				ctrlActions.ShowMessage('E', response.Message);
				document.body.scrollTop = 0;
				document.documentElement.scrollTop = 0;
			} else {
				ctrlActions.ShowMessage('I', response.Message);
				setCookie('user', JSON.stringify(data), 30);
			}
			callBackFunction();
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
				console.log(data);
			})
	};

	this.DeleteToAPI = function (service, data, callBackFunction) {
		var jqxhr = $.delete(this.GetUrlApiService(service), data, function (response) {
			var ctrlActions = new ControlActions();
			ctrlActions.ShowMessage('I', response.Message);
			callBackFunction();
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
				console.log(data);
			})
	};

	this.Login = function (service, data, callBackFunction) {
		var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
			var ctrlActions = new ControlActions();
			if(response.Data == "error") {
				ctrlActions.ShowMessage('E', response.Message);
			} else {
				var data = response.Data;
				setCookie('user', JSON.stringify(data), 30);

				ctrlActions.ShowMessage('I', response.Message);

			}
			callBackFunction(data);

		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
			})
	};


	this.LoginByUser = function (service, callBackFunction) {
		var jqxhr = $.get(this.GetUrlApiService(service), function (response) {
			
			var data = response.Data;
			sessionStorage.setItem('type', response.Data['UserType']);
			setCookie('type', response.Data['UserType'], 30);

			//setCookie('user', JSON.stringify(data), 30);

			callBackFunction(data);
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
			})
	};

	this.GetById = function (service, callbackFunction) {
		var jqxhr = $.get(this.GetUrlApiService(service), function (response) {
			//var ctrlActions = new ControlActions();
			//ctrlActions.ShowMessage('I', response.Message);//no trae respuesta, la respuesta es el objeto
			callbackFunction(response.Data);// la diferencia es una B cuando debe ser una b
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);

			})
	}



	this.RecoverPassword = function (service, data, callBackFunction) {
		var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
			var ctrlActions = new ControlActions();
			if (response.Data == "error") {
				ctrlActions.ShowMessage('E', response.Message);
			} else {
				var data = response.Data;

				ctrlActions.ShowMessage('I', response.Message);

			}
			callBackFunction(response.Data);

		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
			})
	};
}


function setCookie(name, value, days) {
	var expires = "";
	if (days) {
		var date = new Date();
		date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
		expires = "; expires=" + date.toUTCString();
	}
	document.cookie = name + "=" + (value || "") + expires + "; path=/";
}

function getCookie(cname) {
	
	var i, x, y, ARRcookies = document.cookie.split(";");

	for (i = 0; i < ARRcookies.length; i++) {
		x = ARRcookies[i].substr(0, ARRcookies[i].indexOf("="));
		y = ARRcookies[i].substr(ARRcookies[i].indexOf("=") + 1);
		x = x.replace(/^\s+|\s+$/g, "");
		if (x == cname) {
			return unescape(y);
		}
	}

}

function formatDateString(s) {
	var s = s.split(/\D/);
	return s[0] + '-' + s[1] + '-' + s[2];
}

function formatDateStringMonths(s) {
	var s = s.split(/\D/);
	return s[0] + '-' + s[1];
}

//Custom jquery actions
$.put = function (url, data, callback) {
	if ($.isFunction(data)) {
		type = type || callback,
			callback = data,
			data = {}
	}
	return $.ajax({
		url: url,
		type: 'PUT',
		success: callback,
		data: JSON.stringify(data),
		contentType: 'application/json'
	});
}

$.delete = function (url, data, callback) {
	if ($.isFunction(data)) {
		type = type || callback,
			callback = data,
			data = {}
	}
	return $.ajax({
		url: url,
		type: 'DELETE',
		success: callback,
		data: JSON.stringify(data),
		contentType: 'application/json'
	});
}



$.validator.addMethod("new_password_not_same", function (value, element) {
	return $('#txtOldPassword').val() != $('#txtNewPassword').val()
}, "* Debe elegir una contraseña diferente a la actual");