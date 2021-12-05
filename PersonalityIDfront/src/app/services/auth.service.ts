import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, tap } from "rxjs";
import { User, UserData } from "../interfaces/interfaces";

@Injectable({
    providedIn: 'root'
})

export class AuthService {

    private token!: string;
    userData!: UserData;
    responce: any;
    
    constructor (private http: HttpClient,
        private router: Router) {

    }
    
    login(user: User) {
        this.http.post('http://localhost:5000/user/authUser', user).subscribe(
            (data: any) => {
                this.userData=data;
                localStorage.setItem('auth-token', this.userData.jwtToken)
                localStorage.setItem('auth-id', this.userData.id)
                localStorage.setItem('auth-role', this.userData.role)
                this.setToken(this.userData.jwtToken)
                if (this.userData.role == "Administrator") {
                    this.http.get('http://localhost:5000/Administrator/admin/' + this.userData.id).subscribe(
                        (data: any) => {
                            localStorage.setItem('auth-udecinstid', data)
                        },
                        error => {
                            console.warn(error)
                        })
                }
                this.router.navigate(['/profile'])
            },
            error => {
                console.warn(error)
            })
    }

    setToken (token: string) {
        this.token = token
    }

    getToken(): string{
        return this.token
    }

    getRole(): string | null {
        return localStorage.getItem("auth-role");
    }

    isAuthenticated(): boolean {
        return !!localStorage.getItem('auth-token')
    }

    logout() {
        this.setToken('')
        localStorage.clear()
    }
}