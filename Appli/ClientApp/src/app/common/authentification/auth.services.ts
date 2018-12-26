import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthServices {
  
  constructor(private  http: HttpClient) {  }
  isAuthentificated:boolean = false;

  login(data: any) {
    return this.http.post('api/token', data);
  }

  checkAcess() {
     this.http.get<any>('api/checktoken').toPromise().then((res) => { 
       this.isAuthentificated = res;
    },(err) => {
      console.log('это ошибка от сервера ' + err.message);
      this.isAuthentificated = false;
      localStorage.clear();
      return false;
      });
    return this.isAuthentificated;
  }

  register(data: any) {
    return this.http.post('api/register', data);
  }

}
