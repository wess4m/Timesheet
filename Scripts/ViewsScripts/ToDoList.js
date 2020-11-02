GetList = function () {
    $('#dataTable').DataTable({
        destroy: true,
        columns: [
            { 'data': 'Id' },
            { 'data': 'TodoTitle' },
            {
                'render': function (IsDone, Id, full) {
                    if (full.IsDone) {
                        return "<a href='JavaScript:Void(0);' onclick='Delete(" + full.Id + ");'>Delete</a>"
                    }
                    return "<a href='JavaScript:Void(0);' onclick='GetUpdateItem(" + full.Id + ");'>Edit</a> | <a href='JavaScript:Void(0);' onclick='Delete(" + full.Id + ");'>Delete</a> | <a href='JavaScript:Void(0);' onclick='MarkDone(" + full.Id + ");'>Mark Done</a>";
                }
            }
        ],
        bServerSide: true,
        sAjaxSource: 'Data/Handlers/ToDoListHandler.ashx',
        "createdRow": function (row, data) {
            if (data.IsDone) {
                $(row).css('background-color', 'limegreen');
            }
        }
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
AddItem = function () {
    $.ajax({
        type: "POST",
        url: "/additem/",
        data: JSON.stringify({ "TodoTitle": $('#txtTodoTitle').val(), "DueDate": $('#txtDueDate').val() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            GetList();
            $('#AddItem').modal('toggle');
        }
    });
};
GetUpdateItem = function (Id) {
    $.ajax({
        type: "Get",
        url: "/getupdateitem/" + Id,
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            debugger;
            $('.modal-body').html(data);
            $('#AddItem').modal('toggle');
        }
    });
};
UpdateItem = function () {
    $.ajax({
        type: "POST",
        url: "/updateitem/",
        data: JSON.stringify({ "TodoTitle": $('#txtTodoTitle').val(), "DueDate": $('#txtDueDate').val(), "Id": $('#hdId').val()}),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            GetList();
            $('#AddItem').modal('toggle');
        }
    });
};
MarkDone = function (Id) {
    $.ajax({
        type: "POST",
        url: "/markdone/",
        data: JSON.stringify({ "Id": Id }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            GetList();
        }
    });
};
Delete = function (Id) {
    if (confirm('Are you sure you want to delete this item?')) {
        $.ajax({
            type: "POST",
            url: "/delete/",
            data: JSON.stringify({ "Id": Id }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                GetList();
            }
        });
    }
}