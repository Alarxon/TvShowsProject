import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

interface TvShow {
  id: number;
  name: string;
  favorite: boolean;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  public tvshows: TvShow[] = [];

  constructor(private http: HttpClient, private router: Router) { }


  ngOnInit() {
    this.getTvShows();
  }

  getTvShows() {
    this.http.get<TvShow[]>('/api/TvShows').subscribe(
      (result) => {
        this.tvshows = result;
      },
      (error) => {
        alert("There is no TV Shows");
        console.error(error);
      }
    );
  }

  goToInsert() {
    this.router.navigate(['/insert']);
  }

  goToUpdate(id: number) {
    //alert(id);
    this.router.navigate(['/update', id]);
  }

  goToDelete(id: number) {
    //alert(id);
    const confirmation = confirm('Are you sure you want to delete this TV Show?');
    if (confirmation) {
      // If the user clicked "OK", proceed with the deletion
      this.http.delete(`/api/TvShows/${id}`).subscribe(
        response => {
          alert('TV Show deleted successfully!');
          window.location.reload();
        },
        error => {
          alert('Failed to delete the TV Show.');
          console.error(error);
        }
      );
    } else {
      // If the user clicked "Cancel", do nothing
      alert('Deletion cancelled.');
    }
  }

  title = 'tvshowsproject.client';
}
