import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FeedRoutingModule } from './feed-routing.module';
import { FeedLayoutComponent } from './layouts/feed-layout/feed-layout.component';
import { ArticleListComponent } from './pages/article-list/article-list.component';
import { ArticleComponent } from './components/article/article.component';

import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { NewArticleComponent } from './pages/new-article/new-article.component';
import { MatInputModule } from '@angular/material/input';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';




@NgModule({
  declarations: [
    FeedLayoutComponent,
    ArticleListComponent,
    ArticleComponent,
    NewArticleComponent
  ],
  imports: [
    CommonModule,
    FeedRoutingModule,
    MatCardModule,
    MatDividerModule,
    MatButtonModule,
    MatPaginatorModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatInputModule,
    ReactiveFormsModule,
    MatSlideToggleModule,
    FormsModule,
    MatButtonToggleModule,
    MatSnackBarModule,
  
  ]
})
export class FeedModule { }
