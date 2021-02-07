import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AutorizacionGuard implements CanActivate {

  constructor(private router: Router,
    private authService: AuthService){

  }

  canActivate(route: ActivatedRouteSnapshot){
    const user = this.authService.userData;
    if (user) {
      return true;
    }
    this.router.navigate(['/Login']);
    return false;
  }

}
