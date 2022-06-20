import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-list-backup-db',
  templateUrl: './list-backup-db.component.html',
  styleUrls: ['./list-backup-db.component.scss']
})
export class ListBackupDbComponent implements OnInit {

  items: any = [];
  temp: string = ""
  educInstId: any = localStorage.getItem("auth-udecinstid") 
  value: any = localStorage.getItem('auth-token');
  headers: HttpHeaders = new HttpHeaders({ ['Authorization']: 'Bearer ' + this.value });
  constructor(private http: HttpClient, private router: Router,
    private route: ActivatedRoute) { 
    this.list_request()
  }
  list_request() {
    this.http.get('http://localhost:5000/Administrator/allRestorations', {headers: this.headers}).subscribe(
        (data: any) => {
          this.items = data
          console.log(this.items)
        },
        error => {
          console.log("error1")
            console.warn(error)
        })
      }

  ngOnInit(): void {
  }

  onSubmitDelete(id: any) {
    alert(id)
    this.http.delete('http://localhost:5000/Administrator/deleteRestoration/' + id, {headers: this.headers}).subscribe(
      () => {
        location.reload();
      },
      error => {
          console.warn(error)
      })
  }
 
  onSubmitRestore(id: any) {
    this.http.get('http://localhost:5000/Administrator/restore/' + id, {headers: this.headers}).subscribe(
      (data: any) => {
        this.temp = data
        alert(this.temp)
        location.reload();
      },
      error => {
          console.warn(error)
      })
  }

  onSubmitAdd() {
    this.http.get('http://localhost:5000/Administrator/backup', {headers: this.headers}).subscribe(
      (data: any) => {
        alert("ok")
        location.reload();
      },
      error => {
         console.warn(error)
    })
  }

}
