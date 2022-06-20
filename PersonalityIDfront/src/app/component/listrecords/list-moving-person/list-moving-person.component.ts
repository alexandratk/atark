import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from "@angular/forms";
@Component({
  selector: 'app-list-moving-person',
  templateUrl: './list-moving-person.component.html',
  styleUrls: ['./list-moving-person.component.scss']
})
export class ListMovingPersonComponent implements OnInit {
  form!: FormGroup;
  items: any = [];
  educInstId: any = localStorage.getItem("auth-udecinstid") 
  value: any = localStorage.getItem('auth-token');
  headers: HttpHeaders = new HttpHeaders({ ['Authorization']: 'Bearer ' + this.value });
  device: any;
  constructor(private http: HttpClient, private router: Router,
    private route: ActivatedRoute) { 
    this.list_request()
  }
  list_request() {
    this.http.get('http://localhost:5000/MovingPupil/listmovingpupil/' + this.educInstId, {headers: this.headers}).subscribe(
        (data: any) => {
          this.items = data
          console.log(this.items)
        },
        error => {
            console.warn(error)
        })
      }

    ngOnInit(): void {
        this.form = new FormGroup({
          device: new FormControl(null, [Validators.required])
      })
    }

    onSubmit() {
      this.device = this.form.get('device')?.value
      this.http.get('http://localhost:5000/MovingPupil/listmovingpupil/' + this.device, {headers: this.headers}).subscribe(
        (data: any) => {
          this.items = data
          console.log(this.items)
        },
        error => {
            console.warn(error)
        })
    }

}
