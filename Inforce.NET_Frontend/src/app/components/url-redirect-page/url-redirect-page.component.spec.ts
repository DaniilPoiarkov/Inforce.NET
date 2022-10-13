import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UrlRedirectPageComponent } from './url-redirect-page.component';

describe('UrlRedirectPageComponent', () => {
  let component: UrlRedirectPageComponent;
  let fixture: ComponentFixture<UrlRedirectPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UrlRedirectPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UrlRedirectPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
