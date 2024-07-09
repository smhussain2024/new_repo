import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { AllBooksComponent } from './all-books/all-books.component';
import { BookServiceService } from './Services/book-service.service';
import { FormsModule } from '@angular/forms';
import { AddBookComponent } from './add-book/add-book.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { AccountServiceService } from './Services/account-service.service';

@NgModule({
  declarations: [
    AppComponent,
    AllBooksComponent,
    AddBookComponent,
    SignUpComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [
    BookServiceService,
    AccountServiceService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
