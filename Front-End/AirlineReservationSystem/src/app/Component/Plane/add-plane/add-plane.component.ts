import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Plane } from 'src/app/Models/Plane/plane';
import { PlaneService } from 'src/app/Services/Plane/plane.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-plane',
  templateUrl: './add-plane.component.html',
  styleUrls: ['./add-plane.component.css']
})
export class AddPlaneComponent implements OnInit {

  planes: Plane

  constructor(private planeservice: PlaneService, private router: Router) {
    this.planes = new Plane()
  }

  ngOnInit(): void { }

  addplane() {
    this.planeservice.AddPlane(this.planes).subscribe(res => {
      if (res) {
        console.log(res)
        Swal.fire(
          'Course',
          'Added Successfully',
          'success'
        )
        this.router.navigate(['getallplane'])
      }
    })
  }
}
