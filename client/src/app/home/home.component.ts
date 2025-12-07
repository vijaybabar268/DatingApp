import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  users: any;

  constructor(private accountService: AccountService) { }
  
  ngOnInit(): void {
    this.getUsers();
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  getUsers() {
    this.accountService.getUsers().subscribe({
      next : response => this.users = response,
      error: error => console.log(error),
      complete: () => console.log('Request has completed.')
    })
  }

  cancelRegisterMode($event: any) {
    this.registerMode = $event;
  }
}
