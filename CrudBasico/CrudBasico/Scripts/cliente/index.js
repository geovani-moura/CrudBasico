$(document).ready(function () {

	//Incluir
	$("#clienteIncluir").on("click", function () {
		window.location.href = "/Cliente/Create"
	});

	//Editar
	$(".clienteEditar").on("click", function () {
		var Id = $(this).data('id');
		window.location.href = "/Cliente/Edit/" + Id
	});

	//Detalhes
	$(".clienteDetalhes").on("click", function () {
		debugger;
		var Id = $(this).data('id');
		window.location.href = "/Cliente/Details/" + Id
	});

	//Excluir
	$(".clienteExcluir").on("click", function () {
		var Id = $(this).data('id');
		if (confirm(`Deseja realmente excluir o id: ${Id}?`)) {
			window.location.href = "/Cliente/Delete/" + Id
		}
	});
});