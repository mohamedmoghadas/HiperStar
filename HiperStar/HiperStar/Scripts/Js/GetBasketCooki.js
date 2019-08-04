function GetBasketCooki(Content) {
    $.ajax({
        url: '/Home/GetBasketCooki',
        data: null,
        type: 'post',
        beforeSend: function () {
            $(LoadingGift).show();
        },
        success: function (data) {

            $(LoadingGift).hide();

            Content.innerHTML = data;
        }
    });
}