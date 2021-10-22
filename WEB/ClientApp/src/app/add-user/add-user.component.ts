import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'add-user',
  templateUrl: './add-user.component.html'
})
export class AddUserComponent implements OnInit {
  userForm: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.userForm = this.fb.group({
      FullName: ['', {
        validators: [Validators.required]
      }],
      Phone: ['', {
        validators: [Validators.required]
      }],
      Age: ['', {
      }],
    });
  }

  onClose(): void {
    this.router.navigate(['']);
  }
  onSave(): void {
    this.userForm.markAllAsTouched();
    if (this.userForm.valid) {
      const data = {
        FullName: this.userForm.value.FullName,
        Phone: this.userForm.value.Phone,
        Age: this.userForm.value.Age.toString(),
      }
      this.http.post(this.baseUrl + 'user/create', data).subscribe()
      this.router.navigate(['']);
    };
  }
}
