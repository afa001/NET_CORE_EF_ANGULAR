import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Banco } from '../models/banco';

@Injectable({
  providedIn: 'root'
})
export class BancoService {
  myAppUrl = 'https://localhost:44393/';
  myApiUrl = 'api/Banco/';
  list: Banco[];

  constructor(private http: HttpClient) { }

  obtenerBancos() {
    this.http.get(this.myAppUrl + this.myApiUrl).toPromise()
                  .then(data => {
                    //console.log(data);
                    this.list = data as Banco[];
                  });
  }
}
