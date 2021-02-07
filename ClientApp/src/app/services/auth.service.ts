import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Login } from '../models/login';
import { User } from '../models/user';
import { map } from 'rxjs/operators';
import { Response } from '../models/response';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private userSubject: BehaviorSubject<User>;
  public userr: Observable<User>;

  public get userData(): User{
    return this.userSubject.value;
  }
  baseUrl:string;
  constructor(private _http: HttpClient,
  @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('usuario')));
    this.userr = this.userSubject.asObservable();
  }

  login(login: Login): Observable<Response> {
    return this._http.post<Response>(`${this.baseUrl}${'api/Login'}`, login, httpOptions).pipe(map(res=>{
        if (res.exito ===1) {
        const user:User = res.data;
        localStorage.setItem('usuario', JSON.stringify(user));
        this.userSubject.next(user);
        }
        return res;
    }))
  }

  logout(){
    localStorage.removeItem('usuario');
    this.userSubject.next(null);
  }
}
