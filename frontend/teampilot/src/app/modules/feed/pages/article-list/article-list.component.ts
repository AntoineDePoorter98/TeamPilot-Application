import { Component, NgModule, OnInit, Input } from '@angular/core';
import {
  ArticleDTO,
  UserWithNullablePlayerPropsDTO,
} from 'src/app/services/api/v1';
import { PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { ArticleService } from 'src/app/services/api/v1';
import { Observable, map } from 'rxjs';
import { CurrentUserService } from 'src/app/services/current-user.service';
import {
  MatSlideToggleChange,
  MatSlideToggleModule,
} from '@angular/material/slide-toggle';

@Component({
  selector: 'feed',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.css'],
})
export class ArticleListComponent implements OnInit {
  public articles: ArticleDTO[] = [];
  public pageSlice = this.articles.slice(0, 5);
  isLoading: boolean = false;
  canTogglePF: boolean = false;
  currentUser?: UserWithNullablePlayerPropsDTO;
  isChecked: boolean = false;

  constructor(
    private service: ArticleService,
    private router: Router,
    private _currentUserService: CurrentUserService
  ) {
    this.currentUser = _currentUserService.currentUser;
  }

  ngOnInit(): void {
    if (this.currentUser?.userType === 'RegisteredUser') {
      this.canTogglePF = true;
    }
    this.isLoading = true;
    this.GetArticles();
  }

  toggle(event: MatSlideToggleChange) {
    if (this.isChecked) {
      this.GetArticlesFollowing();
    } else {
      this.GetArticles();
    }
  }

  OnPageChange(event: PageEvent) {
    const startIndex = event.pageIndex * event.pageSize;
    let endIndex = startIndex + event.pageSize;
    if (endIndex > this.articles.length) {
      endIndex = this.articles.length;
    }
    this.pageSlice = this.articles.slice(startIndex, endIndex);
  }

  GetArticles() {
    this.service
      .articlesGet()
      .pipe(
        map((results: any) =>
          results.sort(
            (a: any, b: any) =>
              (new Date(b.creationDate).valueOf() ?? 0) -
              (new Date(a.creationDate).valueOf() ?? 0)
          )
        )
      )
      .subscribe((articles) => {
        this.articles = articles;
        this.pageSlice = this.articles.slice(0, 5);
        this.isLoading = false;
      });
  }

  GetArticlesFollowing() {
    this.service
      .articlesFollowingGet()
      .pipe(
        map((results: any) =>
          results.sort(
            (a: any, b: any) =>
              (new Date(b.creationDate).valueOf() ?? 0) -
              (new Date(a.creationDate).valueOf() ?? 0)
          )
        )
      )
      .subscribe((articles) => {
        this.articles = articles;
        this.pageSlice = this.articles.slice(0, 5);
        this.isLoading = false;
      });
  }
}

export interface Article {
  Title: string;
  Author: string;
  Body: string;
  PicUrl: string;
}
