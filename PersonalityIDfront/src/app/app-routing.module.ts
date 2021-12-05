import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AdminGuard } from "./classes/admin.guard";
import { AuthGuard } from "./classes/auth.guard";
import { AboutComponent } from "./component/about/about.component";
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

const routes: Routes = [
    {
        path: 'login', component: LoginComponent
    },
    {
        path: '', component: SiteLayoutComponent, canActivateChild: [AuthGuard], children: [
            { path: 'profile', component: ProfileComponent },
            {
                path: '', component: AdminLayoutComponent, canActivateChild: [AdminGuard], children: [
                    { path: 'adduser', component: AddNewUserComponent },
                    { path: 'addgroup', component: AddNewGroupComponent },
                    { path: 'listpupil', component: ListPupilComponent },
                    { path: 'listpupilfromgroup', component: ListPupilFromGroupComponent },
                    { path: 'listgroup', component: ListGroupComponent },
                    { path: 'listteacher', component: ListTeacherComponent }
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