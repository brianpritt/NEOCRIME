$(document).ready(function () {

    var myChart;
    function Data() {
        this.datasets = [];
    }
    function Coords(x, y, r) {
        this.x = x;
        this.y = y;
        this.r = r;
    }
    function Dataset(label) {
        this.label = label;
        this.data = [];
    }

    $("#dateSubmit").submit(function (event) {
        event.preventDefault();

        var data = new Data();

        console.log($(this).serialize());
        $.ajax({
            url: "/Home/getNeo/",
            type: "POST",
            data: $(this).serialize(),
            datatype: 'json',
            success: function (result) {
                var htmlResult = "";
                for (var i = 0; i < result.length; i++) {
                    htmlResult += "<div class='panel panel-default " + result[i].is_potentially_hazardous_asteroid + "'><div class='panel-heading'><h4>Name: " + result[i].name + "</h4></div><div class='panel-body'><p>Is potentially hazardous: " + result[i].is_potentially_hazardous_asteroid + "<p>Missed us by only: " + result[i].close_approach_data[0].miss_distance.miles + " miles.</p></div></div>";

                    data.datasets.push(new Dataset(result[i].name));
                    data.datasets[i].data.push(
                        new Coords(
                            result[i].close_approach_data[0].miss_distance.miles,
                            result[i].close_approach_data[0].miss_distance.miles,
                            result[i].estimated_diameter.feet.estimated_diameter_max / 100
                        ));
                }
                var ctx = document.getElementById("myChart");
                var myChart = new Chart(ctx, {
                    type: 'bubble',
                    data: data,
                    options: {
                        scales: {
                            yAxes: [{
                                ticks: {
                                    beginAtZero: true
                                }
                            }],
                            xAxes: [{
                                ticks: {
                                    beginAtZero: true
                                }
                            }]
                        }
                    }
                });
                $("#neoResult").html(htmlResult);
            }
        }).error(function () { alert("NO!"); });
    });
});