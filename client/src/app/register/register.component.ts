import { Component, Input, OnInit, Output } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
@Output() emitSomethingOut = new EventEmitter();

  model: any = {};

  constructor(private accountService: AccountService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  register(){
    this.accountService.register(this.model).subscribe(user =>{
      console.log(user);
      this.cancel();
    }, error=> {
      console.log(error);
      this.toastr.error(error.error);
    })
  }

  cancel(){
    console.log('cancelled');
    this.emitSomethingOut.emit(false);
  }
  
}
