import { Component, OnInit } from '@angular/core';

import { Contestant } from '../../interfaces/contestant';
import { BowlingGameService } from '../../bowling-game.service';

@Component({
  selector: 'app-contestants',
  templateUrl: './contestants.component.html',
  styleUrls: ['./contestants.component.css']
})
export class ContestantsComponent implements OnInit {
  selectedContestant: Contestant;
  contestants: Contestant[];

  constructor(public bowlingGameService: BowlingGameService)
  {
    this.selectedContestant = {} as Contestant;
    this.contestants = [];
  }

  ngOnInit(): void {
    this.getContestants();
  }
  getContestants(): void {
    this.bowlingGameService.getContestants()
      .subscribe(contestants => this.contestants = contestants);
  }
  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.contestants.push({contestantName: name, pinsLeft: 10, score: 0} as Contestant)
    //this.heroService.addHero({ name } as Hero)
    //  .subscribe(hero => {
    //    this.heroes.push(hero);
    //  });
  }
  resetGame(): void {
    this.bowlingGameService.reset().subscribe(_ => this.reset());
  }
  reset(): void {
    this.selectedContestant = {} as Contestant;
    this.getContestants();
    this.bowlingGameService.isGameUnderway = false;
    this.bowlingGameService.isGameComplete = false;
    this.bowlingGameService.refreshLeaderboard();
  }
  async startContest(): Promise<void> {
    await this.bowlingGameService.addContestants(this.contestants);
    this.bowlingGameService.beginGame();
  }
  onClick(contestant: Contestant): void {    
      this.selectedContestant = contestant;
  }
}
