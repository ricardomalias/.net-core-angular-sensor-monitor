import { Component, OnInit } from '@angular/core';
import { SensorService } from '../sensor.service';
import { Label } from 'ng2-charts';
import { ChartOptions, ChartType } from 'chart.js';
import * as pluginDataLabels from 'chartjs-plugin-datalabels';

export interface SensorAggregation {
  tag: string
  count: number
}

@Component({
  selector: 'sensor-chart',
  templateUrl: './sensor-chart.component.html',
  styleUrls: ['./sensor-chart.component.css']
})
export class SensorChartComponent implements OnInit {
  sensorData: SensorAggregation[]

  public pieChartOptions: ChartOptions = {
    responsive: true,
    legend: {
      position: 'top',
    },
    plugins: {
      datalabels: {
        formatter: (value, ctx) => {
          const label = ctx.chart.data.labels[ctx.dataIndex];
          return label;
        },
      },
    }
  };
  public pieChartLabels: Label[] = [];
  public pieChartData: number[] = [];
  public pieChartType: ChartType = 'pie';
  public pieChartLegend = true;
  public pieChartPlugins = [pluginDataLabels];
  public pieChartColors = [{}];

  constructor(private sensorService: SensorService) { }

  ngOnInit() {
    this.sensorService.getSensorAggregation().subscribe(data => {
      this.pieChartLabels = data.map(agg => agg.tag)
      this.pieChartData = data.map(agg => agg.count)
      this.pieChartColors = [{
          backgroundColor: data.map((agg) => this.getRandomColor())
      }]

        console.log(this.pieChartColors)
      this.sensorData = data
    })
  }

  getRandomColor() {
    var letters = '0123456789ABCDEF';
    var color = '#';
    for (var i = 0; i < 6; i++) {
      color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
  }

}
