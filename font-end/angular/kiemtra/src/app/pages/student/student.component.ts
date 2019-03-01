import { Component, OnInit } from '@angular/core';
import { ReaderService } from '../../services/reader.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent implements OnInit {

  constructor(private readerService: ReaderService) { }

  ngOnInit() {
    this.readerService.getAll().subscribe(result => {
      console.log(result);
    });
  }

}
