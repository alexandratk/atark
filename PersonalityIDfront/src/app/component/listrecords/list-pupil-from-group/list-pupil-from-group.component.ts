import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Pupil } from 'src/app/interfaces/interfaces';

@Component({
  selector: 'app-list-pupil-from-group',
  templateUrl: './list-pupil-from-group.component.html',
  styleUrls: ['./list-pupil-from-group.component.scss']
})
export class ListPupilFromGroupComponent implements OnInit {
  form!: FormGroup;
  items: any = [];
  pupil!: Pupil;
  namberGroup: any = localStorage.getItem('number-group');
  educInstId: any = localStorage.getItem("auth-udecinstid")
  value: any = localStorage.getItem('auth-token');
  headers: HttpHeaders = new HttpHeaders({ ['Authorization']: 'Bearer ' + this.value });
  constructor(private http: HttpClient) { 
    this.list_request()
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      id: new FormControl(null, [Validators.required])
  })
  }

  list_request() {
    this.http.get('http://localhost:5000/Pupil/listpupilfromgroup/' + this.namberGroup, {headers: this.headers}).subscribe(
      (data: any) => {
        this.items = data
        console.log(this.items)
      },
      error => {
          console.warn(error)
      })
  }

  onSubmitDelete(id: any) {
    alert(id)
    this.http.delete('http://localhost:5000/Pupil/' + id, {headers: this.headers}).subscribe(
      () => {
        location.reload();
      },
      error => {
          console.warn(error)
      })
  }

  onSubmitUpdate(item:any, id: any) {
    alert(id)
    this.http.post('http://localhost:5000/Pupil/update/' + id, item, {headers: this.headers}).subscribe(
      () => {
        location.reload();
        alert(id + "//////////");
      },
      error => {
          console.warn(error)
      })
  }

  onSubmitAddPupil() {
    this.pupil = this.form.value
    this.pupil.groupId = this.namberGroup
    this.http.post('http://localhost:5000/Pupil/update/' + this.pupil.id, this.pupil, {headers: this.headers}).subscribe(
      () => {
        location.reload();
      },
      error => {
          console.warn(error)
      })
  }

}
