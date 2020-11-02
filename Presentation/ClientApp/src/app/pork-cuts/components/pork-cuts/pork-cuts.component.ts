import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/core/services/product/product.service';
import { Product } from 'src/app/Models/product.model';

@Component({
  selector: 'app-pork-cuts',
  templateUrl: './pork-cuts.component.html',
  styleUrls: ['./pork-cuts.component.css']
})
export class PorkCutsComponent implements OnInit {

  constructor(private productService: ProductService) { }

  products: Product[];

  ngOnInit() {

    this.products = this.productService.getAllProducts();
  }

  addCart() {
    console.log('añadir al carrito');
  }

}
