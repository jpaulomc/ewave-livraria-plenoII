import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LivroNovoComponent } from './livro-novo.component';

describe('LivroNovoComponent', () => {
  let component: LivroNovoComponent;
  let fixture: ComponentFixture<LivroNovoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LivroNovoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LivroNovoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
