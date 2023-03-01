import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatToolbarModule } from '@angular/material/toolbar';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { HomeComponent } from './pages/home/home.component';
import { LivrosComponent } from './pages/livros/livros.component';
import { AutoresComponent } from './pages/autores/autores.component';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';
import { LivroCardComponent } from './components/livro/livro-card/livro-card.component';
import { MatCardModule } from '@angular/material/card';
import { AutorCardComponent } from './components/autor/autor-card/autor-card.component';
import { AutorComponent } from './pages/autor/autor.component';
import { LivroComponent } from './pages/livro/livro.component';
import { NovoAutorComponent } from './pages/novo-autor/novo-autor.component';
import { NovoLivroComponent } from './pages/novo-livro/novo-livro.component';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { CaixaDeDialogoComponent } from './components/shared/caixa-de-dialogo/caixa-de-dialogo.component';
import { MatDialogModule } from '@angular/material/dialog';
import { CaixaDeMensagemComponent } from './components/shared/caixa-de-mensagem/caixa-de-mensagem.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    LivrosComponent,
    AutoresComponent,
    LivroCardComponent,
    AutorCardComponent,
    AutorComponent,
    LivroComponent,
    NovoAutorComponent,
    NovoLivroComponent,
    CaixaDeDialogoComponent,
    CaixaDeMensagemComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    CommonModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSlideToggleModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    MatSelectModule,
    FormsModule,
    ReactiveFormsModule,
    MatDividerModule,
    MatListModule,
    MatCardModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatDialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
