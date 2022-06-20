import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { User, UserRegister } from 'src/app/interfaces/interfaces';
import { AddUserService } from 'src/app/services/add-user.service';
@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.scss']
})
export class UpdateUserComponent implements OnInit {

  form!: FormGroup;
  responce: any;
  userRegister!: any;
  user!: User;
  select_list = ["Администратор", "Ученик", "Учитель", "Родственник"];
  selectedRole = this.select_list[1];
  namberPupil: any = localStorage.getItem('number-pupil');
  educInstId: any = localStorage.getItem("auth-udecinstid")
  value: any = localStorage.getItem('auth-token');
  headers: HttpHeaders = new HttpHeaders({ ['Authorization']: 'Bearer ' + this.value });
  constructor(private http: HttpClient,
    private addservice: AddUserService) { 
    }
    list_request() {
      this.http.get('http://localhost:5000/Pupil/getpupil/' + this.namberPupil, {headers: this.headers}).subscribe(
        (data: any) => {
          this.userRegister = data
          console.log(this.userRegister)
          let date: Date = this.userRegister.dateofbirth;
          this.form = new FormGroup({
            name: new FormControl(this.userRegister.name, [Validators.required]),
            dateofbirth: new FormControl(date.getFullYear + '-' + date.getMonth + '-' + date.getDate, [Validators.required]),
            login: new FormControl(this.userRegister.login, [Validators.required]),
            password: new FormControl(this.userRegister.password, [Validators.required])
          })
        },
        error => {
            console.warn(error)
        })
    }
  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(null, [Validators.required]),
      dateofbirth: new FormControl(null, [Validators.required]),
      login: new FormControl(null, [Validators.required]),
      password: new FormControl(null, [Validators.required]),
      groupId: new FormControl(null, [Validators.required])
    })
    this.list_request()
  }

  onSubmitUpdate() {
    this.userRegister = this.form.value
    this.http.post('http://localhost:5000/Pupil/updatepupil/' + this.namberPupil, this.userRegister, {headers: this.headers}).subscribe(
      () => {
        alert("ok")
      },
      error => {
          console.warn(error)
      })
  }

  onChange(event: any) {
    this.selectedRole = event
    alert(event);
  }

}
