import { Component, OnInit, ViewChildren, QueryList } from '@angular/core';
import { FindFalconeService } from '../find-falcone.service';
import { DestinationComponent } from '../destination/destination.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  //service: any
  availablePlanets = []
  vehicles = []
  destinationNames = ["Destination 1", "Destination 2", "Destination 3", "Destination 4"]

  planetState = {
    name: null,
    current: null,
    previous: null
  }
  vehicleState = {
    name: null,
    vehicle: null
  }
  @ViewChildren(DestinationComponent) destinationsComp: QueryList<DestinationComponent>;
  timeTaken: number;
  disableFindButton = true;
  constructor(public service: FindFalconeService) {
  }

  ngOnInit() {
    console.log(this.service.planets)
    this.service.getPlanets().subscribe((res: any) => {
      console.log(res);
      this.availablePlanets = res;
      //res.forEach(item => this.model.planets.push(item))
    });
    this.service.getVehicles().subscribe((res: any) => {
      let list = []
      res.forEach(v => list.push(new Vehicle(v)));
      this.vehicles = list
      console.log(res);
    });
    //this.service.planets.forEach(item => this.availablePlanets.push(item));
  }
  findFalcone($event) {
    if (this.destinationsComp && this.destinationsComp.length > 0) {
      this.destinationsComp.forEach(comp => {
        console.log(comp.selectedPlanet.name);
      });
    }
  }
  planetStateChange($event) {
    this.disableFindButton = true;
    this.planetState = $event;
  }
  vehicleStateChange($event: any) {
    this.timeTaken = 0;
    let count = 0;
    if (this.destinationsComp && this.destinationsComp.length > 0) {
      this.destinationsComp.forEach(d => {
        if (d.selectedVehicle && d.selectedPlanet) {
          this.timeTaken += d.selectedVehicle.calculateTimeTaken(d.selectedPlanet.distance);
          count++;
        }
      });
      if (count > 0 && count == this.destinationsComp.length)
        this.disableFindButton = false;
    }
    this.vehicleState = $event

  }

}
export class Vehicle {
  name = "";
  total_no = 0;
  max_distance = 0;
  speed = 0;
  used_vehicle_no = 0;
  constructor(vehicle: any) {
    this.name = vehicle.name
    this.total_no = vehicle.total_no
    this.max_distance = vehicle.max_distance
    this.speed = vehicle.speed
  }
  use() {
    if (this.used_vehicle_no < this.total_no) {
      this.used_vehicle_no++;
    }
  }
  unUse() {
    if (this.used_vehicle_no > 0) {
      this.used_vehicle_no--;
    }
  }
  getRemainingCount() {
    return this.total_no - this.used_vehicle_no;
  }
  calculateTimeTaken(max_distance) {
    return max_distance / this.speed;
  }

}