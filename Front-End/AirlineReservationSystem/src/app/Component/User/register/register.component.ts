import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/Models/User/user';
import { UserService } from 'src/app/Services/User/user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  user: User

  constructor(private userservice: UserService, private router: Router) {
    this.user = new User();
  }

  ngOnInit(): void {

  }
  
  registerUser() {
    this.userservice.RegisterUser(this.user).subscribe(res => {
      if (res) {
        console.log(res)
        Swal.fire(
          'User Registration',
          'Registered Successfully',
          'success'
        )
        this.router.navigate(['login'])
      }
    })
  }
}
