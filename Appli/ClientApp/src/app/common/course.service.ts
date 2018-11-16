import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Course } from '../common/course/course.model';

@Injectable()
export class CourseServices {
  constructor(private http: HttpClient) {

  }

  private url: string = 'api/cabinet/course';

  getCourse()  {
    debugger;
    return this.http.get<Course[]>(this.url);
  }


}

