import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShortedUrl } from 'src/app/models/shortedUrl';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-url-redirect-page',
  templateUrl: './url-redirect-page.component.html',
  styleUrls: ['./url-redirect-page.component.css']
})
export class UrlRedirectPageComponent implements OnInit {

  constructor(
    private httpService: HttpService,
    private route: ActivatedRoute
  ) { }

  public url: ShortedUrl;

  ngOnInit(): void {
    const tinyUrl = this.route.snapshot.paramMap.get('tinyUrl');
    console.log(tinyUrl);
    this.httpService.getUrlByTinyLink(tinyUrl as string)
    .subscribe((resp) => {
      this.url = resp.body as ShortedUrl;
    });
  }

  public redirectByUrl(): void {
    window.location.href = this.url.url;
  }

}
