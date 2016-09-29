$(function () {
    // Declare a proxy to reference the hub.
    var chart = $.connection.chart;

    //chart.client.value = function (message) {
                
    //    var encodedMsg = $('<div />').text(message).html();
    //    // Add the message to the page.
    //    $('#discussion').append(encodedMsg);
    //};
        
    // Start the connection.
    $.connection.hub.start().done(function () {            
            chart.server.send(0);        
    });

    createGauge();

    chart.client.value = function (message) {
        console.log(message);
        $("#gauge").data("kendoRadialGauge").value(Number(message));
    };

    $(document).bind("kendo:skinChange", function (e) {
        createGauge();
    });
});

function createGauge() {
    $("#gauge").kendoRadialGauge({

        pointer: {
            value: 0
        },

        scale: {
            minorUnit: 2,
            startAngle: -30,
            endAngle: 210,
            max: 400
        }
    });
}

