import { Component } from '@angular/core';
import { UserServices } from '../../../user.services';
import { User } from '../../../models/user.model';
import { Observable } from 'rxjs';
import { CourseServices } from '../../../../common/course.service';
import { Course } from '../../../../common/course/course.model';


@Component({
  selector: 'app-userincabinet',
  templateUrl: './userincabinet.component.html',
})
export class UserInCabinetComponent {

  usercabinet$: Observable<User>;
  
  constructor(private userServices: UserServices, private courseServices: CourseServices) {
  }

  ngOnInit(){
    this.getUser();
  }

  getUser() {
    this.usercabinet$ = this.userServices.getUser();
  }

}
