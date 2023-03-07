import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { autor } from 'src/app/models/autor.models';
import { DataService } from 'src/app/services/data.service';
import { DialogoService } from 'src/app/services/dialogo.service';
import { DateValidator, nonNumericValidator } from 'src/app/validators';

@Component({
  selector: 'app-editar-autor',
  templateUrl: './editar-autor.component.html',
  styleUrls: ['./editar-autor.component.css']
})
export class EditarAutorComponent {
  public form: FormGroup;
  @Input() public autor$!: Observable<autor>;
  public autor!: autor | null;

  constructor(
    private livrariaService: DataService,
    private fb: FormBuilder,
    private dialogoService: DialogoService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.form = this.fb.group({
      nome: ['', Validators.compose([
        Validators.minLength(3),
        Validators.maxLength(50),
        nonNumericValidator(),
        Validators.required
      ])],
      dataDeNascimento: ['', Validators.compose([
        Validators.maxLength(10),
        DateValidator()
      ])],
      nacionalidade: ['', Validators.compose([
        Validators.maxLength(100)
      ])],
      foto: ['', Validators.compose([
        Validators.maxLength(500)
      ])],
      resumoBibliografico: ['', Validators.compose([
        Validators.maxLength(1200)
      ])]
    });
  }


  ngOnInit() {
    const id = this.route.snapshot.params['id'];
    this.autor$ = this.livrariaService.retornarAutor(id);
    this.autor$.subscribe(autorData => {
      this.autor = autorData;
      if (this.autor) {
        this.form.patchValue({
          nome: this.autor?.nome,
          dataDeNascimento: this.autor?.dataDeNascimento ? new Date(this.autor.dataDeNascimento).toISOString().slice(0, 10) : '',
          nacionalidade: this.autor?.nacionalidade,
          foto: this.autor?.foto,
          resumoBibliografico: this.autor?.resumoBibliografico
        });
      }
    });
  }

  async submit() {
    let formValue = this.form.value;
    let resultadoDoDialogo = await this.dialogoService.abrirDialogo("Deseja alterar o autor: " + this.autor!.nome);
    if (resultadoDoDialogo) {
      if (formValue.dataDeNascimento == '') {
        formValue.dataDeNascimento = null;
      }
      this
        .livrariaService
        .alterarAutor(this.autor!.id, formValue)
        .subscribe(
          async (data) => {
            console.log(data);
            await this.dialogoService.abrirMensagem('Altereado', 'Autor "' + this.autor!.id + '" alterado com sucesso!');
            this.router.navigate(['/autor/detalhes/' + this.autor!.id]);
          },
          (err) => {
            console.log(err);
            this.dialogoService.abrirMensagem('Desculpe!', 'Não foi possível alterar o autor. Para mais informações acesse o "ConsoleLog" do seu navegador.');
          }
        );
    }
  }
}
