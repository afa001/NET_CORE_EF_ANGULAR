import { Component, OnInit } from '@angular/core';
import { TipoCuentaService } from 'src/app/services/tipo-cuenta.service';

@Component({
  selector: 'app-tipo-cuentas',
  templateUrl: './tipo-cuentas.component.html',
  styleUrls: ['./tipo-cuentas.component.css']
})
export class TipoCuentasComponent implements OnInit {

  constructor(public tipoService:TipoCuentaService) { }

  ngOnInit(): void {
    this.tipoService.obtenerTipoCuentas();
  }

}
