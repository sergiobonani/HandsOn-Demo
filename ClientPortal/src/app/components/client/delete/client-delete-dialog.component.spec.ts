import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientDeleteDialogComponent } from './client-delete-dialog.component';

describe('DeleteComponent', () => {
  let component: ClientDeleteDialogComponent;
  let fixture: ComponentFixture<ClientDeleteDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ClientDeleteDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClientDeleteDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
