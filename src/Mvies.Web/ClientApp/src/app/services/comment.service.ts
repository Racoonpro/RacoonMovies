import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { MovieComment } from "../models/comment";

@Injectable()
export class CommentService {
    constructor(
        private _http: HttpClient
    ) { }

    getList = (movieId: number): Observable<MovieComment[]> => {
        return this._http.get<MovieComment[]>(`/api/comment/movie/${movieId}`);
    }

    create = (movieId: number, commet: MovieComment): Observable<MovieComment> => {
        return this._http.post<MovieComment>(`/api/comment/movie/${movieId}`, commet);
    }
}