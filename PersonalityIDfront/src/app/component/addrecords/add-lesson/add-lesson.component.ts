import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Lesson, User, UserRegister } from 'src/app/interfaces/interfaces';
import { AddUserService } from 'src/app/services/add-user.service';

@Component({
  selector: 'app-add-lesson',
  templateUrl: './add-lesson.component.html',
  styleUrls: ['./add-lesson.component.scss']
})
export class AddLessonComponent implements OnInit {

  points: any
  educInst: any
  strGroups: any
  timetable: any;
  form!: FormGroup;
  form1!: FormGroup;
  responce: any;
  userRegister!: UserRegister;
  lesson!: Lesson;
  selectedTime: any;
  educInstId: any = localStorage.getItem("auth-udecinstid")
  value: any = localStorage.getItem('auth-token');
  localDBGroups: any = []
  selectedItemGroups: any = [];
  localDBGroups1: any = []
  selectedItemGroups1: any = [];
  headers: HttpHeaders = new HttpHeaders({ ['Authorization']: 'Bearer ' + this.value });
  constructor(private http: HttpClient,
    private addservice: AddUserService) { 
      this.list_group()

    }
    
  changeStatusGroups(userId: any, $event: any) {
      const checkBoxValue = $event.srcElement.checked;
      if (checkBoxValue) {
        const elementToPush = this.localDBGroups.find((el: { id: any; }) => el.id == userId);
        if (elementToPush)
          this.selectedItemGroups.push(elementToPush)
  
        console.log(this.selectedItemGroups)
      }
      else {
        const elementIndexToDelete = this.selectedItemGroups.findIndex((el: { id: any; }) => el.id == userId);
        this.selectedItemGroups.splice(elementIndexToDelete, 1);
        console.log(this.selectedItemGroups)
      }
    }

    changeStatusGroups1(userId: any, $event: any) {
      const checkBoxValue = $event.srcElement.checked;
      if (checkBoxValue) {
        const elementToPush = this.localDBGroups1.find((el: { id: any; }) => el.id == userId);
        if (elementToPush)
          this.selectedItemGroups1.push(elementToPush)
  
        console.log(this.selectedItemGroups1)
      }
      else {
        const elementIndexToDelete = this.selectedItemGroups1.findIndex((el: { id: any; }) => el.id == userId);
        this.selectedItemGroups1.splice(elementIndexToDelete, 1);
        console.log(this.selectedItemGroups1)
      }
    }

    list_group() {
      this.http.get('http://localhost:5000/Group/listgroup/' + this.educInstId, {headers: this.headers}).subscribe(
        (data: any) => {
          this.localDBGroups = data
          this.localDBGroups1 = data
          console.log(this.localDBGroups)
        },
        error => {
            console.warn(error)
        })
    }

  timetable_request() {
    this.http.get('http://localhost:5000/EducationalInstitution/geteducinst/' + this.educInstId, {headers: this.headers}).subscribe(
        (data: any) => {
          this.educInst = data
          var temp = this.educInst.timetable.split("#",1);
          this.timetable = temp[0].split("/");
          console.log(this.timetable)
        },
        error => {
            console.warn(error)
    })
  }

  ngOnInit(): void {
    this.timetable_request()
    this.form = new FormGroup({
      teacherId: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      date: new FormControl(null, [Validators.required]),
      audience: new FormControl(null, [Validators.required])
  })
  this.form1 = new FormGroup({
    teacherId: new FormControl('', [Validators.required]),
    dateofstart: new FormControl('', [Validators.required]),
    dateoffinish: new FormControl(null, [Validators.required]),
})
  }

  onSubmitFindVariant() {
    this.strGroups = ''
    if (this.selectedItemGroups1.length > 0) {
      this.strGroups = this.selectedItemGroups1[0].id
    }
    for(var i = 1; i < this.selectedItemGroups1.length; i++) {
      this.strGroups = this.strGroups + '$' + this.selectedItemGroups1[i].id
    }
    this.lesson = this.form1.value
    this.lesson.educInstId = this.educInstId
    this.lesson.strGroupsId = this.strGroups
    this.lesson.dateofstart = this.form1.get('dateofstart')?.value
    this.lesson.dateoffinish = this.form1.get('dateoffinish')?.value
    console.log(this.lesson)
    this.find_point(this.lesson)
  }

  find_point(lesson: Lesson) {
    return this.http.post('http://localhost:5000/Lesson/findpoint', lesson, {headers: this.headers}).subscribe(
        (data: any) => {
          this.points = data
        },
        error => {
            console.warn(error)
        })
}

  onSubmit() {
    this.strGroups = ''
    if (this.selectedItemGroups.length > 0) {
      this.strGroups = this.selectedItemGroups[0].id
    }
    for(var i = 1; i < this.selectedItemGroups.length; i++) {
      this.strGroups = this.strGroups + '$' + this.selectedItemGroups[i].id
    }
    this.lesson = this.form.value
    this.lesson.educInstId = this.educInstId
    this.lesson.strGroupsId = this.strGroups
    var time = this.selectedTime.split('-')
    this.lesson.dateofstart = this.form.get('date')?.value + " " + time[0]
    this.lesson.dateoffinish = this.form.get('date')?.value + " " + time[1]
    console.log(this.lesson)
    this.userRegister = this.form.value
    this.userRegister.id = "1"
    this.addservice.add_lesson(this.lesson)
  }

  onChange(event: any) {
    this.selectedTime = event
  }

}
