import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(
    private toastr: ToastrService
  ) { }

  positionClass = 'toast-top-right';
  timeOut = 3000;

  public success(message: string): void {
    this.toastr.success(message, '', { 
      positionClass: this.positionClass,
      timeOut: this.timeOut,
    });
  }

  public error(message: string): void {
    this.toastr.error(message);
  }
}
