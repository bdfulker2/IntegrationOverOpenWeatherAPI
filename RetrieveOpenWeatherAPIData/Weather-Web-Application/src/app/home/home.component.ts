import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from "@angular/forms";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  options: FormGroup;
  constructor(formBuilder: FormBuilder) {
    this.options = formBuilder.group({
      bottom: 0,
      fixed: false,
      top: 0,
    })
  }

  ngOnInit(): void {
  }
  shouldRun = true;
}
