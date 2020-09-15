function Inicializar_Grafico(dataSeries, dataDrilldown) {
    Highcharts.chart('graphic-container', {
        chart: {
            type: 'pie',
            options3d: {
                enabled: true,
                alpha: 45,
                beta: 0
            }
        },
        title: {
            text: 'Gráfico resumen del reporte.'
        },
        subtitle: {
            text: 'Haga click en una sección para ver más detalles de la misma.'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                depth: 35,
                dataLabels: {
                    enabled: true,
                    format: '{point.name}'
                }
            },
            series: {
                dataLabels: {
                    enabled: true,
                    format: '{point.name}: {point.y}'
                }
            }
        },
        tooltip: {
            headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
            pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.2f}%</b> of total<br/>'
        },
        series: [{
            name: 'Solicitudes',
            colorByPoint: true,
            data: dataSeries
        }],
        drilldown: {
            series: dataDrilldown
        }
    });
}

    