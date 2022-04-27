import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule,Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HeaderComponent } from './Component/header/header.component';
import { CartComponent } from './Component/cart/cart.component';
import { ProductsComponent } from './Component/products/products.component';

const routes :Routes=[
  {path:'',  component:ProductsComponent},
  {path:'Products', component:ProductsComponent},
  {path:'Cart', component:CartComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    CartComponent,
    ProductsComponent
  ],
  imports: [
    BrowserModule,RouterModule.forRoot(routes),HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
