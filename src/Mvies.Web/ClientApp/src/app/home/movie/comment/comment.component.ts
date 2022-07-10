import { Component, Input, OnInit } from "@angular/core";
import { MovieComment } from "src/app/models/comment";
import { CommentService } from "src/app/services/comment.service";

@Component({
    selector: "racoon-comment",
    templateUrl: "./commpent.component.html"
})
export class CommentComponent implements OnInit {

    comments: MovieComment[] = [];

    constructor(
        private commentSvc: CommentService
    ) { }

    @Input()
    movieId: number = 0;

    ngOnInit(): void {
        this.commentSvc.getList(this.movieId)
            .subscribe(result => this.comments = result);
    }

}