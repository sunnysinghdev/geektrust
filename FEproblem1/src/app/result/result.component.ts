import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.scss']
})
export class ResultComponent implements OnInit, OnDestroy {
  

  successMsg = "Success! Congratulations on Finding Falcone. King Shan is mighty pleased.";
  failMsg = "Failed! Could not find Falcone on any planet."
  displayMsg = "";
  success = false;
  SUCCESS = "success";
  FALSE = "false"
  time_taken = 0;
  planet_name = "";

  constructor(public route: ActivatedRoute, public router: Router) {
   }

  ngOnInit() {
    //const params = this.router.getCurrentNavigation().extras.state
    const params = this.route.snapshot.queryParamMap
    console.log(params);
    if (params.get('status') == this.SUCCESS) {
      this.time_taken = +params.get('time_taken');
      this.planet_name = params.get('planet_name');
      this.displayMsg = this.successMsg
      this.success = true;
    }
    else {
      this.displayMsg = this.failMsg;
    }
    
  }
  ngOnDestroy(): void {
    this.success = false
  }
  startAgain($event){
    this.router.navigate(['']);
  }
}
