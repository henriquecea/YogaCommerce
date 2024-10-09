import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})

export class ContactComponent {
  contact = {
    name: '',
    phone: '',
    email: '',
    subject: '',
    message: ''
  };
  responseMessage = ''; // Mensagem para mostrar ao usuário

  constructor(private http: HttpClient) { }

  sendContact(): void {
    const apiUrl = 'https://localhost:7143/contact';

    // Envia a requisição ao backend
    this.http.post<any>(apiUrl, this.contact).subscribe(
      response => {
        this.responseMessage = response.message; // Exibe a mensagem retornada do backend
      },
      error => {
        if (error.status === 400) {
          const errorMessage = error.error?.message || 'Erro desconhecido.';
          this.responseMessage = errorMessage; // Exibe a mensagem de erro retornada do backend
        } else {
          this.responseMessage = 'Erro ao registrar contato: ' + (error.error?.message || error.message);
        }
      }
    );
  }
}


