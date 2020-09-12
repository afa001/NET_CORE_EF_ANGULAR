import { Component, OnInit } from '@angular/core';
import { FormGroup,FormBuilder,Validators } from '@angular/forms';
import { TransaccionService } from 'src/app/services/transaccion.service';
import { Transaccion } from 'src/app/models/transaccion';
import { CuentaService } from 'src/app/services/cuenta.service';
import { Cuenta } from 'src/app/models/cuenta';

@Component({
  selector: 'app-transacciones',
  templateUrl: './transacciones.component.html',
  styleUrls: ['./transacciones.component.css']
})
export class TransaccionesComponent implements OnInit {

  form:FormGroup;
  transaccion:Number;

  constructor(private formBuilder: FormBuilder, private transaccionService:TransaccionService,public cuentaService:CuentaService) {
    this.form=this.formBuilder.group({
      id: 0,
      tipo:['',[Validators.required]],
      numeroCuentaTransaccion:['',[Validators.max(999999999999999),Validators.min(1000000000)]],
      cuenta:['',[Validators.required]],
      valor:[null,[Validators.required,Validators.max(999999999),Validators.min(1000)]],
    })
  }
  
  ngOnInit(): void {
    this.cuentaService.obtenerCuentas();
  }

  guardarTransaccion(){
    const transaccion: Transaccion = {
      tipo: this.form.get("tipo").value,
      numeroCuentaTransaccion: this.form.get("numeroCuentaTransaccion").value,
      cuenta: this.form.get("cuenta").value,
      valor: this.form.get("valor").value
    }

    this.transaccionService.guardarTransaccion(transaccion).subscribe(data => {
      console.log("Guardado exitosamente")
      this.form.reset();
    });
  }

}
