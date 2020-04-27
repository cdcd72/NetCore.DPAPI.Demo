import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-region-list',
  templateUrl: './region-list.component.html'
})
export class RegionListComponent {
  public regions: Region[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Region[]>(baseUrl + 'region').subscribe(result => {
      this.regions = result;
    }, error => console.error(error));
  }
}

interface Region {
  id: number;
  name: string;
}
