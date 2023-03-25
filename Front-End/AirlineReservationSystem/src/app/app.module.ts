import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Component/header/header.component';
import { AddPlaneComponent } from './Component/Plane/add-plane/add-plane.component';
import { DeletePlaneComponent } from './Component/Plane/delete-plane/delete-plane.component';
import { EditPlaneComponent } from './Component/Plane/edit-plane/edit-plane.component';
import { GetAllPlaneComponent } from './Component/Plane/get-all-plane/get-all-plane.component';
import { RegisterComponent } from './Component/User/register/register.component';
import { LoginComponent } from './Component/User/login/login.component';
import { LogoutComponent } from './Component/User/logout/logout.component';
import { HomeComponent } from './Component/home/home.component';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { DisplayPlaneComponent } from './Component/Plane/display-plane/display-plane.component';
import { SearchPlaneComponent } from './Component/Plane/search-plane/search-plane.component';
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    AddPlaneComponent,
    DeletePlaneComponent,
    EditPlaneComponent,
    GetAllPlaneComponent,
    RegisterComponent,
    LoginComponent,
    LogoutComponent,
    HomeComponent,
    DisplayPlaneComponent,
    SearchPlaneComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
