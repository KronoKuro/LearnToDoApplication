import { Component, OnInit } from "@angular/core";
import { CourseServices } from '../../common/course.service';
import { Course } from '../../common/course/course.model';
import { Router } from '@angular/router';
import { HttpClient} from '@angular/common/http';


@Component({
  selector: 'app-course',
  templateUrl: './course.component.html'
  //styleUrls: ['./user.component.css']
})
export class CourseComponent implements OnInit {

  constructor(private courseServices: CourseServices, private http: HttpClient, private router: Router) {
   // this.getCourse();
  }

  courses: Course[];

  ngOnInit() {
    this.getCourse();
  }

  getCourse() {
    return this.courseServices.getCourse().subscribe(resp => {
      this.courses = resp;
      console.log('Тут курс');
      console.log(this.courses);
    });
  }
}

