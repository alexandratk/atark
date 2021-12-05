import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-site-layout',
  templateUrl: './site-layout.component.html',
  styleUrls: ['./site-layout.component.scss']
})


export class SiteLayoutComponent implements OnInit {
  userRole: any = localStorage.getItem("auth-role");
  form!: FormGroup;

  constructor(private auth: AuthService,
    private router: Router,
    private route: ActivatedRoute) { }

    ngOnInit() {
      this.form = new FormGroup({})


  }


  onSubmit() {
    this.auth.logout()
    this.router.navigate(['/login'])
  }
}
