import { Component } from '@angular/core';
import { EmployeeGetService } from './services/employeeget.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Employee';
  employeedata: String[];
  
  constructor(private employeeservice: EmployeeGetService){}

  ngOnInit(){
    this.employeeservice.getEmployees().subscribe(result => {
      this.employeedata = result;
      console.log(result);
    });
  }
}