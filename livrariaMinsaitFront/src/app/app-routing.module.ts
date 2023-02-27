import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AutorComponent } from './pages/autor/autor.component';
import { AutoresComponent } from './pages/autores/autores.component';
import { HomeComponent } from './pages/home/home.component';
import { LivroComponent } from './pages/livro/livro.component';
import { LivrosComponent } from './pages/livros/livros.component';

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
    path: 'Autores/{id}',
    component: AutorComponent
  },
  {
    path: 'Livros/{id}',
    component: LivroComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
