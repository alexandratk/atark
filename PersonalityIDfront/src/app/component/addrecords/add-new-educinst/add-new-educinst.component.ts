import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { EducationalInstitution, Group } from 'src/app/interfaces/interfaces';
import { AddUserService } from 'src/app/services/add-user.service';

@Component({
  selector: 'app-add-new-educinst',
  templateUrl: './add-new-educinst.component.html',
  styleUrls: ['./add-new-educinst.component.scss']
})
export class AddNewEducinstComponent implements OnInit {

  form!: FormGroup;
  responce: any;
  educInst!: EducationalInstitution;
  select_list = ["Администратор", "Ученик", "Учитель", "Родственник"];
  selectedRole = this.select_list[1];
  educInstId: any = localStorage.getItem("auth-udecinstid")
  constructor(private http: HttpClient,
    private addservice: AddUserService) { }

    ngOnInit(): void {
      this.form = new FormGroup({
        title: new FormControl(null, [Validators.required]),
        address: new FormControl(null, [Validators.required]),
        timetable: new FormControl(null, [Validators.required])
    })
    }

    onSubmit() { 
      this.educInst = this.form.value
      this.addservice.add_educinst(this.educInst)
    }

    onChange(event: any) {
      this.selectedRole = event
      alert(event);
    }

}
