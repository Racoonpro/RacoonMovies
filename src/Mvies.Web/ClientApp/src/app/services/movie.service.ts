import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";

@Injectable()
export class MovieService {

    constructor(
        private _http: HttpClient
    ) {}

    all = () :Observable<any[]> => {
        return of(['Kirill', 'another name']);
        // return this._http.get<any>('');
    }
} 