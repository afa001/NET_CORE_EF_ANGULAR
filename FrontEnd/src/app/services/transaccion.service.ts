import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Transaccion } from '../models/transaccion';
import {BehaviorSubject} from 'rxjs';

@Injectable({
  providedIn: 'root'
})

//configuramos el servicio
export class TransaccionService {
  myAppUrl = 'https://localhost:44393/';
  myApiUrl = 'api/Transaccion/';
  private obtener = new BehaviorSubject<Transaccion>({} as any);

  constructor(private http: HttpClient) { }

  guardarTransaccion(transaccion: Transaccion):Observable<Transaccion>{
    return this.http.post<Transaccion>(this.myAppUrl+this.myApiUrl,transaccion)
  }
}
