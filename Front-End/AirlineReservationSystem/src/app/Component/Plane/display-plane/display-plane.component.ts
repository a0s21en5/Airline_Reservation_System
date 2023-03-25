import { Component, OnInit } from '@angular/core';
import { Plane } from 'src/app/Models/Plane/plane';
import { PlaneService } from 'src/app/Services/Plane/plane.service';

@Component({
  selector: 'app-display-plane',
  templateUrl: './display-plane.component.html',
  styleUrls: ['./display-plane.component.css']
})
export class DisplayPlaneComponent implements OnInit {

  planes?: Plane[]
  selectedplane: any

  constructor(private planeservice: PlaneService) { }

  ngOnInit(): void {
    this.planeservice.DisplayPlane().subscribe(res => {
      console.log(res)
      this.planes = res
    })
  }

  BookTicket() {
    console.log(this.selectedplane)
  }
}
