import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CityDetailPageComponent } from './screen/city-detail-page/city-detail-page.component';
import { CityPageComponent } from './screen/city-page/city-page.component';
import { ClientDetailPageComponent } from './screen/client-detail-page/client-detail-page.component';
import { ClientPageComponent } from './screen/client-page/client-page.component';
import { HomePageComponent } from './screen/home-page/home-page.component';

const routes: Routes = [
  {path:'', component:HomePageComponent},
  {path:'clientsPage', component:ClientPageComponent},
  {path:'clientsDatailPage/:id', component:ClientDetailPageComponent},
  {path:'cityPage', component:CityPageComponent},
  {path:'cityDatailPage/:id', component:CityDetailPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
