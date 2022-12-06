import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private baseService: BaseService) { 

  }

  listCities(){
    return this.baseService.get(`City/ListCities`)
  }

  insertCity(dto:any){
    return this.baseService.post(`City/InsertCity`,dto)
  }

  updateCity(dto:any){
    return this.baseService.post(`City/UpdateCity`,dto)
  }

  getCity(id:number){
    return this.baseService.delete(`City/GetCity/?idCity=${id}`)
  }

  deleteCity(id:number){
    return this.baseService.delete(`City/DeleteCity/?idCity=${id}`)
  }
}
