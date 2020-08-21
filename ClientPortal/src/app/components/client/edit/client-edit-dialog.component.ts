import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Client } from 'src/app/models/client.model';
import { ClientService } from 'src/app/services/client.service';
import { AlertService, MessageSeverity } from 'src/app/services/alert.service';
import { CepService } from 'src/app/services/cep.service';

@Component({
  selector: 'app-client-edit-dialog',
  templateUrl: './client-edit-dialog.component.html',
  styleUrls: ['./client-edit-dialog.component.scss']
})
export class ClientEditDialogComponent implements OnInit {

  loading = false;
  disabledFields = false;

  constructor(
    public dialogRef: MatDialogRef<ClientEditDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public client: Client,
    public dataService: ClientService,
    public alertService: AlertService,
    public cepService: CepService) { }

  ngOnInit() {
  }

  cancel(){
    this.dialogRef.close()
  }

  updateZipCode():void{
    this.loading = true;
    this.cepService.getAddress(this.client.zipCode).subscribe(x => {
      this.client.state = x.uf;
      this.client.country = 'Brasil';
      this.client.district = x.bairro;
      this.client.complement = x.complemento;
      this.client.city = x.localidade;
      this.client.address = x.logradouro;
      this.loading = false;
      this.disabledFields = true;
    }, error =>{
      this.alertService.showStickyMessage("", MessageSeverity.error, error);
      this.loading = false;
    });
  }

  save(): void {
    this.loading = true;
    if(this.client.id){
      this.dataService.update(this.client).subscribe(data =>{
        this.alertService.showStickyMessage("Editado com sucesso", MessageSeverity.success);
        this.dialogRef.close();
        this.loading = false;
      }, error =>{
        this.alertService.showStickyMessage("", MessageSeverity.error, error);
        this.loading = false;
      });
    }else{
      this.dataService.add(this.client).subscribe(data =>{
        this.alertService.showStickyMessage("Criado com sucesso", MessageSeverity.success);
        this.dialogRef.close();
        this.loading = false;
      }, error =>{
        this.alertService.showStickyMessage("", MessageSeverity.error, error);
        this.loading = false;
      });
    }
  }
}
