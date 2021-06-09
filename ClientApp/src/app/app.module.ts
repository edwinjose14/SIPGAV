import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DefaultModule } from './layouts/default/default.module';
import { AppRoutingModule } from './app-routing.module';
import { LoginComponent } from './modules/login/login.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './Security/jwt.interceptor';


import { InfoEventoComponent } from './modules/evento/info-evento/info-evento.component';
import { ModalEventoComponent } from './modules/evento/modal-evento/modal-evento.component';
import { ModalFincaComponent } from './modules/finca/modal-finca/modal-finca.component';
import { InfoFincaComponent } from './modules/finca/info-finca/info-finca.component';
import { InfoMaquinaComponent } from './modules/maquina/info-maquina/info-maquina.component';
import { ModalMaquinaComponent } from './modules/maquina/modal-maquina/modal-maquina.component';
import { ModalGanadoComponent } from './modules/ganado/modal-ganado/modal-ganado.component';
import { InfoGanadoComponent } from './modules/ganado/info-ganado/info-ganado.component';
import { InfoTrabajadorComponent } from './modules/trabajador/info-trabajador/info-trabajador.component';
import { ModalTrabajadorComponent } from './modules/trabajador/modal-trabajador/modal-trabajador.component';
import { DashboardPrincipalComponent } from './modules/dashboard/dashboard-principal/dashboard-principal.component';
import { ModalDeleteComponent } from './modules/common/modal-delete/modal-delete.component';
import { ListProduccionComponent } from './modules/produccion/list-produccion/list-produccion.component';
import { ModalProduccionComponent } from './modules/produccion/modal-produccion/modal-produccion.component';
import { InfoProduccionComponent } from './modules/produccion/info-produccion/info-produccion.component';
import { AngularMaterialModule } from './angular-material/angular-material.module';
import { ListTrabajadorComponent } from './modules/trabajador/list-trabajador/list-trabajador.component';
import { ListFincaComponent } from './modules/finca/list-finca/list-finca.component';
import { ListGanadoComponent } from './modules/ganado/list-ganado/list-ganado.component';
import { ListEventoComponent } from './modules/evento/list-evento/list-evento.component';
import { ListMaquinaComponent } from './modules/maquina/list-maquina/list-maquina.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    InfoEventoComponent,
    ModalEventoComponent,
    ModalFincaComponent,
    InfoFincaComponent,
    InfoMaquinaComponent,
    ModalMaquinaComponent,
    ModalGanadoComponent,
    InfoGanadoComponent,
    InfoTrabajadorComponent,
    ModalTrabajadorComponent,
    DashboardPrincipalComponent,
    ModalDeleteComponent,
    ListProduccionComponent,
    ModalProduccionComponent,
    InfoProduccionComponent,
    ListTrabajadorComponent,
    ListFincaComponent,
    ListGanadoComponent,
    ListEventoComponent,
    ListMaquinaComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    AppRoutingModule,
    NgbModule,
    DefaultModule,
    AngularMaterialModule,

  ],
  providers: [{provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi:true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
