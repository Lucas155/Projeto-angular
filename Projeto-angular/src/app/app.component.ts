import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Projeto-angular';
  clientes = [];
  cliente = "";

  addClientes(){
    this.clientes.push(this.cliente);
  }

}
