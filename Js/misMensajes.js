﻿

function msEnvioFactura() {
	//swal("", "Su compra ha sido procesada correctamente", "success");
	swal("","Gracias por su compra!!!, pronto estaremos en contacto con usted.", "success")
		.then((value) => {
			window.location.href = "Default.aspx";
		});
	
}

function mensajeCorrecto() {
	swal("", "La solicitud ha sido enviada correctamente", "success");
}

function mensajeExisteRegistro() {
	swal("", "La identicación ya existe registrada en la base de datos", "warning");
}

function mensajeError() {
	swal("", "Se ha presentado un error enviando la solicitud, favor intentar mas tarde", "warning");
}


function mensajePagoOk() {
	swal("", "El pago ha sido aplicado correctamente", "success");
}


function validacionCantidadCuotas() {
	swal("", "El número de cuotas supera la cantidad de cuotas pendientes", "warning");
}

