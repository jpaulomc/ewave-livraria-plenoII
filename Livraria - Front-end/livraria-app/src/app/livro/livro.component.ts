import { LivroService } from './../livro.service';
import { Component, OnInit } from '@angular/core';
import { Livro } from '../models/livro.model';

@Component({
  selector: 'app-livro',
  templateUrl: './livro.component.html',
  styleUrls: ['./livro.component.scss']
})
export class LivroComponent implements OnInit {

  livros: any[] = [];

  constructor(private service: LivroService) { }

  ngOnInit(): void {
    this.service.getAllLivros().subscribe((livros: Livro[]) => {
      console.table(livros);
      this.livros = livros;
    })
  }

}
