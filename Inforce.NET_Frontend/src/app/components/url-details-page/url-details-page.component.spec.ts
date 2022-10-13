import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UrlDetailsPageComponent } from './url-details-page.component';

describe('UrlDetailsPageComponent', () => {
  let component: UrlDetailsPageComponent;
  let fixture: ComponentFixture<UrlDetailsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UrlDetailsPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UrlDetailsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
