import { Component, OnInit, Input, Output, EventEmitter, ChangeDetectorRef, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-ck',
  templateUrl: './ck.component.html',
  styleUrls: ['./ck.component.css']
})
export class CkComponent implements OnInit, OnChanges {
  @Input() ngModel: any;
  @Output() ngModelChange = new EventEmitter();
  constructor(private changeDetector: ChangeDetectorRef) { }

  ngOnInit() {
    this.changeDetector.detectChanges();
  }

  ngOnChanges(changes: SimpleChanges) {
    this.ngModelChange.emit(this.ngModel);
  }

}
