import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { autor } from 'src/app/models/autor.models';
import { DataService } from 'src/app/services/data.service';
import { DialogoService } from 'src/app/services/dialogo.service';

@Component({
  selector: 'app-autores',
  templateUrl: './autores.component.html',
  styleUrls: ['./autores.component.css']
})
export class AutoresComponent {
  public autores$!: Observable<autor[]>;
  public autoresOriginal: autor[] = [];
  public autores: autor[] = [];
  public termoDePesquisa: string = '';

  constructor(
    private data: DataService,
    private dialogoService: DialogoService,
    private router: Router) {

  }

  async ngOnInit() {
    this.autores$ = await this.data.retornarAutores();
    this.autores$.subscribe(autores => {
      this.autores = autores;
      this.autoresOriginal = autores;
    });
  }

  async deletarAutor(autor: autor) {
    let resultadoDoDialogo = await this.dialogoService.abrirDialogo('Deseja remover o autor "' + autor.nome + '" de id: ' + autor.id);
    if (resultadoDoDialogo) {
      this
        .data
        .deletarAutor(autor.id)
        .subscribe(
          async (data) => {
            console.log(data);
            await this.dialogoService.abrirMensagem('Sucesso', "O autor foi removido.")
            window.location.reload();
          },
          (err) => {
            console.log(err);
            this.dialogoService.abrirMensagem('Desculpe!', 'Não foi possível remover o autor. Para mais informações acesse o "ConsoleLog" do seu navegador.');
          }
        );
    }
  }

  abrirPaginaAutor(autor: autor) {
    console.log(autor);
    let rota = '/Autor/' + autor.id;
    this.router.navigate([rota]);
  }

  ordenarPorNome() {
    this.autores = this.autores.sort((a, b) => {
      if (a.nome < b.nome) { return -1; }
      if (a.nome > b.nome) { return 1; }
      return 0;
    });
  }

  ordenarPorId() {
    this.autores = this.autores.sort((a, b) => a.id - b.id);
  }

  ordenarPorNacionalidade() {
    this.autores = this.autores.sort((a, b) => {
      if (a.nacionalidade < b.nacionalidade) { return -1; }
      if (a.nacionalidade > b.nacionalidade) { return 1; }
      return 0;
    });
  }

  ordenarPorData() {
    this.autores = this.autores.sort((a, b) => new Date(a.dataDeNascimento).getTime() - new Date(b.dataDeNascimento).getTime());
  }


  filtrarAutores() {
    if (this.termoDePesquisa != '') {
      this.autores = this.autores.filter(autor => autor.nome.toLowerCase().includes(this.termoDePesquisa.toLowerCase()));
    } else {
      this.autores = this.autoresOriginal;
    }
  }

}
