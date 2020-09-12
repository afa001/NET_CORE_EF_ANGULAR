import { Component, OnInit } from '@angular/core';
import { BancoService } from 'src/app/services/banco.service';

@Component({
  selector: 'app-bancos',
  templateUrl: './bancos.component.html',
  styleUrls: ['./bancos.component.css']
})
export class BancosComponent implements OnInit {

  constructor(public bancoService:BancoService) { }

  ngOnInit(): void {
    this.bancoService.obtenerBancos();
  }

}
