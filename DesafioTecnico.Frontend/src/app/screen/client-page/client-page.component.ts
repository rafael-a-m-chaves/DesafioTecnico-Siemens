import { Component, OnInit } from '@angular/core';
import ClienteInputDto from 'src/app/controls/ClientInputDto';
import { ClientHeader } from 'src/app/controls/HeaderTable';
import { ClientService } from 'src/app/service/client.service';

@Component({
  selector: 'app-client-page',
  templateUrl: './client-page.component.html',
  styleUrls: ['./client-page.component.css']
})
export class ClientPageComponent implements OnInit {
  columns:ClientHeader;
  dataObjectClient:any[] = []
  constructor(private clientService: ClientService) { 
    this.columns = new ClientHeader();
  }

   ngOnInit(): void {
    this.listClients()
  }

  ConvertDateForColumTable(data:ClienteInputDto[]){
    data.forEach(element =>{
      let newArray: any[] = [
        {value:element.id,type:"text"},
        {value:element.name,type:"text"},
        {value:element.age,type:"text"},
        {value:element.birthDate,type:"text"},
        {value:element.gender,type:"text"},
        {value:element.localization,type:"text"},
        {value:element.id,type:"action",urlDetail:"clientsDatailPage"}
      ]
      this.dataObjectClient.push(newArray)
    })
  }

  onCallParent(id: number){
      this.deleteClient(id);
  }

  deleteClient(id:number){
    console.log(id)
  }

  listClients(){
    this.clientService.listClients().subscribe(data => {
      if(data.success){
        this.ConvertDateForColumTable(data.data)
      }
    })
  }
}
