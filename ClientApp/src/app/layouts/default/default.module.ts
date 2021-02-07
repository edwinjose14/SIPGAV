import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';


import { DefaultComponent } from './default.component';
import { HomeComponent } from 'src/app/modules/home/home.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ListTrabajadorComponent } from '../../modules/trabajador/list-trabajador/list-trabajador.component';
import { ListFincaComponent } from '../../modules/finca/list-finca/list-finca.component';
import { ListGanadoComponent } from '../../modules/ganado/list-ganado/list-ganado.component';
import { ListEventoComponent } from '../../modules/evento/list-evento/list-evento.component';
import { ListMaquinaComponent } from '../../modules/maquina/list-maquina/list-maquina.component';



import { FlexLayoutModule } from '@angular/flex-layout';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatDividerModule } from "@angular/material/divider";
import { MatCardModule } from "@angular/material/card";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInput, MatInputModule } from "@angular/material/input";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';



@NgModule({
  declarations: [
    DefaultComponent,
    HomeComponent,
    ListTrabajadorComponent,
    ListFincaComponent,
    ListGanadoComponent,
    ListEventoComponent,
    //ProduccionComponent,
    ListMaquinaComponent,
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    SharedModule,
    MatSidenavModule,
    MatDividerModule,
    FlexLayoutModule,
    MatCardModule,
    MatSnackBarModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ]
})
export class DefaultModule { }
