import { TestBed } from '@angular/core/testing';

import { BowlingGameService } from './bowling-game.service';

describe('BowlingGameService', () => {
  let service: BowlingGameService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BowlingGameService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
