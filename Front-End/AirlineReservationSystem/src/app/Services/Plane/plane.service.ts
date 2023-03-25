import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Plane } from 'src/app/Models/Plane/plane';
import { Observable } from 'rxjs';
import { identifierName } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class PlaneService {

  constructor(private httpclient: HttpClient) { }

  GetAllPlane() {
    return this.httpclient.get<Plane[]>('https://localhost:44358/api/Plane/GetAllPlain')
  }

  AddPlane(planes: Plane): Observable<boolean> {
    return this.httpclient.post<boolean>('https://localhost:44358/api/Plane/AddPlain', planes)
  }

  getPlainById(id: any): Observable<Plane> {
    return this.httpclient.get<Plane>('https://localhost:44358/api/Plane/GetPlainById/' + id)
  }

  editPlane(planes: Plane): Observable<boolean> {
    return this.httpclient.put<boolean>('https://localhost:44358/api/Plane/EditPlain/' + planes.id, planes)
  }

  deletePlane(id: any): Observable<boolean> {
    return this.httpclient.delete<boolean>('https://localhost:44358/api/Plane/Delete?id=' + id)
  }

  DisplayPlane() {
    return this.httpclient.get<Plane[]>('https://localhost:44358/api/Plane/GetAllPlain')
  }

  searchPlane(source: string | null, destination: string | null) {
    return this.httpclient.get<Plane[]>(`https://localhost:44358/api/Plane/GetPlainBySourceToDestination?source=${source}&destination=${destination}`)
  }
}

