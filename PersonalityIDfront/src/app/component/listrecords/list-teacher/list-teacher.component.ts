import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-list-teacher',
  templateUrl: './list-teacher.component.html',
  styleUrls: ['./list-teacher.component.scss']
})
export class ListTeacherComponent implements OnInit {
  items: any = [];
  educInstId: any = localStorage.getItem("auth-udecinstid") 
  value: any = localStorage.getItem('auth-token');
  headers: HttpHeaders = new HttpHeaders({ ['Authorization']: 'Bearer ' + this.value });
  constructor(private http: HttpClient) { 
    this.list_request()
  }

  list_request() {
    this.http.get('http://localhost:5000/Teacher/listteacher/' + this.educInstId, {headers: this.headers}).subscribe(
        (data: any) => {
          this.items = data
          console.log(this.items)
        },
        error => {
            console.warn(error)
        })
      }

  ngOnInit(): void {
  }
  onSubmit(id: any) {
    alert(id)
    this.http.delete('http://localhost:5000/Teacher/' + id, {headers: this.headers}).subscribe(
      () => {
        location.reload();
      },
      error => {
          console.warn(error)
      })
  }
}
