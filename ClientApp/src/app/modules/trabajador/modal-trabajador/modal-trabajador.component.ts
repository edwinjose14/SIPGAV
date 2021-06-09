import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Trabajador } from 'src/app/models/trabajador';
import { TrabajadorService } from 'src/app/services/trabajador.service';



@Component({
  selector: 'app-modal-trabajador',
  templateUrl: './modal-trabajador.component.html',
  styleUrls: ['./modal-trabajador.component.css']
})
export class ModalTrabajadorComponent implements OnInit {

  public identificacion: string;
  public idFinca: string;
  public primerApellido: string;
  public segundoApellido: string;
  public nombres: string;
  public sexo: string;
  public fechaNacimiento: Date;
  public edad: number;
  public telefono: string;
  public correo: string;
  public password: string;
  public eps: string;
  public fechaIngreso: Date;
  public salario: number;
  public estado: string;
  public foto: string;

  baseUrl:string;
  progress: number;
  message: string;
  @Output() public onUploadFinished = new EventEmitter();


  constructor(private modal: MatDialogRef<ModalTrabajadorComponent>,
    private trabajadorService: TrabajadorService,
    private snack: MatSnackBar,
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    @Inject(MAT_DIALOG_DATA)
    public trabajador: Trabajador) {
     this.baseUrl = baseUrl;
      if (this.trabajador !== null) {
        this.identificacion = trabajador.identificacion
        this.idFinca = trabajador.idFinca
        this.primerApellido = trabajador.primerApellido
        this.segundoApellido = trabajador.segundoApellido
        this.nombres = trabajador.nombres
        this.sexo = trabajador.sexo
        this.fechaNacimiento = trabajador.fechaNacimiento
        this.edad = trabajador.edad
        this.telefono = trabajador.telefono
        this.correo = trabajador.correo
        this.password = trabajador.password
        this.eps = trabajador.eps
        this.fechaIngreso = trabajador.fechaIngreso
        this.salario = trabajador.salario
        this.estado = trabajador.estado
        this.foto = trabajador.foto
      }
     }

  ngOnInit(): void {

  }

  closeModal(){
    this.modal.close();
  }

  addTrabajador(){
    const trabajador: Trabajador = {identificacion: this.identificacion, idFinca:this.idFinca, primerApellido: this.primerApellido, segundoApellido: this.segundoApellido, nombres: this.nombres, sexo: this.sexo, fechaNacimiento: this.fechaNacimiento, edad: this.edad, telefono: this.telefono, correo: this.correo, password: this.password, eps: this.eps, fechaIngreso: this.fechaIngreso, salario: this.salario, estado: this.estado, foto: this.foto};
    this.trabajadorService.addTrabajador(trabajador).subscribe(response=>{
      if (response.exito === 1) {
        this.modal.close();
        this.snack.open(response.mensaje, '',{duration: 2000});
      }
    });
  }


  editTrabajador(){
    const trabajador: Trabajador = {identificacion: this.identificacion, idFinca:this.idFinca, primerApellido: this.primerApellido, segundoApellido: this.segundoApellido, nombres: this.nombres, sexo: this.sexo, fechaNacimiento: this.fechaNacimiento, edad: this.edad, telefono: this.telefono, correo: this.correo, password: this.password, eps: this.eps, fechaIngreso: this.fechaIngreso, salario: this.salario, estado: this.estado, foto: this.foto};
    this.trabajadorService.editTrabajador(trabajador).subscribe(response=>{
      if (response.exito === 1) {
        this.modal.close();
        this.snack.open(response.mensaje, '',{duration: 2000});
      }
    });
  }




  public uploadFile = (files) => {
    if (files.length === 0) {
        return;
    }

    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    this.http.post(this.baseUrl +'api/Trabajador/UploadPhoto', formData,{ reportProgress: true, observe: 'events' })
    .subscribe(event => {

        if (event.type === HttpEventType.UploadProgress)
            this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
            this.message = 'Upload success.';
            this.onUploadFinished.emit(event.body);
        }
    });
  }
  CalculateAge(): number {
    const today: Date = new Date();
    const birthDate: Date = new Date(this.fechaNacimiento);
    this.edad = today.getFullYear() - birthDate.getFullYear();
    const month: number = today.getMonth() - birthDate.getMonth();
    if (month < 0 || (month === 0 && today.getDate() < birthDate.getDate())) {
      this.edad--;
    }
    return this.edad;
}

}
