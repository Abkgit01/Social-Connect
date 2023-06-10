import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable } from 'rxjs';
import { User } from '../_Models/user';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};

  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
  }

  login(){
    this.accountService.login(this.model).subscribe(response =>{
      console.log(response);
    }, error =>{
      console.log(error);
    })

  }

  logOut(){
    this.accountService.logOut();
  }

}
