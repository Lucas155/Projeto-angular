import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ApiService } from 'src/service/api.service';

@Component({
  selector: 'app-produto-editar',
  templateUrl: './produto-editar.component.html',
  styleUrls: ['./produto-editar.component.scss']
})
export class ProdutoEditarComponent implements OnInit {
  _id: String = '';
  productForm: FormGroup;
  produto: String = '';
  preco: String = '';
  sku: number = null;
  isLoadingResults = false;
  constructor(private router: Router, private route: ActivatedRoute, private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.getProduto(this.route.snapshot.params['id']);
    this.productForm = this.formBuilder.group({
   'produto' : [null, Validators.required],
   'preco' : [null, Validators.required],
   'sku' : [null, Validators.required]
 });
 }

 getProduto(id) {
  this.api.getProduto(id).subscribe(data => {
    this._id = data._id;
    this.productForm.setValue({
      produto: data.produto,
      preco: data.preco,
      sku: data.sku
    });
  });
}

updateProduto(form: NgForm) {
  this.isLoadingResults = true;
  this.api.updateProduto(this._id, form)
    .subscribe(res => {
        this.isLoadingResults = false;
        this.router.navigate(['/produto-detalhe/' + this._id]);
      }, (err) => {
        console.log(err);
        this.isLoadingResults = false;
      }
    );
}
}