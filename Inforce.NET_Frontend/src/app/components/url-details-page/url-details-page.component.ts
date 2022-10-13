import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ShortedUrl } from 'src/app/models/shortedUrl';
import { UserModel } from 'src/app/models/user';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-url-details-page',
  templateUrl: './url-details-page.component.html',
  styleUrls: ['./url-details-page.component.css']
})
export class UrlDetailsPageComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private httpService: HttpService,
  ) { }

  public shortedUrl: ShortedUrl;
  public user: UserModel;

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.httpService.getUrlById(parseInt(id as string))
      .subscribe((resp) => {
        this.shortedUrl = resp.body as ShortedUrl;
        this.getUser(this.shortedUrl.createdById)
    }, (err) => {
      console.log(err);
    });
  }

  private getUser(id: number): void {
    this.httpService.getUserById(id)
      .subscribe((resp) => {
        this.user = resp.body as UserModel;
    }, (err) => {
      console.log(err);
    });
  }

  public navigateByUrl(isFull: boolean): void {
    if(isFull){
      window.location.href = this.shortedUrl.url;
    } else {
      window.location.href = this.shortedUrl.shortUrl;
    }
  }
}
