import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { HeaderFormat } from 'src/app/controls/HeaderTable';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.css']
})
export class GridComponent implements OnInit {
  @Input() theadList?: HeaderFormat[]
  @Input() bodyList?:any[]
  @Output() callParent = new EventEmitter<any>();
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  DeleteItem(id:number){
    this.callParent.emit(id)
  }

  RedirectToDetailPage(url:string){
    this.router.navigate([url])
  }

}
