import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { autor } from 'src/app/models/autor.models';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-autor',
  templateUrl: './autor.component.html',
  styleUrls: ['./autor.component.css']
})
export class AutorComponent {
  public autor$!: Observable<autor>;

  constructor(
    private data: DataService,
    private route: ActivatedRoute
  ) { }

  async ngOnInit() {
    const id = this.route.snapshot.params['id'];
    this.autor$ = await this.data.retornarAutor(id);
  }

}
