import { Component, OnInit, Output,EventEmitter } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  @Output() search : EventEmitter<any> = new EventEmitter();
  constructor() { }

  ngOnInit(): void {
  }
  public onSearch(event:any){
    this.search.emit(event);
  }
}
