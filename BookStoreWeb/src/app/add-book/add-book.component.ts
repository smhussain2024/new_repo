import { Component } from '@angular/core';
import { BookServiceService } from '../Services/book-service.service';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrl: './add-book.component.css'
})
export class AddBookComponent {

  constructor(private service : BookServiceService) { }

  public addBooks(data: any): void {
    this.service.addBook(data).subscribe(result => {
      alert(`New book added with id  = ${result}`);
    });
  }
}
