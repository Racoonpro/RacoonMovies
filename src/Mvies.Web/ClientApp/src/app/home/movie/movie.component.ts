import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Movie } from "src/app/models";
import { MovieService } from "src/app/services/movie.service";

@Component({
    selector: "racoon-movie",
    templateUrl: "./movie.component.html"
})
export class MovieComponent implements OnInit {

    constructor(
        private activatedRoute: ActivatedRoute,
        private movieSvc: MovieService,
        private router: Router
    ) { }

    movie = this.activatedRoute.snapshot.data.movie;

    ngOnInit(): void {
    }

    create = (movie: Movie) => {
        this.movieSvc.create(movie)
            .subscribe(() => this.router.navigate([``]))
    }
}
