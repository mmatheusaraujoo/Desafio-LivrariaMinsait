import { Component, Input } from '@angular/core';
import { autor } from 'src/app/models/autor.models';

@Component({
  selector: 'app-autor-card',
  templateUrl: './autor-card.component.html',
  styleUrls: ['./autor-card.component.css']
})
export class AutorCardComponent {
  @Input() public autor!: autor;

  constructor() {
  }

  testaFoto() {
    if (this.autor.foto != '' || this.autor.foto == null) {
      return true;
    } else {
      return false;
    }
  }
}
