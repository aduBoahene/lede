var Movie = {};

$(function () {
    getMovieById(HouseId, MovieId);
});


function getMovieById(houseId,movieId) {


    $.ajax({
        type: "GET",
        //url: Api_Root + "doc/GetDocById?docId=" + id,
        url: "http://localhost:27036/api/Movie/GetMovieById?houseId=" + houseId + "&MovieId=" + movieId,
        success: function (result) {
            console.log(result);
            Movie = result;

            console.log("Movie to be edited", Movie);

            $("#title").val(Movie[0].Title);
            $("#genre").val(Movie[0].GenreName);
            $("#synopsis").val(Movie[0].Synopsis);
            $("#posterUrl").val(Movie[0].PosterUrl);
            $("#trailerUrl").val(Movie[0].TrailerUrl);
            $("#amount").val(Movie[0].Amount);
            $("#date").val(Movie[0].ReleaseDate);

        }
    });
}