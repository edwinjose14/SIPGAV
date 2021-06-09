import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { User } from "../../../models/user";
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  user: User;
  @Output() toggleSideBarForMe: EventEmitter<any> = new EventEmitter();
  constructor(private authService: AuthService,
              private router: Router) {
                this.authService.userr.subscribe(res=>{
                  this.user = res;
                  if (this.user == null) {
                    console.log('Sesion Cerrada')
                  }else{
                    console.log('Sesion Abierta')
                  }
                });
               }

  ngOnInit(): void {
  }

  toggleSideBar() {
    this.toggleSideBarForMe.emit();
    setTimeout(() => {
      window.dispatchEvent(
        new Event('resize')
      );
    }, 300);
  }

  logout(){
    this.authService.logout();
    this.router.navigate(['/Login']);
  }

  login(){
    this.router.navigate(['/Login']);
  }

}
