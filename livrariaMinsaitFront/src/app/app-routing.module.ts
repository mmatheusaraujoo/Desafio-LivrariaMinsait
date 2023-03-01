import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AutorComponent } from './pages/autor/autor.component';
import { AutoresComponent } from './pages/autores/autores.component';
import { HomeComponent } from './pages/home/home.component';
import { LivroComponent } from './pages/livro/livro.component';
import { LivrosComponent } from './pages/livros/livros.component';
import { NovoAutorComponent } from './pages/novo-autor/novo-autor.component';
import { NovoLivroComponent } from './pages/novo-livro/novo-livro.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'Livros',
    component: LivrosComponent
  },
  {
    path: 'Autores',
    component: AutoresComponent
  },
  {
    path: 'Autor/{id}',
    component: AutorComponent
  },
  {
    path: 'Livro/{id}',
    component: LivroComponent
  },
  {
    path: 'Autor/Novo-Autor',
    component: NovoAutorComponent
  },
  {
    path: 'Livro/Novo-Livro',
    component: NovoLivroComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
