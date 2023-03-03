import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { autor } from '../models/autor.models';
import { livro } from '../models/livro.models';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private url = 'http://localhost:5011';

  constructor(private http: HttpClient) {

  }

  retornarAutores() {
    return this.http.get<autor[]>(this.url + '/Autor');
  }
  retornarAutor(id: number) {
    return this.http.get<autor>(this.url + '/Autor/' + id);
  }
  cadastraAutor(object: object) {
    return this.http.post(this.url + '/Autor', object);
  }
  deletarAutor(idAutor: number) {
    return this.http.delete(this.url + '/Autor/' + idAutor);
  }
  alterarAutor(idAutor: number, object: any) {
    return this.http.put(this.url + '/Autor/' + idAutor, object)
  }


  retornarLivros() {
    return this.http.get<livro[]>(this.url + '/Livro');
  }
  retornarlivro(id: number) {
    return this.http.get<livro>(this.url + '/Livro/' + id);
  }
  cadastraLivro(object: object) {
    return this.http.post(this.url + '/Livro', object);
  }
  deletarLivro(idLivro: number) {
    return this.http.delete(this.url + '/Livro/' + idLivro);
  }
  alterarLivro(idLivro: number, object: any) {
    return this.http.put(this.url + '/Livro/' + idLivro, object)
  }


  vincularLivroAutor(idAutor: number, idLivro: number) {
    return this.http.post(this.url + '/Autor/' + idAutor + '/Livro/' + idLivro, '')
  }
  deletarVinculoLivroAutor(idAutor: number, idLivro: number) {
    return this.http.delete(this.url + '/Autor/' + idAutor + '/Livro/' + idLivro)
  }

}
