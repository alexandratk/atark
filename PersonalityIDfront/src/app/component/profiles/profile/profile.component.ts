import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from 'src/app/services/auth.service';
import { User, UserData } from 'src/app/interfaces/interfaces';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
  userName: string = "";
  userDate: string = "";
  userId: any = localStorage.getItem("auth-id");
  userRole: any = localStorage.getItem("auth-role");
  userData!: UserData;
  user: User = {
    id:this.userId,
    role:this.userRole,
    password:"1234",
    login:"1234",
  }
  responce: any;
  constructor(private http: HttpClient,
    private auth:AuthService) { 
      this.mysearch()
  }

  mysearch() {
    this.http.post('http://localhost:5000/user/profile', this.user).subscribe(
            (data: any) => {
                this.userData = data;
                this.userName = this.userData.name
                this.userDate = this.userData.dateofbirth
            },
            error => {
                console.warn(error)
            })
  }
}
