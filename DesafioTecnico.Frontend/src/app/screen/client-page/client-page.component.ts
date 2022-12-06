import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import CityInputDto from 'src/app/controls/CidadeInputDto';
import ClienteInputDto from 'src/app/controls/ClientInputDto';
import { ClientHeader } from 'src/app/controls/HeaderTable';
import { CityService } from 'src/app/service/city.service';
import { ClientService } from 'src/app/service/client.service';

@Component({
  selector: 'app-client-page',
  templateUrl: './client-page.component.html',
  styleUrls: ['./client-page.component.css']
})
export class ClientPageComponent implements OnInit {
  
  columns:ClientHeader;
  dataObjectClient:any[] = []
  form!:FormGroup
  listCities?:any[]
  
  constructor(
    private clientService: ClientService,
    private cityService: CityService) { 
    this.columns = new ClientHeader();
  }

   ngOnInit(): void {
    this.listClients()
    this.listCity()
    this.initiateForm()
  }

  ConvertDateForColumTable(data:ClienteInputDto[]){
    this.dataObjectClient = []
    data.forEach(element =>{
      let newArray: any[] = [
        {value:element.id,type:"text"},
        {value:element.name,type:"text"},
        {value:element.age,type:"text"},
        {value:element.birthDate,type:"text"},
        {value:element.gender?.toUpperCase() == "M" ? 'Masculino' : 
        (element.gender?.toUpperCase() == "F" ? 'Feminino': 'Não binario')  ,type:"text"},
        {value:element.localization,type:"text"},
        {value:element.dateUpdateOrCreate,type:"text"},
        {value:element.id,type:"action",urlDetail:"clientsDatailPage"}
      ]
      this.dataObjectClient.push(newArray)
    })
  }

  onCallParent(id: number){
      this.deleteClient(id);
  }

  deleteClient(id:number){
    this.clientService.deleteClient(id).subscribe(data  => {
      if(data.success){
        this.listClients()
      }
    })
  }

  listClients(){
    this.clientService.listClients().subscribe(data => {
      if(data.success){
        this.ConvertDateForColumTable(data.data)
      }
    })
  }

  initiateForm(){
    this.form = new FormGroup({
      id: new FormControl(),
      name: new FormControl(''),
      city: new FormControl(),
    })
  }

  seacherClient(){
    let idClient: number = this.form.controls.id.value  ?? null
    let name: string = this.form.controls.name.value  ?? null
    let idCity: number = this.form.controls.city.value  ?? null
    this.clientService.listClients(name, idClient, idCity).subscribe(data => {
      if(data.success){
        console.log(data.messages)
        this.ConvertDateForColumTable(data.data)
      }
    })
  }

  listCity(){
    this.cityService.listCities().subscribe(data => {
      if(data.success){
        this.convertCityInListSelect(data.data)
      }
    })
  }

  convertCityInListSelect(data: CityInputDto[]){
    this.listCities = data.map(element => {
      return {
          key: element.id,
          value: `${element.name} - ${element.uf}` 
        }
    })
  }

  clearSearch(){
    this.form.get("name")?.setValue('')
    this.form.get("id")?.setValue(null)
    this.form.get("city")?.setValue(null)

    this.listClients()
  }
}
