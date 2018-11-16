import { Component, OnInit } from "@angular/core";
import { CourseServices } from '../../common/course.service';
import { Course } from '../../common/course/course.model';
import { Router } from '@angular/router';



@Component({
  selector: 'app-course',
  templateUrl: './course.component.html'
  //styleUrls: ['./user.component.css']
})
export class CourseComponent {

  constructor(private courseServices: CourseServices, private  router: Router) { }
  courses: Course[];

  ngOnInit() {
    this.getCourse();
  }

  getCourse() {
    debugger;
    this.courseServices.getCourse().subscribe(resp => {
      this.courses = resp;
      console.log('Это курс ' + this.courses);
    });
  }
}

