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
    }, 5000)
  }

  getSensorRefresh(self) {
    console.log("aqui")
    self.sensorService.getSensors().subscribe(data => {
      this.sensorData = data
      setTimeout(() => {
        this.getSensorRefresh(this)
      }, 5000)
    })
  }

}
