import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

import { SalesComponent } from './sales/sales.component';
import { UsersComponent } from './users/users.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { BeefCutsComponent } from './beef-cuts/beef-cuts.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
  { path: '', loadChildren: () => import('./home/home.module').then(m => m.HomeModule)},
  { path: 'home', loadChildren: () => import('./home/home.module').then(m => m.HomeModule)},
  { path: 'clients', loadChildren: () => import('./clients/clients.module').then(m => m.ClientsModule)},
  { path: 'invoice', loadChildren: () => import('./invoice/invoice.module').then(m => m.InvoiceModule)},
  {
    path: 'products/register', loadChildren: () => import('./products/products.module').then(m => m.ProductsModule)
  },
  {
    path: 'products/consult', loadChildren: () => import('./product-consult/product-consult.module').then(m => m.ProductConsultModule)
  },
  { path: 'sales', component: SalesComponent},
  { path: 'users', component: UsersComponent},
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'beef-cuts', component: BeefCutsComponent },
  { path: 'pork-cuts', loadChildren: () => import('./pork-cuts/pork-cuts.module').then(m => m.PorkCutsModule)},
  { path: '**', component: PageNotFoundComponent},
];




@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes, {
      preloadingStrategy: PreloadAllModules
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
