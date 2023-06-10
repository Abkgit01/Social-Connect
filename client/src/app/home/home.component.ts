import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  registerMode = false;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }

  registerToggler(){
    this.registerMode = true;
  }

  cancelRegister(event: boolean){
    this.registerMode = event;
  }
}
