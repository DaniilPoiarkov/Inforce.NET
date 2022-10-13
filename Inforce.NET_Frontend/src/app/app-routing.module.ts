import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UrlTableComponent } from './components/url-table/url-table.component';

const routes: Routes = [
  {path: ':id', component: UrlTableComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
