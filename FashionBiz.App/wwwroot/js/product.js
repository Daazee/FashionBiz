$(document).ready(function () {
    $('#Save').click(function (e) {
        debugger;
        e.preventDefault();

        var productCategoryId = $('#ProductCategoryId').val();
        var productName = $('#ProductName').val();
        var costPrice = $('#CostPrice').val();
        var sellingPrice = $('#SellingPrice').val();
        var productDetailId = $('#ProductDetailId').val();
        var reorderLevel = $('#ReorderLevel').val();
        var stockLevel = $('#StockLevel').val();
        var flag = $('#Flag').val();

        if (productCategoryId === "") {
            alert("Please select product category");
            $('#ProductCategoryId').focus();
            return;
        }
        else if (productName === "") {
            alert("Please enter product name");
            $('#ProductName').focus();
            return;
        }
        /*
                else if (costPrice === "") {
                    alert("Please enter product cost price");
                    $('#CostPrice').focus();
                    return;
                }
                else if (costPrice !== "" && !$.isNumeric(costPrice)) {
                    alert("Cost Price must be numeric");
                    $('#CostPrice').focus();
                    return;
                }
                else if (sellingPrice === "") {
                    alert("Please enter product selling price");
                    $('#SellingPrice').focus();
                    return;
                }
                else if (sellingPrice !== "" && !$.isNumeric(sellingPrice)) {
                    alert("Selling Price must be numeric");
                    $('#SellingPrice').focus();
                    return;
                }
        
                else if (reorderLevel === "") {
                    alert("Please enter product reorder level");
                    $('#ReorderLevel').focus();
                    return;
                }
                else if (reorderLevel !== "" && !$.isNumeric(reorderLevel)) {
                    alert("Reorder Level must be numeric");
                    $('#ReorderLevel').focus();
                    return;
                }
        
                else if (stockLevel === "") {
                    alert("Please enter product stock level");
                    $('#ReorderLevel').focus();
                    return;
                }
                else if (stockLevel !== "" && !$.isNumeric(stockLevel)) {
                    alert("Stock Level Level must be numeric");
                    $('#ReorderLevel').focus();
                    return;
                }
                */

        var type = "POST";
        var confirmMessage = "Are you sure you want to add this product";

        if (flag === "U") { //update
            //  type = "PATCH";
            confirmMessage = "Are you sure you want to update this category";
        }


        var productDetail = {};
        productDetail.ProductCategoryId = productCategoryId;
        productDetail.ProductName = productName;
        productDetail.CostPrice = costPrice;
        productDetail.SellingPrice = sellingPrice;
        productDetail.ProductDetailId = Number(productDetailId);
        productDetail.Flag = flag;
        productDetail.ReorderLevel = reorderLevel;
        productDetail.StockLevel = stockLevel;

        var con = confirm(confirmMessage);
        if (con) {
            debugger;
            $.ajax({
                url: "/Product/Products?handler=ManageProduct",
                type: type,
                contentType: 'application/json',
                data: JSON.stringify(productDetail),
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
    $('.editProduct').click(function (e) {
        debugger;
        var id = $(this).attr('id');
        if (id == 'Edit') {
            e.preventDefault();
            e.stopPropagation();
            var ProductDetailId = $(this).attr("href");
        }
        $.ajax({
            url: "/Product/Products?handler=RetrieveProductById",
            cache: false,
            type: 'GET',
            contentType: 'application/json',
            data: {
                id: Number(ProductCategoryId)
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