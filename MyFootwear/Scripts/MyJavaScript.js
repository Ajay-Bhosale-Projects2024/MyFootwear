function FetchCart() {    
    $.ajax({
        url: "/Home/Cart1",
        type: "GET",
        success: function (data) {
            $("#MyCartItem tbody").empty();
            $.each(data, function (index, record) {                
                $("#MyCartItem tbody").append("<tr><td>" + record.ProductName + "</td><td>" + record.Price + "</td><td>" + record.Image + "</td><td>" + record.CustomerId + "</td><td><input type='submit' value='Remove' onclick='Delete(" + record.CartId + ") '></td> </tr>");                
            });
        },
        error: function (error) {
            alert("Got Error");
        }
    });

    
}



function mycart(ProudctId) {
    $.ajax({
        url: "/Home/Cart?ProudctId=" + ProudctId,
        type: "POST",
        success: function (data) {

          alert("Has been added in Cart Checkout");
          FetchCart();
          console.log(data);                 
        },
        error: function () {
            alert("Got Error...");
        }
    });
};

function Delete(CartId) {
    $.ajax({
        url: "/Home/Delete?CartId=" + CartId,
        type: "POST",
        success: function (data) {
            console.log(data);
            FetchCart();                      
        },
        error: function (error) {
            alert("Error Got");
        }
    })
}

