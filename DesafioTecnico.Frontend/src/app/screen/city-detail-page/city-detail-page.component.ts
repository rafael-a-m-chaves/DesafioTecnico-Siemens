import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import CityOutputDto from 'src/app/controls/CityOutputDto';
import Gender from 'src/app/controls/Gender';
import States from 'src/app/controls/States';
import { CityService } from 'src/app/service/city.service';

@Component({
  selector: 'app-city-detail-page',
  templateUrl: './city-detail-page.component.html',
  styleUrls: ['./city-detail-page.component.css']
})
export class CityDetailPageComponent implements OnInit {
  idCity!:number;
  outputDto!:CityOutputDto
  form!:FormGroup
  gender!:Gender
  listStates?:any[]

  constructor(
    private routeActive: ActivatedRoute,
    private cityService: CityService,
    private toast: ToastrService,
    private router: Router
    ) {
      this.routeActive.params.subscribe(params => this.idCity = parseInt(params['id']))
      this.outputDto = new CityOutputDto()
      this.gender = new Gender()
      this.listStates = new States().listStates
     }

  ngOnInit(): void {
    this.initiateForm()
    this.getCity()
  }

  initiateForm(){
    this.form = new FormGroup({
      name: new FormControl(''),
      uf: new FormControl(''),
    })
  }

  getCity(){
    if(this.idCity && this.idCity > 0){
      this.cityService.getCity(this.idCity).subscribe(data => {
        if(data.success){
          this.fillDto(data.data)
        }else{
          data.messages?.forEach(element => this.toast.error(element))
        }
      })
    }
  }

  fillDto(data: CityOutputDto){
    this.outputDto = data
  }

  postCity(){
    this.outputDto.id = this.idCity
    this.outputDto.name = this.form.controls.name.value
    this.outputDto.uf = this.form.controls.uf.value

    if(this.idCity == 0 ){
      this.cityService.insertCity(this.outputDto).subscribe(data => {
        if(data.success){
          data.messages?.forEach(element => this.toast.success(element))
          this.router.navigate(['cityPage'])
        }
      }
      )
    }else{
      this.cityService.updateCity(this.outputDto).subscribe(data => {
        if(data.success){
            data.messages?.forEach(element => this.toast.success(element))
            this.router.navigate(['cityPage'])
        }else{
          data.messages?.forEach(element => this.toast.error(element))
        }
      })
    }
  }

  cancel(){
    this.router.navigate(['cityPage'])
  }
}
