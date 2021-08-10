import { Component } from '@angular/core';
import { BowlingGameService } from './bowling-game.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Welcome to the Imaginary Bowling Game';
  description = 'Where it literally all happens in your head, the app just keeps score.';

  constructor(public bowlingGameService: BowlingGameService) {
  }
}
