import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './password.component.html',
  styleUrls: ['./password.component.css']
})

export class PasswordComponent {
  user = {
    email: ''
  };
  responseMessage = ''; 

  constructor(private http: HttpClient) { }

  resetPassword(): void {
    const apiUrl = 'https://localhost:7143/reset';

    // Envia a requisição ao backend
    this.http.post<any>(apiUrl, this.user).subscribe(
      response => {
        this.responseMessage = response.message;
      },
      error => {
        if (error.status === 400) {
          const errorMessage = error.error?.message || 'Erro desconhecido.';
          this.responseMessage = errorMessage;
        } else {
          this.responseMessage = 'Erro ao fazer resetar senha: ' + (error.error?.message || error.message);
        }
      }
    );
  }
}
