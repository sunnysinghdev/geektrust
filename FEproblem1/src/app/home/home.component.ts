import { Component, OnInit, ViewChildren, QueryList } from '@angular/core';
import { FindFalconeService, planetList, vehileList } from '../find-falcone.service';
import { DestinationComponent } from '../destination/destination.component';
import { Route, Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  
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
  TYPE_VEHICLE = "Vehicle";
  TYPE_PLANET = "Planet";
  
  constructor(public service: FindFalconeService, public router: Router, public route: ActivatedRoute) {
  }

  ngOnInit() {
    let data = this.route.snapshot.data['home']
    // this.service.getPlanets().subscribe((res: any) => {
    //   this.availablePlanets = res;
    // },
    // error => {
    //   this.availablePlanets = planetList;
    // }
    //   );
    // this.service.getVehicles().subscribe((res: any) => {
    //   this.initVehiclleList(res)
    // },
    // error=>{
    //   this.initVehiclleList(vehileList);
    // });
    this.initList(data);
  }
  initList(data){

    //this.service.getPlanetsAndVehicles().subscribe((res:any)=>{
      this.availablePlanets = data.planets;
      this.initVehiclleList(data.vehicles);
    //})
  }
  initVehiclleList(res){
    let list = []
    res.forEach(v => list.push(new Vehicle(v)));
    this.vehicles = list
  }
  
  findFalcone($event) {
    let planet_names = this.getNames(this.TYPE_PLANET);
    let vehicle_names = this.getNames(this.TYPE_VEHICLE);
    
    this.service.find(planet_names, vehicle_names).subscribe((res: any) => {
      console.log(res);
      
      if (res.status) {
        res['time_taken'] = this.timeTaken;
        this.router.navigate(['/result'], { queryParams: res});
      }
      else if (res.status == "success") {

      }
    });
  }
  
  getNames(nameType){
    let list = []
    if (this.destinationsComp && this.destinationsComp.length > 0) {
      this.destinationsComp.forEach(comp => {
        let obj = nameType == this.TYPE_PLANET ? comp.selectedPlanet : comp.selectedVehicle;
        if (obj) {
          list.push(comp.selectedPlanet.name);
        }
      });
    }
    return list;
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