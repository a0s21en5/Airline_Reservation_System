import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Plane } from 'src/app/Models/Plane/plane';
import { PlaneService } from 'src/app/Services/Plane/plane.service';

@Component({
  selector: 'app-search-plane',
  templateUrl: './search-plane.component.html',
  styleUrls: ['./search-plane.component.css']
})
export class SearchPlaneComponent implements OnInit {

  planes: any = []

  constructor(private activeroute: ActivatedRoute, private planeservice: PlaneService) { }

  source = this.activeroute.snapshot.paramMap.get('source')
  destination = this.activeroute.snapshot.paramMap.get('destination')

  ngOnInit(): void {
  }

  SearhPlane(source: any, destination: any) {
    this.planeservice.searchPlane(source, destination).subscribe(res => {
      this.planes = res
    })
  }
}
