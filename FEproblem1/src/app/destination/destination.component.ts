import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-destination',
  templateUrl: './destination.component.html',
  styleUrls: ['./destination.component.scss']
})
export class DestinationComponent implements OnInit {

  selectVal = null;
  vehicleGroup = "";
  @Input()
  name = "Destination"

  @Input()
  planets = []


  _planetState = {
    name: null,
    current: null,
    previous: null
  }

  @Input()
  get planetState() {
    return this._planetState;
  }
  set planetState(value) {
    this._planetState = value
    this.updateList()
    this.planetStateChange.emit(value);
  }

  @Output()
  planetStateChange = new EventEmitter();

  _vehicles = []
  @Input()
  get vehicles() {
    return this._vehicles;
  }
  set vehicles(value) {
    this._vehicles = value
    this._vehicles.forEach(v => this.vCountDict[v.name] = v.total_no);
  }

  _vehicleState = {
    name: "",
    vehicle: null
  }
  @Input()
  get vehicleState() {
    return this._vehicleState;
  }
  set vehicleState(value) {
    this._vehicleState = value
    this.updateVehicleCount()
    this.vehicleStateChange.emit(value);
  }

  @Output()
  vehicleStateChange = new EventEmitter();

  selectedPlanet = null
  selectedVehicle = null
  vCountDict = {}
  constructor() { }

  ngOnInit() {
    this.vehicleGroup = this.name.replace(" ", "");
    console.log(this.vehicles)
    //this.vehicles.forEach( v=> this.vCountDict[v.name] = v.total_no);
  }
  getCount(name) {
    if (this.vCountDict[name]) {
      return this.vCountDict[name];
    }
    return 0;
  }
  updateVehicleCount() {
    if (this.name != this._vehicleState.name) {
      if (this._vehicleState)
        this.refreshVehicleCount(this._vehicleState.vehicle);
    }
  }
  refreshVehicleCount(vehicle) {
    if (vehicle) {
      this._vehicles.forEach(v => {
        if (!this.selectedVehicle || this.selectedVehicle.name != v.name) {
          this.vCountDict[v.name] = v.getRemainingCount();
        }
      });
    }
  }
  onVehicleSelected($event) {
    if (this.selectedVehicle) {
      this.selectedVehicle.unUse();
      this.vCountDict[this.selectedVehicle.name] = this.selectedVehicle.getRemainingCount()
    }
    if ($event) {
      this.selectedVehicle = $event;
      this.selectedVehicle.use();
      this.vCountDict[this.selectedVehicle.name] = this.selectedVehicle.getRemainingCount()
    }
    this.vehicleStateChange.emit({ name: this.name, vehicle: this.selectedVehicle });
    this.selectedVehicle = $event;


  }
  updateList() {
    if (this._planetState && this._planetState.name != this.name) {
      this.removeSelectedPlanet(this._planetState.current);
      this.addRemovedPlanet(this._planetState.previous);
    }

  }
  addRemovedPlanet(planet) {
    if (planet) {
      if (!this.selectedPlanet || planet.name != this.selectedPlanet.name) {
        this.planets.push(planet);
        this.planets.sort((a, b) => a.distance - b.distance);
      }
    }
  }
  removeSelectedPlanet(planet) {
    if (planet) {
      if (!this.selectedPlanet || planet.name != this.selectedPlanet.name) {
        this.planets = this.planets.filter(p => p.name != planet.name);
      }
    }
  }
  onSelected($event) {

    let prev = null;
    if (this.selectedPlanet) {
      prev = {
        name: this.selectedPlanet.name,
        distance: this.selectedPlanet.distance
      }
    }
    this.selectedPlanet = null;
    this.selectedPlanet = $event;

    //if(prev && prev.name != $event.name){
    this.planetStateChange.emit({
      name: this.name,
      current: $event,
      previous: prev
    });
    this.onVehicleSelected(null)
    //}

  }
}
