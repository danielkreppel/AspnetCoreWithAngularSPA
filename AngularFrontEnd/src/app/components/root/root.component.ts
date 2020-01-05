import { Component, OnInit } from '@angular/core';
import {ToasterService} from 'angular2-toaster';

@Component({
  selector: 'app-root',
  templateUrl: './root.component.html',
  styles: ['./root.component.css']
})
export class RootComponent implements OnInit {
  private toasterService: ToasterService;

  constructor(toasterService: ToasterService) {
    this.toasterService = toasterService;
   }

  ngOnInit() {
  }

  popToast() {
    this.toasterService.pop('success', 'Args Title', 'Args Body');
  }

}
