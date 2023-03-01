import { Component } from '@angular/core';
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

  constructor(
    private data: DataService,
    private dialogoService: DialogoService) {

  }

  async ngOnInit() {
    this.autores$ = await this.data.retornarAutores();
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

}
