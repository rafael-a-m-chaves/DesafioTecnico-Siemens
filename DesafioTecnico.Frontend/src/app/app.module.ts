import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
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
import { ToastrModule } from 'ngx-toastr';
import { CityPageComponent } from './screen/city-page/city-page.component';
import { CityDetailPageComponent } from './screen/city-detail-page/city-detail-page.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    ClientPageComponent,
    SideBarComponent,
    GridComponent,
    ClientDetailPageComponent,
    InputComponent,
    CityPageComponent,
    CityDetailPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    NgSelectModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(), 
  ],
  providers: [BaseService,ClientService],
  bootstrap: [AppComponent]
})
export class AppModule { }
