import { Component } from '@angular/core';
import { UserServices } from '../../../user/user.services';
import { User } from '../../../user/models/user.model';

@Component({
  selector: 'app-admin_user',
  templateUrl: './usercontrol.component.html',
  styleUrls: ['./usercontrol.component.css']
})
export class UserControlComponent {

  users: User[];

  constructor(private userServices: UserServices) {

  }

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this.userServices.getUsers().subscribe(responce => {
      this.users = responce;
    });
  }


}
