import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Contestant } from './interfaces/contestant';
import { NotificationsService } from './notifications.service'
import { Leaderboard } from './interfaces/leaderboard';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BowlingGameService {
  private domain: string;
  private bowlingApiUrl = '/api/bowling';
  isGameComplete: boolean;
  isGameUnderway: boolean;
  checkingForGame: boolean;
  leaderboard: Leaderboard[];

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient, private notificationService: NotificationsService)
  {
    this.domain = environment.apiBaseUrl;
    this.isGameComplete = false;
    this.isGameUnderway = false;
    this.checkingForGame = true;
    this.leaderboard = [];

    this.checkForExistingGame().subscribe(x => this.isGameUnderway = x);
    this.checkExistingGameComplete().subscribe(x => this.checkGameComplete(x));
    this.getLeaderboard().subscribe(x => this.leaderboard = x);
  }

  private checkGameComplete(isComplete: boolean): void {
    this.isGameComplete = isComplete;
    this.checkingForGame = false
  }

  refreshLeaderboard(): void {
    this.getLeaderboard().subscribe(x => this.leaderboard = x);
  }
  refreshPage(): void {
    this.getLeaderboard().subscribe(x => this.leaderboard = x);
  }
  beginGame(): void {
    this.isGameUnderway = true;
    this.isGameComplete = false;
    this.getLeaderboard().subscribe(x => this.leaderboard = x);
    this.log('Game has begun');
  }
  resetGame(): void {
    this.reset().subscribe(_ => this.isGameUnderway = false);
    this.isGameComplete = false;
    this.refreshLeaderboard();
  }

  //Post, intentionally implemented synchronously
  async roll(contestant: Contestant, pinsKnocked: number): Promise<number> {
    return await this.http.post<number>(`${this.domain}${this.bowlingApiUrl}/roll`, { contestantName: contestant.contestantName, pinsKnocked: pinsKnocked }, this.httpOptions).toPromise();
  }
  async addContestants(contestants: Contestant[]): Promise<boolean> {
    return await this.http.post<boolean>(`${this.domain}${this.bowlingApiUrl}/addcontestants`, contestants, this.httpOptions).toPromise();
  }

  //Get
  getLeaderboard(): Observable<Leaderboard[]> {
    return this.http.get<Leaderboard[]>(`${this.domain}${this.bowlingApiUrl}/leaderboard`)
      .pipe(
        catchError(this.handleError<Leaderboard[]>('getLeaderboard', []))
      );
  }
  getContestants(): Observable<Contestant[]> {
    return this.http.get<Contestant[]>(`${this.domain}${this.bowlingApiUrl}/getcontestants`)
      .pipe(
        tap(_ => this.log('fetched contestants')),
        catchError(this.handleError<Contestant[]>('getContestants', []))
      );
  }
  checkForExistingGame(): Observable<boolean> {
    return this.http.get<boolean>(`${this.domain}${this.bowlingApiUrl}/hasexisting`)
      .pipe(
        tap(x => this.isGameUnderway = x),
        catchError(this.handleError<boolean>('checkForExistingGame'))
      );
  }
  checkExistingGameComplete(): Observable<boolean> {
    return this.http.get<boolean>(`${this.domain}${this.bowlingApiUrl}/iscomplete`)
      .pipe(
        catchError(this.handleError<boolean>('checkExistingGameComplete'))
      );
  }
  reset(): Observable<any> {
    this.notificationService.clear();
    return this.http.get(`${this.domain}${this.bowlingApiUrl}/reset`)
      .pipe(
        catchError(this.handleError<any>('resetGame'))
      );
  }

  private log(message: string) {
    this.notificationService.add(`BowlingGameService: ${message}`);
  }
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
