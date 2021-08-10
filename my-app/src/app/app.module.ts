import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ContestantsComponent } from './components/contestants/contestants.component';
import { ContestantDetailComponent } from './components/contestant-detail/contestant-detail.component';
import { LeaderboardComponent } from './components/leaderboard/leaderboard.component';
import { NotificationsComponent } from './components/notifications/notifications.component';

@NgModule({
  declarations: [
    AppComponent,
    ContestantsComponent,
    ContestantDetailComponent,
    LeaderboardComponent,
    NotificationsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
