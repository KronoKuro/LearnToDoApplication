import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthServices } from '../auth.services';
import { Router } from '@angular/router';



@Component({
  selector: 'app-register',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements  OnInit {

  registerForm: FormGroup;
  @Input() Password = '';
  @Input() confirmedPassword = '';


  constructor(private authService: AuthServices, private router: Router) {
    this.registerForm = new FormGroup({
        'Login': new FormControl('', [Validators.required, Validators.minLength(6)]),
        'Password': new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(15)]),
        'LastName': new FormControl(null, Validators.required),
        'FirstName': new FormControl(null, Validators.required),
        'Email': new FormControl(null, [Validators.required, Validators.pattern("[a-zA-Z_]+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}")]),
      'confirmedPassword': new FormControl(null, [Validators.required, this.passwordsMatch(this.Password, this.confirmedPassword).bind(this)])
    });
  }

  register() {
    debugger;
    if (this.registerForm.valid) {
      this.authService.register(this.registerForm.getRawValue()).subscribe(resp => {
          console.log(this.registerForm);

          this.router.navigate(['login']);
        },
        error => {
          alert(error['error']);
        });
      alert('form submitted');
    } else {
      alert('Ошибка заполнения полей'); //{7}
    }
   
  }

  ngOnInit() {

  }

  passwordsMatch(password: string, confirmedPassword: string) {

    return (control: FormControl): { [s: string]: boolean } => {
      //getting undefined values for both variables
      console.log(password, confirmedPassword);
      //if I change this condition to === it throws the error if the 
      //  two fields are the same, so this part works
      if (password !== confirmedPassword) {
        return { 'passwordMismatch': true }
      } else {
        //it always gets here no matter what
        return null;
      }
    }
  }

}
