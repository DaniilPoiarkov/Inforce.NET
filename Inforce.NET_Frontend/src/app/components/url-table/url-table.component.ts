import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShortedUrl } from 'src/app/models/shortedUrl';
import { UserModel } from 'src/app/models/user';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-url-table',
  templateUrl: './url-table.component.html',
  styleUrls: ['./url-table.component.css']
})
export class UrlTableComponent implements OnInit {

  constructor(
    private httpService: HttpService,
    private route: ActivatedRoute
  ) { }

  public user?: UserModel;
  public shortedUrls: ShortedUrl[] = [];

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.httpService.getUserById(parseInt(id as string))
      .subscribe((resp) => {
        this.user = resp.body as UserModel;
        this.shortedUrls = this.user.ownedUrls;
        this.shortedUrls.push({
          id: 1,
          url: 'qwerty',
          shortedUrl: 'qwe',
          createdDate: new Date(),
          createdBy: this.user
        });
      });
  }
}
