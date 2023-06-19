import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../shared/models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  public postUser(user: User): Observable<any> {
    return this.http.post(environment.backend.baseUrl + environment.backend.endpoints.user,user)
  }

  public putUser(user: User): Observable<any> {
    return this.http.put(environment.backend.baseUrl + environment.backend.endpoints.user + user.id,user)
  }

  public listUsers(): Observable<User[]> {
    return this.http.get<User[]>(environment.backend.baseUrl + environment.backend.endpoints.user)
  }

  public getUser(id :string): Observable<User> {
    return this.http.get<User>(environment.backend.baseUrl + environment.backend.endpoints.user + id)
  }
}
