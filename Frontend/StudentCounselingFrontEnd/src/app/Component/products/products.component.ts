import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/Service/api.service';
import {Product} from '../../Models/ProductModels';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

 public productList: Product[] = [];
 public productModel: Product = new Product();
 public searchText : string='';

  constructor(private service:ApiService) { }

  ngOnInit(): void {
    this.GetProductList('');
  }
  public GetProductList(event:any){
    this.service.GetProductList(this.searchText).subscribe(result=>{
     this.productList = result;
     console.log(result);
    });
  }
  public AddProduct(){
    this.service.AddProduct(this.productModel).subscribe(result=>{
     });
  }
}
