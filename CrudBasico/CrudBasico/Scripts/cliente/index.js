$(window).on("load", function () {
	
	//Ignora que é do template
	new DataTable('#tabelaCliente', {
		info: false,
		ordering: false,
		paging: false
	});

});
