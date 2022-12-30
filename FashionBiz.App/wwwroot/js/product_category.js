$(document).ready(function () {
    $('#Save').click(function (e) {
        //function clickbtn(e) {
        debugger;
        e.preventDefault();

        var productCategoryName = $('#ProductCategoryName').val();
        var flag = $('#Flag').val();
        var productCategoryId = $('#ProductCategoryId').val();

        if (productCategoryName === "") {
            alert("Please enter product category");
            $('#ProductCategoryName').focus();
            return;
        }

        var productCategory = {};
        productCategory.ProductCategoryName = productCategoryName;
        if (productCategoryId !== "" && productCategoryId !== null)
            productCategory.ProductCategoryID = Number(productCategoryId);
        productCategory.Flag = flag;

        var type = "POST" //add
        //var url = '../../api/ProductCategory/AddProductCategory'; //add
        var confirmMessage = "Are you sure you want to add this category";

        if (flag === "U") { //update
          //  type = "PATCH";
            confirmMessage = "Are you sure you want to update this category";
        }

        var con = confirm(confirmMessage);
        if (con) {

            //building product category object


            debugger;
            $.ajax({
                url: "/ProductCategory/ProductCategories?handler=ManageProductCategory",
                type: type,
                contentType: 'application/json',
                data: JSON.stringify(productCategory),
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("X-XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },
                success: function () {
                    alert("success");
                    location.reload();
                },
                complete: function () {
                    alert("complete")
                },
                failure: function () {
                    alert("failure");
                }
            });
        }

    })
    $('.editCategory').click(function (e) {
        debugger;
        var id = $(this).attr('id');
        if (id == 'Edit') {
            e.preventDefault();
            e.stopPropagation();
            var ProductCategoryID = $(this).attr("href");
        }
        $.ajax({
            url: "/ProductCategory/ProductCategories?handler=RetrieveProductCategoryById",
            cache: false,
            type: 'GET',
            contentType: 'application/json',
            data: {
                id: Number(ProductCategoryID)
            },
            beforeSend: function (xhr) {
                xhr.setRequestHeader("X-XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            success: successFunc,
            error: errorFunc
        });

        function successFunc(response) {
            debugger;
            console.log(response);
            if (response !== null) {
                $('#ProductCategoryName').val(response.productCategoryName);
                $('#Flag').val("U");
                $('#Save').val("Update");
                $('#ProductCategoryId').val(response.productCategoryId);
            }
        }

        function errorFunc(error) {
            console.log(error);
        }
    })

});