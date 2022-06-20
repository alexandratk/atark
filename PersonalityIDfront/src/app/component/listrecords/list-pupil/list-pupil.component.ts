import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-list-pupil',
  templateUrl: './list-pupil.component.html',
  styleUrls: ['./list-pupil.component.scss']
})
export class ListPupilComponent implements OnInit {
  
  items: any = [];
  educInstId: any = localStorage.getItem("auth-udecinstid")
  value: any = localStorage.getItem('auth-token');
  headers: HttpHeaders = new HttpHeaders({ ['Authorization']: 'Bearer ' + this.value });
  constructor(private http: HttpClient, private router: Router,
    private route: ActivatedRoute) { 
    this.list_request()
  }

  ngOnInit(): void {
  }

  list_request() {
    console.log(this.educInstId);
    this.http.get('http://localhost:5000/Pupil/listpupil/' + this.educInstId, {headers: this.headers}).subscribe(
        (data: any) => {
          this.items = data
          console.log(data)
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

  onSubmitListParent(id: any) {
    localStorage.setItem('number-pupil', id);
    this.router.navigateByUrl("admin/listparentfrompupil");
  }
}
