import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Component/home/home.component';
import { AddPlaneComponent } from './Component/Plane/add-plane/add-plane.component';
import { DeletePlaneComponent } from './Component/Plane/delete-plane/delete-plane.component';
import { DisplayPlaneComponent } from './Component/Plane/display-plane/display-plane.component';
import { EditPlaneComponent } from './Component/Plane/edit-plane/edit-plane.component';
import { GetAllPlaneComponent } from './Component/Plane/get-all-plane/get-all-plane.component';
import { SearchPlaneComponent } from './Component/Plane/search-plane/search-plane.component';
import { LoginComponent } from './Component/User/login/login.component';
import { LogoutComponent } from './Component/User/logout/logout.component';
import { RegisterComponent } from './Component/User/register/register.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'logout',
    component: LogoutComponent
  },
  {
    path: 'displayplane/logout',
    component: LogoutComponent
  },
  {
    path: 'getallplane/logout',
    component: LogoutComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'addplane',
    component: AddPlaneComponent
  },
  {
    path: 'deleteplane/:id',
    component: DeletePlaneComponent
  },
  {
    path: 'editplane/:id',
    component: EditPlaneComponent
  },
  {
    path: 'getallplane',
    component: GetAllPlaneComponent
  },
  {
    path: 'displayplane',
    component: DisplayPlaneComponent
  },
  {
    path: 'search/:source,destination',
    component: SearchPlaneComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
