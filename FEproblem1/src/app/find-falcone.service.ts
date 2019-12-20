import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, observable } from 'rxjs';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class FindFalconeService {

  apiUrl = "";
  token = "random";
  
  constructor(private http: HttpClient) {
    this.apiUrl = environment.apiEndpoint;
  }
  getPlanets() {
    return this.http.get(this.apiUrl + 'planets');
  }
  getVehicles() {
    return this.http.get(this.apiUrl + 'vehicles');
  }
  find(planet_names: string[], vehicle_names: string[]) {
    const resultObserver =  new Observable(observable =>{
      let body = {}
      body["planet_names"] = planet_names
      body["vehicle_names"] = vehicle_names
      console.log(body)
      this.getToken().subscribe((res: any) => {
        console.log(res);
        body["token"] = res.token;
        this.http.post(this.apiUrl + 'find', body, {
          headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          }
        }).subscribe( (res:any)=>{
          observable.next(res);
        });
      });
    });
    return resultObserver;   
    
  }
  getToken() {
    return this.http.post(this.apiUrl + 'token', '', { headers: { 'Accept': 'application/json' } });
  }
}
//------------test data--------------------

export const test_planet = [
  "Donlon", 
  "Enchai", 
  "Pingasor", 
  "Sapir"
];
export const test_vehicle = [
  "Space pod",
  "Space rocket",
  "Space Shuttle",
  "Space Ship"
];
export const vehileList = [
  {
      name:"Space Pod",
      total_no:2,
      max_distance: 200,
      speed:2
  },
  {
      name:"Space Rocket",
      total_no:1,
      max_distance: 300,
      speed:4
  },
  {
      name:"Space Shuttle",
      total_no:1,
      max_distance: 400,
      speed:5
  },
  {
      name:"Space Ship",
      total_no:2,
      max_distance: 600,
      speed:10
  }
]
export const planetList = [
  {
      name:"Dolon",
      distance:100
  },
  {
      name:"Enchai",
      distance:200
  },
  {
      name:"Jebing",
      distance:300
  },
  {
      name:"Sapir",
      distance:400
  },
  {
      name:"Lerbin",
      distance:500
  },
  {
      name:"Pingasor",
      distance:600
  }
]