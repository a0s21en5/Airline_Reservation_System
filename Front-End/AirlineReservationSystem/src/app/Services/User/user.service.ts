import { Injectable, OnInit } from '@angular/core';
import { User } from 'src/app/Models/User/user';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Login } from 'src/app/Models/User/Login/login';


@Injectable({
  providedIn: 'root'
})
export class UserService implements OnInit {

  constructor(private httpclient: HttpClient) { }

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  RegisterUser(user: User): Observable<boolean> {
    return this.httpclient.post<boolean>('https://localhost:44309/api/User/AddUser', user)
  }

  LoginUser(login: Login): Observable<string> {
    return this.httpclient.post<string>('https://localhost:44309/api/User/Login', login);
  }
}
