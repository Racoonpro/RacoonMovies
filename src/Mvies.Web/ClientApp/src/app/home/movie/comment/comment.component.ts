import { Component, Input, OnInit } from "@angular/core";
import { MovieComment } from "src/app/models/comment";
import { CommentService } from "src/app/services/comment.service";
import { mergeMap, tap } from "rxjs/operators";

@Component({
    selector: "racoon-comment",
    templateUrl: "./commpent.component.html"
})
export class CommentComponent implements OnInit {

    comments: MovieComment[] = [];
    newComment: MovieComment = new MovieComment();
    constructor(
        private commentSvc: CommentService
    ) { }

    @Input()
    movieId: number = 0;

    ngOnInit(): void {
        this.commentSvc.getList(this.movieId)
            .subscribe(result => this.comments = result);
    }

    create(newCmment: MovieComment): void {
        this.commentSvc.create(this.movieId, newCmment).pipe(
            tap(() => this.newComment = new MovieComment()),
            mergeMap(() => this.commentSvc.getList(this.movieId))
        ).subscribe(result => this.comments = result);
    }

    setRating = (value: number): void => {
        this.newComment.rating = value;
    }
}