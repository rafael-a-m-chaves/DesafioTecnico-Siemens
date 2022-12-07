import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.scss']
})
export class InputComponent implements OnInit {
  @Input() type?:string
  @Input() formGroupControl!: FormGroup;
  @Input() FildValue:any
  @Input() DataSelect:any
  @Input() style?:string
  @Input() label?:string
  @Input() formControlNameInput!:string
  @Input() readonly!: boolean
  @Input() minimo?:number
  constructor() { }

  ngOnInit(): void {
  }

  customSearchFn(term: string, item: any) {
    term = term.toLocaleLowerCase();
    return item.value.toLocaleLowerCase().indexOf(term) > -1;
   }
}
