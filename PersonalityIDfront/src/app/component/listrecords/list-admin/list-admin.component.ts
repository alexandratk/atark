import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Device } from 'src/app/interfaces/interfaces';

@Component({
  selector: 'app-list-admin',
  templateUrl: './list-admin.component.html',
  styleUrls: ['./list-admin.component.scss']
})
export class ListAdminComponent implements OnInit {
  form!: FormGroup;
  device!: Device;
  items: any = [];
  namberEducinst: any = localStorage.getItem('number-educinst');
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
    this.http.get('http://localhost:5000/Administrator/listadmin/' + this.namberEducinst, {headers: this.headers}).subscribe(
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
    this.http.delete('http://localhost:5000/Administrator/' + id, {headers: this.headers}).subscribe(
      () => {
        location.reload();
      },
      error => {
          console.warn(error)
      })
  }

}
