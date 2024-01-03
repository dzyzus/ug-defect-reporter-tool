function createPieChart(canvasId, labels, data) {
    var ctx = document.getElementById(canvasId).getContext('2d');
    
    var myPieChart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: ['red', 'green']
            }]
        }
    });
};

function createPieChartFourColors(canvasId, labels, data) {
    var ctx = document.getElementById(canvasId).getContext('2d');

    var myPieChart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: ['#8A2BE2', '#48D1CC', '#32CD32', '#A52A2A']
            }]
        }
    });
};

function createBarChart(canvasId, labels, data) {
    var canvas = document.getElementById(canvasId);

    if (canvas) {
        var ctx = canvas.getContext('2d');

        var barChartOptions = {
            type: 'bar',
            data: {
                labels: labels,
                datasets: [{
                    label: 'Frequency of defects',
                    data: data,
                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                    borderColor: 'rgba(75, 192, 192, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                scales: {
                    x: {
                        type: 'time',
                        time: {
                            unit: 'day',
                            parser: 'YYYY-MM-DD',
                            tooltipFormat: 'll',
                            displayFormats: {
                                day: 'YYYY-MM-DD'
                            }
                        }
                    },
                    y: {
                        beginAtZero: true,
                        stepSize: 1
                    }
                }
            }
        };

        var barChart = new Chart(ctx, barChartOptions);
    } else {
        console.error("Canvas element with id '" + canvasId + "' not found.");
    }
}