import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent {
  user = {
    username: '',
    email: '',
    password: '',
    confirmPassword: '',
    termsOfUseAccepted: false
  };
  responseMessage = ''; // Mensagem para mostrar ao usuário

  constructor(private http: HttpClient) { }

  registerUser(): void {
    const apiUrl = 'https://localhost:7143/register';

    // Envia a requisição ao backend
    this.http.post<any>(apiUrl, this.user).subscribe(
      response => {
        this.responseMessage = response.message; // Exibe a mensagem retornada do backend
      },
      error => {
        if (error.status === 400) {
          const errorMessage = error.error?.message || 'Erro desconhecido.';
          this.responseMessage = errorMessage; // Exibe a mensagem de erro retornada do backend
        } else {
          this.responseMessage = 'Erro ao registrar usuário: ' + (error.error?.message || error.message);
        }
      }
    );
  }
}
