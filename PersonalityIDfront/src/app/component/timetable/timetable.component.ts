import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CalendarDay } from 'src/app/class/CalendarDay';

@Component({
  selector: 'app-timetable',
  templateUrl: './timetable.component.html',
  styleUrls: ['./timetable.component.scss']
})
export class TimetableComponent implements OnInit {
  public calendar: CalendarDay[] = []; 
  strGroups: string =""
  strTeachers: string =""
  monthNames = ["Січень", "Лютий", "Березень", "Квітень", "Травень", "Червень", "Липень", "Август", "Вересень", "Жовтень", "Листопад", "Грудень"];
  items: any = [];
  namberEducinst: any = localStorage.getItem('number-educinst');
  educInstId: any = localStorage.getItem("auth-udecinstid")
  value: any = localStorage.getItem('auth-token');
  headers: HttpHeaders = new HttpHeaders({ ['Authorization']: 'Bearer ' + this.value });
  localDBGroups: any = []
  selectedItemGroups: any = [];
  localDBTeachers: any = []
  selectedItemTeachers: any = [];
  constructor(private http: HttpClient) { 
  //  this.list_request()
  }
  changeStatusGroups(userId: any, $event: any) {
    const checkBoxValue = $event.srcElement.checked;
    if (checkBoxValue) {
      const elementToPush = this.localDBGroups.find((el: { id: any; }) => el.id == userId);
      if (elementToPush)
        this.selectedItemGroups.push(elementToPush)

      console.log(this.selectedItemGroups)
    }
    else {
      const elementIndexToDelete = this.selectedItemGroups.findIndex((el: { id: any; }) => el.id == userId);
      this.selectedItemGroups.splice(elementIndexToDelete, 1);
      console.log(this.selectedItemGroups)
    }
  }

  changeStatusTeachers(userId: any, $event: any) {
    const checkBoxValue = $event.srcElement.checked;
    if (checkBoxValue) {
      const elementToPush = this.localDBTeachers.find((el: { id: any; }) => el.id == userId);
      if (elementToPush)
        this.selectedItemTeachers.push(elementToPush)

      console.log(this.selectedItemTeachers)
    }
    else {
      const elementIndexToDelete = this.selectedItemTeachers.findIndex((el: { id: any; }) => el.id == userId);
      this.selectedItemTeachers.splice(elementIndexToDelete, 1);
      console.log(this.selectedItemTeachers)
    }
  }

  ngOnInit(): void {

    this.list_group()
    this.list_teacher()
    this.list_request()
  }

  list_group() {
    this.http.get('http://localhost:5000/Group/listgroup/' + this.educInstId, {headers: this.headers}).subscribe(
      (data: any) => {
        this.localDBGroups = data
      },
      error => {
          console.warn(error)
      })
  }

  list_teacher() {
    this.http.get('http://localhost:5000/Teacher/listteacher/' + this.educInstId, {headers: this.headers}).subscribe(
      (data: any) => {
        this.localDBTeachers = data
      },
      error => {
          console.warn(error)
      })
  }
  
  list_request() {
    this.http.get('http://localhost:5000/Lesson/timetable/' + this.educInstId, {headers: this.headers}).subscribe(
      (data: any) => {
        this.items = data
        console.log(this.items)
        // здесь мы инициализируем календарь
        this.generateCalendarDays();
      },
      error => {
          console.warn(error)
      })
  }
  selectLessons() {
    this.strGroups = ''
    for(var i = 0; i < this.selectedItemGroups.length; i++) {
      this.strGroups = this.strGroups + this.selectedItemGroups[i].id + '$'
    }
    if (this.strGroups == '') {
      this.strGroups = 'free'
    }
    this.strTeachers = ''
    for(var i = 0; i < this.selectedItemTeachers.length; i++) {
      this.strTeachers = this.strTeachers + this.selectedItemTeachers[i].id + '$'
    }
    if (this.strTeachers == '') {
      this.strTeachers = 'free'
    }
    console.log(this.strTeachers)
    this.http.get('http://localhost:5000/Lesson/timetableselect/' + this.strGroups + '/' + this.strTeachers + '/' + this.educInstId, {headers: this.headers}).subscribe(
      (data: any) => {
        this.items = data
        console.log("/////")
        console.log(this.items)
        // здесь мы инициализируем календарь
        this.generateCalendarDays();
      },
      error => {
          console.warn(error)
      })
  }


  private generateCalendarDays(): void {
    // мы сбрасываем календарь каждый раз
    this.calendar = [];
   
    // мы устанавливаем дату
   // let day: Date = new Date();
    let day: Date = new Date(this.items[0].dateofstart);
    let lastday: Date = new Date(this.items[this.items.length - 1].dateofstart);
    console.log(lastday);

    // здесь мы находим первый день, с которого начинается календарь
    // это должен быть последний понедельник предыдущего месяца
    let startingDateOfCalendar = this.getStartDateForCalendar(day);
    let year = lastday.getFullYear() - startingDateOfCalendar.getFullYear();
    let month = lastday.getMonth() + year * 12 - startingDateOfCalendar.getMonth();
    let countday = lastday.getDate() + month * 31 - startingDateOfCalendar.getDate() + 7;
    // dateToAdd - это  an промежуточная переменная, которая увеличивается на 1 
    // в следующем цикле for
    let dateToAdd = startingDateOfCalendar;
   
    // ok, так как мы имеем начальную дату, когда получаем следующие 41 день
    // нам нужно добавить в календарь массив
    // 41 значит, что нужно отображать 6 недель, и математика говорит, что
    // 6 недель * 7 дней = 42[HTML]
    for (var i = 0; i < countday; i++) {
      this.calendar.push(new CalendarDay(new Date(dateToAdd)));
      dateToAdd = new Date(dateToAdd.setDate(dateToAdd.getDate() + 1));
    }
  }
   
  private getStartDateForCalendar(selectedDate: Date){
    // для дня, который мы выбрали, давайте получим последний день предыдущего месяца
    let lastDayOfPreviousMonth = new Date(selectedDate.setDate(0));
    // начинаем с установки для календаря начальной даты, совпадающей с последним днем предыдущего месяца
    let startingDateOfCalendar: Date = lastDayOfPreviousMonth;
   
    // но так как мы фактически хотим найти последний понедельник предыдущего месяца
    // мы идем назад, пока не найдем последний понедельник предыдущего месяца
    if (startingDateOfCalendar.getDay() != 1) {
      do {
        startingDateOfCalendar = new Date(startingDateOfCalendar.setDate(startingDateOfCalendar.getDate() - 1));
      } while (startingDateOfCalendar.getDay() != 1);
    }
   
    return startingDateOfCalendar;
  }

}
