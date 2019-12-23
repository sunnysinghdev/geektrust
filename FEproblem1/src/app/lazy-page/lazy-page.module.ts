import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MovieComponent } from './movie/movie.component';
import { LazyPageComponent } from './lazy-page/lazy-page.component';
import { Routes, RouterModule } from '@angular/router';


const lazyRoutes: Routes = [
  {
    path:'lazyload',
    component: LazyPageComponent
  },
  {
    path:'movie',
    component: MovieComponent
  }
]
@NgModule({
  declarations: [MovieComponent, LazyPageComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(lazyRoutes)
  ]
})
export class LazyPageModule { }
