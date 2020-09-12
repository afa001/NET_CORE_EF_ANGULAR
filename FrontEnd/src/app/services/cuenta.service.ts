import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cuenta } from '../models/cuenta';
import {BehaviorSubject} from 'rxjs';

@Injectable({
  providedIn: 'root'
})

//configuramos el servicio
export class CuentaService {
  myAppUrl = 'https://localhost:44393/';
  myApiUrl = 'api/Cuenta/';
  list: Cuenta[];
  
  constructor(private http: HttpClient) { }

  guardarCuenta(cuenta: Cuenta):Observable<Cuenta>{
    return this.http.post<Cuenta>(this.myAppUrl+this.myApiUrl,cuenta)
  }

  obtenerCuentas() {
    this.http.get(this.myAppUrl + this.myApiUrl).toPromise()
                  .then(data => {
                    //console.log(data);
                    this.list = data as Cuenta[];
                  });
  }

  eliminarCuenta(id:number): Observable<Cuenta> {
    return this.http.delete<Cuenta>(this.myAppUrl+this.myApiUrl+id);
  }
}
