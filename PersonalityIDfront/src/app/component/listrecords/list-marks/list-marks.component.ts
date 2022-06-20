import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Lesson, Mark, User, UserRegister } from 'src/app/interfaces/interfaces';

@Component({
  selector: 'app-list-marks',
  templateUrl: './list-marks.component.html',
  styleUrls: ['./list-marks.component.scss']
})
export class ListMarksComponent implements OnInit {
  updateMark!:Mark
  updateMarkId:any
  updateMarkName: any
  updateMarkTime: any
  updateMarkMark: any
  items: any
  itemsLength: any
  pupils: any
  pupilsLength: any
  lessons: any
  lessonsLength: any
  points: any
  educInst: any
  strGroups: any
  form!: FormGroup;
  form1!: FormGroup;
  lessonMark: any
  responce: any;
  userRegister!: UserRegister;
  lesson!: Lesson;
  educInstId: any = localStorage.getItem("auth-udecinstid")
  value: any = localStorage.getItem('auth-token');

  headers: HttpHeaders = new HttpHeaders({ ['Authorization']: 'Bearer ' + this.value });
  constructor(private http: HttpClient) { 


    }

  onSubmit() {
    this.http.post('http://localhost:5000/Mark/listmarkspupils/', this.form.value, {headers: this.headers}).subscribe(
      (data: any) => {
        this.pupils = data
        this.pupilsLength = data.length
        console.log(this.pupils)
      },
      error => {
          console.warn(error)
      })
      this.http.post('http://localhost:5000/Mark/listmarkslessons/', this.form.value, {headers: this.headers}).subscribe(
        (data: any) => {
          this.lessons = data
          this.lessonsLength = data.length
          console.log(this.lessons)
        },
        error => {
            console.warn(error)
        })
        
    this.http.post('http://localhost:5000/Mark/listmarksss/', this.form.value, {headers: this.headers}).subscribe(
      (data: any) => {
        console.log("555555")
        this.items = data
        this.itemsLength = data.length
        console.log(this.items)
      },
      error => {
          console.warn(error)
      })
  }

  changeMark(i: any, j:any) {
    this.updateMark = this.items[i * this.lessonsLength + j]
    this.updateMarkId = this.items[i * this.lessonsLength + j].id
    this.updateMarkName = this.items[i * this.lessonsLength + j].pupil.name
    this.updateMarkTime = this.items[i * this.lessonsLength + j].lesson.dateofstart
    this.updateMarkMark = this.items[i * this.lessonsLength + j].lessonMark
  }

  updateMarkDB() {
    this.http.post('http://localhost:5000/Mark/update/' + this.updateMarkId, this.form1.value, {headers: this.headers}).subscribe(
      (data: any) => {
        this.onSubmit();
      },
      error => {
          console.warn(error)
      })
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      teacherId: new FormControl('', [Validators.required]),
      groupId: new FormControl('', [Validators.required]),
      dateStart: new FormControl(null, [Validators.required]),
      description: new FormControl('', [Validators.required])
    })
    this.form1 = new FormGroup({
      lessonMark: new FormControl('', [Validators.required])
    })

  }

}
