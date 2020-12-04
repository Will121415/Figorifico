import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { MaterialModule } from '../material/material.module';
import { BoostrapModule } from '../boostrap/boostrap.module';
import { FilterProductsPipe } from '../pipe/filter-products.pipe';

@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    NavMenuComponent,
    FilterProductsPipe
  ],
  exports: [
    HeaderComponent,
    FooterComponent,
    NavMenuComponent,
    FilterProductsPipe
  ],
  imports: [
    CommonModule,
    RouterModule,
    MaterialModule,
    BoostrapModule
  ]
})
export class SharedModule { }
