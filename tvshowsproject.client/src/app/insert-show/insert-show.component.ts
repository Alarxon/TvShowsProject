import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-insert-show',
  templateUrl: './insert-show.component.html',
  styleUrl: './insert-show.component.css'
})


export class InsertShowComponent {
  constructor(private http: HttpClient, private router: Router) { }

  onSubmit(form: any) {
    //console.log('Form Submitted!', form.value);
    const formData = form.value;

    if (formData.favorite) {
      formData.favorite = true;
    } else {
      formData.favorite = false;
    }

    const url = '/api/TvShows';
    this.http.post(url, formData).subscribe(
      response => {
        //console.log('Form submitted successfully!', response);
        alert("Tv Show added successfully!");
        this.goToHome();
      },
      error => {
        //console.error('Form submission failed', error);
        const errorCode = error.status;

        if (errorCode) {
          alert(`Tv Show submission failed! Error code: ${errorCode}`);
        } else {
          alert("Tv Show submission failed! Unknown error.");
        }
      }
    );

  }

  goToHome() {
    this.router.navigate(['/home']);
  }
}
