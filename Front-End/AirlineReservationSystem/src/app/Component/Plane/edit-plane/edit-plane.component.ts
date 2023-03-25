import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Plane } from 'src/app/Models/Plane/plane';
import { PlaneService } from 'src/app/Services/Plane/plane.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-edit-plane',
  templateUrl: './edit-plane.component.html',
  styleUrls: ['./edit-plane.component.css']
})
export class EditPlaneComponent implements OnInit {

  planes: Plane
  // id: any

  constructor(private planeservice: PlaneService, private activatedRoute: ActivatedRoute, private router: Router) {
    this.planes = new Plane()
  }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.paramMap.get('id')
    // this.getPlainById(this.id)

    this.planeservice.getPlainById(id).subscribe(res => {
      this.planes = res
      console.log(res)
    });
  }

  editPlane() {
    this.planeservice.editPlane(this.planes).subscribe(res => {
      if (res) {
        console.log(res)
        Swal.fire(
          'Plane',
          'Edit Successfully',
          'success'
        )
        this.router.navigate(['getallplane'])
      }
    });
  }
}


