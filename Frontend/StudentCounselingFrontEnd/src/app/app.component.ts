import { Component, EventEmitter, Output, ViewChild } from '@angular/core';
import { ProductsComponent } from './Component/products/products.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  @ViewChild('ProductsComponent', { static: false }) productsComponent!: ProductsComponent;
  title = 'Online Shopping';

  public AppComponent()
  {
  }
  ngOnInit(): void {

  }
  public OnProductSearch(event:any){
    this.productsComponent.GetProductList(event);
  }
}
