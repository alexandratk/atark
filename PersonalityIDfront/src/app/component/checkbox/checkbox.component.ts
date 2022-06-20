import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
@Component({
  selector: 'app-checkbox',
  templateUrl: './checkbox.component.html',
  styleUrls: ['./checkbox.component.scss']
})
export class CheckboxComponent implements OnInit {
  toppings: FormGroup;
  constructor(fb: FormBuilder) {
    this.toppings = fb.group({
      pepperoni: false,
      extracheese: false,
      mushroom: false,
    });
  }


  onSubmit() {
    alert(this.toppings.get("pepperoni")?.value);
  }

  ngOnInit(): void {
  }

}
