$(document).ready(function () {
    //load dữ liệu:
    r = new Role();
})
class Role {
    constructor() {
        try {
            var me = this;
            me.LoadData()
            //me.initEvent();
            //me.FormMode = null;
            //$("#frmDialogDetail").show();
        } catch (e) {

        }
    }
    LoadData() {
        //try {
        //    $('tbody').empty();
        //        debugger;
        //    $.ajax({
        //        url: "/api/Role",
        //        method: "GET",
        //        data: {},
        //        dataType: "json",
        //        contentType: "application/json",
        //    }).done(function (response) {
        //        if (response) {
        //             Đọc dữ liệu và gen dữ liệu từng khách hàng với HTML:
        //            $.each(response, function (index, item) {
        //                var customerInfoHTML = $(`<tr>
        //                        <td>`+ item.RoleID + `</td>
        //                        <td>`+ item.RoleName + `</td>
        //                    </tr>`);
        //                customerInfoHTML.data("id", item['RoleID']);
        //                $('tbody').append(customerInfoHTML);
        //            })
        //             Mặc định chọn bản ghi đầu tiên có trong danh sách:
        //            $('tbody tr').first().addClass('row-selected');
        //        }
        //        alert('Có lỗi xảy ra')
        //    }).fail(function (response) {
        //        debugger;
        //        alert("Có lỗi xảy ra trong lúc debug");
        //    })

        //} catch (e) {
        //    console.log(e);
        //}

        //Code test
        $.ajax({

            url: "http://localhost/shopmoji/api/Role",
            type: "GET",
            dataType: 'json',
            
            success: function (result) {
                debugger;
                $("tbody").empty();
                $.each(result, function (index, item) {
                    var dataRow = '<tr>' +
                        '<td>' + item.RoleID + '</td>' +
                        '<td>' + item.RoleName+'</td>'
                    '</tr>';
                    $("tbody").append(dataRow);
                });
                console.log(result);
            },
            fail: function () {
                debugger;
                alert("Có lỗi xảy ra");
            }
        });

        //$('tbody').empty();
        //$.each(ds, function (index, item) {
        //    var trHTML = $(`<tr>'>
        //                    <td>`+ item['RoleID'] + `</td>
        //                    <td>`+ item['RoleName'] + `</td>
        //                </tr>`);
        //    trHTML.data("id", item['RoleID']);
        //    $('tbody').append(trHTML);
        //})
    }
}
var ds = [
    {
        "RoleID": 1,
        "RoleName": "CATEGORY",
        "PERMISIONs": []
    },
    {
        "RoleID": 2,
        "RoleName": "STORE",
        "PERMISIONs": []
    },
    {
        "RoleID": 3,
        "RoleName": "MEMBERSHIP",
        "PERMISIONs": []
    },
    {
        "RoleID": 4,
        "RoleName": "CUSTOMER",
        "PERMISIONs": []
    },
    {
        "RoleID": 5,
        "RoleName": "VOUCHER",
        "PERMISIONs": []
    },
    {
        "RoleID": 6,
        "RoleName": "ROLES",
        "PERMISIONs": []
    },
    {
        "RoleID": 7,
        "RoleName": "PRODUCT",
        "PERMISIONs": []
    },
    {
        "RoleID": 8,
        "RoleName": "EMPLOYEE",
        "PERMISIONs": []
    },
    {
        "RoleID": 9,
        "RoleName": "GROUPADMIN",
        "PERMISIONs": []
    },
    {
        "RoleID": 10,
        "RoleName": "BILL",
        "PERMISIONs": []
    },
    {
        "RoleID": 11,
        "RoleName": "NEWS",
        "PERMISIONs": []
    },
    {
        "RoleID": 12,
        "RoleName": "BILLINFO",
        "PERMISIONs": []
    },
    {
        "RoleID": 13,
        "RoleName": "PERMISION",
        "PERMISIONs": []
    }
]