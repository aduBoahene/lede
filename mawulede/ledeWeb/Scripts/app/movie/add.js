$(function () {
    getAllGenre();
});

Genre = {};

function getAllGenre() {

    alert("hello");

    $.ajax({
        type: "GET",
        url: "http://localhost:27036/api/Genre/GetAllGenre",
        success: function (result) {
            Genre = result;

            console.log("ALl Genre", Genre);

            var outputGenre = "";

            for (var a = 0; Genre < length; a++) {
                outputGenre = outputGenre + "\
                     <option value=''>" + Genre[a].GenreName + "</option>";
                $("#genre").html(outputGenre);
            }

        }
    });
}