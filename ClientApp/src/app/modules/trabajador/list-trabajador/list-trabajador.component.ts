import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, Inject, OnInit, Output, EventEmitter, ViewChild} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from "@angular/material/table";
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import { Trabajador } from 'src/app/models/trabajador';
import { TrabajadorService } from 'src/app/services/trabajador.service';
import { ModalDeleteComponent } from '../../common/modal-delete/modal-delete.component';
import { InfoTrabajadorComponent } from '../info-trabajador/info-trabajador.component';
import { ModalTrabajadorComponent } from '../modal-trabajador/modal-trabajador.component';

@Component({
  selector: 'app-list-trabajador',
  templateUrl: './list-trabajador.component.html',
  styleUrls: ['./list-trabajador.component.css']
})
export class ListTrabajadorComponent implements OnInit {

  progress: number;
  message: string;
  baseUrl: string;
  dataSource : MatTableDataSource<Trabajador>

  @Output() public onUploadFinished = new EventEmitter();
  public id: string;
  public list: Trabajador[]=[];
  public columnas: string[]=['Identificacion', 'IdFinca','Apellidos', 'Nombres', 'Sexo','Edad', 'Telefono', 'Correo', 'Eps', 'FechaIngreso', 'Estado', 'Salario', 'Foto', 'Acciones'];
  readonly width:string = '850px';

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private trabajadorService: TrabajadorService,
              private modal: MatDialog,
              private snack: MatSnackBar,
              private http: HttpClient,
              @Inject('BASE_URL') baseUrl: string) {
              this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.getTrabajadores()
  }


  getTrabajadores(){
    this.trabajadorService.getTrabajadores().subscribe(response => {
      this.dataSource = new MatTableDataSource(response.data)
    });
  }
/*
  getOneTrabajador(id : string){
    this.trabajadorService.getOneTrabajador(id).subscribe(response=>{
      this.dataSource=response.data
    });
  }
*/
  openModalAdd(){
    const _modal = this.modal.open(ModalTrabajadorComponent, {
      width: this.width
    });
    _modal.afterClosed().subscribe(res=>{
      this.getTrabajadores();
    });
  }

  openModalEdit(trabajador: Trabajador){
    const _modal = this.modal.open(ModalTrabajadorComponent, {
      width: this.width,
      data: trabajador
    });
    _modal.afterClosed().subscribe(res=>{
      this.getTrabajadores();
    });
  }

  openModalInfo(trabajador: Trabajador){
    const _modal = this.modal.open(InfoTrabajadorComponent, {
      width: this.width,
      data: trabajador
    });
    _modal.afterClosed().subscribe(res=>{
      this.getTrabajadores();
    });
  }


  deleteTrabajador(trabajador: Trabajador){
    const _modal = this.modal.open(ModalDeleteComponent, {
      width: this.width,

    });
    _modal.afterClosed().subscribe(res=>{
      if (res) {
        this.trabajadorService.deleteTrabajador(trabajador.identificacion).subscribe(res=>{
          if (res.exito === 1) {
            this.snack.open(res.mensaje,'',{
              duration:2000
            });
            this.getTrabajadores();
          }
        });
      }

    });
  }


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
}
