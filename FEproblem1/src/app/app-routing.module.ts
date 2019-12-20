import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ResultComponent } from './result/result.component';


const routes: Routes = [
  { 
    path: '',
    component: HomeComponent
  },
  {
    path:'home',
    redirectTo:''
  },
  {
    path:'result',
    component: ResultComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { onSameUrlNavigation : 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }