import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Major, MajorService } from '../../services/major.service';
import { BsModalService, BsModalRef, ModalDirective } from 'ngx-bootstrap/modal';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-major',
  templateUrl: './major.component.html',
  styleUrls: ['./major.component.scss']
})
export class MajorComponent implements OnInit {
  modalRef: BsModalRef;
  majors: Major[] = [];
  major: Major = {} as Major;
  idDelete: number;
  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('deletemodal') deletemodal: ModalDirective;
  constructor(private majorService: MajorService, private modalService: BsModalService) { }

  ngOnInit() {
    this.loadData();
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  loadData() {
    this.majorService.getAll().subscribe(result => {
      this.majors = result.majors;
    });
  }
  save() {
    if (this.major.id === undefined || this.major.id === 0) {
      this.majorService.add(this.major).subscribe(result => {
        this.modal.hide();
        this.loadData();
      });
    } else {
      this.majorService.update(this.major).subscribe(result => {
        this.modal.hide();
        this.loadData();
      });
    }

  }

  public showModal(event = null, id: number = 0) {
    if (event) {
      event.preventDefault();
    }
    if (id > 0) {
      this.majorService.get(id).subscribe(result => {
        this.major = result.major;
        this.modal.show();
      });
    } else {
      this.major = {} as Major;
      this.modal.show();
    }
    this.modal.show();
  }

  public delete(event, id) {
    if (event) {
      event.preventDefault();
    }
    this.idDelete = id;
    this.deletemodal.show();
  }
  deleteConfirm() {
    this.majorService.delete(this.idDelete).subscribe(result => {
      if (result.errorCode === 0) {
        const deletedMajor = this.majors.find(x => x.id === this.idDelete);
        if (deletedMajor) {
          const index = this.majors.indexOf(deletedMajor);
          this.majors.splice(index, 1);
        }
      }
      //this.loadData();
    });
    this.deletemodal.hide();
  }

}
