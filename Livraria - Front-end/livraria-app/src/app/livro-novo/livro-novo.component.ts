import { AutorService } from './../services/autor.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, FormControlName } from '@angular/forms';
import { GeneroService } from '../services/genero.service';
import { LivroService } from '../services/livro.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-livro-novo',
  templateUrl: './livro-novo.component.html',
  styleUrls: ['./livro-novo.component.scss']
})
export class LivroNovoComponent implements OnInit {

  @Output() public onUploadFinished = new EventEmitter();

  autores: any;
  generos: any;
  form!: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private autorService: AutorService,
    private generoService: GeneroService,
    private livroService: LivroService,
    private router: Router ) { }

  ngOnInit(): void {

    this.getAutores();
    this.getGeneros();
    this.form = this.formBuilder.group({
      file: [''],
      titulo: [''],
      autor: [''],
      genero: [''],
      ativo: ['']
    });
  }

  onFileSelect(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.form.get('file')?.setValue(file);
    }
  }


  getAutores(){
    this.autorService.getAllAutor().subscribe(autor => this.autores = autor);
  }

  getGeneros(){
    this.generoService.getAllGenero().subscribe(genero => this.generos = genero);
  }
  salvarLivro(){
    const formData = new FormData();
    formData.append('Titulo', this.form.get('titulo')?.value);
    formData.append('AutorID', this.form.get('autor')?.value);
    formData.append('GeneroID', this.form.get('genero')?.value);
    formData.append('Ativo', this.form.get('ativo')?.value);
    formData.append('file', this.form.get('file')?.value);

    this.livroService.addLivro(formData).subscribe(livro => {
      console.log(livro);
    });
    this.router.navigate(['/livro']);

  //  console.log(this.form.get('titulo')?.value);
  //  console.log(this.form.get('autor')?.value);
  //  console.log(this.form.get('genero')?.value);
  //  console.log(this.form.get('ativo')?.value);
  //  console.log(this.form.get('file')?.value);
  }


}
