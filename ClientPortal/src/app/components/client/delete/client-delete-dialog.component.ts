import { Component, OnInit, Inject } from '@angular/core';
import { AlertService, MessageSeverity } from 'src/app/services/alert.service';
import { ClientService } from 'src/app/services/client.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-client-delete-dialog',
  templateUrl: './client-delete-dialog.component.html',
  styleUrls: ['./client-delete-dialog.component.scss']
})
export class ClientDeleteDialogComponent {

  constructor(public dialogRef: MatDialogRef<ClientDeleteDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dataService: ClientService,
    public alertService: AlertService) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  confirmDelete(): void {
    this.dataService.delete(this.data.id).subscribe(data => {
      this.alertService.showStickyMessage("Removido com sucesso", MessageSeverity.success);
      this.dialogRef.close();
    }, error => {
      this.alertService.showStickyMessage("", MessageSeverity.error, error);
    });;
  }

}
