import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalDirective, BsModalService } from 'ngx-bootstrap';
import { ProductService, ProductsRespone, Product } from '../../services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  idDelete: number;
  productList: Product[];
  product: Product = {} as Product;
  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('deletemodal') deletemodal: ModalDirective;
  constructor(private productService: ProductService, private modalService: BsModalService) { }

  ngOnInit() {
    this.loadData();
  }

  public showModal(event = null, id: number = 0) {
    if (event) {
      event.preventDefault();
    }
    if (id > 0) {
      this.productService.get(id).subscribe(result => {
        this.product = result.product;
        this.modal.show();
      });
    } else {
      this.product = {} as Product;
      this.modal.show();
    }
    this.modal.show();
  }

  loadData() {
    this.productService.getAll().subscribe(result => {
      this.productList = result.products;
    });
  }
  save() {
    if (this.product.id === undefined || this.product.id === 0) {
      this.productService.add(this.product).subscribe(result => {
        this.modal.hide();
        this.loadData();
      });
    } else {
      this.productService.update(this.product).subscribe(result => {
        this.modal.hide();
        this.loadData();
      });
    }

  }
  public delete(event, id) {
    if (event) {
      event.preventDefault();
    }
    this.idDelete = id;
    this.deletemodal.show();
  }
  deleteConfirm() {
    this.productService.delete(this.idDelete).subscribe(result => {
      if (result.errorCode === 0) {
        const deletedproduct = this.productList.find(x => x.id === this.idDelete);
        if (deletedproduct) {
          const index = this.productList.indexOf(deletedproduct);
          this.productList.splice(index, 1);
        }
      }
      //this.loadData();
    });
    this.deletemodal.hide();
  }

}
