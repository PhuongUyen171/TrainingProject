﻿class Store {
    constructor() {
        try {
            var me = this;
            me.LoadData();
        } catch (e) {

        }
    }

    LoadData() {
        $.ajax({
            url: "/api/Store",
            method: "GET",
            //data: "",
            contentType: "application/json",
            dataType: "json"
        }).done(function (response) {
            debugger;
            $('tbody').empty();
            $.each(response, function (index, item) {
                var trHTML = $(`<tr>
                    <td>`+ item.StoreID + `</td>
                    <td>`+ item.StoreName + `</td>
                </tr >`);
                $('tbody').append(trHTML);
            })
        }).fail(function (response) {
            alert("Đã có lỗi xảy ra.");
        })
        document.getElementById("tbody").innerHTML = trHTML;
    }
}