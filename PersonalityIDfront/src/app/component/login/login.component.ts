import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Params, Router } from "@angular/router";
import { TranslateService } from "@ngx-translate/core";
import { AuthService } from "src/app/services/auth.service";


@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {
    
    form!: FormGroup;
    responce: any;

    constructor(private auth: AuthService,
        private router: Router,
        private route: ActivatedRoute,
        private translate: TranslateService) {

    }

    ngOnInit() {
        this.form = new FormGroup({
            login: new FormControl(null, [Validators.required]),
            password: new FormControl(null, [Validators.required])
        })

        this.route.queryParams.subscribe((params: Params) => {
            if (params['registered']) {
                // Теперь вы можетет войти
            } else if (params['accessDenied']) {
                //Для начала авторизируйтесь
            }
        })
    }
    useLanguage(language: string): void {
        this.translate.use(language);
    }
    onSubmit() {
        this.auth.login(this.form.value);
        if (this.auth.isAuthenticated()) {
          //  this.router.navigate(['/profile'])
        }
    }
} 