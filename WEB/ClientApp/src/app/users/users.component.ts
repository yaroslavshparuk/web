import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';
import { take } from 'rxjs/operators';
import { BehaviorSubject, Observable } from 'rxjs';

@Component({
  selector: 'users-data',
  templateUrl: './users.component.html'
})
export class UsersComponent implements OnInit {
  public users$ = new Observable<User[]>();

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) { }

  ngOnInit(): void {
    this.users$ = this.http.get<User[]>(this.baseUrl + 'user/get');
  }
}
