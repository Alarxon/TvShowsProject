import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-update-show',
  templateUrl: './update-show.component.html',
  styleUrl: './update-show.component.css'
})
export class UpdateShowComponent {
  id: number;
  name: string = 'Enter Name of the Show';
  favorite: boolean = true;
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute) {
    if (+!this.route.snapshot.paramMap.get('id') === null) {
      this.id = 0;
    } else {
      this.id = +this.route.snapshot.paramMap.get('id')!;
    }

    //alert(this.id);
    this.getTvShow();
  }

  getTvShow() {
    this.http.get('/api/TvShows/' + this.id).subscribe(
      (result : any) => {
        this.name = result.name;
        this.favorite = result.favorite;
      },
      (error) => {
        alert("There is no TV Show with matching ID");
        console.error(error);
        this.goToHome();
      }
    );
  }



  onSubmit(form: any) {
    const formData = form.value;

    if (formData.favorite) {
      formData.favorite = true;
    } else {
      formData.favorite = false;
    }

    formData.id = this.id;

    const url = '/api/TvShows/' + this.id;
    this.http.put(url, formData).subscribe(
      response => {
        //console.log('Form submitted successfully!', response);
        alert("Tv Show updated successfully!");
        this.goToHome();
      },
      error => {
        //console.error('Form submission failed', error);
        //alert(JSON.stringify(error));
        const errorCode = error.status;

        if (errorCode) {
          alert(`Tv Show updated failed! Error code: ${errorCode}`);
        } else {
          alert("Tv Show updated failed! Unknown error.");
        }
      }
    );
  }

  goToHome() {
    this.router.navigate(['/home']);
  }
}
