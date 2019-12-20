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
}
