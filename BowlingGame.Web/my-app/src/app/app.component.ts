import { Component } from '@angular/core';
import { BowlingGameService } from './bowling-game.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Bowling Game';

  constructor(public bowlingGameService: BowlingGameService) {
  }
}
