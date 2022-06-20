import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { AbsentPupil } from 'src/app/interfaces/interfaces';

@Component({
  selector: 'app-list-absent-from-class',
  templateUrl: './list-absent-from-class.component.html',
  styleUrls: ['./list-absent-from-class.component.scss']
})
export class ListAbsentFromClassComponent implements OnInit {
  form!: FormGroup;
  responce: any;
  absentPupil!: AbsentPupil;
  items: any = [];
  count_absents:any;
  educInstId: any = localStorage.getItem("auth-udecinstid") 
  value: any = localStorage.getItem('auth-token');
  headers: HttpHeaders = new HttpHeaders({ ['Authorization']: 'Bearer ' + this.value });
  constructor(private http: HttpClient, private router: Router,
    private route: ActivatedRoute) { 
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      date: new FormControl(null, [Validators.required])
  })
  }

  onSubmit() { 
    this.absentPupil = this.form.value
    this.absentPupil.educationalInstitutionId = this.educInstId
    alert(this.educInstId);
    return this.http.post('http://localhost:5000/Pupil/listabsentpupileduc/', this.absentPupil, {headers: this.headers}).subscribe(
      (data: any) => {
        this.items = data
        console.log(this.items)
      },
      error => {
          console.warn(error)
      })
  }

}
