import { Injectable } from '@angular/core';
import { Contestant } from './interfaces/contestant';

@Injectable({
  providedIn: 'root'
})
export class NotificationsService {
  notifications: string[] = [];

  add(message: string) {
    this.notifications.push(message);
  }

  addRoll(contestant: Contestant, rollAmount: number) {
    this.notifications.push(`${contestant.contestantName} knocked ${rollAmount} pins. Next throw has maximum of ${contestant.pinsLeft}.`);
  }

  clear() {
    this.notifications = [];
  }
}
