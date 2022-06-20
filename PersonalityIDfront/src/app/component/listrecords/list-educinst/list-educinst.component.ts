import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-list-educinst',
  templateUrl: './list-educinst.component.html',
  styleUrls: ['./list-educinst.component.scss']
})
export class ListEducinstComponent implements OnInit {

  items: any = [];
  educInstId: any = localStorage.getItem("auth-udecinstid") 
  value: any = localStorage.getItem('auth-token');
  headers: HttpHeaders = new HttpHeaders({ ['Authorization']: 'Bearer ' + this.value });
  constructor(private http: HttpClient, private router: Router,
    private route: ActivatedRoute) { 
    this.list_request()
  }
  list_request() {
    this.http.get('http://localhost:5000/EducationalInstitution/listeducinst', {headers: this.headers}).subscribe(
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

  onSubmitDelete(id: any) {
    alert(id)
    this.http.delete('http://localhost:5000/EducationalInstitution/' + id, {headers: this.headers}).subscribe(
      () => {
        location.reload();
      },
      error => {
          console.warn(error)
      })
  }

  onSubmitListDevice(id: any) {
    localStorage.setItem('number-educinst', id);
    this.router.navigateByUrl("superadmin/listdevicefromeducinst");
    alert(id)
  }

  onSubmitListAdmin(id: any) {
    localStorage.setItem('number-educinst', id);
    this.router.navigateByUrl("superadmin/listadmin");
    alert(id)
  }
}
