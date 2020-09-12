import { Component, OnInit } from '@angular/core';
import { CuentaService } from 'src/app/services/cuenta.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-list-cuenta',
  templateUrl: './list-cuenta.component.html',
  styleUrls: ['./list-cuenta.component.css']
})
export class ListCuentaComponent implements OnInit {

  constructor(public cuentaService:CuentaService,public toastr:ToastrService) { }

  ngOnInit(): void {
    this.cuentaService.obtenerCuentas();
  }

   eliminarCuenta(id:number){
    if(confirm('Esta seguro que desea eliminar el registro?')){
        this.cuentaService.eliminarCuenta(id).subscribe(data=>{
            this.toastr.warning('Registro eliminado','La cuenta fue eliminada')
            this.cuentaService.obtenerCuentas();
        });
    }
  }

}
