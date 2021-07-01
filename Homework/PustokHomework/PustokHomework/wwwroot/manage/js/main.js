$(document).ready(function () {


    $(document).on("click", ".delete-btn", function (e) {

        console.log("testing")
        e.preventDefault();

        var url = $(this).attr("href")

        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                console.log(url)
                fetch(url)
                    .then(response => response.json())
                    .then(data => console.log(data));
                location.reload(true);
                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )
            }


        })
    })
})