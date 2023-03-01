import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { FuncoesUteis } from 'src/app/funcoes-uteis';
import { autor } from 'src/app/models/autor.models';
import { DataService } from 'src/app/services/data.service';
import { DateValidator, nonNumericValidator } from 'src/app/validators';

@Component({
  selector: 'app-novo-autor',
  templateUrl: './novo-autor.component.html',
  styleUrls: ['./novo-autor.component.css']
})
export class NovoAutorComponent implements OnInit {
  public form: FormGroup;

  constructor(
    private livrariaService: DataService,
    private fb: FormBuilder
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

  ngOnInit(): void {
  }

  async submit() {
    let formValue = this.form.value;
    if (formValue.dataDeNascimento === '') {
      delete formValue.dataDeNascimento;
    }
    this
      .livrariaService
      .cadastraAutor(formValue)
      .subscribe(
        (data) => {
          console.log(data);
        },
        (err) => {
          console.log(err);
        }
      );
  }
}


