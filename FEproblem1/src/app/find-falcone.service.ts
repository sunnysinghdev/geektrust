import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { error } from 'protractor';

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
  getPlanetsAndVehicles() {
    return new Observable((observer) => {
      this.getPlanets().subscribe((res: any) => {
        let r = {};
        r['planets'] = res;
        this.getVehicles().subscribe((res: any) => {
          r['vehicles'] = res;
          observer.next(r);
          observer.complete();
        },
          error => {
            console.log("Error for vehicle api", error);
            this.completeRquest(observer);
          });

      },
        error => {
          console.log("Error for Planets:  ", error);
          this.completeRquest(observer);
        });
    })
  }
  completeRquest(observer) {
    let r = {}
    r['planets'] = planetList;
    r['vehicles'] = vehileList;

    observer.next(r);
    observer.complete();
  }
  find(planet_names: string[], vehicle_names: string[]) {
    const resultObserver = new Observable(observable => {
      let body = {}
      body["planet_names"] = planet_names
      body["vehicle_names"] = vehicle_names
      this.getToken().subscribe((res: any) => {
        body["token"] = res.token;
        this.http.post(this.apiUrl + 'find', body, {
          headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          }
        }).subscribe((res: any) => {
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
    name: "Space Podwa",
    total_no: 2,
    max_distance: 200,
    speed: 2
  },
  {
    name: "Space Rocket",
    total_no: 1,
    max_distance: 300,
    speed: 4
  },
  {
    name: "Space Shuttle",
    total_no: 1,
    max_distance: 400,
    speed: 5
  },
  {
    name: "Space Ship",
    total_no: 2,
    max_distance: 600,
    speed: 10
  }
]
export const planetList = [
  {
    name: "Dolonwa",
    distance: 100
  },
  {
    name: "Enchai",
    distance: 200
  },
  {
    name: "Jebing",
    distance: 300
  },
  {
    name: "Sapir",
    distance: 400
  },
  {
    name: "Lerbin",
    distance: 500
  },
  {
    name: "Pingasor",
    distance: 600
  }
]