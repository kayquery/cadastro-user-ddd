import { ToastrService } from 'ngx-toastr';
import { User } from './../../shared/models/User';
import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {

  public edit: boolean = false;
  public user: User = {
    name: '',
    document: '',
    email: '',
    birthDate: new Date,
    zipCode: '',
    id: ''
  }

  constructor(private _toastrService: ToastrService, private _userService: UserService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');

      if(id != null)
      {
        this.edit = true;
        this._userService.getUser(id).subscribe(user => {this.user = user; console.log(user)});
      }
    });
  }

  public signUpUser(): void {
    if(!this.isUserValid())
      return;

    this._userService.postUser(this.user).subscribe( x => {

      this._toastrService.success("Usuário cadastrado")
    },
    (error: HttpErrorResponse) => {
      console.log(error)

      this._toastrService.error("Houve um erro na solicitação de cadastro");
    })

  }

  public editUser(): void {
    if(!this.isUserValid())
    return;

    this._userService.putUser(this.user).subscribe( x => {

      this._toastrService.success("Usuário editado")
    },
    (error: HttpErrorResponse) => {
      console.log(error)

      this._toastrService.error("Houve um erro na solicitação de cadastro");
    })

  }

  private isUserValid(): boolean {
    let ret: boolean = true;

    if( this.user.birthDate == undefined)
      ret = false;

    if( this.user.name == "")
      ret = false;

    if( this.user.email == "")
      ret = false;

    if( this.user.document == "")
      ret = false;

    if( this.user.zipCode == "")
      ret = false;

    if(!ret)
      this._toastrService.error("Todos os campos devem ser preenchidos");

    return ret;
  }
}
