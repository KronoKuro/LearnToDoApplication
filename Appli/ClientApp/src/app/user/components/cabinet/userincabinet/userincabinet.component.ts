import { Component } from '@angular/core';
import { UserServices } from '../../../user.services';
import { User } from '../../../models/user.model';


@Component({
  selector: 'app-userincabinet',
  templateUrl: './userincabinet.component.html',
})
export class UserInCabinetComponent {
  
  usercabinet: User;

  constructor(private userServices: UserServices) {
  }

  ngOnInit(){
    this.getUser();
  }

  getUser(){
     this.userServices.getUser().subscribe(resp => {
       this.usercabinet = resp;
     });
  }

}
