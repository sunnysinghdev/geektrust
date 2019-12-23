import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { FindFalconeService } from './find-falcone.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HomeResolverService implements Resolve<any> {
  

  constructor(public service: FindFalconeService) { }
  
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> {
    //throw new Error("Method not implemented.");
    return this.service.getPlanetsAndVehicles();
  }
}
