$(document).ready(function () {
    $('#Save').click(function (e) {
        //function clickbtn(e) {
        debugger;
        e.preventDefault();

        var productCategoryName = $('#ProductCategoryName').val();
        var flag = $('#Flag').val();
        var productCategoryId = $('#ProductCategoryId').val();

        if (productCategoryName == "") {
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

        if (flag == "U") { //update
            type = "PATCH";
            confirmMessage = "Are you sure you want to update this category";
        }

        var con = confirm(confirmMessage);
        if (con) {

            //building product category object


            debugger;
            $.ajax({
                url: "/ProductCategory/ProductCategories?handler=AddProductCategory",
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
});