import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../core/services/auth/authentication.service';

@Injectable({
  providedIn: 'root'
})
export class AuthDomiciliaryGuard implements CanActivate {
  constructor(
    private router: Router,
    private authenticationService: AuthenticationService
  ) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const currentUser = this.authenticationService.currentUserValue;
    if (currentUser) {
      if ( currentUser.role === 'Domiciliary' ) {
        return true;
      } else {
        this.router.navigate(['/home'], { queryParams: { returnUrl: state.url } });
        return false;
      }
      // authorised so return true
    }

      // not logged in so redirect to login page with the return url
      this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
      return false;
    }
}
