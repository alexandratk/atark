import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  temp: any;
  constructor(private http: HttpClient, private translate: TranslateService){
    this.temp = localStorage.getItem('translate')
    if (this.temp == null) {
      localStorage.setItem('translate', 'uk');
      this.translate.use('uk');
    } else {
      this.translate.use(this.temp);
    }
     // translate.setDefaultLang('uk');
  }
}
