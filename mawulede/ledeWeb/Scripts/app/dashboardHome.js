//
var outputBooking = "";
var outputCustomers = "";
var outputMovie = "";



$(function () {
    //loadData();

    $.when(bookingAjax, customerAjax, houseAjax, movieAjax, houseAjax)
       .done(function (dataBooking, dataCustomer, dataHouse, dataMovie, dataHouse) {
           booking = dataBooking[2].responseJSON;
           Customers = dataCustomer[2].responseJSON;
           House = dataHouse[2].responseJSON;
           Movie = dataMovie[2].responseJSON;
           House = dataHouse[2].responseJSON;


           var HouseName = House[0].HouseName;
           console.log("val new", HouseName);
           $("#houseName").text(HouseName);



           for (var i = 0; i < Movie.length; i++) {
               outputMovie = outputMovie + "\
                    <div class='col-md-4 movieClass mag' id= '" + Movie[i].MovieId + "' >\
                        <img src="+ Movie[i].PosterUrl + " class='media-object' style='width:70px;height:90px'>\
                    </div>\
                    <div class='col-md-4 mag movieClass' style='margin-left:-240px'><h3>"+ Movie[i].Title + "</h3><p>" + Movie[i].Synopsis.substring(0, 100) + "</p>\
                </div>";

               $("#tab1primary").html(outputMovie);
           }




           $(".movieClass").click(function () {

               var hymn = $(this).attr("id");
               //console.log("tris", hymn);
               //alert('you clicked me!' + hymn);

               window.location = "/Movie/EditMovie/" + hymn;
           });


           for (var i = 0; i < booking.length; i++) {

               outputBooking = outputBooking + "<tr>\
                    <td>"+ booking[i].BookingNumber + "</a></td>\
                    <td>"+ booking[i].Title + "</td>\
                    <td>"+ booking[i].FullName + "</td>\
                    <td>"+ booking[i].BookingDate + "</td>\
                    <td>"+ booking[i].PaymentName + "</td>\
                    <td>"+ booking[i].Day + "</td>\
                    <td>"+ booking[i].Time + "</td>\
                    <td>"+ booking[i].Amount + "</td>\
                </td>\
                </tr>";

               $("#bookingDetails").html(outputBooking);
           }


           for (var i = 0; i < Customers.length; i++) {
               outputCustomers = outputCustomers + " <div class='user-block'>\
                    <img class='img-circle img-bordered-sm' src='Content/images/profile.jpg' />\
                    <span class='username'>\
                        <a href='#'>"+ Customers[i].FullName + "</a>\
                        </span>\
                    <span class='description'>Shared publicly - 7:30 PM today</span>\
                    </div>";

               $("#custDetails").html(outputCustomers);
           }
       });

    
});



var booking = {};
var Customers = {};
var House = {};
var Movie = {};
var House = {};

var bookingAjax = $.ajax({
    url: basrUrl + "Booking/GetAllBooking?houseId=" + HouseId,
    type: "Get"
});

var houseAjax = $.ajax({
    url: basrUrl + "House/GetOneHouseDetails?houseId=" + HouseId,
    type: "Get"
});

var customerAjax = $.ajax({
    url: basrUrl + "Customer/GetAllCustomers?houseId=" + HouseId,
    type: "Get"
});

var houseAjax = $.ajax({
    url: basrUrl + "House/GetAllHouses?houseId=" + HouseId,
    type: "Get"
});

var movieAjax = $.ajax({
    url: basrUrl + "Movie/GetAllMovie?houseId=" + HouseId,//http://localhost:55365/api/Movie/GetAllMovie?houseId=4
    type: "Get"
});



function loadData() {
   

}

    



