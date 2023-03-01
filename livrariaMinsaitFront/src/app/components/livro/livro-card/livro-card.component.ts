import { Component, Input } from '@angular/core';
import { livro } from 'src/app/models/livro.models';

@Component({
  selector: 'app-livro-card',
  templateUrl: './livro-card.component.html',
  styleUrls: ['./livro-card.component.css']
})
export class LivroCardComponent {

  @Input() public livro!: livro;

  constructor() {

  }
}
