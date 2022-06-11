import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";

@Injectable()
export class MovieService {

    constructor(
        private _http: HttpClient
    ) {}

    all = () :Observable<any[]> => {
        return this._http.get<any>('/api/movie/list');
    }
} 