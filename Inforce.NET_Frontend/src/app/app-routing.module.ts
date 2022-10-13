import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UrlDetailsPageComponent } from './components/url-details-page/url-details-page.component';
import { UrlRedirectPageComponent } from './components/url-redirect-page/url-redirect-page.component';
import { UrlTableComponent } from './components/url-table/url-table.component';

const routes: Routes = [
  { path: ':id', component: UrlTableComponent },
  { path: 'details/:id', component: UrlDetailsPageComponent },
  { path: 'tiny/:tinyUrl', component: UrlRedirectPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
