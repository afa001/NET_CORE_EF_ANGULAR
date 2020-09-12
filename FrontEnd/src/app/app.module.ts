import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CuentasComponent } from './components/cuentas/cuentas.component';
import { CuentaComponent } from './components/cuentas/cuenta/cuenta.component';
import { ListCuentaComponent } from './components/cuentas/list-cuenta/list-cuenta.component';
import { FooterComponent } from './components/footer/footer.component';
import { TransaccionesComponent } from './components/transacciones/transacciones.component';
import { RouterModule, Router } from '@angular/router';
import { PersonasComponent } from './components/personas/personas.component';
import { TipoCuentasComponent } from './components/tipo-cuentas/tipo-cuentas.component';
import { BancosComponent } from './components/bancos/bancos.component';
import { HeaderComponent } from './components/header/header.component';
import { ContentComponent } from './components/content/content.component';

@NgModule({
declarations: [
  AppComponent,
  CuentasComponent,
  CuentaComponent,
  ListCuentaComponent,
  TransaccionesComponent,
  FooterComponent,
  PersonasComponent,
  TipoCuentasComponent,
  BancosComponent,
  HeaderComponent,
  ContentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    RouterModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
