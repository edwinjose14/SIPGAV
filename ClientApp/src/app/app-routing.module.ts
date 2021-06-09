import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AutorizacionGuard } from "./Security/autorizacion.guard";
import { DefaultComponent } from './layouts/default/default.component';
import { HomeComponent } from './modules/home/home.component';
import { ListTrabajadorComponent } from './modules/trabajador/list-trabajador/list-trabajador.component';
import { ListGanadoComponent } from './modules/ganado/list-ganado/list-ganado.component';
import { ListEventoComponent } from './modules/evento/list-evento/list-evento.component';
import { ListFincaComponent } from './modules/finca/list-finca/list-finca.component';
import { ListMaquinaComponent } from './modules/maquina/list-maquina/list-maquina.component';
import { LoginComponent } from './modules/login/login.component';
import { DashboardPrincipalComponent } from './modules/dashboard/dashboard-principal/dashboard-principal.component'
import { ListProduccionComponent } from './modules/produccion/list-produccion/list-produccion.component';


const routes: Routes = [
  {
    path:'Login',
    component: LoginComponent,
  },
  {
    path: '',
    loadChildren: () => import('./angular-material/angular-material.module').then(x => x.AngularMaterialModule)
  },
  {
    path: '**',
    loadChildren: () => import('./angular-material/angular-material.module').then(x => x.AngularMaterialModule)
  }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),
    CommonModule
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
