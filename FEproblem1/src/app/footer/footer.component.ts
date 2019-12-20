import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  content = 'Coding problem - <a target="_blank" href="https://www.geektrust.in/coding-problem/frontend/space">https://www.geektrust.in/finding-falcone</a> '
  constructor() { }

  ngOnInit() {
  }

}
