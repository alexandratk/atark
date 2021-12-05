import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { User, UserRegister } from 'src/app/interfaces/interfaces';
import { AddUserService } from 'src/app/services/add-user.service';

@Component({
  selector: 'app-add-new-user',
  templateUrl: './add-new-user.component.html',
  styleUrls: ['./add-new-user.component.scss']
})
export class AddNewUserComponent implements OnInit {

  form!: FormGroup;
  responce: any;
  userRegister!: any;
  user!: User;
  select_list = ["Администратор", "Ученик", "Учитель", "Родственник"];
  selectedRole = this.select_list[1];
  educInstId: any = localStorage.getItem("auth-udecinstid")
  constructor(private http: HttpClient,
    private addservice: AddUserService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(null, [Validators.required]),
      dateofbirth: new FormControl(null, [Validators.required]),
      login: new FormControl(null, [Validators.required]),
      password: new FormControl(null, [Validators.required]),
      groupId: new FormControl(null, [Validators.required])
    })
  }

  onSubmit() {
    this.userRegister = this.form.value
    this.userRegister.educationalInstitutionId = this.educInstId
    this.userRegister.id = "1"
    if (this.selectedRole == "Администратор") {
      this.addservice.add_user_admin(this.userRegister)
    }
    if (this.selectedRole == "Родственник") {
      this.addservice.add_user_parent(this.userRegister)
    }
    if (this.selectedRole == "Учитель") {
      this.addservice.add_user_teacher(this.userRegister)
    }
    if (this.selectedRole == "Ученик") {
      this.addservice.add_user_pupil(this.userRegister)
    }

  }

  onChange(event: any) {
    this.selectedRole = event
    alert(event);
  }

}
