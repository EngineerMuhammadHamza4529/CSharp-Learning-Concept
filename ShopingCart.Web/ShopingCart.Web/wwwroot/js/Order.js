//var dtable;
//$(document).ready(function () {

//    var url = window.location.search;
//    if (url.includes("pending")) {
//        OrderTable("pending");
//    }
//    else {
//        if (url.includes("approved")) {
//            OrderTable("approved");
//        }
//        else {
//            if (url.includes("shipped")) {
//                OrderTable("shipped");
//            }

//            else {
//                if (url.includes("underprocess")) {
//                    OrderTable("underprocess");
//                }

//                else {
//                    if (url.includes("underprocess")) {
//                        OrderTable("underprocess");
//                    }
//                    else {
//                        OrderTable("all");
//                    }

//                }
//            }
//        }
//    });

//function OrderTable(status) {
//    dtable = $('#myTable').DataTable({
//        "ajax": { "url": "/Admin/Order/AllOrders?status" + status },
//        "columns": [
//            { "data": "name" },
//            { "data": "phone" },
//            { "data": "orderStatus" },
//            { "data": "orderTotal" },
//            {
//                "data": "id",
//                "render": function (data) {
//                    return `<a href="/Admin/order/OrderDetails?id=${data}"><i class="bi bi-pencil-square"></i></a>`;
//                }
//            }
//        ]
//    });
//}



var dtable;

$(document).ready(function () {

    dtable = $('#MyTable').DataTable({
        "ajax": { "url": "/Admin/order/AllOrders?" + status },
        "columns": [
            { "data": "name" },
            { "data": 'description' },
            { "data": "price" },
            { "data": "category.name" },

            {
                "data": "id",
                //"render": function (data, type, row, meta) {
                //    return
                //    '< a href = "/Admin/order/OrderDetails?id=' + data + '" > <i class="bi bi-pencil-square"></i></a>';
                //        //<a onclick=RemoveProduct("/Admin/Product/Delete/${data}")><i class="bi bi-trash"></i></a>';
                //}
                "render": function (data, type, row, meta) {
                    return '<a href="/Admin/order/OrderDetails?id=' + data + '"><i class="bi bi-pencil-square"></i></a> <a onclick=RemoveProduct("/Admin/Product/Delete/' + data + '")><i class="bi bi-trash"></i></a>';
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