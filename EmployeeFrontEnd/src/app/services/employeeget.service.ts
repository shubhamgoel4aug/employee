import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class EmployeeGetService {

  constructor(private http: Http) { }

  getEmployees(){
    return this.http.get("http://104.208.217.234:8111/edata").pipe(map(response => response.json()));
  }
}
