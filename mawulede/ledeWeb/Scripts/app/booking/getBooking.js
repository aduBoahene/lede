var booking = {};
var output = "";
$(function () {
   
    getBookingById(HouseId);
});


function getBookingById(id) {
    
    $.ajax({
        type: "GET",
        //url: Api_Root + "doc/GetDocById?docId=" + id,
        url: "http://localhost:55365/api/Booking/GetAllBooking?houseId=" + id,
        success: function (result) {
            console.log(result);
            booking = result;
            console.log("all bookings for House" + id, result);


            for (var i = 0; i < booking.length; i++){
                
                output = output + "<tr>\
                    <td> <a href=''>"+ booking[i].BookingId+"</a></td>\
                    <td>"+booking[i].Title+"</td>\
                    <td>"+ booking[i].FullName +"</td>\
                    <td>"+ booking[i].BookingDate +"</td>\
                    <td>"+ booking[i].PaymentName +"</td>\
                    <td>"+ booking[i].Day +"</td>\
                    <td>"+ booking[i].Time +"</td>\
                    <td>"+ booking[i].Amount +"</td>\
                </td>\
                </tr>";

                $("#bookingDetails").html(output);
            }

           
            

        }
    });
}

