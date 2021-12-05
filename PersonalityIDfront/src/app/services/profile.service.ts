import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, tap } from "rxjs";
import { User, UserData } from "../interfaces/interfaces";
import { AuthService } from "./auth.service";

@Injectable({
    providedIn: 'root'
})

export class ProfileService {

    private token!: string;
    userData!: UserData;
    responce: any;
    
    constructor (private http: HttpClient,
        private auth:AuthService) {

    }
    
    find_profile(user: User) {
        return this.http.post('http://localhost:5000/user/profile', user).subscribe(
            (data: any) => {
                this.userData = data;
                localStorage.setItem("userData-name", this.userData.name)
                localStorage.setItem("userData-dateofbirth", this.userData.dateofbirth)
            },
            error => {
                console.warn(error)
            })
    }

    getDataName(): string | null{
        return localStorage.getItem("userData-name")
    }
}