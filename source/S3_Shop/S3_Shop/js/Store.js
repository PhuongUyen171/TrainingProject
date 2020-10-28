class Store {
    constructor() {
        try {
            var me = this;
            me.LoadData();
        } catch (e) {

        }
    }
    
    LoadData() {
        deb
        $.ajax({
            url: "/api/Store",
            method: "GET",
            //data: "",
            contentType: "application/json",
            dataType: "json"
        }).done(function (response) {
            debugger;
            $('.grid tbody').empty();
            $.each(response, function (index, item) {
                var trHTML = $(`<tr>
                    <td>`+ item.StoreID +`</td>
                    <td>`+item.StoreName+`</td>
                </tr >`);
                $('.grid tbody').append(trHTML);
            })
        }).fail(function (response) {
            alert("Đã có lỗi xảy ra.");
        })
    }
}