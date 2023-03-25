import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/app/Models/User/Login/login';
import { UserService } from 'src/app/Services/User/user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login: Login

  constructor(private userservice: UserService, private router: Router) {
    this.login = new Login()
  }

  ngOnInit(): void {
  }

  loginUser(loginForm: NgForm) {
    this.userservice.LoginUser(this.login).subscribe(res => {
      console.log(res);
      let jsonObject = JSON.stringify(res);
      let jsonToken = JSON.parse(jsonObject);
      console.log(`User Token Received::${jsonToken["Token"]}`);
      localStorage.setItem('userToken', jsonToken["Token"]);
      localStorage.setItem('userName', jsonToken["Name"]);
      localStorage.setItem('userRole', jsonToken["Role"]);

      Swal.fire(
        'User Login',
        'Logged Successfully',
        'success'
      )

      const Role = localStorage.getItem('userRole')
      if (Role == "admin") {
        this.router.navigate(['getallplane'])
      }
      else {
        this.router.navigate(['displayplane'])
      }
    })
  }
}
