import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TransaccionesComponent } from './components/transacciones/transacciones.component';
import { AppComponent } from './app.component';
import { CuentaComponent } from './components/cuentas/cuenta/cuenta.component';
import { CuentasComponent } from './components/cuentas/cuentas.component';

//reglas de ruteo
const routes: Routes = [
  { path: 'transacciones',component: TransaccionesComponent },
  { path: 'cuentas',component: CuentasComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{enableTracing: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
