import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loading: boolean = false;

  public formLogin = this.fb.group({
    correo: ['', Validators.required],
    password: ['', Validators.required]
  });

  constructor(private authService: AuthService,
    private router: Router,
    private fb: FormBuilder,
    private snack: MatSnackBar) {
      if (this.authService.userData) {
        this.router.navigate(['/'])
      }
    }

  ngOnInit(): void {


  }

  Login(){
    this.authService.login(this.formLogin.value).subscribe(response => {
      if (response.exito === 1) {
        this.loading = true;
        setTimeout(()=>{
          this.router.navigate(['/'])
        }, 1500)
     }
     if(response.exito === 0){
      this.snack.open(response.mensaje,'',{
        duration:4000
      });
      this.formLogin.reset();
     }
      this.snack.open('Has Iniciado Sesion como '+response.data['correo'],'',{
        duration:4000
      });
    })
  }

  Logout(){
    this.authService.logout();
  }

}
