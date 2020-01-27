// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#responsetable').DataTable({
        "pageLength": 3,
        "processing": true,
        "bSearchable": true,
        "bFilter": true,
        "ajax": "/GuestCRUD/GetJsonData",
        "columnDefs": [{
            "orderable": false,
            "targets": 4,
            "render": function (data, type, row) {
                return `<button type="submit" class="btn btn-info btn-sm" onclick="window.location.href='/GuestCRUD/EditGuest/${data}'" value='${data}'><i class="fas fa-edit"></i></button>

                        <button type="submit" class="btn btn-danger btn-sm show-bs-modal" onclick="window.location.href='/GuestCRUD/DeleteGuest/${data}'" data-id='${data}' value='${data}'> <i class="fas fa-trash"></i></button>`;
            }
        }]

    });
});

//$("#listresponses .pagination .page-item").click(function () {
//    var pagenum = $(this).text();
//    console.log(pagenum);

//    var datapack = {
//        "pagenumber": pagenum
//    };
//    //listresponses_table
//    var request;
//     //Abort any pending request
//    if (request) {
//        request.abort();
//    }

//    request = $.ajax({
//        url: "/Paginate/",
//        type: "POST",
//        beforeSend: function (xhr) {
//            xhr.setRequestHeader("XSRF-TOKEN",
//                $('input:hidden[name="__RequestVerificationToken"]').val());
//        },
//        data: pagenum,
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//    });

//    request.done(function (response) {
//        console.log(response);
//        $('#responsesmessage').html(response);
//    });

//    request.fail(function (jqXHR, textStatus, errorThrown) {
//        console.error(
//            "Error: " + textStatus
//        );
//    });
//});

//$("#listpage_searchform").submit(function () {
//    var jqxhr = $.post('ListResponses', $('#searchbox').val())
//        .success(function () {
//            var loc = jqxhr.getResponseHeader('Location');
//        })
//        .error(function () {
//            $('#searchmessage').html("Error posting the update.");
//        });
//    return false;
//});

////Request functions
//function GetRequest(urlstring) {

//    return $.ajax({
//        type: "GET",
//        url: urlstring,
//        contentType: "application/json; charset=utf-8",
//        dataType: "json"
//        /*,
//         contentLength: 12,
//         data: {},
//        success: function (data) {
//            //alert(JSON.stringify(data));
            
//            //console.log(data);
//            var result = JSON.stringify(data);
//            alert(result);
//            return result;
//        }, //End of AJAX Success function  

//        failure: function (data) {
//            return data.responseText;
//        }, //End of AJAX failure function  
//        error: function (data) {
//            return data.responseText;
//        } //End of AJAX error function  
//        */
//    });
//}

//var htmltr;
////Function caller
//var value = 0, apiresult = "", flag = 0;
//$(".table tr").click(function () {
//    value = $(this).find('td:first').html();
//    alert(value);
//    if (value > 0 && flag == 0) {
//        $(this).addClass("selected");
//        var urlstr = "/GuestCRUD/GetGuest/" + value;

//        $.when(GetRequest(urlstr)).then(
//            function (data) {
//                apiresult = data;

//                //console.log(apiresult);
//                htmltr = $(".selected").html();

//                flag = 1;

//                var replacetxt = "<tr class=" + "selected" + "><td><input " + " name = " + "id" + " value=" + apiresult["id"] + " disabled /></td>" +
//                    "<td><input type=" + " text" + " name = " + "name" + " value=" + apiresult["name"] + " /></td>" +
//                    "<td><input type=" + " email" + " name = " + "email" + " value=" + apiresult["email"] + " /></td>" +
//                    "<td><input type=" + " tel" + " name = " + "phone" + " value=" + apiresult["phone"] + " /></td>" +
//                    "<td><input name = " + "giftid" + " value=" + apiresult["giftId"] + " disabled/></td>" +
//                    "<td ><a class="+ "btn-edit" +"> ✅ </a></td></tr>";

//                //console.log(htmltr);
//                $(".table tr.selected").replaceWith(replacetxt);
//            }
//        );
//    }
//    else {
//        $(".table .selected").replaceWith("<tr>" + htmltr + "</tr>");
//        flag = 0;
//    }
//});
