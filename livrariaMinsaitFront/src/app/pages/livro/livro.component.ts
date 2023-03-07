import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { livro } from 'src/app/models/livro.models';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-livro',
  templateUrl: './livro.component.html',
  styleUrls: ['./livro.component.css']
})
export class LivroComponent {
  public livro$!: Observable<livro>;

  constructor(
    private data: DataService,
    private route: ActivatedRoute
  ) { }

  async ngOnInit() {
    const id = this.route.snapshot.params['id'];
    this.livro$ = await this.data.retornarLivro(id);
    this.livro$.subscribe(x => {
      console.log(x);
    });
  }

}
