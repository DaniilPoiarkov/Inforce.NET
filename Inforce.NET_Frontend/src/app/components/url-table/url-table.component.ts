import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
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

  public inputControl: FormControl;
  public user?: UserModel;
  public shortedUrls: ShortedUrl[] = [];
  public inputUrl: string;

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
        this.shortedUrls.push({
          id: 2,
          url: 'asdfgh',
          shortedUrl: 'asd',
          createdDate: new Date(),
          createdBy: this.user
        });
      }, () => {
        window.location.href = environment.apiUrl + '/Auth/LoginPage?isError=true';
      });
      this.inputControl = new FormControl(this.inputUrl, [
        Validators.required,
      ]);
  }

  setInputValue(val: string): void {
    this.inputUrl = val;
  }

  addUrl(): void {
    console.log('Add url ' + this.inputUrl);
  }
}
