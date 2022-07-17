import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { Observable, of } from "rxjs";
import { Movie } from "src/app/models";
import { MovieService } from "src/app/services/movie.service";

@Injectable({ providedIn: 'root' })
export class MovieResolver implements Resolve<Movie> {

    constructor(
        private movieSvc: MovieService) {
    }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Movie> {
        const movieId = route.paramMap.get('id') as string;
        if (movieId == "new") {
            return of(new Movie())
        }

        return this.movieSvc.get(+movieId);
    }

}