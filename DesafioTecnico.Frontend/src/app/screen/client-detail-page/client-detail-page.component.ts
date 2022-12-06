import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { ToastrService } from 'ngx-toastr';
import CityInputDto from 'src/app/controls/CidadeInputDto';
import ClientOutputDto from 'src/app/controls/ClientOutputDto';
import Gender from 'src/app/controls/Gender';
import { CityService } from 'src/app/service/city.service';
import { ClientService } from 'src/app/service/client.service';


@Component({
  selector: 'app-client-detail-page',
  templateUrl: './client-detail-page.component.html',
  styleUrls: ['./client-detail-page.component.css']
})
export class ClientDetailPageComponent implements OnInit {
  
  idClient!:number;
  outputDto!:ClientOutputDto
  form!:FormGroup
  gender!:Gender
  listCities?:any[]

  constructor(
    private routeActive: ActivatedRoute,
    private clientService: ClientService,
    private cityService: CityService,
    private toast: ToastrService,
    private router: Router
    ) {
      this.routeActive.params.subscribe(params => this.idClient = parseInt(params['id']))
      this.outputDto = new ClientOutputDto()
      this.gender = new Gender()
     }

  ngOnInit(): void {
    this.initiateForm()
    this.listCity()
    this.getClient()
  }

  listCity(){
    this.cityService.listCities().subscribe(data => {
      if(data.success){
        this.convertCityInListSelect(data.data)
      }else{
        data.messages?.forEach(element => this.toast.error(element))
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

  initiateForm(){
    this.form = new FormGroup({
      name: new FormControl(''),
      gender: new FormControl(),
      birthDate: new FormControl(),
      idCity : new FormControl(), 
    })
  }

  getClient(){
    if(this.idClient && this.idClient > 0){
      this.clientService.getClient(this.idClient).subscribe(data => {
        if(data.success){
          this.fillDto(data.data)
        }else{
          data.messages?.forEach(element => this.toast.error(element))
        }
      })
    }
  }

  fillDto(data: ClientOutputDto){
    data.birthDate = String(moment(data.birthDate).format('YYYY-MM-DD'))
    this.outputDto = data
  }

  postClient(){
    this.outputDto.id = this.idClient
    this.outputDto.name = this.form.controls.name.value
    this.outputDto.gender = this.form.controls.gender.value
    this.outputDto.idCity = this.form.controls.idCity.value
    this.outputDto.birthDate = this.form.controls.birthDate.value
    this.outputDto.age = (this.outputDto.age !=null && this.outputDto.age > 0) ? this.outputDto.age : 0 
    
    if(this.outputDto.id > 0){
      this.clientService.updateClient(this.outputDto).subscribe(data => {
        if(data.success){
          data.messages?.forEach(element => this.toast.success(element))
          this.router.navigate(['clientsPage'])
        }
      }
      )
    }else{
      this.clientService.insertClient(this.outputDto).subscribe(data => {
        if(data.success){
            data.messages?.forEach(element => this.toast.success(element))
            this.router.navigate(['clientsPage'])
        }else{
          data.messages?.forEach(element => this.toast.error(element))
        }
      })
    }
  }
}

