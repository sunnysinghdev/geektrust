import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-destination',
  templateUrl: './destination.component.html',
  styleUrls: ['./destination.component.scss']
})
export class DestinationComponent implements OnInit {

  selectVal = null;

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

  @Input()
  vehicles = []

  selectedPlanet = null
  selectedVehicle = null
  constructor() { }

  ngOnInit() {
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
    this.selectedPlanet = $event;

    //if(prev && prev.name != $event.name){
      this.planetStateChange.emit({
        name: this.name,
        current: $event,
        previous: prev
      });
    //}
    
  }
}
