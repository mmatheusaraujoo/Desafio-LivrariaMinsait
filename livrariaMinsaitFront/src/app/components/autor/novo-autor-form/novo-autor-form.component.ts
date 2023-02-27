import { Component } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { nonNumericValidator } from 'src/app/validators';

@Component({
  selector: 'app-novo-autor-form',
  templateUrl: './novo-autor-form.component.html',
  styleUrls: ['./novo-autor-form.component.css']
})
export class NovoAutorFormComponent {

  nomeFormControl = new FormControl('', [Validators.required, Validators.maxLength(50), nonNumericValidator()]);
  matcher = new MyErrorStateMatcher();


}


export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}