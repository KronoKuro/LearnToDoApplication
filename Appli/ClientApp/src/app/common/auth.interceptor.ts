import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Router } from '@angular/router';


@Injectable()

export class AuthInterceptor implements HttpInterceptor {
  
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const mod = req.clone({ setHeaders: { 'Authorization': `Bearer ${localStorage.getItem('access_token')}` } });
    return next.handle(mod);
   /* .catch((error) => {
      if (error.status == 401) {
        localStorage.clear();
    //    this.router.navigate(['login']);
        return Observable.throw(error);
      } else {
        return Observable.throw(error);
      }
    })as any;*/
  }
}
