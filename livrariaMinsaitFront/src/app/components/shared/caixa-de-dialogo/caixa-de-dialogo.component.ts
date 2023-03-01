import { Component, Input } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-caixa-de-dialogo',
  templateUrl: './caixa-de-dialogo.component.html',
  styleUrls: ['./caixa-de-dialogo.component.css']
})
export class CaixaDeDialogoComponent {
  @Input() public mensagem!: string;

  constructor(public dialogRef: MatDialogRef<CaixaDeDialogoComponent>) { }
}
