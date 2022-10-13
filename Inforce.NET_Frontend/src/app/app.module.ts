import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UrlTableComponent } from './components/url-table/url-table.component';
import { HttpService } from './services/http.service';
import { UrlViewComponent } from './components/url-view/url-view.component';
import { ButtonComponent } from './shared/button/button.component';
import { UrlRedirectPageComponent } from './components/url-redirect-page/url-redirect-page.component';
import { UrlDetailsPageComponent } from './components/url-details-page/url-details-page.component';
import { LinkViewPipe } from './pipes/link-view.pipe';
import { ToastrModule } from 'ngx-toastr';
import { ToastrConfig } from './toastr-config';
import { NotificationService } from './services/notification.service';

@NgModule({
  declarations: [
    AppComponent,
    UrlTableComponent,
    UrlViewComponent,
    ButtonComponent,
    UrlRedirectPageComponent,
    UrlDetailsPageComponent,
    LinkViewPipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(ToastrConfig)
  ],
  providers: [
    HttpService, 
    NotificationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
