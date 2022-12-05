import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientDetailPageComponent } from './screen/client-detail-page/client-detail-page.component';
import { ClientPageComponent } from './screen/client-page/client-page.component';
import { HomePageComponent } from './screen/home-page/home-page.component';

const routes: Routes = [
  {path:'', component:HomePageComponent},
  {path:'clientsPage', component:ClientPageComponent},
  {path:'clientsDatailPage', component:ClientDetailPageComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
