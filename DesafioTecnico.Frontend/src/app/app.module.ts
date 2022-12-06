import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './screen/home-page/home-page.component';
import { ClientPageComponent } from './screen/client-page/client-page.component';
import { SideBarComponent } from './components/side-bar/side-bar.component';
import { GridComponent } from './components/grid/grid.component';
import { ClientDetailPageComponent } from './screen/client-detail-page/client-detail-page.component';
import { BaseService } from './service/base.service';
import { ClientService } from './service/client.service';
import { HttpClientModule } from '@angular/common/http';
import { InputComponent } from './components/input/input.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    ClientPageComponent,
    SideBarComponent,
    GridComponent,
    ClientDetailPageComponent,
    InputComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    NgSelectModule 
  ],
  providers: [BaseService,ClientService],
  bootstrap: [AppComponent]
})
export class AppModule { }
