import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { autor } from 'src/app/models/autor.models';
import { DataService } from 'src/app/services/data.service';
import { DialogoService } from 'src/app/services/dialogo.service';
import { DateValidator, numberValidator } from 'src/app/validators';

@Component({
  selector: 'app-novo-livro',
  templateUrl: './novo-livro.component.html',
  styleUrls: ['./novo-livro.component.css']
})
export class NovoLivroComponent {
  public form: FormGroup;
  public autores$!: Observable<autor[]>;

  constructor(
    private livrariaService: DataService,
    private fb: FormBuilder,
    private dialogoService: DialogoService
  ) {
    this.form = this.fb.group({
      titulo: ['', Validators.compose([
        Validators.minLength(3),
        Validators.maxLength(100),
        Validators.required
      ])],
      subtitulo: ['', Validators.compose([
        Validators.maxLength(200)
      ])],
      quantidadeDePaginas: ['', Validators.compose([
        Validators.required
      ])],
      dataDePublicacao: ['', Validators.compose([
        Validators.maxLength(10),
        DateValidator(),
        Validators.required
      ])],
      editora: ['', Validators.compose([
        Validators.maxLength(100),
        Validators.required
      ])],
      edicao: ['', Validators.compose([
      ])],
      isbn: ['', Validators.compose([
        Validators.minLength(13),
        Validators.maxLength(13),
        numberValidator()
      ])],
      quantidadeEmEstoque: ['', Validators.compose([
        Validators.required
      ])],
      fotoDaCapa: ['', Validators.compose([
        Validators.maxLength(500)
      ])],
      resumo: ['', Validators.compose([
        Validators.maxLength(1200)
      ])]
    });
  }

  async ngOnInit(): Promise<void> {
    this.autores$ = await this.livrariaService.retornarAutores();
  }

  async submit() {
    let formValue = this.form.value;
    let resultadoDoDialogo = await this.dialogoService.abrirDialogo("Deseja salvar o livro: " + formValue.titulo);
    if (resultadoDoDialogo) {
      if (formValue.dataDePublicacao == '') {
        formValue.dataDePublicacao = null;
      }
      this
        .livrariaService
        .cadastraLivro(formValue)
        .subscribe(
          async (data) => {
            console.log(data);
            await this.dialogoService.abrirMensagem('Criado.', 'Livro "' + formValue.titulo + '" criado com sucesso!');
            window.history.back();
          },
          (err) => {
            console.log(err);
            this.dialogoService.abrirMensagem('Desculpe!', 'Não foi possível cadastrar o livro. Para mais informações acesse o "ConsoleLog" do seu navegador.');
          }
        );
    }
  }

}
