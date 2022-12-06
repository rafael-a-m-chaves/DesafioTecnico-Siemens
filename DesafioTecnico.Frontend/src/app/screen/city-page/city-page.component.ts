import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import CityInputDto from 'src/app/controls/CidadeInputDto';
import { CityHeader } from 'src/app/controls/HeaderTable';
import States from 'src/app/controls/States';
import { CityService } from 'src/app/service/city.service';

@Component({
  selector: 'app-city-page',
  templateUrl: './city-page.component.html',
  styleUrls: ['./city-page.component.css']
})
export class CityPageComponent implements OnInit {
  columns:CityHeader;
  dataObjectCity:any[] = []
  form!:FormGroup
  listCities?:any[]
  listUf:any[]
  constructor(
    private cityService: CityService,
    private toast: ToastrService,
    private router: Router) { 
    this.columns = new CityHeader();
    this.listUf = new States().listStates
  }

   ngOnInit(): void {
    this.listCity()
    this.initiateForm()
  }

  onCallParent(id: number){
      this.deleteCity(id);
  }

  deleteCity(id:number){
    this.cityService.deleteCity(id).subscribe(data  => {
      if(data.success){
        this.listCity()
        data.messages?.forEach(element => this.toast.success(element))
      }else{
        data.messages?.forEach(element => this.toast.error(element))
      }
    })
  }

  initiateForm(){
    this.form = new FormGroup({
      idCity: new FormControl(),
      name: new FormControl(''),
      uf: new FormControl(),
    })
  }

  seacherCity(){
    let idCity: number = this.form.controls.idCity.value  ?? null
    let name: string = this.form.controls.name.value  ?? null
    let uf: string = this.form.controls.uf.value  ?? null
    
    this.cityService.listCities(idCity,name, uf).subscribe(data => {
      if(data.success){
        console.log(data.messages)
        this.convertCityInTable(data.data)
        data.messages?.forEach(element => this.toast.success(element))
      }else{
        data.messages?.forEach(element => this.toast.error(element))
      }
    })
  }

  listCity(){
    this.cityService.listCities().subscribe(data => {
      if(data.success){
        this.convertCityInTable(data.data)
        data.messages?.forEach(element => this.toast.success(element))
      }else{
        data.messages?.forEach(element => this.toast.error(element))
      }
    })
  }

  convertCityInTable(data: CityInputDto[]){
    this.dataObjectCity = []
    data.forEach(element =>{
      let stateArray = this.listUf.filter(filter => filter.key == element.uf)
      let stateString = `${stateArray[0].key} - ${stateArray[0].value}`
      let newArray: any[] = [
        {value:element.id,type:"text"},
        {value:element.name,type:"text"},
        {value:stateString,type:"text"},
        {value:element.dateUpdateOrCreate,type:"text"},
        {value:element.id,type:"action",urlDetail:"cityDatailPage"}
      ]
      this.dataObjectCity.push(newArray)
    })
  }

  newCity(){
    this.router.navigate(['/cityDatailPage/0'])
  }

  clearSearch(){
    this.form.get("name")?.setValue('')
    this.form.get("idCity")?.setValue(null)
    this.form.get("uf")?.setValue(null)
    this.listCity()
  }
}