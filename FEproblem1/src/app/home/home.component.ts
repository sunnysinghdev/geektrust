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
  destinationNames = ["Destination 1", "Destination 2", "Destination 3", "Destination 4"]
  
  planetState = {
    name: null,
    current: null,
    previous: null
  }
  @ViewChildren(DestinationComponent) destinationsComp: QueryList<DestinationComponent>;
  constructor(public service: FindFalconeService) {
  }

  ngOnInit() {
    console.log(this.service.planets)
    this.service.getPlanets().subscribe((res: any) => {
      console.log(res);
      this.availablePlanets = res;
      //res.forEach(item => this.model.planets.push(item))
    });
    //this.service.planets.forEach(item => this.availablePlanets.push(item));
  }
  findFalcone($event) {
    this.destinationsComp.forEach(comp => {
      console.log(comp.selectedPlanet.name);
    });
  }

}
