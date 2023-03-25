import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Plane } from 'src/app/Models/Plane/plane';
import { PlaneService } from 'src/app/Services/Plane/plane.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-delete-plane',
  templateUrl: './delete-plane.component.html',
  styleUrls: ['./delete-plane.component.css']
})
export class DeletePlaneComponent implements OnInit {

  planes: Plane

  constructor(private planeservice: PlaneService, private activatedRoute: ActivatedRoute, private router: Router) {
    this.planes = new Plane()
  }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.paramMap.get('id')

    this.planeservice.deletePlane(id).subscribe(res => {
      if (res) {
        console.log(res)
        Swal.fire(
          'Plane',
          'Deleted Successfully',
          'success'
        )
        this.router.navigate(['getallplane'])
      }
    });
  }
}
