export interface Trabajador {
  identificacion : string;
  idFinca: string;
  primerApellido: string;
  segundoApellido: string;
  nombres: string;
  sexo: string;
  fechaNacimiento: Date;
  edad: number;
  telefono: string;
  correo: string;
  password: string;
  eps: string;
  fechaIngreso: Date;
  fechaSalida ?: Date;
  estado: string;
  salario: number;
  foto ?: string;

}

