import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { AngularFireStorage } from '@angular/fire/storage';
import { finalize } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { ProductService } from 'src/app/core/services/product/product.service';
import { Product } from 'src/app/Models/product.model';
import {MatDialog} from '@angular/material';
import { AlertDialogComponent } from '../../../@base/alert-dialog/alert-dialog.component';
import { CategoryService } from 'src/app/core/services/category/category.service';
import { Category } from 'src/app/Models/category.model';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})

export class ProductsComponent implements OnInit {

  constructor(
    private categoryService: CategoryService,
    private productService: ProductService,
    private formBuilder: FormBuilder,
    private storage: AngularFireStorage,
    public dialog: MatDialog
    ) { }

  product: Product;
  categorys: Category[];
  categorysFilter: Category[] = [];
  types: Category[] = [];
  formGroup: FormGroup;
  uploadPercent: Observable<number>;
  downloadURL$: Observable<string>;

  ngOnInit() {
    this.buildForm();
    this.getCategorys();
  }

  getCategorys(): void {
    this.categoryService.get().subscribe(res => {
      this.categorys = res;
      this.types = this.categorys.filter(
        (thing, i, arr) => arr.findIndex(t => t.typeProduct.idType === thing.typeProduct.idType) === i);
    });
  }
  change() {
    this.categorysFilter =  this.categorys.filter(c => c.typeProduct.name === this.control.type.value);
  }

  private buildForm() {
    this.product = new Product();
    this.product.idProduct = '';
    this.product.type = 'seleccionar...';
    this.product.description = '';
    this.product.image = '';
    this.product.category = 'seleccionar...';

    this.formGroup = this.formBuilder.group({
      idProduct: [this.product.idProduct, Validators.required],
      type : [this.product.type, [Validators.required, this.validatType]],
      salePrice: [this.product.salePrice, Validators.required],
      purchasePrice: [this.product.purchasePrice, Validators.required],
      quantity: [this.product.quantity, Validators.required],
      iva: [this.product.iva, Validators.required],
      description: [this.product.description, Validators.required],
      image: [this.product.image, Validators.required],
      category: [this.product.category, [Validators.required, this.validatCatagory]]
    });
  }

  private validatType(control: AbstractControl) {
    const type = control.value;
    if (type !== 'seleccionar...' ) { return null; }
    return  {validateType: true, messageType: 'debe seleccionar una tipo'};
  }
  private validatCatagory(control: AbstractControl) {
    const category = control.value;
    if (category !== 'seleccionar...' ) { return null; }
    return  {validateCategory: true, messageCategory: 'debe seleccionar una catagoria'};
  }

  get control() {
    return this.formGroup.controls;
  }

  add() {
    if (this.formGroup.invalid) { return; }
    this.product = this.formGroup.value;
    console.log(this.product);
    this.productService.post(this.product).subscribe(p => {
     if (p != null) {
      this.dialog.open(AlertDialogComponent, {
        width: '250px',
        data: { title: 'Resultado Operacion!', message: 'Producto Creado..!',
                  nameBtnOne: 'Close', nameBtnTwo: 'Aceptar', btnEnable: false}
      });
      this.cleanForm();
     }
     this.product = p;
     console.log(p);

    });
  }

  cleanForm() {
    this.formGroup.reset();
    this.uploadPercent = null;
    this.downloadURL$ = null;
  }

  uploadFile(event) {
    const file = event.target.files[0];
    const filePath = file.name;
    const fileRef = this.storage.ref(filePath);
    console.log(file);
    console.log(filePath);
    const task = this.storage.upload(filePath, file);

    // observe percentage changes
    this.uploadPercent = task.percentageChanges();
    // get notified when the download URL is available
    task.snapshotChanges().pipe(
        finalize(() => {
          this.downloadURL$ = fileRef.getDownloadURL();
          this.downloadURL$.subscribe(url => {
            console.log(url);
            this.formGroup.get('image').setValue(url);
          });
        })

     )
    .subscribe();
  }


}
