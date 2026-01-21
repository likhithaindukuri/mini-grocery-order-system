import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
  standalone: false
})
export class HomePage implements OnInit {

  products: any[] = [];
  quantities: { [productId: number]: number } = {};
  message = '';

  constructor(private productService: ProductService) {}

  ngOnInit() {
    this.productService.getProducts().subscribe({
      next: (data) => {
        this.products = data;
        this.products.forEach((product) => {
          this.quantities[product.id] = 1;
        });
      },
      error: () => {
        this.message =
          'Failed to load products. Please check if the backend is running.';
      }
    });
  }

  order(productId: number) {
    const quantity = this.quantities[productId] ?? 1;

    this.productService.placeOrder(productId, quantity).subscribe({
      next: (res) => {
        this.message = res.message;
      },
      error: (err) => {
        this.message =
          err?.error?.message ?? 'Order failed. Please try again.';
      }
    });
  }
}
