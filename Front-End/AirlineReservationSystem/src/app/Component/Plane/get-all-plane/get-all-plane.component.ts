import { Component, OnInit } from '@angular/core';
import { Plane } from 'src/app/Models/Plane/plane';
import { PlaneService } from 'src/app/Services/Plane/plane.service';

@Component({
  selector: 'app-get-all-plane',
  templateUrl: './get-all-plane.component.html',
  styleUrls: ['./get-all-plane.component.css']
})
export class GetAllPlaneComponent implements OnInit {

  planes?: Plane[]
  displayName?: string | null

  constructor(private planeservice: PlaneService) { }

  ngOnInit(): void {
    this.displayName = localStorage.getItem('userName')

    this.planeservice.GetAllPlane().subscribe(res => {
      console.log(res);
      this.planes = res
    })
  }
  
}
