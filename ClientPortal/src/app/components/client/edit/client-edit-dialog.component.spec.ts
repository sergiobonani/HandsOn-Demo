import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientEditDialogComponent } from './client-edit-dialog.component';

describe('EditComponent', () => {
  let component: ClientEditDialogComponent;
  let fixture: ComponentFixture<ClientEditDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ClientEditDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClientEditDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
