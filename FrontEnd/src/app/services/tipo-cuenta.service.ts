import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TipoCuenta } from '../models/tipoCuenta';

@Injectable({
  providedIn: 'root'
})
export class TipoCuentaService {
  myAppUrl = 'https://localhost:44393/';
  myApiUrl = 'api/TipoCuenta/';
  list: TipoCuenta[];

  constructor(private http: HttpClient) { }

  obtenerTipoCuentas() {
    this.http.get(this.myAppUrl + this.myApiUrl).toPromise()
                  .then(data => {
                    //console.log(data);
                    this.list = data as TipoCuenta[];
                  });
  }
}
