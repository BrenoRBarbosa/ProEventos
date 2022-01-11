import { Component, OnInit, ValueProvider } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-evento-detalhes',
  templateUrl: './evento-detalhes.component.html',
  styleUrls: ['./evento-detalhes.component.scss']
})
export class EventoDetalhesComponent implements OnInit {

  form!: FormGroup;

  get f(): any{
    return this.form.controls;
  }

  constructor( private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  public validation(): void{
    this.form = this.fb.group({
      tema: ["",[Validators.required,Validators.minLength(4), Validators.maxLength(50)]],
      local: ["",Validators.required],
      dataEvento: ["",Validators.required],
      qtdPessoas: ["",[Validators.required, Validators.max(120000)]],
      telefone: ["",Validators.required],
      email: ["",[Validators.required, Validators.email]],
      imagemURL: ["",Validators.required],
    });
  }

  public resetForm(): void{
    this.form.reset();
  }

}
