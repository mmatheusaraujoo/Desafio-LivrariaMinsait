import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { autor } from 'src/app/models/autor.models';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-autores',
  templateUrl: './autores.component.html',
  styleUrls: ['./autores.component.css']
})
export class AutoresComponent {
  public autores$!: Observable<autor[]>;

  constructor(private data: DataService) {

  }

  async ngOnInit() {
    this.autores$ = await this.data.retornarAutores();
  }
}
