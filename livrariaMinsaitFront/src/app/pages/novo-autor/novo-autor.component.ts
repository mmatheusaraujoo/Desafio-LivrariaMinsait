import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { FuncoesUteis } from 'src/app/funcoes-uteis';
import { DataService } from 'src/app/services/data.service';
import { nonNumericValidator } from 'src/app/validators';

@Component({
  selector: 'app-novo-autor',
  templateUrl: './novo-autor.component.html',
  styleUrls: ['./novo-autor.component.css']
})
export class NovoAutorComponent implements OnInit {

  private service: DataService;
  public form: FormGroup;

  constructor(
    private livrariaService: DataService,
    private fb: FormBuilder
  ) {
    const teste = FuncoesUteis.converterParaData('09/05/1999');
    this.service = livrariaService;
    this.form = this.fb.group({
      nome: ['', Validators.compose([
        Validators.minLength(3),
        Validators.maxLength(50),
        nonNumericValidator(),
        Validators.required
      ])],
      data: ['', this.DateValidator]
    });
  }

  ngOnInit(): void {

  }

  DateValidator(control: FormControl) {
    const value = control.value;
    const regex = /^(0?[1-9]|[1-2]\d|3[01])\/(0?[1-9]|1[0-2])\/\d{4}$/;
    if (!regex.test(value)) {
      return { invalidDate: true };
    }
    return null;
  }

}


