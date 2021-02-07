import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DefaultComponent } from './layouts/default/default.component';
import { HomeComponent } from './modules/home/home.component';
import { ListTrabajadorComponent } from './modules/trabajador/list-trabajador/list-trabajador.component';
import { ListGanadoComponent } from './modules/ganado/list-ganado/list-ganado.component';
import { ListEventoComponent } from './modules/evento/list-evento/list-evento.component';
import { ListFincaComponent } from './modules/finca/list-finca/list-finca.component';
import { ListMaquinaComponent } from './modules/maquina/list-maquina/list-maquina.component';


const routes: Routes = [{
  path: '',
  component: DefaultComponent,
    children:[{
      path: '',
      component: HomeComponent
    },
    {
      path:'Trabajadores',
      component: ListTrabajadorComponent
    },
    {
      path:'Animales',
      component: ListGanadoComponent
    },
    {
      path:'Eventos',
      component: ListEventoComponent
    },
    {
      path:'Fincas',
      component: ListFincaComponent
    },
    {
      path:'Produccion',
      component: ListEventoComponent
    },
    {
      path:'Maquinas',
      component: ListMaquinaComponent
    }
  ]
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
