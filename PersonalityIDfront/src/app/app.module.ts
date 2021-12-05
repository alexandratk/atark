import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router'

import { AppComponent } from './app.component';
import { HomeComponent } from './component/home/home.component';
import { AboutComponent } from './component/about/about.component';
import { NotFoundComponent } from './component/not-found/not-found.component';
import { AuthService } from './services/auth.service';
import { LoginComponent } from './component/login/login.component';
import { AuthGuard } from './classes/auth.guard';
import { AppRoutingModule } from './app-routing.module';
import { AuthLayoutComponent } from './shared/layouts/auth-layout/auth-layout.component';
import { SiteLayoutComponent } from './shared/layouts/site-layout/site-layout.component';
import { ProfileComponent } from './component/profiles/profile/profile.component';
import { AdminLayoutComponent } from './shared/layouts/admin-layout/admin-layout.component';
import { AddUserService } from './services/add-user.service';
import { AddNewUserComponent } from './component/addrecords/add-new-user/add-new-user.component';
import { AddNewGroupComponent } from './component/addrecords/add-new-group/add-new-group.component';
import { ListPupilComponent } from './component/listrecords/list-pupil/list-pupil.component';
import { ListTeacherComponent } from './component/listrecords/list-teacher/list-teacher.component';
import { ListGroupComponent } from './component/listrecords/list-group/list-group.component';
import { ListPupilFromGroupComponent } from './component/listrecords/list-pupil-from-group/list-pupil-from-group.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    NotFoundComponent,
    LoginComponent,
    AuthLayoutComponent,
    SiteLayoutComponent,
    ProfileComponent,
    AdminLayoutComponent,
    AddNewUserComponent,
    AddNewGroupComponent,
    ListPupilComponent,
    ListTeacherComponent,
    ListGroupComponent,
    ListPupilFromGroupComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [AuthService, AddUserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
