import { Component, Input } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-caixa-de-mensagem',
  templateUrl: './caixa-de-mensagem.component.html',
  styleUrls: ['./caixa-de-mensagem.component.css']
})
export class CaixaDeMensagemComponent {
  @Input() public mensagem!: string;
  @Input() public titulo!: string;

  constructor(public dialogRef: MatDialogRef<CaixaDeMensagemComponent>) { }

}
