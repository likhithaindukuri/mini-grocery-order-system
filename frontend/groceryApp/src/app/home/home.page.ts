import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
  standalone: false,
})
export class HomePage implements OnInit {

  products: any[] = [];
  quantity = 1;
  message = '';

  constructor(private productService: ProductService) {}

  ngOnInit() {
    this.productService.getProducts().subscribe({
      next: (data) => {
        this.products = data;
      },
      error: () => {
        this.message =
          'Failed to load products. Please check if the backend is running.';
      }
    });
  }

  order(productId: number) {
    this.productService.placeOrder(productId, this.quantity).subscribe({
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
