import { Component } from '@angular/core';
import { UserServices } from '../../../user.services';
import { User } from '../../../models/user.model';


@Component({
  selector: 'app-userincabinet',
  templateUrl: './userincabinet.component.html',
})
export class UserInCabinetComponent {
  
  user: User;

  constructor(private userServices: UserServices) {
  }

  ngOnInit(){
    const id = localStorage.getItem('id');
    this.getUser(id);
  }

  getUser(id: string){
     this.userServices.getUser(id).subscribe(resp => {
        this.user = resp;
     });
  }

}
