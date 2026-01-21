import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class ProductService {
  // Use your actual backend URL and port
  private apiUrl = 'http://localhost:5158';

  constructor(private http: HttpClient) {}

  getProducts() {
    return this.http.get<any[]>(`${this.apiUrl}/products`);
  }

  placeOrder(productId: number, quantity: number) {
    return this.http.post<{ message: string }>(`${this.apiUrl}/orders`, {
      productId,
      quantity
    });
  }
}