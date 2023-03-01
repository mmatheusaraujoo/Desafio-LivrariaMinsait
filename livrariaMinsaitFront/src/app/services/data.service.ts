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
  retornarLivros() {
    return this.http.get<livro[]>(this.url + '/Livro');
  }
  cadastraAutor(object: object) {
    return this.http.post(this.url + '/Autor', object);
  }
  deletarAutor(idAutor: number) {
    return this.http.delete(this.url + '/Autor/' + idAutor);
  }
}
