import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { AddUserService } from 'src/app/services/add-user.service';
import { Device } from 'src/app/interfaces/interfaces';


@Component({
  selector: 'app-add-new-device',
  templateUrl: './add-new-device.component.html',
  styleUrls: ['./add-new-device.component.scss']
})
export class AddNewDeviceComponent implements OnInit {

  form!: FormGroup;
  responce: any;
  device!: Device;
  select_list = ["Администратор", "Ученик", "Учитель", "Родственник"];
  selectedRole = this.select_list[1];
  educInstId: any = localStorage.getItem("auth-udecinstid")
  constructor(private http: HttpClient,
    private addservice: AddUserService) { }

    ngOnInit(): void {
      this.form = new FormGroup({
        number: new FormControl(null, [Validators.required])
    })
    }

    onSubmit() { 
      this.device = this.form.value
      this.device.id = "1"
      this.addservice.add_device(this.device)
    }

    onChange(event: any) {
      this.selectedRole = event
      alert(event);
    }

}
