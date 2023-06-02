import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ArticleComponent } from './components/article/article.component';
import { ArticleListComponent } from './pages/article-list/article-list.component';
import { NewArticleComponent } from './pages/new-article/new-article.component';

const routes: Routes = [
  { path: '', component: ArticleListComponent },
  { path: 'new', component: NewArticleComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FeedRoutingModule { }
