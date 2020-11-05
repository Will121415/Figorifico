import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductConsultComponent } from './components/product-consult/product-consult.component';

const routes: Routes = [
  { path: '', component: ProductConsultComponent }
];

@NgModule({
  imports:
  [
    RouterModule.forChild(routes),
    CommonModule
  ],
  exports: [
    RouterModule
  ]
})
export class ProductConsultRoutingModule { }