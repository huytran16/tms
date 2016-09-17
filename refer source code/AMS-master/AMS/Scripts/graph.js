﻿//google.charts.load('current', { packages: ['corechart', 'line'] });
//google.charts.setOnLoadCallback(drawCrosshairs);

//function drawCrosshairs() {
//    var data = new google.visualization.DataTable();
//    data.addColumn('number', 'X');
//    data.addColumn('number', 'Dogs');
//    data.addColumn('number', 'Cats');

//    data.addRows([
//      [0, 0, 0], [1, 10, 5], [2, 23, 15], [3, 17, 9], [4, 18, 10], [5, 9, 5],
//      [6, 11, 3], [7, 27, 19], [8, 33, 25], [9, 40, 32], [10, 32, 24], [11, 35, 27],
//      [12, 30, 22], [13, 40, 32], [14, 42, 34], [15, 47, 39], [16, 44, 36], [17, 48, 40],
//      [18, 52, 44], [19, 54, 46], [20, 42, 34], [21, 55, 47], [22, 56, 48], [23, 57, 49],
//      [24, 60, 52], [25, 50, 42], [26, 52, 44], [27, 51, 43], [28, 49, 41], [29, 53, 45],
//      [30, 55, 47], [31, 60, 52], [32, 61, 53], [33, 59, 51], [34, 62, 54], [35, 65, 57],
//      [36, 62, 54], [37, 58, 50], [38, 55, 47], [39, 61, 53], [40, 64, 56], [41, 65, 57],
//      [42, 63, 55], [43, 66, 58], [44, 67, 59], [45, 69, 61], [46, 69, 61], [47, 70, 62],
//      [48, 72, 64], [49, 68, 60], [50, 66, 58], [51, 65, 57], [52, 67, 59], [53, 70, 62],
//      [54, 71, 63], [55, 72, 64], [56, 73, 65], [57, 75, 67], [58, 70, 62], [59, 68, 60],
//      [60, 64, 56], [61, 60, 52], [62, 65, 57], [63, 67, 59], [64, 68, 60], [65, 69, 61],
//      [66, 70, 62], [67, 72, 64], [68, 75, 67], [69, 80, 72]
//    ]);

//    var options = {
//        hAxis: {
//            title: 'Time'
//        },
//        vAxis: {
//            title: 'Popularity'
//        },
//        colors: ['#a52714', '#097138'],
//        crosshair: {
//            color: '#000',
//            trigger: 'selection'
//        }
//    };

//    var chart = new google.visualization.LineChart(document.getElementById('chart_div'));

//    chart.draw(data, options);
//    chart.setSelection([{ row: 38, column: 1 }]);

//}
google.charts.load('current', { 'packages': ['line'] });
google.charts.setOnLoadCallback(drawChart);

function drawChart() {

    var data = new google.visualization.DataTable();
    data.addColumn('number', 'Tháng');
    data.addColumn('number', 'Tiền điện');
    data.addColumn('number', 'Tiền nước');
    data.addColumn('number', 'Tiền khác');

    data.addRows([
      [1, 37.8, 80.8, 41.8],
      [2, 30.9, 69.5, 32.4],
      [3, 25.4, 57, 25.7],
      [4, 11.7, 18.8, 10.5],
      [5, 11.9, 17.6, 10.4],
      [6, 8.8, 13.6, 7.7],
      [7, 7.6, 12.3, 9.6],
      [8, 12.3, 29.2, 10.6],
      [9, 16.9, 42.9, 14.8],
      [10, 12.8, 30.9, 11.6],
      [11, 5.3, 7.9, 4.7],
      [12, 6.6, 8.4, 5.2],
      [13, 4.8, 6.3, 3.6],
      [14, 4.2, 6.2, 3.4]
    ]);

    var options = {
        chart: {
            title: 'Biểu đồ chi tiêu',
            subtitle: 'nghìn đô'
        },
        width: 900,
        height:500
    };

    var chart = new google.charts.Line(document.getElementById('chart_div'));

    chart.draw(data, options);
}