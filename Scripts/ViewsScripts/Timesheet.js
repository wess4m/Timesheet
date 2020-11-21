GetList = function () {
    $('#dataTable').DataTable({
        destroy: true,
        columns: [
            { 'data': 'EmployeeNumber' },
            { 'data': 'Name' },
            { 'data': 'Month' },
            {
                'render': function (WorkingHours,Id, full) {
                    if (full.WorkingHours > 8) {
                        return "<span style='background-color : green; color : white; padding :10px'>" + full.WorkingHours + "</span>"
                    }
                    else if (full.WorkingHours < 8) {
                        return "<span style='background-color : red; color : white; padding :10px'>" + full.WorkingHours + "</span>"
                    }
                    else {
                        return "<span style='padding :10px'>" + full.WorkingHours + "</span>"
                    }
                }
            }
        ],
        "ajax": {
            "url": "getlist/",
            "type": "POST",
            "dataSrc": function (response) {
                return response;
            }
        }
        //,
        //"createdRow": function (row, data) {
        //    if (data.IsDone) {
        //        $(row).css('background-color', 'limegreen');
        //    }
        //}
    });
};
$(document).ready(function () {
    GetList();
});
GetAddItem = function () {
    $.ajax({
        type: "Get",
        url: "/getadditem/",
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            debugger;
            $('.modal-body').html(data);
            $('#AddItem').modal('toggle');
        }
    });

}
GetImport = function () {
    $.ajax({
        type: "Get",
        url: "/getimport/",
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            debugger;
            $('.modal-body').html(data);
            $('#AddItem').modal('toggle');
        }
    });
}
