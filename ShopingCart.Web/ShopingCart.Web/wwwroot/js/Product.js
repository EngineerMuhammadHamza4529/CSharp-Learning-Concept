var dtable;

$(document).ready(function () {

    dtable = $('#MyTable').DataTable({
        "ajax": { "url": "/Admin/Product/AllProducts" },
        "columns": [
            { "data": "name" },
            { "data": 'description' },
            { "data": "price" },
            { "data": "category.name" },

            {
                "data": "id",
                //"render": function (data, type, row, meta) {
                //    return
                //    '< a href = "/Admin/Product/CreateUpdate?id=' + data + '" > <i class="bi bi-pencil-square"></i></a>';
                //        //<a onclick=RemoveProduct("/Admin/Product/Delete/${data}")><i class="bi bi-trash"></i></a>';
                //}
                    "render": function (data, type, row, meta) {
                        return '<a href="/Admin/Product/CreateUpdate?id=' + data + '"><i class="bi bi-pencil-square"></i></a> <a onclick=RemoveProduct("/Admin/Product/Delete/'+data+'")><i class="bi bi-trash"></i></a>';
                }

            }

        ]

    });

});

function RemoveProduct(url) {
    Swal.fire({
        title: 'Area you sure?',
        text: "You Want to able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, Delete It!'
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {

                        dtable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {

                        toastr.error(data.message);
                    }
                }


            });
        }
    })
}