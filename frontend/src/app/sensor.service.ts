import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SensorService {
  private baseurl = "https://localhost:5001/api"

  constructor(private http: HttpClient) {

  }

  getSensors(): Observable<any> {
    return this.http.get<any>(`${this.baseurl}/sensor`);
  }

  getSensorAggregation(): Observable<any> {
    return this.http.get<any>(`${this.baseurl}/sensor/aggregation`);
  }
}
