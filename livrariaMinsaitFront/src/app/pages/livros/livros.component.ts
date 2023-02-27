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

  constructor(private data: DataService) {

  }

  async ngOnInit() {
    this.livros$ = await this.data.retornarLivros();;
  }
}