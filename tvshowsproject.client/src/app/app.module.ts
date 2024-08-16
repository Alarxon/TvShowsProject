import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InsertShowComponent } from './insert-show/insert-show.component';
import { HomeComponent } from './home/home.component';
import { UpdateShowComponent } from './update-show/update-show.component';

@NgModule({
  declarations: [
    AppComponent,
    InsertShowComponent,
    HomeComponent,
    UpdateShowComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
