$(document).on('click', '#deleteEntity', function (event) {
    event.preventDefault();
    const url = $(event.target).attr('href');
    console.log(url);
    let resultDialog = confirm("Вы действительно хотите удалить?");
    if (resultDialog) {
        let token = $('input[name="__RequestVerificationToken"]').val();
        $.ajax({
            type: 'POST',
            url: url,
            data: {
                __RequestVerificationToken: token,
            },
            success: function (urlRedirect) {
                window.location = urlRedirect;
            },
            error: function (error) {
                alert(error);
            }
        });
    }
});