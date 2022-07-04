import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { observable, Observable, of } from "rxjs";
import { Movie } from "../models";

@Injectable()
export class MovieService {

    constructor(
        private _http: HttpClient
    ) { }

    all = (): Observable<Movie[]> => {
        return this._http.get<Movie[]>('/api/movie/list');
    }

    get = (id: number): Observable<Movie> => {
        return this._http.get<Movie>(`/api/movie/${id}`);
    }

    create = (movie: Movie): Observable<Movie> => {
        return this._http.post<Movie>(`/api/movie`, movie);
    }
} 