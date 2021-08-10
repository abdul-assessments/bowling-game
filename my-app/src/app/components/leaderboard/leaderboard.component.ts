import { Component, OnInit } from '@angular/core';
import { BowlingGameService } from '../../bowling-game.service';

@Component({
  selector: 'app-leaderboard',
  templateUrl: './leaderboard.component.html',
  styleUrls: ['./leaderboard.component.css']
})
export class LeaderboardComponent implements OnInit {

  constructor(public bowlingGameService: BowlingGameService) { }

  ngOnInit(): void {
  }

}
