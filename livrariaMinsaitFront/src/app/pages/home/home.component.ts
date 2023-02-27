import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { autor } from 'src/app/models/autor.models';
import { livro } from 'src/app/models/livro.models';
import { DataService } from 'src/app/services/data.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public livros$!: Observable<livro[]>;
  public autores$!: Observable<autor[]>;
  constructor(private data: DataService) {

  }

  async ngOnInit() {
    this.livros$ = await this.data.retornarLivros();
    this.autores$ = await this.data.retornarAutores();
  }

}
