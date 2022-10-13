import { Component, OnInit, Input } from '@angular/core';
import { ShortedUrl } from 'src/app/models/shortedUrl';

@Component({
  selector: 'app-url-view',
  templateUrl: './url-view.component.html',
  styleUrls: ['./url-view.component.css']
})
export class UrlViewComponent implements OnInit {

  @Input() url: ShortedUrl = {
    id: 0,
    shortedUrl: '',
    url: '',
    createdBy: {
      id: 0,
      fullName: '',
      login: '',
      password: '',
      role: 0,
      ownedUrls: [],
    },
    createdDate: new Date(),
  };

  constructor() { }

  ngOnInit(): void {
  }

  openDetails(): void {
    console.log('Clicked');
  }

}
