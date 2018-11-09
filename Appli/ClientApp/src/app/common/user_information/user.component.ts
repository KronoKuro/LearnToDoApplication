import { Component, OnInit } from "@angular/core";
import { UserServices } from '../../user/user.services';
import { User } from '../../user/models/user.model';
import { Router } from '@angular/router';



@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
/*  styleUrls: ['./user.component.css']*/
})
export class UserComponent {

  constructor(private userServices: UserServices, private  router: Router) { }
  user: User;
  isHasUser: boolean;

  ngOnInit() {
    const id = localStorage.getItem('id');
    this.getUser(id);
  }

  getUser(id: string) {
    debugger;
    this.userServices.getUser(id).subscribe(resp => {
      this.user = resp;
      console.log(this.user);
      if (this.user != null) {
        debugger;
        this.isHasUser = true;
      } else {
        this.isHasUser = false;
      }
    });
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['login']);
  }


}

