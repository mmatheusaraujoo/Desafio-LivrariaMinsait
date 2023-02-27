import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { livro } from 'src/app/models/livro.models';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public livros$!: Observable<livro[]>;
  constructor(private data: DataService) {

  }

  ngOnInit() {
    this.livros$ = this.data.retornarLivros();
    this.data.retornarAutores();
  }

}
