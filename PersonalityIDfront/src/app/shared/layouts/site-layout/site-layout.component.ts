import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-site-layout',
  templateUrl: './site-layout.component.html',
  styleUrls: ['./site-layout.component.scss']
})


export class SiteLayoutComponent implements OnInit {
  userRole: any = localStorage.getItem("auth-role");
  form!: FormGroup;
  temp: any = localStorage.getItem('translate')
  constructor(private auth: AuthService,
    private router: Router,
    private route: ActivatedRoute,
    private translate: TranslateService) { }

    ngOnInit() {
      this.form = new FormGroup({})


  }

  useLanguage(language: string): void {
    localStorage.setItem('translate', language);
    this.temp = localStorage.getItem('translate');
    this.translate.use(this.temp);
}


  onSubmit() {
    this.auth.logout()
    this.router.navigate(['/login'])
  }
}
