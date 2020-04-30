import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-region-details',
  templateUrl: './region-details.component.html'
})
export class RegionDetailsComponent implements OnInit {
  public regionId: string;
  public region: Region;

  private http: HttpClient;
  private baseUrl: string;

  constructor(
    private route: ActivatedRoute,
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.regionId = params.get('regionId');
    });
    this.getWeatherForecast();
  }

  getWeatherForecast(): void {
    this.http.get<Region>(this.baseUrl + `region/${this.regionId}`).subscribe(result => {
      this.region = result;
    }, error => console.error(error));
  }
}

interface Region {
  name: string;
  weatherForecast: WeatherForecast;
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
