import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CaixaDeDialogoComponent } from '../components/shared/caixa-de-dialogo/caixa-de-dialogo.component';

@Injectable({
  providedIn: 'root'
})
export class DialogoService {
  constructor(public dialogo: MatDialog) { }

  async abrirDialogo(mensagem: string): Promise<boolean> {
    const dialogRef = this.dialogo.open(CaixaDeDialogoComponent);
    dialogRef.componentInstance.mensagem = mensagem;

    const result = await dialogRef.afterClosed().toPromise();

    return result === true;
  }
}
