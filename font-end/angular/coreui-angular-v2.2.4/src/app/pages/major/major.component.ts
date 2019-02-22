import { Component, OnInit, TemplateRef  } from '@angular/core';
import { Major, MajorService } from '../../services/major.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-major',
  templateUrl: './major.component.html',
  styleUrls: ['./major.component.scss']
})
export class MajorComponent implements OnInit {
  modalRef: BsModalRef;
  majors: Major[] = [];
  major: Major={} as Major;
  constructor(private majorService: MajorService, private modalService: BsModalService) { }

  ngOnInit() {
    this.majorService.getAll().subscribe(result => {
      this.majors = result.majors;
    });
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  save(){
    console.log(this.major);
    this.majorService.add(this.major).subscribe(result=>{
      console.log(result);
    })
  }

}
