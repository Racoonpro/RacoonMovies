import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { of } from "rxjs";
import { mergeMap } from "rxjs/operators";
import { Movie } from "src/app/models";
import { MovieService } from "src/app/services/movie.service";

@Component({
    selector: "racoon-movie",
    templateUrl: "./movie.component.html"
})
export class MovieComponent implements OnInit {

    movie: Movie = new Movie();

    constructor(
        private activatedRoute: ActivatedRoute,
        private movieSvc: MovieService,
        private router: Router
    ) { }

    ngOnInit(): void {
        const routeResolution$ = this.activatedRoute.params.pipe(
            mergeMap((params, _) => {
                if (params.id == "new") {
                    return of(new Movie())
                }
                return this.movieSvc.get(params.id);
            })
        );
        routeResolution$.subscribe(movie => this.movie = movie);
    }

    create = (movie: Movie) => {
        this.movieSvc.create(movie)
            .subscribe(() => this.router.navigate([``]))
    }

}
