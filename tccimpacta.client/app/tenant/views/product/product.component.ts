import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent {
  product = {
    productName: "Tapete de Yoga PU",
    productValue: 475,
    emailAddress: ""
  }

  constructor(private http: HttpClient) { }

  buyProduct(): void {
    const apiUrl = 'https://localhost:7143/buy';

    this.http.post<any>(apiUrl, this.product).subscribe(
    );
  }
}
