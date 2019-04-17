$(document).on('click', '#deleteStreet', function (event) {
    event.preventDefault();
    const url = $(event.target).attr('href');
    let resultDialog = confirm("Вы действительно хотите удалить?");
    if (resultDialog) {
        let token = $('input[name="__RequestVerificationToken"]').val();
        $.ajax({
            type: 'POST',
            url: url,
            data: {
                __RequestVerificationToken: token
            }
        });
    }
});