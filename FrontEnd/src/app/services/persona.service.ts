import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Persona } from '../models/persona';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {
  myAppUrl = 'https://localhost:44393/';
  myApiUrl = 'api/Persona/';
  list: Persona[];

  constructor(private http: HttpClient) { }

  obtenerPersonas() {
    this.http.get(this.myAppUrl + this.myApiUrl).toPromise()
                  .then(data => {
                    //console.log(data);
                    this.list = data as Persona[];
                  });
  }
}
