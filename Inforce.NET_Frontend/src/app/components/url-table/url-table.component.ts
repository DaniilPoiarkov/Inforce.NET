import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NewUrl } from 'src/app/models/create-new-url';
import { ShortedUrl } from 'src/app/models/shortedUrl';
import { UserModel } from 'src/app/models/user';
import { HttpService } from 'src/app/services/http.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-url-table',
  templateUrl: './url-table.component.html',
  styleUrls: ['./url-table.component.css']
})
export class UrlTableComponent implements OnInit {

  constructor(
    private httpService: HttpService,
    private route: ActivatedRoute,
  ) { }

  public user?: UserModel;
  public shortedUrls: ShortedUrl[] = [];
  public inputUrl: string;

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.httpService.getUserById(parseInt(id as string))
      .subscribe((resp) => {
        this.user = resp.body as UserModel;
        this.shortedUrls = this.user.ownedUrls;
      }, () => {
        window.location.href = environment.apiUrl + '/Auth/LoginPage?isError=true';
      });
  }

  addUrl(): void {
    const model: NewUrl = {
      url: this.inputUrl, 
      createdById: this.user?.id as number 
    }
    this.httpService.saveNewUrl(model).subscribe((resp) => {
      this.shortedUrls.push(resp.body as ShortedUrl)
    });
  }
}
