import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MoviesComponent } from './movies/movies.component';
import { ConcertsComponent } from './concerts/concerts.component';
import { OnlineshowsComponent } from './onlineshows/onlineshows.component';
import { MovieslistComponent } from './movies/movieslist/movieslist.component';
import { ConcertslistComponent } from './concerts/concertslist/concertslist.component';

@NgModule({
  declarations: [
    AppComponent,
    MoviesComponent,
    ConcertsComponent,
    OnlineshowsComponent,
    MovieslistComponent,
    ConcertslistComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
