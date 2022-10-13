import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.css']
})
export class ButtonComponent implements OnInit {

  constructor() { }

  @Input() buttonName: string = '';
  @Input() btnClass: string = 'btn';
  @Output() isClicked = new EventEmitter<void>();

  ngOnInit(): void {
  }

  emitEvent(): void {
    this.isClicked.emit();
  }
}
