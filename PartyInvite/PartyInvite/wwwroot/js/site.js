// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Request functions
function GetRequest(urlstring) {

    return $.ajax({
        type: "GET",
        url: urlstring,
        contentType: "application/json; charset=utf-8",
        dataType: "json"
        /*,
         contentLength: 12,
         data: {},
        success: function (data) {
            //alert(JSON.stringify(data));
            
            //console.log(data);
            var result = JSON.stringify(data);
            alert(result);
            return result;
        }, //End of AJAX Success function  

        failure: function (data) {
            return data.responseText;
        }, //End of AJAX failure function  
        error: function (data) {
            return data.responseText;
        } //End of AJAX error function  
        */
    });
}

var htmltr;
//Function caller
var value = 0, apiresult = "", flag = 0;
$(".table tr").click(function () {
    value = $(this).find('td:first').html();
    alert(value);
    if (value > 0 && flag == 0) {
        $(this).addClass("selected");
        var urlstr = "/GuestCRUD/GetGuest/" + value;

        $.when(GetRequest(urlstr)).then(
            function (data) {
                apiresult = data;

                //console.log(apiresult);
                htmltr = $(".selected").html();

                flag = 1;

                var replacetxt = "<tr class=" + "selected" + "><td><input " + " name = " + "id" + " value=" + apiresult["id"] + " disabled /></td>" +
                    "<td><input type=" + " text" + " name = " + "name" + " value=" + apiresult["name"] + " /></td>" +
                    "<td><input type=" + " email" + " name = " + "email" + " value=" + apiresult["email"] + " /></td>" +
                    "<td><input type=" + " tel" + " name = " + "phone" + " value=" + apiresult["phone"] + " /></td>" +
                    "<td><input name = " + "giftid" + " value=" + apiresult["giftId"] + " disabled/></td>" +
                    "<td ><a class="+ "btn-edit" +"> ✅ </a></td></tr>";

                //console.log(htmltr);
                $(".table tr.selected").replaceWith(replacetxt);
            }
        );
    }
    else {
        $(".table .selected").replaceWith("<tr>" + htmltr + "</tr>");
        flag = 0;
    }
});
