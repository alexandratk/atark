import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router'


import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { HomeComponent } from './component/home/home.component';
import { NotFoundComponent } from './component/not-found/not-found.component';
import { AuthService } from './services/auth.service';
import { LoginComponent } from './component/login/login.component';
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
import { SuperAdminLayoutComponent } from './shared/layouts/super-admin-layout/super-admin-layout.component';
import { ListEducinstComponent } from './component/listrecords/list-educinst/list-educinst.component';
import { AddNewEducinstComponent } from './component/addrecords/add-new-educinst/add-new-educinst.component';
import { ListDeviceComponent } from './component/listrecords/list-device/list-device.component';
import { ListDeviceFromEducinstComponent } from './component/listrecords/list-device-from-educinst/list-device-from-educinst.component';
import { AddNewAdminComponent } from './component/addrecords/add-new-admin/add-new-admin.component';
import { AddNewDeviceComponent } from './component/addrecords/add-new-device/add-new-device.component';
import { ListAdminComponent } from './component/listrecords/list-admin/list-admin.component';
import { TimetableComponent } from './component/timetable/timetable.component';
import { ChunkPipe } from './pipe/chunk.pipe';
import { CheckboxComponent } from './component/checkbox/checkbox.component';
import { ListParentFromPupilComponent } from './component/listrecords/list-parent-from-pupil/list-parent-from-pupil.component';
import { ListBackupDbComponent } from './component/listrecords/list-backup-db/list-backup-db.component';
import { UpdateUserComponent } from './component/updaterecords/update-user/update-user.component';
import { ListMovingPersonComponent } from './component/listrecords/list-moving-person/list-moving-person.component';
import { AddLessonComponent } from './component/addrecords/add-lesson/add-lesson.component';
import { ListAbsentFromClassComponent } from './component/listrecords/list-absent-from-class/list-absent-from-class.component';
import { TeacherLayoutComponent } from './shared/layouts/teacher-layout/teacher-layout.component';
import { ListPupilOnLessonComponent } from './component/listrecords/list-pupil-on-lesson/list-pupil-on-lesson.component';
import { ListMarksComponent } from './component/listrecords/list-marks/list-marks.component';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
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
    ListPupilFromGroupComponent,
    SuperAdminLayoutComponent,
    ListEducinstComponent,
    AddNewEducinstComponent,
    ListDeviceComponent,
    ListDeviceFromEducinstComponent,
    AddNewAdminComponent,
    AddNewDeviceComponent,
    ListAdminComponent,
    TimetableComponent,
    ChunkPipe,
    CheckboxComponent,
    ListParentFromPupilComponent,
    ListBackupDbComponent,
    UpdateUserComponent,
    ListMovingPersonComponent,
    AddLessonComponent,
    ListAbsentFromClassComponent,
    TeacherLayoutComponent,
    ListPupilOnLessonComponent,
    ListMarksComponent
  ],
  imports: [
    RouterModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    TranslateModule.forRoot({
      loader: {
          provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient]
      }
  })
  ],
  providers: [AuthService, AddUserService],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function HttpLoaderFactory(http: HttpClient): TranslateHttpLoader {
  return new TranslateHttpLoader(http);
}