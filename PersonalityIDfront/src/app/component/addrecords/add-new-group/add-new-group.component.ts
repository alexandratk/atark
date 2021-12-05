import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Group } from 'src/app/interfaces/interfaces';
import { AddUserService } from 'src/app/services/add-user.service';

@Component({
  selector: 'app-add-new-group',
  templateUrl: './add-new-group.component.html',
  styleUrls: ['./add-new-group.component.scss']
})
export class AddNewGroupComponent implements OnInit {

  form!: FormGroup;
  responce: any;
  group!: Group;
  select_list = ["Администратор", "Ученик", "Учитель", "Родственник"];
  selectedRole = this.select_list[1];
  educInstId: any = localStorage.getItem("auth-udecinstid")
  constructor(private http: HttpClient,
    private addservice: AddUserService) { }

    ngOnInit(): void {
      this.form = new FormGroup({
        title: new FormControl(null, [Validators.required]),
        teacherId: new FormControl(null, [Validators.required])
    })
    }

    onSubmit() { 
      this.group = this.form.value
      this.group.educationalInstitutionId = this.educInstId
      this.group.id = "1"
      this.addservice.add_user_group(this.group)
    }

    onChange(event: any) {
      this.selectedRole = event
      alert(event);
    }

}
