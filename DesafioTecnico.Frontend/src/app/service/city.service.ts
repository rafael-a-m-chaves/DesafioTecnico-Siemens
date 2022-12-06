import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private baseService: BaseService) { 

  }

  listCities(idCity?:number, name?:string, uf?:string){
    let param = "/?"
    if(idCity){
      param += param.length > 2 ? `&idCity=${idCity}` : `idCity=${idCity}`
    }
    if(name && name.length > 0){
      param += `name=${name}`
    }
    if(uf){
      param += param.length > 2 ? `&uf=${uf}` : `uf=${uf}`
    }
    return this.baseService.get(`City/ListCities${param.length > 2 ? param:''}`)
  }

  insertCity(dto:any){
    return this.baseService.post(`City/InsertCity`,dto)
  }

  updateCity(dto:any){
    return this.baseService.put(`City/UpdateCity`,dto)
  }

  getCity(id:number){
    return this.baseService.get(`City/GetCity/?idCity=${id}`)
  }

  deleteCity(id:number){
    return this.baseService.delete(`City/DeleteCity/?idCity=${id}`)
  }
}
