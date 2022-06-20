import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AdminGuard } from "./guard/admin.guard";
import { SuperAdminGuard } from "./guard/superadmin.guard";
import { AuthGuard } from "./guard/auth.guard";
import { AddNewGroupComponent } from "./component/addrecords/add-new-group/add-new-group.component";
import { AddNewUserComponent } from "./component/addrecords/add-new-user/add-new-user.component";
import { HomeComponent } from "./component/home/home.component";
import { ListGroupComponent } from "./component/listrecords/list-group/list-group.component";
import { ListPupilFromGroupComponent } from "./component/listrecords/list-pupil-from-group/list-pupil-from-group.component";
import { ListPupilComponent } from "./component/listrecords/list-pupil/list-pupil.component";
import { ListTeacherComponent } from "./component/listrecords/list-teacher/list-teacher.component";
import { LoginComponent } from "./component/login/login.component";
import { ProfileComponent } from "./component/profiles/profile/profile.component";
import { AdminLayoutComponent } from "./shared/layouts/admin-layout/admin-layout.component";
import { AuthLayoutComponent } from "./shared/layouts/auth-layout/auth-layout.component";
import { SiteLayoutComponent } from "./shared/layouts/site-layout/site-layout.component";
import { SuperAdminLayoutComponent } from "./shared/layouts/super-admin-layout/super-admin-layout.component";
import { ListEducinstComponent } from "./component/listrecords/list-educinst/list-educinst.component";
import { AddNewEducinstComponent } from "./component/addrecords/add-new-educinst/add-new-educinst.component";
import { ListDeviceComponent } from "./component/listrecords/list-device/list-device.component";
import { ListDeviceFromEducinstComponent } from "./component/listrecords/list-device-from-educinst/list-device-from-educinst.component";
import { AddNewAdminComponent } from "./component/addrecords/add-new-admin/add-new-admin.component";
import { AddNewDeviceComponent } from "./component/addrecords/add-new-device/add-new-device.component";
import { ListAdminComponent } from "./component/listrecords/list-admin/list-admin.component";
import { TimetableComponent } from "./component/timetable/timetable.component";
import { ListParentFromPupilComponent } from "./component/listrecords/list-parent-from-pupil/list-parent-from-pupil.component";
import { ListBackupDbComponent } from "./component/listrecords/list-backup-db/list-backup-db.component";
import { UpdateUserComponent } from "./component/updaterecords/update-user/update-user.component";
import { ListMovingPersonComponent } from "./component/listrecords/list-moving-person/list-moving-person.component";
import { AddLessonComponent } from "./component/addrecords/add-lesson/add-lesson.component";
import { ListAbsentFromClassComponent } from "./component/listrecords/list-absent-from-class/list-absent-from-class.component";
import { TeacherLayoutComponent } from "./shared/layouts/teacher-layout/teacher-layout.component";
import { TeacherGuard } from "./guard/teacher.guard";
import { ListPupilOnLessonComponent } from "./component/listrecords/list-pupil-on-lesson/list-pupil-on-lesson.component";
import { ListMarksComponent } from "./component/listrecords/list-marks/list-marks.component";

const routes: Routes = [
    {
        path: 'login', component: LoginComponent
    },
    {
        path: '', component: SiteLayoutComponent, canActivateChild: [AuthGuard], children: [
            { path: 'profile', component: ProfileComponent },
            {
                path: 'admin', component: AdminLayoutComponent, canActivate: [AdminGuard], canActivateChild: [AdminGuard], children: [
                    { path: 'adduser', component: AddNewUserComponent },
                    { path: 'addgroup', component: AddNewGroupComponent },
                    { path: 'addlesson', component: AddLessonComponent},
                    { path: 'listpupil', component: ListPupilComponent },
                    { path: 'listpupilfromgroup', component: ListPupilFromGroupComponent },
                    { path: 'listgroup', component: ListGroupComponent },
                    { path: 'listteacher', component: ListTeacherComponent },
                    { path: 'listparentfrompupil', component: ListParentFromPupilComponent},
                    { path: 'listmovingperson', component: ListMovingPersonComponent },
                    { path: 'updateuser', component: UpdateUserComponent },
                    { path: 'timetable', component: TimetableComponent},
                    { path: 'listabsentfromclass', component: ListAbsentFromClassComponent}
                ]
            },
            {
                path: 'teacher', component: TeacherLayoutComponent, canActivate: [TeacherGuard], canActivateChild: [TeacherGuard], children :[
                    { path: 'timetable', component: TimetableComponent},
                    { path: 'listpupilonlesson', component: ListPupilOnLessonComponent},
                    { path: 'listmarks', component: ListMarksComponent}
                ]
            },
            {
                path: 'superadmin', component: SuperAdminLayoutComponent, canActivate: [SuperAdminGuard], canActivateChild: [SuperAdminGuard], children :[
                    { path: 'listeducinst', component: ListEducinstComponent},
                    { path: 'listdevicefromeducinst', component: ListDeviceFromEducinstComponent},
                    { path: 'listdevice', component: ListDeviceComponent},
                    { path: 'listadmin', component: ListAdminComponent},
                    { path: 'listbackupdb', component: ListBackupDbComponent},
                    { path: 'addeducinst', component: AddNewEducinstComponent},
                    { path: 'addadmin', component: AddNewAdminComponent},
                    { path: 'adddevice', component: AddNewDeviceComponent}
                ]
            },
            { path: 'home', component: HomeComponent },
        ]
    }
]

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule {}