import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { livro } from 'src/app/models/livro.models';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-livros',
  templateUrl: './livros.component.html',
  styleUrls: ['./livros.component.css']
})
export class LivrosComponent implements OnInit {

  public livros$!: Observable<livro[]>;
  public termoDePesquisa: string = '';
  public livrosOriginal: livro[] = [];
  public livrosLista: livro[] = [];

  constructor(private data: DataService) {

  }

  async ngOnInit() {
    this.livros$ = await this.data.retornarLivros();
    this.livros$.subscribe(livros => {
      this.livrosLista = livros;
      this.livrosOriginal = livros;
    });
  }

  filtrarLivros() {
    if (this.termoDePesquisa != '') {
      this.livrosLista = this.livrosLista.filter(livro => livro.titulo.toLowerCase().includes(this.termoDePesquisa.toLowerCase()));
    } else {
      this.livrosLista = this.livrosOriginal;
    }
  }

  ordenarPorId() {
    this.livrosLista = this.livrosLista.sort((a, b) => a.id - b.id);
  }

  ordenarPorEstoque() {
    this.livrosLista = this.livrosLista.sort((a, b) => a.quantidadeEmEstoque - b.quantidadeEmEstoque);
  }

  ordenarPorAutor() {
    this.livrosLista = this.livrosLista.sort((a, b) => {
      if (a.autores[0].nome < b.autores[0].nome) { return -1; }
      if (a.autores[0].nome > b.autores[0].nome) { return 1; }
      return 0;
    });
  }

  ordenarPorTitulo() {
    this.livrosLista = this.livrosLista.sort((a, b) => {
      if (a.titulo < b.titulo) { return -1; }
      if (a.titulo > b.titulo) { return 1; }
      return 0;
    });
  }

  ordenarPorData() {
    this.livrosLista = this.livrosLista.sort((a, b) => new Date(a.dataDePublicacao).getTime() - new Date(b.dataDePublicacao).getTime());
  }


}