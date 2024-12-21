var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'title', "width": "13%" },
            { data: 'description', "width": "20%" },
            { data: 'isbn', "width": "10%" },
            { data: 'listPrice', "width": "7%" },
            { data: 'author', "width": "12%" },
            { data: 'category.name', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>               
                     <a onClick=Delete('/admin/product/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
                },
                "width": "28%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Bạn chắc chắn chứ?',
        text: "Bạn sẽ không thể hoàn tác hành động này",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Đồng ý xóa'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data && data.success) {
                        // Làm mới bảng dữ liệu
                        dataTable.ajax.reload();

                        // Hiển thị thông báo thành công
                        toastr.success(data.message || "Xóa thành công");
                    } else {
                        // Hiển thị lỗi nếu phản hồi không như mong đợi
                        toastr.error(data.message || "Đã xảy ra lỗi trong quá trình xóa");
                    }
                },
                error: function (xhr) {
                    // Xử lý khi xảy ra lỗi từ server (HTTP 4xx hoặc 5xx)
                    toastr.error("Không thể xóa. Đã xảy ra lỗi từ máy chủ.");
                }
            });
        }
    });
}
