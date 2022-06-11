import { Component, OnInit } from '@angular/core';
import { MovieService } from '../services/movie.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  movies: any[] = [];

  constructor(private _movieSvc: MovieService) {
  }

  ngOnInit(): void {
    const movies$ = this._movieSvc.all();
    movies$.subscribe(movies => {
      this.movies = movies;
      console.info(this.movies);
    })
  }


}
