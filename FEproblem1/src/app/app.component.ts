import { Component } from '@angular/core';
import { FindFalconeService } from './find-falcone.service';
import { Router, NavigationStart, NavigationEnd, NavigationCancel, NavigationError, RouterEvent } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'FEproblem1';
  loading =  true;
  constructor(private findFalconeService: FindFalconeService, public router:Router){
    router.events.subscribe((routerEvent: RouterEvent) => {
      this.checkRouterEvent(routerEvent);
    });
  }
  checkRouterEvent(routerEvent: RouterEvent): void {
    if(routerEvent instanceof NavigationStart){
      this.loading = true;
    }
    if(routerEvent instanceof NavigationEnd ||
      routerEvent instanceof NavigationCancel ||
      routerEvent instanceof NavigationError){
        this.loading = false;
      }
  }
}
