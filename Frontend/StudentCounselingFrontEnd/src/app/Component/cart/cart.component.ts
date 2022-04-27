import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  public productsList:string[]=[];
  public productsInCart:string[]=[];
  public grandTotal:string='';

  constructor() { }

  ngOnInit(): void {
  }
  public RemoveProductInCart()
  {
    this.productsInCart=[];
  }
  public RemoveAllProductsInCart()
  {
    this.productsInCart=[];
  }
}
