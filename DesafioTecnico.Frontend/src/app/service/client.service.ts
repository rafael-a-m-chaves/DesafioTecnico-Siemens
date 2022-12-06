import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(private baseService: BaseService) { 

  }

  listClients(name?:string, idClient?:number, idCity?:number){
    let param = "/?"
    if(name && name.length > 0){
      param += `name=${name}`
    }
    if(idCity){
      param += param.length > 2 ? `&idCity=${idCity}` : `idCity=${idCity}`
    }
    if(idClient){
      param += param.length > 2 ? `&idClient=${idClient}` : `idClient=${idClient}`
    }
    return this.baseService.get(`Client/ListClient${param.length > 2 ? param:''}`)
  }

  insertClient(dto:any){
    return this.baseService.post(`Client/InsertClient`,dto)
  }

  updateClient(dto:any){
    return this.baseService.post(`Client/UpdateClient`,dto)
  }

  getClient(id:number){
    return this.baseService.delete(`Client/GetClient/?idClient=${id}`)
  }

  deleteClient(id:number){
    return this.baseService.delete(`Client/DeleteClient/?idClient=${id}`)
  }
}
