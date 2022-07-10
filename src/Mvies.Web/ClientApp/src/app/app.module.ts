import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { MovieComponent } from './home/movie/movie.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { MovieService } from './services/movie.service';
import { CommentComponent } from './home/movie/comment/comment.component';
import { CommentService } from './services/comment.service';

const viewComponents = [
  CommentComponent,
  HomeComponent,
  MovieComponent
];


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ...viewComponents,
    CounterComponent,
    FetchDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      {
        path: 'movie',
        children: [
          {
            path: ':id',
            component: MovieComponent
          },
          {
            path: 'new',
            component: MovieComponent
          },

        ]
      },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },

    ])
  ],
  providers: [
    MovieService,
    CommentService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
