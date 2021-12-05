import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-list-group',
  templateUrl: './list-group.component.html',
  styleUrls: ['./list-group.component.scss']
})
export class ListGroupComponent implements OnInit {
  items: any = [];
  educInstId: any = localStorage.getItem("auth-udecinstid") 
  value: any = localStorage.getItem('auth-token');
  headers: HttpHeaders = new HttpHeaders({ ['Authorization']: 'Bearer ' + this.value });
  constructor(private http: HttpClient, private router: Router,
    private route: ActivatedRoute) { 
    this.list_request()
  }
  list_request() {
    this.http.get('http://localhost:5000/Group/listgroup/' + this.educInstId, {headers: this.headers}).subscribe(
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
    // this.http.delete('http://localhost:5000/Group/' + id, {headers: this.headers}).subscribe(
    //   () => {
    //     location.reload();
    //   },
    //   error => {
    //       console.warn(error)
    //   })
  }

  onSubmitListPupil(id: any) {
    localStorage.setItem('number-group', id);
    this.router.navigateByUrl("admin/listpupilfromgroup");
    alert(id)
  }

}
