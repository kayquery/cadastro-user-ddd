import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/shared/models/User';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  public users: User[] = []

  constructor(private _userService: UserService) { }

  ngOnInit(): void {
    this._userService.listUsers().subscribe( users => this.users = users);
  }

}
