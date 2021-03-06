import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { Invoice } from 'src/app/Models/Invoice';
import { tap, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) { this.baseUrl = baseUrl; }

  post(invoice: Invoice): Observable<Invoice> {
    return this.http.post<Invoice>(this.baseUrl + 'api/Invoice', invoice)
    .pipe(tap(_ => this.handleErrorService.log('Factura guardada')),
    catchError(this.handleErrorService.handleError<Invoice>('Error al guardar la factura', null))
  ); }

  get(): Observable<Invoice[]> {
    return this.http.get<Invoice[]>(this.baseUrl + 'api/Invoice')
    .pipe(tap(_ => this.handleErrorService.log('Facturas Consultadas..!')),
    catchError(this.handleErrorService.handleError<Invoice[]>('Error al consultar las facturas', null))
    ); }

     getCount(): Observable<number> {
    return this.http.get<number>(this.baseUrl + 'api/WInvoice')
    .pipe(tap(_ => this.handleErrorService.log('Facturas Contadas..!')),
    catchError(this.handleErrorService.handleError<number>('Error al contar las facturas', 0))
    ); }

}
