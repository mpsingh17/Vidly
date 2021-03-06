﻿$(document).ready(function () {
    var table = $("#customers").DataTable({
        ajax: {
            url: "/api/customers/",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, customer) {
                    return `<a href=/customers/edit/${customer.id}>${data}</a>`;
                }
            },
            {
                data: "membershipType.name"
            },
            {
                data: "id",
                render: function (data) {
                    return `<button data-customer-id="${data}" class="btn-link js-delete">Delete</button>`;
                }
            }
        ]
    });

    $("#customers").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this customer?", function (result) {
            if (result) {
                const userId = button.attr("data-customer-id");
                $.ajax({
                    url: `/api/customers/${userId}`,
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });
});