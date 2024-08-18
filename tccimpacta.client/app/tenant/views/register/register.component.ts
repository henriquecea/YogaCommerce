import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent {
  user = {
    user: '',
    email: '',
    password: '',
    confirmPassword: ''
  };
  responseMessage = '';

  constructor(private http: HttpClient) { }

  registerUser(): void {
    const apiUrl = 'https://localhost:7143/register';
    this.http.post(apiUrl, this.user)
      .subscribe(
        response => {
          this.responseMessage = 'Usuário registrado com sucesso!';
        },
        error => {
          this.responseMessage = 'Erro ao registrar usuário' + error;
          console.error('erro aqui' + error);
        }
      );
  }
}
