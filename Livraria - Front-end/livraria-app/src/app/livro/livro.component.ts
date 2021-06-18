import { LivroService } from '../services/livro.service';

import { Component, OnInit } from '@angular/core';
import { Livro } from '../models/livro.model';

@Component({
  selector: 'app-livro',
  templateUrl: './livro.component.html',
  styleUrls: ['./livro.component.scss']
})
export class LivroComponent implements OnInit {

  livros: any[] = [];

  constructor(private livroService: LivroService) { }

  ngOnInit(): void {
    this.livroService.getAllLivros().subscribe((livros: Livro[]) => {
      console.table(livros);
      this.livros = livros;
    })
  }

}
