import { Component, OnInit } from '@angular/core';
import { SensorService } from '../sensor.service';

export interface Sensor {
  timestamp?: Date
  value: string
  tag: string
}

@Component({
  selector: 'sensor-table',
  templateUrl: './sensor-table.component.html',
  styleUrls: ['./sensor-table.component.css']
})
export class SensorTableComponent implements OnInit {
  displayedColumns: string[] = ['timestamp', 'tag', 'value'];
  sensorData: Sensor[];

  constructor(private sensorService: SensorService) {

  }

  ngOnInit() {
    setTimeout(() => {
      this.getSensorRefresh(this)
    }, 1000)
  }

  getSensorRefresh(self) {
    self.sensorService.getSensors().subscribe(data => {
      data = data.map((d) => {
        d.timestamp = new Date(d.timestamp)
        return d
      })

      this.sensorData = data

      setTimeout(() => {
        this.getSensorRefresh(this)
      }, 5000)
    })
  }

}
