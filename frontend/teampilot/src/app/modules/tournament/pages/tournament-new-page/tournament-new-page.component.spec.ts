import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TournamentNewPageComponent } from './tournament-new-page.component';

describe('TournamentNewPageComponent', () => {
  let component: TournamentNewPageComponent;
  let fixture: ComponentFixture<TournamentNewPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TournamentNewPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TournamentNewPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
