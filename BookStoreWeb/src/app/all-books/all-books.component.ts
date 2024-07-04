import { Component, OnInit } from '@angular/core';
import { BookServiceService } from '../Services/book-service.service';

@Component({
  selector: 'app-all-books',
  templateUrl: './all-books.component.html',
  styleUrl: './all-books.component.css'
})
export class AllBooksComponent implements OnInit {

  public books : any;
  constructor(private service : BookServiceService) { }

  ngOnInit(): void {
    this.getBooks();
  }

  public getBooks(): void {
    this.service.getBooks().subscribe(result => {
      this.books = result;
    });
  }
}
