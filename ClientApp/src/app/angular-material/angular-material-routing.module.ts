import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DefaultComponent } from '../layouts/default/default.component';
import { DashboardPrincipalComponent } from '../modules/dashboard/dashboard-principal/dashboard-principal.component';
import { ListEventoComponent } from '../modules/evento/list-evento/list-evento.component';
import { ListFincaComponent } from '../modules/finca/list-finca/list-finca.component';
import { ListGanadoComponent } from '../modules/ganado/list-ganado/list-ganado.component';
import { ListMaquinaComponent } from '../modules/maquina/list-maquina/list-maquina.component';
import { ListProduccionComponent } from '../modules/produccion/list-produccion/list-produccion.component';
import { ListTrabajadorComponent } from '../modules/trabajador/list-trabajador/list-trabajador.component';
import { AutorizacionGuard } from '../Security/autorizacion.guard';

const routes: Routes = [

    {
      path: '',
      component: DefaultComponent,
      canActivate: [AutorizacionGuard],
      children:[
        {
          path:'',
          component: DashboardPrincipalComponent,
          canActivate: [AutorizacionGuard]
        },
      {
        path:'Trabajadores',
        component: ListTrabajadorComponent,
        canActivate: [AutorizacionGuard]
      },
      {
        path:'Animales',
        component: ListGanadoComponent,
        canActivate: [AutorizacionGuard]
      },
      {
        path:'Eventos',
        component: ListEventoComponent,
        canActivate: [AutorizacionGuard]
      },
      {
        path:'Fincas',
        component: ListFincaComponent,
        canActivate: [AutorizacionGuard]
      },
      {
        path:'Produccion',
        component: ListProduccionComponent,
        canActivate: [AutorizacionGuard]
      },
      {
        path:'Maquinas',
        component: ListMaquinaComponent,
        canActivate: [AutorizacionGuard]
      }]
    },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AngularMaterialRoutingModule { }
