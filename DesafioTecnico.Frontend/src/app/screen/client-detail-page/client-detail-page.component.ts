import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-client-detail-page',
  templateUrl: './client-detail-page.component.html',
  styleUrls: ['./client-detail-page.component.css']
})
export class ClientDetailPageComponent implements OnInit {
  idClient?:number;
  constructor(
    private route: ActivatedRoute
    ) {
      this.route.params.subscribe(params => this.idClient = params['id']);
     }

  ngOnInit(): void {
  }

}
