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
}