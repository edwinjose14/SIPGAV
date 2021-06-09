import { HttpClient, HttpEventType, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable, EventEmitter, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Response } from "../models/response";
import { Trabajador } from '../models/trabajador';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class TrabajadorService {

  baseUrl: string;
  constructor(private _http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
      this.baseUrl = baseUrl;
  }

  getTrabajadores(): Observable<Response> {
    return this._http.get<Response>(`${this.baseUrl}api/Trabajador`);
  }

  getOneTrabajador(identificacion: string): Observable<Response> {
    return this._http.get<Response>(`${this.baseUrl}api/Trabajador/${identificacion}`);
  }

  addTrabajador(trabajador: Trabajador): Observable<Response>{
   return this._http.post<Response>(`${this.baseUrl}api/Trabajador`, trabajador, httpOptions);
  }

  editTrabajador(trabajador: Trabajador): Observable<Response>{
   return this._http.put<Response>(`${this.baseUrl}api/Trabajador`, trabajador, httpOptions);
  }

  deleteTrabajador(identificacion : string): Observable<Response>{
   return this._http.delete<Response>(`${this.baseUrl}api/Trabajador/${identificacion}`);
  }

}
