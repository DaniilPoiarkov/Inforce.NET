import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { ShortedUrl } from 'src/app/models/shortedUrl';

@Component({
  selector: 'app-url-view',
  templateUrl: './url-view.component.html',
  styleUrls: ['./url-view.component.css']
})
export class UrlViewComponent implements OnInit {

  @Input() url: ShortedUrl;

  constructor(
    private router: Router,
  ) { }

  ngOnInit(): void {
  }

  openDetails(): void {
    this.router.navigate(['details/' + this.url.id]);
  }

}
