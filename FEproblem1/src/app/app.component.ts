import { Component } from '@angular/core';
import { FindFalconeService } from './find-falcone.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'FEproblem1';
  constructor(private findFalconeService: FindFalconeService){

  }
  findFalcone($event){
    //this.findFalconeService.getPlanets();
    //this.findFalconeService.getVehicles();
    this.findFalconeService.find(this.findFalconeService.test_planet, this.findFalconeService.test_vehicle);
  }
}
