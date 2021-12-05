import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, tap } from "rxjs";
import { Device, EducationalInstitution, Group, User, UserData, UserRegister } from "../interfaces/interfaces";
import { AuthService } from "./auth.service";

@Injectable({
    providedIn: 'root'
})

export class AddUserService {

    private token!: string;
    userData!: any;
    responce: any;
    value: any = localStorage.getItem('auth-token');
    headers: HttpHeaders = new HttpHeaders({ ['Authorization']: 'Bearer ' + this.value });

    constructor (private http: HttpClient,
        private auth:AuthService) {
    }
    
    add_user_admin(user: UserRegister) {
        return this.http.post('http://localhost:5000/Administrator/addadmin/', user, {headers: this.headers}).subscribe(
            (data: any) => {
                this.userData = data;
                alert("ok")
            },
            error => {
                console.warn(error)
            })
    }

    add_user_parent(user: UserRegister) {
        return this.http.post('http://localhost:5000/Parent/addparent/', user, {headers: this.headers}).subscribe(
            (data: any) => {
                this.userData = data;
                alert("ok")
            },
            error => {
                console.warn(error)
            })
    }

    add_user_pupil(user: UserRegister) {
        return this.http.post('http://localhost:5000/Pupil/addpupil/', user, {headers: this.headers}).subscribe(
            (data: any) => {
                this.userData = data;
                alert("ok")
            },
            error => {
                console.warn(error)
            })
    }

    add_user_teacher(user: UserRegister) {
        return this.http.post('http://localhost:5000/Teacher/addteacher/', user, {headers: this.headers}).subscribe(
            (data: any) => {
                this.userData = data;
                alert("ok")
            },
            error => {
                console.warn(error)
            })
    }

    add_user_group(group: Group) {
        return this.http.post('http://localhost:5000/Group/addgroup/', group, {headers: this.headers}).subscribe(
            (data: any) => {
                alert("ok")
            },
            error => {
                console.warn(error)
            })
    }

    add_educinst(educinst: EducationalInstitution) {
        return this.http.post('http://localhost:5000/EducationalInstitution/addeducinst/', educinst, {headers: this.headers}).subscribe(
            (data: any) => {
                alert("ok")
            },
            error => {
                console.warn(error)
            })
    }

    add_device(device: Device) {
        return this.http.post('http://localhost:5000/Device/adddevice/', device, {headers: this.headers}).subscribe(
            (data: any) => {
                alert("ok")
            },
            error => {
                console.warn(error)
            })
    }
}