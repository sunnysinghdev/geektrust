import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class FindFalconeService {

  apiUrl = ""
  token = "random"
  constructor(private http: HttpClient) {
    this.apiUrl = environment.apiEndpoint;
    this.getToken()
  }
  getPlanets() {
    this.http.get(this.apiUrl + 'planets').subscribe(res => {
      console.log(res);
    });
  }
  getVehicles() {
    this.http.get(this.apiUrl + 'vehicles').subscribe(res => {
      console.log(res);
    });
  }
  find() {
    let body = {}
    body["token"] = this.token
    body["planet_names"] = ["Donlon", "Enchai", "Pingasor", "Sapir"];
    body["vehicle_names"] = [
      "Space pod",
      "Space rocket",
      "Space Shuttle",
      "Space Ship"
    ];
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
