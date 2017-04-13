import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class Fetchdata {
    public movies: IMovie[];

    constructor(http: HttpClient) {
        http.fetch('http://localhost:5000/api/movie')
            .then(result => result.json() as Promise<IMovie[]>)
            .then(data => {
                this.movies = data;
            });
    }
}

interface IMovie {
    id: string;
    title: string;
    year: number;
    description: string;
    runtime: string;
    rating: number;
}
