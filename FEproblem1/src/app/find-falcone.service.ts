import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class FindFalconeService {

  apiUrl = "";
  token = "random";
  planets = [];
  vehicles = [];
  test_planet = [
    "Donlon", 
    "Enchai", 
    "Pingasor", 
    "Sapir"
  ];
  test_vehicle = [
    "Space pod",
    "Space rocket",
    "Space Shuttle",
    "Space Ship"
  ];
  constructor(private http: HttpClient) {
    this.apiUrl = environment.apiEndpoint;
    this.getToken();
    this.getPlanets();
    this.getVehicles();
  }
  getPlanets() {
    return this.http.get(this.apiUrl + 'planets');
  }
  getVehicles() {
    this.http.get(this.apiUrl + 'vehicles').subscribe((res: any) => {
      this.vehicles = res;
      console.log(res);
    });
  }
  find(planet_names: string[], vehicle_names: string[]) {
    let body = {}
    body["token"] = this.token
    body["planet_names"] = planet_names
    body["vehicle_names"] = vehicle_names
    console.log(body)
    this.http.post(this.apiUrl + 'find', body, {
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      }
    }
    ).subscribe(res => {
      console.log(res);
    });
  }
  getToken() {
    this.http.post(this.apiUrl + 'token', '', { headers: { 'Accept': 'application/json' } }).subscribe((res: any) => {
      console.log(res);
      this.token = res.token;
    });
  }
}
