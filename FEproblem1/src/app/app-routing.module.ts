import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ResultComponent } from './result/result.component';
import { HomeResolverService } from './home-resolver.service';
import { LazyPageModule } from './lazy-page/lazy-page.module';


const routes: Routes = [
  { 
    path: '',
    redirectTo:'home',
    pathMatch:'full',

  },
  {
    path:'home',
    resolve:{ home: HomeResolverService},
    component: HomeComponent,
    children:[
      {
        path: 'lazyload',
        loadChildren:'./lazy-page/lazy-page.module#LazyPageModule',
        pathMatch:'full'
      }
    ]
  },
  {
    path:'result',
    component: ResultComponent
  }
];

@NgModule({
  imports: [
    LazyPageModule,   
    RouterModule.forRoot(routes, { onSameUrlNavigation : 'reload'})],
  providers:[HomeResolverService],
  exports: [RouterModule]
})
export class AppRoutingModule { }