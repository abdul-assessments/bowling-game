import { Component, OnInit, Input } from '@angular/core';
import { BowlingGameService } from '../../bowling-game.service';
import { Contestant } from '../../interfaces/contestant';
import { NotificationsService } from '../../notifications.service';

@Component({
  selector: 'app-contestant-detail',
  templateUrl: './contestant-detail.component.html',
  styleUrls: ['./contestant-detail.component.css']
})
export class ContestantDetailComponent implements OnInit {
  @Input()
  contestant!: Contestant;
  busy = false;

  constructor(public bowlingGameService: BowlingGameService, public notificationService: NotificationsService) { }

  ngOnInit(): void {
    this.notificationService.addRoll
  }

  async roll(contestant: Contestant, pins: string): Promise<number> {
    this.busy = true;
    let parsedPins: number = +pins;
    parsedPins = Math.min(parsedPins, contestant.pinsLeft);
    contestant.pinsLeft = await this.bowlingGameService.roll(contestant, parsedPins);
    this.bowlingGameService.refreshLeaderboard();
    this.busy = false;
    this.notificationService.addRoll(contestant, parsedPins);

    if (contestant.pinsLeft < 0) {
      this.bowlingGameService.checkExistingGameComplete().subscribe(x => this.bowlingGameService.isGameComplete = x)
    }      

    return contestant.pinsLeft < 0 ? 0 : contestant.pinsLeft;
  }
}
