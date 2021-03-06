﻿$(document).ready(function () {
    var table = $("#movies").DataTable({
        ajax: {
            url: "/api/movies/",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, movie) {
                    return `<a href="/movies/edit/${movie.id}">${data}</a>`;
                }
            },
            {
                data: "releaseDate",
                render: function (data) {
                    //return `${data.getMonth() + 1}/${data.getDate()}/${data.getFullYear()}`;
                    return data.substr(0, 10);
                }
            },
            {
                data: "stock"
            },
            {
                data: "genre.name"
            },
            {
                data: "id",
                render: function (data) {
                    return `<button data-movie-id="${data}" class="btn-link js-delete">Delete</button>`;
                }
            }
        ]
    });

    table.on("click", ".js-delete", function () {
        const button = $(this);

        bootbox.confirm("Are you sure you want to delete this movie?", function (result) {
            if (result) {
                const userId = button.attr("data-movie-id");
                $.ajax({
                    url: `/api/movies/${userId}`,
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });
});