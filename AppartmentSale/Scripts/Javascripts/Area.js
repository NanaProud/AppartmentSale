$(document).on('click','#deleteArea', function (event) {
    event.preventDefault();
    const url = $(event.target).attr('href');
    let resultDialog = confirm("Вы действительно хотите удалить?");
});