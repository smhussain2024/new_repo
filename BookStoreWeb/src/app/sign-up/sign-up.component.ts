import { Component } from '@angular/core';
import { AccountServiceService } from '../Services/account-service.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.css'
})
export class SignUpComponent {
  
  public books : any;
  constructor(private service : AccountServiceService) { }

  public SignUp(data: any): void {
    this.service.signUp(data).subscribe(result => {
      alert(`Sign-Up = ${result}`);
    });
  }
}
