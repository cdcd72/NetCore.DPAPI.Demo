import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { RegionListComponent } from './region-list/region-list.component';
import { RegionDetailsComponent } from './region-details/region-details.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    RegionListComponent,
    RegionDetailsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: '/regions', pathMatch: 'full' },
      { path: 'regions', component: RegionListComponent },
      { path: 'regions/:regionId', component: RegionDetailsComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
