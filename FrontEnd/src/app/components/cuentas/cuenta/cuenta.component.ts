import { Component, OnInit } from '@angular/core';
import { FormGroup,FormBuilder,Validators } from '@angular/forms';
import { CuentaService } from 'src/app/services/cuenta.service';
import { Cuenta } from 'src/app/models/cuenta';
import { ToastrService } from 'ngx-toastr';
import { TipoCuentaService } from 'src/app/services/tipo-cuenta.service';
import { BancoService } from 'src/app/services/banco.service';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-cuenta',
  templateUrl: './cuenta.component.html',
  styleUrls: ['./cuenta.component.css']
})
export class CuentaComponent implements OnInit {

  form:FormGroup;

  constructor(private formBuilder: FormBuilder, private cuentaService:CuentaService,private toastr:ToastrService,public tipoCuentaService:TipoCuentaService,public bancoService:BancoService,public personaService:PersonaService) { 
    this.form=this.formBuilder.group({
      id: 0,
      numeroCuenta:['',[Validators.required,Validators.max(999999999999999),Validators.min(1000000000)]],
      valorInicial:['',[Validators.required,Validators.max(999999999),Validators.min(1000)]],
      clave:['',[Validators.required,Validators.maxLength(4),Validators.minLength(4)]],
      tipoCuenta:['',[Validators.required]],
      banco:['',[Validators.required]],
      persona:['',[Validators.required]],
    })
  }

  ngOnInit(): void {
    this.tipoCuentaService.obtenerTipoCuentas();
    this.bancoService.obtenerBancos();
    this.personaService.obtenerPersonas();
  }

  guardarCuenta(){
    const cuenta: Cuenta = {
      numeroCuenta: this.form.get("numeroCuenta").value,
      valorInicial: this.form.get("valorInicial").value,
      clave: this.form.get("clave").value,
      tipoCuenta: this.form.get("tipoCuenta").value,
      banco: this.form.get("banco").value,
      persona: this.form.get("persona").value
    }

    this.cuentaService.guardarCuenta(cuenta).subscribe(data => {
      this.cuentaService.obtenerCuentas();
      this.toastr.success("Registro Agregado","La cuenta se creo correctamente");
      this.form.reset();
    });
  }
}
