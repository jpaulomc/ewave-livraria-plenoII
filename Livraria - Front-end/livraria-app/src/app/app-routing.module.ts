import { LivroComponent } from './livro/livro.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LivroNovoComponent } from './livro-novo/livro-novo.component';

export const routes: Routes = [
  { path: '', redirectTo: 'livro', pathMatch: 'full'},
  { path: 'livro', component: LivroComponent },
  { path: 'livro-novo', component: LivroNovoComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
