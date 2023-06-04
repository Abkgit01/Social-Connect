import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Dating App';
  users: any;

  constructor(private http: HttpClient){}

  ngOnInit(){
    this.getUsers();
  }

  getUsers(){
    this.http.get('https://localhost:7220/api/Users/GetUsers').subscribe(response =>{
      this.users = response;
    }, error =>{
      console.log('error occured');
      console.log(error);
    })
  }

}
