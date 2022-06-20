import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ParentPupil, UserRegister } from 'src/app/interfaces/interfaces';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Pupil } from 'src/app/interfaces/interfaces';
@Component({
  selector: 'app-list-parent-from-pupil',
  templateUrl: './list-parent-from-pupil.component.html',
  styleUrls: ['./list-parent-from-pupil.component.scss']
})
export class ListParentFromPupilComponent implements OnInit {

  parentPupil!: ParentPupil;
  numberPupil: any = localStorage.getItem('number-pupil');
  items: any = [];
  pupilId: any = localStorage.getItem("number-pupil")
  value: any = localStorage.getItem('auth-token');
  headers: HttpHeaders = new HttpHeaders({ ['Authorization']: 'Bearer ' + this.value });
  form!: FormGroup;
  pupil!: Pupil;
  constructor(private http: HttpClient, private router: Router,
    private route: ActivatedRoute) { 
    this.list_request()
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      parentId: new FormControl(null, [Validators.required]),
      relationship: new FormControl(null, [Validators.required]),
  })
  }

  list_request() {
    console.log(this.pupilId);
    this.http.get('http://localhost:5000/Parent/listparentfrompupil/' + this.pupilId, {headers: this.headers}).subscribe(
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

  onSubmitAddPupil() {
     this.parentPupil = this.form.value
     this.parentPupil.pupilId = this.numberPupil
     this.http.post('http://localhost:5000/PupilParent/addpupilparent/', this.parentPupil, {headers: this.headers}).subscribe(
       () => {
         location.reload();
       },
       error => {
           console.warn(error)
       })
   }

}
