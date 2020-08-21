import { Component, OnInit, ViewChild } from '@angular/core';
import { Client } from 'src/app/models/client.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { HttpClient } from '@angular/common/http';
import { ClientService } from 'src/app/services/client.service';
import { MatDialog } from '@angular/material/dialog';
import { AlertService } from 'src/app/services/alert.service';
import { ClientEditDialogComponent } from './edit/client-edit-dialog.component';
import { ClientDeleteDialogComponent } from './delete/client-delete-dialog.component';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss']
})
export class ClientComponent implements OnInit {
  displayedColumns = ['name', 'dateOfBirth', 'gender', 'actions'];
  
  public dataSource = new MatTableDataSource<Client>();
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  

  constructor(public httpClient: HttpClient,
              public dialog: MatDialog,
              public dataService: ClientService,
              public alertService: AlertService) {}

  ngOnInit() {
   this.loadData();
  }

  loadData(){
    this.dataService.getAllClients().subscribe(result =>{
      this.dataSource.data = result as Client[];
    })
  }

  hasData(){
    return this.dataSource && this.dataSource.data && this.dataSource.data.length > 0; 
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator =this.paginator;
  }

  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  addNew(client: Client) {
    const dialogRef = this.dialog.open(ClientEditDialogComponent, {
      data:  new Client()
    });

    dialogRef.afterClosed().subscribe(result => {
      this.loadData();
    });
  }

  startEdit(id: string) {
    this.dataService.getById(id).subscribe(result => {
      const dialogRef = this.dialog.open(ClientEditDialogComponent, {
        data: result
      });

      dialogRef.afterClosed().subscribe(result => {
        this.loadData();
      });
  });
}

  deleteItem(row: Client) {
    if(row){
      const dialogRef = this.dialog.open(ClientDeleteDialogComponent, {
        data: row
      });

      dialogRef.afterClosed().subscribe(result => {
          this.loadData();
      });
    }
  }
}