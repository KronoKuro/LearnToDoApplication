import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './models/user.model';



@Injectable()
export class UserServices {

  constructor(private http: HttpClient) {}

  private url: string = 'api/cabinet/user';

  getUser(id: string) {
    return this.http.get<User>(this.url + '/' + id);
  }

  getUsers() {
    return this.http.get<User[]>('api/admin/overview');
  }

}
