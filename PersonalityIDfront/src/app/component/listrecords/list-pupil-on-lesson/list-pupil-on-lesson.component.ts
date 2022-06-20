import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Pupil } from 'src/app/interfaces/interfaces';

@Component({
  selector: 'app-list-pupil-on-lesson',
  templateUrl: './list-pupil-on-lesson.component.html',
  styleUrls: ['./list-pupil-on-lesson.component.scss']
})
export class ListPupilOnLessonComponent implements OnInit {

  form!: FormGroup;
  items: any = [];
  pupil!: Pupil;
  namberGroup: any = localStorage.getItem('number-group');
  educInstId: any = localStorage.getItem("auth-udecinstid");
  idTeacher: any = localStorage.getItem('auth-id');
  value: any = localStorage.getItem('auth-token');
  headers: HttpHeaders = new HttpHeaders({ ['Authorization']: 'Bearer ' + this.value });
  constructor(private http: HttpClient, private router: Router,
    private route: ActivatedRoute) { 
    this.list_request()
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      id: new FormControl(null, [Validators.required])
  })
  }

  list_request() {
    this.http.get('http://localhost:5000/Pupil/listpupilonlesson/' + this.idTeacher, {headers: this.headers}).subscribe(
      (data: any) => {
        this.items = data
        console.log(this.items)
      },
      error => {
          console.warn(error)
      })
  }

  onSubmitUpdate() {
    this.list_request();
  }

}
