import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TournamentEditPageComponent } from './tournament-edit-page.component';

describe('TournamentEditPageComponent', () => {
  let component: TournamentEditPageComponent;
  let fixture: ComponentFixture<TournamentEditPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TournamentEditPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TournamentEditPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
