$(document).ready(function () {

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }



    $(document).on("click", ".book-modal", function (e) {

        e.preventDefault()

        // get object from constroller
        //set values by dom

        //var id = $(this).data("id");
        //console.log("book id=" + id);

        var url = $(this).attr("href")
        console.log(url)

        fetch(url)
            .then(response => response.text())
            .then(data => {
                console.log(data)
                $("#quickModal .modal-dialog").html(data)
            })

        //fetch(url)
        //    .then(response => response.json())
        //    .then(data => {
        //        console.log(data)

        //        $("#quickModal .product-title").text(data.name)
        //        $("#quickModal .book-genre").text(data.category.name)
        //        $("#quickModal .book-code").text(data.code)

        //        var stockText = data.isAvailable == true ? "In Stock" : "Out Stock";
        //        $("#quickModal .book-stock-status").text(stockText)

        //        if (data.discountPercent > 0) {
        //            var priceHtml = `<span class="price-new">£` + data.dicountedPrice + `</span>
        //                              <del class="price-old">£`+ data.price + `</del>`
        //        }
        //        else {
        //            var priceHtml = `<span class="price-new">£` + data.price + `</span>`
        //        }
        //        $("#quickModal .book-price").html(priceHtml)
        //        $("#quickModal .book-poster").attr("src","image/products/"+data.bookImages[0].name)
        //    })

        $("#quickModal").modal("show")
    })

    $(document).on("click", ".add-basket", function (e) {
        e.preventDefault();

        var url = $(this).attr("href");
        fetch(url)
            .then(response => response.json())
            .then(data => {
                if (data.isSucceeded == false) {
                    toastr.error('Xeta var qaqa!')
                }
                else {
                    toastr.success('Məhsul səbətə əlavə edildi!')
                    $(".basket-count").text(data.totalCount);
                    $(".basket-price").text("£" + data.totalPrice);
                }
            });
    })

    $(document).on("click", ".load-comments", function (e) {
        e.preventDefault();

        var nextPage = $(this).attr("data-nextpage");
        console.log(nextPage)
        var url = $(this).attr("href") + "?page=" + nextPage;

        console.log(url);
        fetch(url)
            .then(response => response.text())
            .then(data => {
                $(".comments").append(data)
            });

        var totalPage = +$(this).data("totalpage");
        nextPage = +nextPage + 1;

        if (nextPage > totalPage) {
            $(this).remove();
        }
        $(this).attr("data-nextpage", nextPage)
    })

    $(document).on("click", ".show-basket", function (e) {

        if ($(".cart-dropdown-block").css('opacity') == 1) {
            $(".cart-dropdown-block").css('opacity', '0');
        }
        else {
            $(".cart-dropdown-block").css('opacity', '1');
        }


        fetch("/book/loadbasket")
            .then(response => response.text())
            .then(data => {
                $(".basket-items").html(data)
            });
    })

})
