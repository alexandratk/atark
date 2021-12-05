import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { User, UserRegister } from 'src/app/interfaces/interfaces';
import { AddUserService } from 'src/app/services/add-user.service';

@Component({
  selector: 'app-add-new-admin',
  templateUrl: './add-new-admin.component.html',
  styleUrls: ['./add-new-admin.component.scss']
})
export class AddNewAdminComponent implements OnInit {

  form!: FormGroup;
  responce: any;
  userRegister!: UserRegister;
  user!: User;
  select_list = ["Администратор", "Ученик", "Учитель", "Родственник"];
  selectedRole = this.select_list[1];
  educInstId: any = localStorage.getItem("auth-udecinstid")
  constructor(private http: HttpClient,
    private addservice: AddUserService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      educationalInstitutionId: new FormControl(null, [Validators.required]),
      name: new FormControl(null, [Validators.required]),
      dateofbirth: new FormControl(null, [Validators.required]),
      login: new FormControl(null, [Validators.required]),
      password: new FormControl(null, [Validators.required])
  })
  }

  onSubmit() {
    this.userRegister = this.form.value
    this.userRegister.id = "1"
    this.addservice.add_user_admin(this.userRegister)
  }

  onChange(event: any) {
    this.selectedRole = event
    alert(event);
  }

}
