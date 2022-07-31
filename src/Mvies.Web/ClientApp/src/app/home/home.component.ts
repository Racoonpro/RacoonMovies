import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { fromEvent } from 'rxjs';
import { debounce, debounceTime, mergeMap, tap } from 'rxjs/operators';
import { MovieService } from '../services/movie.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  movies: any[] = [];

  constructor(private _movieSvc: MovieService) {
  }

  @ViewChild("searchbox") searchBox!: ElementRef;

  ngOnInit(): void {
    const movies$ = this._movieSvc.all();
    movies$.subscribe(movies => {
      this.movies = movies;
      console.info(this.movies);
    })
  }

  ngAfterViewInit() {
    const debounceEvent$ = fromEvent<KeyboardEvent>(this.searchBox.nativeElement, "keyup");
    debounceEvent$.pipe(
      debounceTime(1200),
      mergeMap((value) => this._movieSvc.search((<HTMLInputElement>value.target).value))
      ).subscribe((results) => this.movies = results)

  }
}