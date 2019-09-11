import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../service/api.service';
import { Produto } from 'src/model/produto';

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.scss']
})
export class ProdutosComponent implements OnInit {

  displayedColumns: string[] = ['produto', 'preco', 'sku', 'acao'];
  dataSource: Produto[];
  isLoadingResults = true;
  constructor(private _api: ApiService) { }

  ngOnInit() {

    this._api.getProdutos()
    .subscribe(res => {
      this.dataSource = res;
      console.log(this.dataSource);
      this.isLoadingResults = false;
      console.log("to aqui");
    }, err => {
      console.log(err);
      this.isLoadingResults = false;
    });
  }

}
