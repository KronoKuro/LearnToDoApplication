import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router";
import { AuthServices } from "./authentification/auth.services";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import * as decode from 'jwt-decode';





@Injectable()
export class AuthGuard implements CanActivate {

  constructor(public authService: AuthServices, public router: Router) { 
    
  }

  public message: string = '';
  public IsAuthentificated: boolean = false;

  canActivate(router: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean{
    const expectedRole = router.data.expectedRole;
    if(expectedRole == null)
      return false;
    
    const token = localStorage.getItem('access_token');
    if(token == null){
      this.router.navigate(['login']);
      return false;
    } 
      
    const tokenPayLoad = decode(token);
    
    if (!this.getAccess() || tokenPayLoad.role != expectedRole) {
      this.router.navigate(['login']);
      return false;
    }
    return true;
  }

  async getAccess() {
    return await this.authService.checkAcess();
  }


  IsAdmin() {
    const token = localStorage.getItem('access_token');
    if (token != null) {
      const tokenPayLoad = decode(token);
      if (tokenPayLoad.role === "Admin") {
        return true;
      }
      else {
        return false;
      }
    }
    return false;
  }

}
